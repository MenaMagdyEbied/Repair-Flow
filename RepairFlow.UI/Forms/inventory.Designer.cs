namespace finalProject
{
    partial class Inventory
    {
        
        private System.ComponentModel.IContainer components = null;

     
        /// <p name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

      
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventory));
            header = new Panel();
            label2 = new Label();
            back = new Label();
            right_panel = new Panel();
            label3 = new Label();
            products_num = new Label();
            middle_panel = new Panel();
            label4 = new Label();
            label5 = new Label();
            left_panel = new Panel();
            label6 = new Label();
            label7 = new Label();
            add_product = new Label();
            label8 = new Label();
            search = new TextBox();
            alert = new Panel();
            label9 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            partsGrid = new DataGridView();
            panel1 = new Panel();
            label30 = new Label();
            label34 = new Label();
            label32 = new Label();
            label23 = new Label();
            label29 = new Label();
            label28 = new Label();
            label18 = new Label();
            label17 = new Label();
            label1 = new Label();
            label12 = new Label();
            label10 = new Label();
            label27 = new Label();
            label26 = new Label();
            label25 = new Label();
            label24 = new Label();
            label21 = new Label();
            label20 = new Label();
            label19 = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label11 = new Label();
            label16 = new Label();
            label31 = new Label();
            panel2 = new Panel();
            label22 = new Label();
            editProduct = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            header.SuspendLayout();
            right_panel.SuspendLayout();
            middle_panel.SuspendLayout();
            left_panel.SuspendLayout();
            alert.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            SuspendLayout();
            // 
            // header
            // 
            header.BackColor = SystemColors.ActiveCaption;
            header.Controls.Add(label2);
            header.Controls.Add(back);
            resources.ApplyResources(header, "header");
            header.Name = "header";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.White;
            label2.Name = "label2";
            // 
            // back
            // 
            back.AccessibleRole = AccessibleRole.SplitButton;
            resources.ApplyResources(back, "back");
            back.BackColor = SystemColors.ControlDarkDark;
            back.Cursor = Cursors.Hand;
            back.ForeColor = Color.White;
            back.Name = "back";
            back.Click += label1_Click;
            // 
            // right_panel
            // 
            right_panel.BackColor = Color.Gainsboro;
            right_panel.Controls.Add(label3);
            right_panel.Controls.Add(products_num);
            resources.ApplyResources(right_panel, "right_panel");
            right_panel.Name = "right_panel";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.ForeColor = Color.DimGray;
            label3.Name = "label3";
            label3.Click += label3_Click;
            // 
            // products_num
            // 
            resources.ApplyResources(products_num, "products_num");
            products_num.Name = "products_num";
            // 
            // middle_panel
            // 
            middle_panel.BackColor = Color.Gainsboro;
            middle_panel.Controls.Add(label4);
            middle_panel.Controls.Add(label5);
            resources.ApplyResources(middle_panel, "middle_panel");
            middle_panel.Name = "middle_panel";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.ForeColor = Color.DimGray;
            label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // left_panel
            // 
            left_panel.BackColor = Color.Gainsboro;
            left_panel.Controls.Add(label6);
            left_panel.Controls.Add(label7);
            resources.ApplyResources(left_panel, "left_panel");
            left_panel.Name = "left_panel";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.ForeColor = Color.DimGray;
            label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            // 
            // add_product
            // 
            resources.ApplyResources(add_product, "add_product");
            add_product.BackColor = SystemColors.MenuHighlight;
            add_product.Cursor = Cursors.Hand;
            add_product.ForeColor = Color.White;
            add_product.Name = "add_product";
            add_product.Click += add_product_Click;
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.BackColor = Color.LightGray;
            label8.ForeColor = Color.DimGray;
            label8.Name = "label8";
            // 
            // search
            // 
            search.BorderStyle = BorderStyle.None;
            resources.ApplyResources(search, "search");
            search.Name = "search";
            search.TextChanged += search_TextChanged;
            // 
            // alert
            // 
            resources.ApplyResources(alert, "alert");
            alert.BackColor = Color.AntiqueWhite;
            alert.Controls.Add(label9);
            alert.Name = "alert";
            // 
            // label9
            // 
            resources.ApplyResources(label9, "label9");
            label9.BackColor = Color.Transparent;
            label9.ForeColor = Color.SaddleBrown;
            label9.Name = "label9";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
            tableLayoutPanel1.Controls.Add(panel1, 0, 2);
            tableLayoutPanel1.Controls.Add(label32, 3, 2);
            tableLayoutPanel1.Controls.Add(label23, 2, 2);
            tableLayoutPanel1.Controls.Add(label29, 3, 1);
            tableLayoutPanel1.Controls.Add(label28, 2, 1);
            tableLayoutPanel1.Controls.Add(label18, 1, 1);
            // create static header labels in the tableLayoutPanel1 first row (row 0)
            label17.Text = "الاسم";
            label1.Text = "النوع";
            label12.Text = "الكمية";
            label10.Text = "سعر الشراء";
            tableLayoutPanel1.Controls.Add(label17, 7, 0);
            tableLayoutPanel1.Controls.Add(label1, 6, 0);
            tableLayoutPanel1.Controls.Add(label12, 5, 0);
            tableLayoutPanel1.Controls.Add(label10, 4, 0);
            tableLayoutPanel1.Controls.Add(label27, 7, 2);
            tableLayoutPanel1.Controls.Add(label26, 6, 2);
            tableLayoutPanel1.Controls.Add(label25, 5, 2);
            tableLayoutPanel1.Controls.Add(label24, 4, 2);
            tableLayoutPanel1.Controls.Add(label21, 6, 1);
            tableLayoutPanel1.Controls.Add(label20, 5, 1);
            tableLayoutPanel1.Controls.Add(label19, 4, 1);
            tableLayoutPanel1.Controls.Add(label15, 6, 0);
            tableLayoutPanel1.Controls.Add(label14, 5, 0);
            tableLayoutPanel1.Controls.Add(label13, 4, 0);
            tableLayoutPanel1.Controls.Add(label11, 7, 0);
            tableLayoutPanel1.Controls.Add(label16, 7, 1);
            // label31 used as status style reference
            label31.Text = "متوفر";
            tableLayoutPanel1.Controls.Add(label31, 1, 2);
            tableLayoutPanel1.Controls.Add(panel2, 0, 1);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            // hide the heavy TableLayoutPanel at runtime; we'll use a virtualized DataGridView for performance
            tableLayoutPanel1.Visible = false;
            // 
            // partsGrid
            // 
            partsGrid.AllowUserToAddRows = false;
            partsGrid.AllowUserToDeleteRows = false;
            partsGrid.AutoGenerateColumns = false;
            partsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            partsGrid.MultiSelect = false;
            partsGrid.ReadOnly = true;
            partsGrid.RowHeadersVisible = false;
            partsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            partsGrid.RightToLeft = RightToLeft.Yes;
            partsGrid.ColumnHeadersVisible = true;
            partsGrid.EnableHeadersVisualStyles = false;
            partsGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            partsGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            partsGrid.Margin = new Padding(0, 10, 0, 0);
            // position the grid to overlap the original table layout
            partsGrid.Location = tableLayoutPanel1.Location;
            partsGrid.Size = tableLayoutPanel1.Size;
            partsGrid.Name = "partsGrid";
            partsGrid.TabIndex = tableLayoutPanel1.TabIndex + 1;
            // define columns (DataPropertyName will be set in code-behind)
            partsGrid.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colName", HeaderText = "Name", DataPropertyName = "Name" });
            partsGrid.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colType", HeaderText = "Type", DataPropertyName = "Type" });
            partsGrid.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colQuantity", HeaderText = "Quantity", DataPropertyName = "Quantity" });
            partsGrid.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colPurchase", HeaderText = "PurchasePrice", DataPropertyName = "PurchasePrice" });
            partsGrid.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colSelling", HeaderText = "SellingPrice", DataPropertyName = "SellingPrice" });
            partsGrid.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colAlert", HeaderText = "حد التنبيه", DataPropertyName = "AlertThreshold" });
            // flag column (after alert) showing low/available status
            partsGrid.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colFlag", HeaderText = "الحالة", ReadOnly = true });
            // Edit/Delete small icon buttons
            partsGrid.Columns.Add(new DataGridViewButtonColumn() { Name = "colEdit", HeaderText = "", Text = "🖊️", UseColumnTextForButtonValue = true, Width = 100, AutoSizeMode = DataGridViewAutoSizeColumnMode.None });
            partsGrid.Columns.Add(new DataGridViewButtonColumn() { Name = "colDelete", HeaderText = "", Text = "🗑️", UseColumnTextForButtonValue = true, Width = 100, AutoSizeMode = DataGridViewAutoSizeColumnMode.None });
            try
            {
                partsGrid.Columns["colEdit"].ReadOnly = false;
                partsGrid.Columns["colDelete"].ReadOnly = false;
            }
            catch { }
            partsGrid.CellDoubleClick += new DataGridViewCellEventHandler(this.PartsGrid_CellDoubleClick);
            partsGrid.CellFormatting += new DataGridViewCellFormattingEventHandler(this.PartsGrid_CellFormatting);
            partsGrid.CellContentClick += new DataGridViewCellEventHandler(this.PartsGrid_CellContentClick);
            partsGrid.CellPainting += new DataGridViewCellPaintingEventHandler(this.PartsGrid_CellPainting);
            // ensure display order: with RightToLeft enabled, set DisplayIndex so colFlag appears as second column from the left
            try
            {
                partsGrid.Columns["colFlag"].DisplayIndex = 1;
            }
            catch { }
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(tableLayoutPanel2, "tableLayoutPanel2");
            tableLayoutPanel2.Controls.Add(right_panel, 2, 0);
            tableLayoutPanel2.Controls.Add(middle_panel, 1, 0);
            tableLayoutPanel2.Controls.Add(left_panel, 0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(tableLayoutPanel3, "tableLayoutPanel3");
            tableLayoutPanel3.Controls.Add(add_product, 2, 0);
            tableLayoutPanel3.Controls.Add(label8, 1, 0);
            tableLayoutPanel3.Controls.Add(search, 0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // Inventory
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel3);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(partsGrid);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(alert);
            Controls.Add(header);
            DoubleBuffered = true;
            Name = "Inventory";
            Load += Inventory_Load;
            header.ResumeLayout(false);
            header.PerformLayout();
            right_panel.ResumeLayout(false);
            right_panel.PerformLayout();
            middle_panel.ResumeLayout(false);
            middle_panel.PerformLayout();
            left_panel.ResumeLayout(false);
            left_panel.PerformLayout();
            alert.ResumeLayout(false);
            alert.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel header;
        private Label back;
        private Label label2;
        private Panel right_panel;
        private Label label3;
        private Label products_num;
        private Panel middle_panel;
        private Label label4;
        private Label label5;
        private Panel left_panel;
        private Label label6;
        private Label label7;
        private Label add_product;
        private Label label1;
        private Label label8;
        private TextBox search;
        private Panel alert;
        private Label label9;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label21;
        private Label label20;
        private Label label19;
        private Label label26;
        private Label label25;
        private Label label24;
        private Label label10;
        private Label label32;
        private Label label23;
        private Label label31;
        private Label label29;
        private Label label28;
        private Label label18;
        private Label label22;
        private Label label17;
        private Label label12;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private Label editProduct;
        private Label label27;
        private Label label11;
        private Label label16;
        private Panel panel2;
        private Panel panel1;
        private Label label30;
        private Label label34;
        private DataGridView partsGrid;
    }
}
