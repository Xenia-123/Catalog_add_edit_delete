using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class MainForm : Form
    {
        string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial catalog=flower;Integrated security=true";
        private int currentProductId = 0;

        public MainForm(int role)
        {
            InitializeComponent();

            comboBox1.Items.Clear();
            comboBox1.Items.Add("Без сортировки");
            comboBox1.Items.Add("По возрастанию цены");
            comboBox1.Items.Add("По убыванию цены");
            comboBox1.SelectedIndex = 0;

            comboBox1.Visible = (role == 1);
            editBtn.Visible = (role == 1);
            deleteBtn.Visible = (role == 1);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts(string searchFilter = "", string orderBy = "")
        {
            flowLayoutPanel1.Controls.Clear();
            currentProductId = 0;

            string query = "SELECT p.id, p.name, p.price, p.photo, c.name AS category FROM product p LEFT JOIN category c ON p.category_id = c.id";

            if (!string.IsNullOrEmpty(searchFilter))
            {
                query += " WHERE p.name LIKE '%" + searchFilter + "%'";
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                query += " ORDER BY " + orderBy;
            }

            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            SqlCommand sql = new SqlCommand(query, conn);
            SqlDataReader reader = sql.ExecuteReader();

            while (reader.Read())
            {
                int productId = Convert.ToInt32(reader["id"]);
                string properties = GetPropertiesForProduct(productId);

                UserControl1 userControl = new UserControl1();
                userControl.Card(
                    productId,
                    reader["name"].ToString(),
                    reader["category"].ToString(),
                    properties,
                    Convert.ToDecimal(reader["price"]),
                    reader["photo"].ToString());

                userControl.Click += (s, ev) => {
                    currentProductId = ((UserControl1)s).ProductId;
                    foreach (UserControl1 ctrl in flowLayoutPanel1.Controls)
                        ctrl.BackColor = Color.Transparent;
                    userControl.BackColor = Color.LightBlue;
                };

                flowLayoutPanel1.Controls.Add(userControl);
            }

            reader.Close();
            conn.Close();
        }

        private string GetPropertiesForProduct(int productId)
        {
            string properties = "";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();

            string query = "SELECT pr.name AS propName, d.value FROM description d JOIN property pr ON d.property_id = pr.id WHERE d.product_id = @productId";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@productId", productId);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (properties != "")
                    properties += ", ";
                properties += reader["propName"].ToString() + ": " + reader["value"].ToString();
            }

            reader.Close();
            conn.Close();
            return properties;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string search = textBox1.Text.Trim();
            LoadProducts(search);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string orderBy = "";
            string search = textBox1.Text.Trim();

            if (comboBox1.SelectedIndex == 1)
                orderBy = "p.price ASC";
            else if (comboBox1.SelectedIndex == 2)
                orderBy = "p.price DESC";

            LoadProducts(search, orderBy);
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            AddProduct addForm = new AddProduct();
            addForm.ShowDialog();
            LoadProducts();
        }

        private void editBnt_Click(object sender, EventArgs e)
        {
            if (currentProductId == 0)
            {
                MessageBox.Show("Выберите товар для редактирования!");
                return;
            }
            EditProduct editForm = new EditProduct(currentProductId);
            editForm.ShowDialog();
            LoadProducts();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (currentProductId == 0)
            {
                MessageBox.Show("Выберите товар для удаления!");
                return;
            }

            DialogResult result = MessageBox.Show("Удалить товар?", "Подтверждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SqlConnection conn = new SqlConnection(connection);
                conn.Open();
                string query = "DELETE FROM product WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", currentProductId);
                cmd.ExecuteNonQuery();
                conn.Close();

                LoadProducts();
            }
        }
    }
}