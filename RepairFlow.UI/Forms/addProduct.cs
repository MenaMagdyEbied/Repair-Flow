using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using RepairFlow.DAL;
using RepairFlow.DAL.Repositories;
using RepairFlow.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace finalProject
{
    public partial class addProduct : Form
    {
        public addProduct()
        {
            InitializeComponent();
            label1.BackColor = ColorTranslator.FromHtml("#2C3E6B");
            header.BackColor = ColorTranslator.FromHtml("#2C3E6B");
            label5.BackColor = ColorTranslator.FromHtml("#2C3E6B");
            label3.BackColor = ColorTranslator.FromHtml("#2C3E6B");
            label4.BackColor = ColorTranslator.FromHtml("#2C3E6B");
            label6.BackColor = ColorTranslator.FromHtml("#2C3E6B");
            add_product.BackColor = ColorTranslator.FromHtml("#566589");

            back_button.BackColor = ColorTranslator.FromHtml("#C0392B");
            roundedElement(label1, 7);
            roundedElement(label3, 7);
            roundedElement(label4, 7);
            roundedElement(label5, 7);
            roundedElement(label6, 7);
            roundedElement(add_product, 3);
            roundedElement(back_button, 3);


        }
        public static void roundedElement(Control ctrl, int radius)
        {
            ctrl.Resize += (s, e) =>
            {
                ApplyRound(ctrl, radius);
            };

            ApplyRound(ctrl, radius);
        }

        private static void ApplyRound(Control ctrl, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(ctrl.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(ctrl.Width - radius, ctrl.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, ctrl.Height - radius, radius, radius, 90, 90);

            path.CloseFigure();
            ctrl.Region = new Region(path);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addProduct_Load(object sender, EventArgs e)
        {

        }

        private void add_product_Click(object sender, EventArgs e)
        {
            // create repository and save new SparePart
            try
            {
                var context = new AppDbContext();
                var repo = new SparePartRepository(context);

                var part = new SparePart
                {
                    Name = product_name.Text,
                    Type = product_type.Text,
                    Quantity = int.TryParse(quantity.Text, out var q) ? q : 0,
                    PurchasePrice = decimal.TryParse(produt_code.Text, out var p) ? p : 0, // reuse produt_code as purchase price field temporarily
                    SellingPrice = decimal.TryParse(textBox3.Text, out var s) ? s : 0,
                    Code = Guid.NewGuid().ToString().Substring(0, 8)
                };

                repo.Add(part);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("تعذر إضافة المنتج: " + ex.Message);
            }
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
