using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class AddProduct : Form
    {
        string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial catalog=flower;Integrated security=true";
        string photoPath = "";

        public AddProduct()
        {
            InitializeComponent();
        }

        private void buttonChangePhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Изображения|*.jpg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                photoPath = openFileDialog.FileName;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string price = textBoxPrice.Text;

            int categoryId = textBoxCategory.Text.ToLower().Contains("аксессуар") ? 2 : 1;

            SqlConnection conn = new SqlConnection(connection);
            conn.Open();

            string maxIdQuery = "SELECT ISNULL(MAX(id),0)+1 FROM product";
            SqlCommand cmd = new SqlCommand(maxIdQuery, conn);
            int newId = Convert.ToInt32(cmd.ExecuteScalar());

            string fileName = Path.GetFileName(photoPath);
            string photoForDb = "Res\\" + fileName;

            if (File.Exists(photoPath))
            {
                string resFolder = Path.Combine(Application.StartupPath, "Res");
                if (!Directory.Exists(resFolder)) Directory.CreateDirectory(resFolder);
                File.Copy(photoPath, Path.Combine(resFolder, fileName), true);
            }

            string query = "INSERT INTO product (id,name,category_id,price,photo) VALUES (@id,@name,@cat,@price,@photo)";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", newId);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@cat", categoryId);
            cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(price));
            cmd.Parameters.AddWithValue("@photo", photoForDb);
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Товар добавлен!");
            this.Close();
        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != ',')
                e.Handled = true;
        }
    }
}