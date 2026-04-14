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

namespace finalProject
{
    public partial class EditProduct : Form
    {
        private int _id = 0;
        // Event fired after a successful save so parent forms can update UI immediately
        public event EventHandler<SparePart>? Saved;
        public EditProduct(int id, string c1 , string c2 , string c3 , string c4 , string c5)
        {
            _id = id;
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
            product_name.Text = c1;
            product_type.Text = c2;
            quantity.Text = c3;
            buy.Text = c4;
            sel.Text = c5;

            // wire save action to the add_product label (acts as Save here)
            add_product.Click += AddProduct_Click;
        }

        private void AddProduct_Click(object? sender, EventArgs e)
        {
            try
            {
                var ctx = new AppDbContext();
                var repo = new SparePartRepository(ctx);
                var entity = repo.GetById(_id);
                if (entity == null)
                {
                    MessageBox.Show("المنتج غير موجود");
                    return;
                }

                entity.Name = product_name.Text;
                entity.Type = product_type.Text;
                if (int.TryParse(quantity.Text, out var q)) entity.Quantity = q;
                if (decimal.TryParse(buy.Text, out var b)) entity.PurchasePrice = b;
                if (decimal.TryParse(sel.Text, out var s)) entity.SellingPrice = s;

                repo.Update(entity);
                // notify listeners before closing so parent can update binding immediately
                Saved?.Invoke(this, entity);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("تعذر حفظ التغييرات: " + ex.Message);
            }
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


        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void header_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
