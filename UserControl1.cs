using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class UserControl1 : UserControl
    {
        public int ProductId { get; set; }
        public UserControl1()
        {
            InitializeComponent();
        }

        public void Card(int id, string Product, string Category, string Properties, decimal Price, string photo)
        {
            ProductId = id;
            lbProducts.Text = Product;
            lblCategory.Text = Category;
            lbStructure.Text = Properties;
            lbPrice.Text = $"{Price.ToString()} руб.";

            string fullPath = Path.Combine(Application.StartupPath, photo);
            if (File.Exists(fullPath))
                pbPhoto.Image = Image.FromFile(fullPath);
        }

        private void lbProducts_Click(object sender, EventArgs e)
        {

        }
    }
}