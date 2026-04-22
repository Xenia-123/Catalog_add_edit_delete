using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    partial class UserControl1
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.lbProducts = new System.Windows.Forms.Label();
            this.lbStructure = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPhoto
            // 
            this.pbPhoto.Location = new System.Drawing.Point(16, 21);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(102, 90);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPhoto.TabIndex = 0;
            this.pbPhoto.TabStop = false;
            // 
            // lbProducts
            // 
            this.lbProducts.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbProducts.ForeColor = System.Drawing.Color.DarkRed;
            this.lbProducts.Location = new System.Drawing.Point(144, 21);
            this.lbProducts.MinimumSize = new System.Drawing.Size(150, 50);
            this.lbProducts.Name = "lbProducts";
            this.lbProducts.Size = new System.Drawing.Size(240, 64);
            this.lbProducts.TabIndex = 2;
            this.lbProducts.Text = "label1";
            this.lbProducts.Click += new System.EventHandler(this.lbProducts_Click);
            // 
            // lbStructure
            // 
            this.lbStructure.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbStructure.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbStructure.Location = new System.Drawing.Point(144, 85);
            this.lbStructure.MaximumSize = new System.Drawing.Size(257, 173);
            this.lbStructure.MinimumSize = new System.Drawing.Size(171, 0);
            this.lbStructure.Name = "lbStructure";
            this.lbStructure.Size = new System.Drawing.Size(200, 91);
            this.lbStructure.TabIndex = 3;
            this.lbStructure.Text = "label1";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPrice.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbPrice.Location = new System.Drawing.Point(25, 121);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(57, 21);
            this.lbPrice.TabIndex = 4;
            this.lbPrice.Text = "label1";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCategory.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCategory.Location = new System.Drawing.Point(25, 142);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(57, 21);
            this.lblCategory.TabIndex = 5;
            this.lblCategory.Text = "label1";
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.lbStructure);
            this.Controls.Add(this.lbProducts);
            this.Controls.Add(this.pbPhoto);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(387, 210);
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pbPhoto;
        private Label lbProducts;
        private Label lbStructure;
        private Label lbPrice;
        private Label lblCategory;
    }
}
