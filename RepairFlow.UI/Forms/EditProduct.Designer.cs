namespace finalProject
{
    partial class EditProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            sel = new TextBox();
            label6 = new Label();
            add_product = new Label();
            back_button = new Label();
            buy = new TextBox();
            quantity = new TextBox();
            label5 = new Label();
            label4 = new Label();
            product_type = new TextBox();
            label3 = new Label();
            product_name = new TextBox();
            header = new Panel();
            label2 = new Label();
            back = new Label();
            label1 = new Label();
            header.SuspendLayout();
            SuspendLayout();
            // 
            // sel
            // 
            sel.Location = new Point(13, 304);
            sel.Name = "sel";
            sel.Size = new Size(448, 27);
            sel.TabIndex = 32;
            sel.TextAlign = HorizontalAlignment.Right;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ActiveCaption;
            label6.ForeColor = Color.White;
            label6.Location = new Point(481, 304);
            label6.Name = "label6";
            label6.Padding = new Padding(12, 3, 14, 3);
            label6.Size = new Size(95, 26);
            label6.TabIndex = 31;
            label6.Text = "سعر البيع";
            // 
            // add_product
            // 
            add_product.AutoSize = true;
            add_product.BackColor = SystemColors.ActiveCaption;
            add_product.Cursor = Cursors.Hand;
            add_product.ForeColor = Color.White;
            add_product.Location = new Point(13, 375);
            add_product.Name = "add_product";
            add_product.Padding = new Padding(20, 4, 20, 4);
            add_product.Size = new Size(86, 28);
            add_product.TabIndex = 30;
            add_product.Text = "تعديل";
            // 
            // back_button
            // 
            back_button.AutoSize = true;
            back_button.BackColor = SystemColors.ActiveCaption;
            back_button.Cursor = Cursors.Hand;
            back_button.ForeColor = Color.White;
            back_button.Location = new Point(107, 375);
            back_button.Name = "back_button";
            back_button.Padding = new Padding(20, 4, 20, 4);
            back_button.Size = new Size(81, 28);
            back_button.TabIndex = 29;
            back_button.Text = "رجوع";
            back_button.Click += back_button_Click;
            // 
            // buy
            // 
            buy.Location = new Point(13, 252);
            buy.Name = "buy";
            buy.Size = new Size(448, 27);
            buy.TabIndex = 28;
            buy.TextAlign = HorizontalAlignment.Right;
            // 
            // quantity
            // 
            quantity.Location = new Point(13, 197);
            quantity.Name = "quantity";
            quantity.Size = new Size(448, 27);
            quantity.TabIndex = 27;
            quantity.TextAlign = HorizontalAlignment.Right;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ActiveCaption;
            label5.ForeColor = Color.White;
            label5.Location = new Point(481, 252);
            label5.Name = "label5";
            label5.Padding = new Padding(10, 3, 10, 3);
            label5.Size = new Size(96, 26);
            label5.TabIndex = 26;
            label5.Text = "سعر الشراء";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ActiveCaption;
            label4.ForeColor = Color.White;
            label4.Location = new Point(481, 197);
            label4.Name = "label4";
            label4.Padding = new Padding(23, 3, 23, 3);
            label4.Size = new Size(94, 26);
            label4.TabIndex = 25;
            label4.Text = "الكمية";
            // 
            // product_type
            // 
            product_type.Location = new Point(13, 139);
            product_type.Name = "product_type";
            product_type.Size = new Size(448, 27);
            product_type.TabIndex = 24;
            product_type.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ActiveCaption;
            label3.ForeColor = Color.White;
            label3.Location = new Point(481, 142);
            label3.MinimumSize = new Size(60, 0);
            label3.Name = "label3";
            label3.Padding = new Padding(27, 3, 27, 3);
            label3.Size = new Size(94, 26);
            label3.TabIndex = 23;
            label3.Text = "النوع";
            // 
            // product_name
            // 
            product_name.Location = new Point(13, 81);
            product_name.Name = "product_name";
            product_name.Size = new Size(448, 27);
            product_name.TabIndex = 22;
            product_name.TextAlign = HorizontalAlignment.Right;
            // 
            // header
            // 
            header.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            header.BackColor = SystemColors.ActiveCaption;
            header.Controls.Add(label2);
            header.Controls.Add(back);
            header.Location = new Point(-35, 0);
            header.Name = "header";
            header.Size = new Size(674, 32);
            header.TabIndex = 21;
            header.Paint += header_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.ImeMode = ImeMode.NoControl;
            label2.Location = new Point(271, 5);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 1;
            label2.Text = "تعديل المنتج";
            // 
            // back
            // 
            back.AutoSize = true;
            back.BackColor = SystemColors.ControlDarkDark;
            back.ForeColor = Color.White;
            back.ImeMode = ImeMode.NoControl;
            back.Location = new Point(943, 4);
            back.Name = "back";
            back.Padding = new Padding(2);
            back.Size = new Size(62, 24);
            back.TabIndex = 0;
            back.Text = "رجوع →";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.ForeColor = Color.White;
            label1.Location = new Point(477, 82);
            label1.Name = "label1";
            label1.Padding = new Padding(10, 3, 10, 3);
            label1.Size = new Size(96, 26);
            label1.TabIndex = 20;
            label1.Text = "اسم المنتج";
            // 
            // EditProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 425);
            Controls.Add(sel);
            Controls.Add(label6);
            Controls.Add(add_product);
            Controls.Add(back_button);
            Controls.Add(buy);
            Controls.Add(quantity);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(product_type);
            Controls.Add(label3);
            Controls.Add(product_name);
            Controls.Add(header);
            Controls.Add(label1);
            Name = "EditProduct";
            Text = "EditProduct";
            header.ResumeLayout(false);
            header.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox sel;
        private Label label6;
        private Label add_product;
        private Label back_button;
        private TextBox buy;
        private TextBox quantity;
        private Label label5;
        private Label label4;
        private TextBox product_type;
        private Label label3;
        private TextBox product_name;
        private Panel header;
        private Label label2;
        private Label back;
        private Label label1;
    }
}