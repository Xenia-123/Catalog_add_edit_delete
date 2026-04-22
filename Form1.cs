using Microsoft.Data.SqlClient;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial catalog=flower;Integrated security=true";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Оба поля должны быть заполнены!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string query = "SELECT * FROM [user] WHERE login=@login AND password=@password";

            SqlCommand sqlCommand = new SqlCommand(query, conn);
            sqlCommand.Parameters.AddWithValue("@login", login);
            sqlCommand.Parameters.AddWithValue("@password", password);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                MessageBox.Show("Добро пожаловать", "Авторизация прошла успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int roleId = reader.GetInt32(reader.GetOrdinal("role"));
                MainForm mainForm = new MainForm(roleId);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неправильный пароль или логин", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}