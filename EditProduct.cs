using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class EditProduct : Form
    {
        string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial catalog=flower;Integrated security=true";
        int productId;
        string photoPath = "";

        public EditProduct(int id)
        {
            InitializeComponent();
            productId = id;
        }

        private void EditProduct_Load(object sender, EventArgs e)
        {

        }

        private void buttonChangePhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Изображения|*.jpg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                photoPath = openFileDialog.FileName;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string price = textBoxPrice.Text;

            int categoryId = textBoxCategory.Text.ToLower().Contains("аксессуар") ? 2 : 1;

            string photoForDb = photoPath;
            if (photoPath.Contains("\\") && !photoPath.StartsWith("Res"))
            {
                string fileName = Path.GetFileName(photoPath);
                photoForDb = "Res\\" + fileName;
                string resFolder = Path.Combine(Application.StartupPath, "Res");
                if (!Directory.Exists(resFolder)) Directory.CreateDirectory(resFolder);
                File.Copy(photoPath, Path.Combine(resFolder, fileName), true);
            }

            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            string query = "UPDATE product SET name=@name, category_id=@cat, price=@price, photo=@photo WHERE id=@id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@cat", categoryId);
            cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(price));
            cmd.Parameters.AddWithValue("@photo", photoForDb);
            cmd.Parameters.AddWithValue("@id", productId);
            cmd.ExecuteNonQuery();
            conn.Close();

            this.Close();
        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != ',')
                e.Handled = true;
        }
    }
}