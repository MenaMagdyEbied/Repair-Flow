namespace RepairFlow.UI.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            pnlTitleBar = new Panel();
            lblTitle = new Label();
            pnlDots = new Panel();
            pnlToolbar = new Panel();
            btnNew = new Button();
            pnlSearch = new Panel();
            txtSearch = new TextBox();
            lblSearchIcon = new Label();
            lblLogoIcon = new Label();
            lblLogo = new Label();
            tblMain = new TableLayoutPanel();
            pnlSidebar = new Panel();
            flpFilters = new FlowLayoutPanel();
            pnlMainContent = new Panel();
            pnlOrdersView = new TableLayoutPanel();
            pnlGridArea = new Panel();
            pnlPagination = new Panel();
            lblPagInfo = new Label();
            btnNextPage = new FontAwesome.Sharp.IconButton();
            btnPrevPage = new FontAwesome.Sharp.IconButton();
            dgvOrders = new DataGridView();
            colReceipt = new DataGridViewTextBoxColumn();
            colClient = new DataGridViewTextBoxColumn();
            colDevice = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            pnlDetail = new Panel();
            pnlDetailScroll = new Panel();
            cap1 = new Label();
            valReceipt = new Label();
            cap2 = new Label();
            valClient = new Label();
            cap3 = new Label();
            valPhone = new Label();
            cap4 = new Label();
            valDevice = new Label();
            cap5 = new Label();
            valModel = new Label();
            cap6 = new Label();
            valFault = new Label();
            cap7 = new Label();
            valAccessories = new Label();
            btnAccEdit = new Button();
            lblSectionParts = new Label();
            pnlParts = new Panel();
            dgvParts = new DataGridView();
            colPartName = new DataGridViewTextBoxColumn();
            colPartQty = new DataGridViewTextBoxColumn();
            colPartPrice = new DataGridViewTextBoxColumn();
            colPartDel = new DataGridViewButtonColumn();
            pnlPartsFooter = new Panel();
            cmbPartSearch = new ComboBox();
            numPartQty = new NumericUpDown();
            numPartPrice = new NumericUpDown();
            btnAddPart = new Button();
            lblPartsSubtotal = new Label();
            lblSectionDates = new Label();
            pnlDates = new Panel();
            boxIn = new Panel();
            capIn = new Label();
            valDateIn = new Label();
            boxOut = new Panel();
            capOut = new Label();
            valDateOut = new Label();
            pnlCost = new Panel();
            capCost = new Label();
            valCost = new Label();
            pnlWarranty = new Panel();
            capWarranty = new Label();
            valWarranty = new Label();
            pnlSt = new Panel();
            capSt = new Label();
            cmbStatus = new ComboBox();
            btnEditReceipt = new Button();
            btnWA = new Button();
            btnPr = new Button();
            lblQRTitle = new Label();
            pnlQR = new Panel();
            pnlDtlHeader = new Panel();
            lblDtlTitle = new Label();
            btnEditAcc = new Button();
            btnEditField = new Button();
            pnlTitleBar.SuspendLayout();
            pnlToolbar.SuspendLayout();
            pnlSearch.SuspendLayout();
            tblMain.SuspendLayout();
            pnlSidebar.SuspendLayout();
            pnlMainContent.SuspendLayout();
            pnlOrdersView.SuspendLayout();
            pnlGridArea.SuspendLayout();
            pnlPagination.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            pnlDetail.SuspendLayout();
            pnlDetailScroll.SuspendLayout();
            pnlParts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvParts).BeginInit();
            pnlPartsFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPartQty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPartPrice).BeginInit();
            pnlDates.SuspendLayout();
            boxIn.SuspendLayout();
            boxOut.SuspendLayout();
            pnlCost.SuspendLayout();
            pnlWarranty.SuspendLayout();
            pnlSt.SuspendLayout();
            pnlDtlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTitleBar
            // 
            pnlTitleBar.BackColor = Color.FromArgb(44, 62, 107);
            pnlTitleBar.Controls.Add(lblTitle);
            pnlTitleBar.Controls.Add(pnlDots);
            pnlTitleBar.Dock = DockStyle.Top;
            pnlTitleBar.Location = new Point(0, 0);
            pnlTitleBar.Name = "pnlTitleBar";
            pnlTitleBar.Padding = new Padding(8, 0, 8, 0);
            pnlTitleBar.Size = new Size(1280, 30);
            pnlTitleBar.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 9F);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(70, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1202, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Repair Flow";
            lblTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlDots
            // 
            pnlDots.BackColor = Color.FromArgb(44, 62, 107);
            pnlDots.Dock = DockStyle.Left;
            pnlDots.Location = new Point(8, 0);
            pnlDots.Name = "pnlDots";
            pnlDots.Size = new Size(62, 30);
            pnlDots.TabIndex = 1;
            // 
            // pnlToolbar
            // 
            pnlToolbar.BackColor = Color.FromArgb(245, 245, 245);
            pnlToolbar.Controls.Add(btnNew);
            pnlToolbar.Controls.Add(pnlSearch);
            pnlToolbar.Controls.Add(lblLogoIcon);
            pnlToolbar.Controls.Add(lblLogo);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 30);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Padding = new Padding(8, 6, 8, 6);
            pnlToolbar.Size = new Size(1280, 44);
            pnlToolbar.TabIndex = 1;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(44, 62, 107);
            btnNew.Cursor = Cursors.Hand;
            btnNew.FlatAppearance.BorderSize = 0;
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(8, 7);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(130, 30);
            btnNew.TabIndex = 0;
            btnNew.Text = " استلام جهاز  +";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // pnlSearch
            // 
            pnlSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSearch.BackColor = Color.White;
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(lblSearchIcon);
            pnlSearch.Location = new Point(148, 10);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(560, 24);
            pnlSearch.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.White;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.ForeColor = Color.FromArgb(110, 110, 110);
            txtSearch.Location = new Point(24, 0);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "بحث: رقم إيصال / هاتف / اسم";
            txtSearch.Size = new Size(536, 20);
            txtSearch.TabIndex = 0;
            // 
            // lblSearchIcon
            // 
            lblSearchIcon.Dock = DockStyle.Left;
            lblSearchIcon.Font = new Font("Segoe UI", 9F);
            lblSearchIcon.ForeColor = Color.FromArgb(150, 150, 150);
            lblSearchIcon.Location = new Point(0, 0);
            lblSearchIcon.Name = "lblSearchIcon";
            lblSearchIcon.Size = new Size(24, 24);
            lblSearchIcon.TabIndex = 1;
            lblSearchIcon.Text = "🔍";
            lblSearchIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLogoIcon
            // 
            lblLogoIcon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblLogoIcon.Font = new Font("Segoe UI", 16F);
            lblLogoIcon.ForeColor = Color.FromArgb(44, 62, 107);
            lblLogoIcon.Location = new Point(1039, -2);
            lblLogoIcon.Name = "lblLogoIcon";
            lblLogoIcon.Size = new Size(54, 40);
            lblLogoIcon.TabIndex = 2;
            lblLogoIcon.Text = "🔧";
            lblLogoIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLogo
            // 
            lblLogo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblLogo.ForeColor = Color.FromArgb(44, 62, 107);
            lblLogo.Location = new Point(915, 6);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(116, 25);
            lblLogo.TabIndex = 2;
            lblLogo.Text = " Repair Flow";
            // 
            // tblMain
            // 
            tblMain.BackColor = Color.FromArgb(222, 222, 222);
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 230F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(pnlSidebar, 0, 0);
            tblMain.Controls.Add(pnlMainContent, 1, 0);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 74);
            tblMain.Margin = new Padding(0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 1;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.Size = new Size(1280, 726);
            tblMain.TabIndex = 0;
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(248, 248, 248);
            pnlSidebar.Controls.Add(flpFilters);
            pnlSidebar.Dock = DockStyle.Fill;
            pnlSidebar.Location = new Point(1050, 0);
            pnlSidebar.Margin = new Padding(0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Padding = new Padding(0, 8, 0, 8);
            pnlSidebar.Size = new Size(230, 726);
            pnlSidebar.TabIndex = 0;
            // 
            // flpFilters
            // 
            flpFilters.AutoScroll = true;
            flpFilters.BackColor = Color.FromArgb(248, 248, 248);
            flpFilters.Dock = DockStyle.Fill;
            flpFilters.FlowDirection = FlowDirection.TopDown;
            flpFilters.Location = new Point(0, 8);
            flpFilters.Name = "flpFilters";
            flpFilters.Padding = new Padding(4, 0, 4, 0);
            flpFilters.Size = new Size(230, 710);
            flpFilters.TabIndex = 0;
            flpFilters.WrapContents = false;
            // 
            // pnlMainContent
            // 
            pnlMainContent.BackColor = Color.FromArgb(222, 222, 222);
            pnlMainContent.Controls.Add(pnlOrdersView);
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(0, 0);
            pnlMainContent.Margin = new Padding(0);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(1050, 726);
            pnlMainContent.TabIndex = 3;
            // 
            // pnlOrdersView
            // 
            pnlOrdersView.ColumnCount = 2;
            pnlOrdersView.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pnlOrdersView.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 375F));
            pnlOrdersView.Controls.Add(pnlGridArea, 0, 0);
            pnlOrdersView.Controls.Add(pnlDetail, 1, 0);
            pnlOrdersView.Dock = DockStyle.Fill;
            pnlOrdersView.Location = new Point(0, 0);
            pnlOrdersView.Name = "pnlOrdersView";
            pnlOrdersView.RowCount = 1;
            pnlOrdersView.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlOrdersView.Size = new Size(1050, 726);
            pnlOrdersView.TabIndex = 0;
            // 
            // pnlGridArea
            // 
            pnlGridArea.BackColor = Color.FromArgb(222, 222, 222);
            pnlGridArea.Controls.Add(pnlPagination);
            pnlGridArea.Controls.Add(dgvOrders);
            pnlGridArea.Dock = DockStyle.Fill;
            pnlGridArea.Location = new Point(378, 3);
            pnlGridArea.Name = "pnlGridArea";
            pnlGridArea.Size = new Size(669, 720);
            pnlGridArea.TabIndex = 1;
            // 
            // pnlPagination
            // 
            pnlPagination.BackColor = Color.White;
            pnlPagination.Controls.Add(lblPagInfo);
            pnlPagination.Controls.Add(btnNextPage);
            pnlPagination.Controls.Add(btnPrevPage);
            pnlPagination.Dock = DockStyle.Bottom;
            pnlPagination.Location = new Point(0, 692);
            pnlPagination.Name = "pnlPagination";
            pnlPagination.Size = new Size(669, 28);
            pnlPagination.TabIndex = 1;
            // 
            // lblPagInfo
            // 
            lblPagInfo.Dock = DockStyle.Right;
            lblPagInfo.Font = new Font("Segoe UI", 8F);
            lblPagInfo.ForeColor = Color.FromArgb(120, 120, 120);
            lblPagInfo.Location = new Point(419, 0);
            lblPagInfo.Name = "lblPagInfo";
            lblPagInfo.Padding = new Padding(0, 0, 8, 0);
            lblPagInfo.Size = new Size(250, 28);
            lblPagInfo.TabIndex = 0;
            lblPagInfo.Text = "صفحة 1 من 1  |  المجموع: 0";
            lblPagInfo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnNextPage
            // 
            btnNextPage.Cursor = Cursors.Hand;
            btnNextPage.Dock = DockStyle.Left;
            btnNextPage.FlatAppearance.BorderSize = 0;
            btnNextPage.FlatStyle = FlatStyle.Flat;
            btnNextPage.IconChar = FontAwesome.Sharp.IconChar.ChevronLeft;
            btnNextPage.IconColor = Color.FromArgb(44, 62, 107);
            btnNextPage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNextPage.IconSize = 16;
            btnNextPage.Location = new Point(32, 0);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(32, 28);
            btnNextPage.TabIndex = 1;
            // 
            // btnPrevPage
            // 
            btnPrevPage.Cursor = Cursors.Hand;
            btnPrevPage.Dock = DockStyle.Left;
            btnPrevPage.FlatAppearance.BorderSize = 0;
            btnPrevPage.FlatStyle = FlatStyle.Flat;
            btnPrevPage.IconChar = FontAwesome.Sharp.IconChar.ChevronRight;
            btnPrevPage.IconColor = Color.FromArgb(44, 62, 107);
            btnPrevPage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnPrevPage.IconSize = 16;
            btnPrevPage.Location = new Point(0, 0);
            btnPrevPage.Name = "btnPrevPage";
            btnPrevPage.Size = new Size(32, 28);
            btnPrevPage.TabIndex = 2;
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.AllowUserToResizeRows = false;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.BackgroundColor = Color.White;
            dgvOrders.BorderStyle = BorderStyle.None;
            dgvOrders.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvOrders.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 245, 245);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(80, 80, 80);
            dataGridViewCellStyle1.Padding = new Padding(6, 0, 6, 0);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvOrders.ColumnHeadersHeight = 32;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvOrders.Columns.AddRange(new DataGridViewColumn[] { colReceipt, colClient, colDevice, colPhone, colDate, colStatus });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 8.5F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(51, 51, 51);
            dataGridViewCellStyle2.Padding = new Padding(6, 0, 6, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(232, 240, 252);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(44, 62, 107);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvOrders.DefaultCellStyle = dataGridViewCellStyle2;
            dgvOrders.Dock = DockStyle.Fill;
            dgvOrders.EnableHeadersVisualStyles = false;
            dgvOrders.Font = new Font("Segoe UI", 8.5F);
            dgvOrders.GridColor = Color.FromArgb(232, 232, 232);
            dgvOrders.Location = new Point(0, 0);
            dgvOrders.MultiSelect = false;
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.RowHeadersWidth = 62;
            dgvOrders.RowTemplate.Height = 32;
            dgvOrders.ScrollBars = ScrollBars.Vertical;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(669, 720);
            dgvOrders.TabIndex = 0;
            // 
            // colReceipt
            // 
            colReceipt.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colReceipt.HeaderText = "الإيصال";
            colReceipt.MinimumWidth = 100;
            colReceipt.Name = "colReceipt";
            colReceipt.ReadOnly = true;
            // 
            // colClient
            // 
            colClient.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colClient.HeaderText = "العميل";
            colClient.MinimumWidth = 80;
            colClient.Name = "colClient";
            colClient.ReadOnly = true;
            colClient.Width = 91;
            // 
            // colDevice
            // 
            colDevice.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDevice.HeaderText = "الجهاز";
            colDevice.MinimumWidth = 80;
            colDevice.Name = "colDevice";
            colDevice.ReadOnly = true;
            // 
            // colPhone
            // 
            colPhone.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colPhone.HeaderText = "الهاتف";
            colPhone.MinimumWidth = 100;
            colPhone.Name = "colPhone";
            colPhone.ReadOnly = true;
            // 
            // colDate
            // 
            colDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colDate.HeaderText = "الاستلام";
            colDate.MinimumWidth = 80;
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            colDate.Width = 98;
            // 
            // colStatus
            // 
            colStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colStatus.HeaderText = "الحالة";
            colStatus.MinimumWidth = 95;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            colStatus.Width = 95;
            // 
            // pnlDetail
            // 
            pnlDetail.BackColor = Color.FromArgb(248, 248, 248);
            pnlDetail.Controls.Add(pnlDetailScroll);
            pnlDetail.Controls.Add(pnlDtlHeader);
            pnlDetail.Dock = DockStyle.Fill;
            pnlDetail.Location = new Point(3, 3);
            pnlDetail.Name = "pnlDetail";
            pnlDetail.Size = new Size(369, 720);
            pnlDetail.TabIndex = 2;
            // 
            // pnlDetailScroll
            // 
            pnlDetailScroll.AutoScroll = true;
            pnlDetailScroll.BackColor = Color.FromArgb(248, 248, 248);
            pnlDetailScroll.Controls.Add(cap1);
            pnlDetailScroll.Controls.Add(valReceipt);
            pnlDetailScroll.Controls.Add(cap2);
            pnlDetailScroll.Controls.Add(valClient);
            pnlDetailScroll.Controls.Add(cap3);
            pnlDetailScroll.Controls.Add(valPhone);
            pnlDetailScroll.Controls.Add(cap4);
            pnlDetailScroll.Controls.Add(valDevice);
            pnlDetailScroll.Controls.Add(cap5);
            pnlDetailScroll.Controls.Add(valModel);
            pnlDetailScroll.Controls.Add(cap6);
            pnlDetailScroll.Controls.Add(valFault);
            pnlDetailScroll.Controls.Add(cap7);
            pnlDetailScroll.Controls.Add(valAccessories);
            pnlDetailScroll.Controls.Add(btnAccEdit);
            pnlDetailScroll.Controls.Add(lblSectionParts);
            pnlDetailScroll.Controls.Add(pnlParts);
            pnlDetailScroll.Controls.Add(lblSectionDates);
            pnlDetailScroll.Controls.Add(pnlDates);
            pnlDetailScroll.Controls.Add(pnlCost);
            pnlDetailScroll.Controls.Add(pnlWarranty);
            pnlDetailScroll.Controls.Add(pnlSt);
            pnlDetailScroll.Controls.Add(btnEditReceipt);
            pnlDetailScroll.Controls.Add(btnWA);
            pnlDetailScroll.Controls.Add(btnPr);
            pnlDetailScroll.Controls.Add(lblQRTitle);
            pnlDetailScroll.Controls.Add(pnlQR);
            pnlDetailScroll.Dock = DockStyle.Fill;
            pnlDetailScroll.Location = new Point(0, 42);
            pnlDetailScroll.Name = "pnlDetailScroll";
            pnlDetailScroll.Padding = new Padding(12, 8, 12, 12);
            pnlDetailScroll.Size = new Size(369, 678);
            pnlDetailScroll.TabIndex = 0;
            // 
            // cap1
            // 
            cap1.Font = new Font("Segoe UI", 8.5F);
            cap1.ForeColor = Color.FromArgb(119, 119, 119);
            cap1.Location = new Point(196, 6);
            cap1.Name = "cap1";
            cap1.Size = new Size(147, 28);
            cap1.TabIndex = 0;
            cap1.Text = "رقم الإيصال";
            cap1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // valReceipt
            // 
            valReceipt.AutoEllipsis = true;
            valReceipt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            valReceipt.ForeColor = Color.FromArgb(44, 62, 107);
            valReceipt.Location = new Point(12, 6);
            valReceipt.Name = "valReceipt";
            valReceipt.Size = new Size(180, 28);
            valReceipt.TabIndex = 1;
            valReceipt.Text = "—";
            valReceipt.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cap2
            // 
            cap2.Font = new Font("Segoe UI", 8.5F);
            cap2.ForeColor = Color.FromArgb(119, 119, 119);
            cap2.Location = new Point(196, 42);
            cap2.Name = "cap2";
            cap2.Size = new Size(147, 28);
            cap2.TabIndex = 2;
            cap2.Text = "العميل";
            cap2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // valClient
            // 
            valClient.AutoEllipsis = true;
            valClient.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            valClient.ForeColor = Color.FromArgb(51, 51, 51);
            valClient.Location = new Point(12, 42);
            valClient.Name = "valClient";
            valClient.Size = new Size(180, 28);
            valClient.TabIndex = 3;
            valClient.Text = "—";
            valClient.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cap3
            // 
            cap3.Font = new Font("Segoe UI", 8.5F);
            cap3.ForeColor = Color.FromArgb(119, 119, 119);
            cap3.Location = new Point(196, 78);
            cap3.Name = "cap3";
            cap3.Size = new Size(147, 28);
            cap3.TabIndex = 4;
            cap3.Text = "الهاتف";
            cap3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // valPhone
            // 
            valPhone.AutoEllipsis = true;
            valPhone.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            valPhone.ForeColor = Color.FromArgb(51, 51, 51);
            valPhone.Location = new Point(12, 78);
            valPhone.Name = "valPhone";
            valPhone.Size = new Size(180, 28);
            valPhone.TabIndex = 5;
            valPhone.Text = "—";
            valPhone.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cap4
            // 
            cap4.Font = new Font("Segoe UI", 8.5F);
            cap4.ForeColor = Color.FromArgb(119, 119, 119);
            cap4.Location = new Point(196, 114);
            cap4.Name = "cap4";
            cap4.Size = new Size(147, 28);
            cap4.TabIndex = 6;
            cap4.Text = "الجهاز";
            cap4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // valDevice
            // 
            valDevice.AutoEllipsis = true;
            valDevice.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            valDevice.ForeColor = Color.FromArgb(51, 51, 51);
            valDevice.Location = new Point(12, 114);
            valDevice.Name = "valDevice";
            valDevice.Size = new Size(180, 28);
            valDevice.TabIndex = 7;
            valDevice.Text = "—";
            valDevice.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cap5
            // 
            cap5.Font = new Font("Segoe UI", 8.5F);
            cap5.ForeColor = Color.FromArgb(119, 119, 119);
            cap5.Location = new Point(196, 150);
            cap5.Name = "cap5";
            cap5.Size = new Size(147, 28);
            cap5.TabIndex = 8;
            cap5.Text = "الموديل";
            cap5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // valModel
            // 
            valModel.AutoEllipsis = true;
            valModel.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            valModel.ForeColor = Color.FromArgb(51, 51, 51);
            valModel.Location = new Point(12, 150);
            valModel.Name = "valModel";
            valModel.Size = new Size(180, 28);
            valModel.TabIndex = 9;
            valModel.Text = "—";
            valModel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cap6
            // 
            cap6.Font = new Font("Segoe UI", 8.5F);
            cap6.ForeColor = Color.FromArgb(119, 119, 119);
            cap6.Location = new Point(196, 186);
            cap6.Name = "cap6";
            cap6.Size = new Size(147, 28);
            cap6.TabIndex = 10;
            cap6.Text = "العطل";
            cap6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // valFault
            // 
            valFault.AutoEllipsis = true;
            valFault.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            valFault.ForeColor = Color.FromArgb(51, 51, 51);
            valFault.Location = new Point(12, 186);
            valFault.Name = "valFault";
            valFault.Size = new Size(180, 28);
            valFault.TabIndex = 11;
            valFault.Text = "—";
            valFault.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cap7
            // 
            cap7.Font = new Font("Segoe UI", 8.5F);
            cap7.ForeColor = Color.FromArgb(119, 119, 119);
            cap7.Location = new Point(196, 222);
            cap7.Name = "cap7";
            cap7.Size = new Size(147, 28);
            cap7.TabIndex = 12;
            cap7.Text = "المرفقات";
            cap7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // valAccessories
            // 
            valAccessories.AutoEllipsis = true;
            valAccessories.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            valAccessories.ForeColor = Color.FromArgb(51, 51, 51);
            valAccessories.Location = new Point(12, 222);
            valAccessories.Name = "valAccessories";
            valAccessories.Size = new Size(180, 28);
            valAccessories.TabIndex = 13;
            valAccessories.Text = "—";
            valAccessories.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnAccEdit
            // 
            btnAccEdit.BackColor = Color.FromArgb(240, 240, 240);
            btnAccEdit.Cursor = Cursors.Hand;
            btnAccEdit.FlatAppearance.BorderColor = Color.FromArgb(205, 205, 205);
            btnAccEdit.FlatStyle = FlatStyle.Flat;
            btnAccEdit.Font = new Font("Segoe UI", 7F);
            btnAccEdit.ForeColor = Color.FromArgb(60, 60, 60);
            btnAccEdit.Location = new Point(12, 225);
            btnAccEdit.Name = "btnAccEdit";
            btnAccEdit.Size = new Size(86, 22);
            btnAccEdit.TabIndex = 14;
            btnAccEdit.Text = "✎  تعديل";
            btnAccEdit.UseVisualStyleBackColor = false;
            // 
            // lblSectionParts
            // 
            lblSectionParts.Font = new Font("Segoe UI", 7.5F);
            lblSectionParts.ForeColor = Color.FromArgb(136, 136, 136);
            lblSectionParts.Location = new Point(12, 380);
            lblSectionParts.Name = "lblSectionParts";
            lblSectionParts.Size = new Size(347, 31);
            lblSectionParts.TabIndex = 15;
            lblSectionParts.Text = "قطع الغيار المستخدمة  ●  داخلي";
            lblSectionParts.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlParts
            // 
            pnlParts.BackColor = Color.White;
            pnlParts.Controls.Add(dgvParts);
            pnlParts.Controls.Add(pnlPartsFooter);
            pnlParts.Location = new Point(12, 404);
            pnlParts.Name = "pnlParts";
            pnlParts.Size = new Size(347, 192);
            pnlParts.TabIndex = 16;
            // 
            // dgvParts
            // 
            dgvParts.AllowUserToAddRows = false;
            dgvParts.AllowUserToDeleteRows = false;
            dgvParts.AllowUserToResizeRows = false;
            dgvParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvParts.BackgroundColor = Color.White;
            dgvParts.BorderStyle = BorderStyle.None;
            dgvParts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvParts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(238, 242, 250);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(70, 70, 70);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dgvParts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvParts.ColumnHeadersHeight = 26;
            dgvParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvParts.Columns.AddRange(new DataGridViewColumn[] { colPartName, colPartQty, colPartPrice, colPartDel });
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 8F);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(232, 240, 252);
            dataGridViewCellStyle7.SelectionForeColor = Color.FromArgb(44, 62, 107);
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dgvParts.DefaultCellStyle = dataGridViewCellStyle7;
            dgvParts.Dock = DockStyle.Top;
            dgvParts.EnableHeadersVisualStyles = false;
            dgvParts.Font = new Font("Segoe UI", 8F);
            dgvParts.GridColor = Color.FromArgb(228, 228, 228);
            dgvParts.Location = new Point(0, 0);
            dgvParts.MultiSelect = false;
            dgvParts.Name = "dgvParts";
            dgvParts.RowHeadersVisible = false;
            dgvParts.RowHeadersWidth = 62;
            dgvParts.RowTemplate.Height = 28;
            dgvParts.ScrollBars = ScrollBars.None;
            dgvParts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvParts.Size = new Size(347, 26);
            dgvParts.TabIndex = 0;
            // 
            // colPartName
            // 
            colPartName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPartName.HeaderText = "القطعة / الخدمة";
            colPartName.MinimumWidth = 80;
            colPartName.Name = "colPartName";
            // 
            // colPartQty
            // 
            colPartQty.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colPartQty.DefaultCellStyle = dataGridViewCellStyle4;
            colPartQty.HeaderText = "كمية";
            colPartQty.MinimumWidth = 8;
            colPartQty.Name = "colPartQty";
            colPartQty.Width = 46;
            // 
            // colPartPrice
            // 
            colPartPrice.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colPartPrice.DefaultCellStyle = dataGridViewCellStyle5;
            colPartPrice.HeaderText = "سعر ج";
            colPartPrice.MinimumWidth = 8;
            colPartPrice.Name = "colPartPrice";
            colPartPrice.Width = 58;
            // 
            // colPartDel
            // 
            colPartDel.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(180, 50, 40);
            dataGridViewCellStyle6.Padding = new Padding(2);
            colPartDel.DefaultCellStyle = dataGridViewCellStyle6;
            colPartDel.FlatStyle = FlatStyle.Flat;
            colPartDel.HeaderText = "";
            colPartDel.MinimumWidth = 8;
            colPartDel.Name = "colPartDel";
            colPartDel.Text = "✕";
            colPartDel.UseColumnTextForButtonValue = true;
            colPartDel.Width = 28;
            // 
            // pnlPartsFooter
            // 
            pnlPartsFooter.BackColor = Color.FromArgb(248, 249, 252);
            pnlPartsFooter.Controls.Add(cmbPartSearch);
            pnlPartsFooter.Controls.Add(numPartQty);
            pnlPartsFooter.Controls.Add(numPartPrice);
            pnlPartsFooter.Controls.Add(btnAddPart);
            pnlPartsFooter.Controls.Add(lblPartsSubtotal);
            pnlPartsFooter.Dock = DockStyle.Bottom;
            pnlPartsFooter.Location = new Point(0, 116);
            pnlPartsFooter.Name = "pnlPartsFooter";
            pnlPartsFooter.Padding = new Padding(5);
            pnlPartsFooter.Size = new Size(347, 76);
            pnlPartsFooter.TabIndex = 1;
            // 
            // cmbPartSearch
            // 
            cmbPartSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbPartSearch.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbPartSearch.BackColor = Color.White;
            cmbPartSearch.Font = new Font("Segoe UI", 8F);
            cmbPartSearch.Location = new Point(116, 5);
            cmbPartSearch.Name = "cmbPartSearch";
            cmbPartSearch.Size = new Size(225, 25);
            cmbPartSearch.TabIndex = 0;
            // 
            // numPartQty
            // 
            numPartQty.BackColor = Color.White;
            numPartQty.Font = new Font("Segoe UI", 8F);
            numPartQty.Location = new Point(72, 5);
            numPartQty.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numPartQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPartQty.Name = "numPartQty";
            numPartQty.Size = new Size(42, 25);
            numPartQty.TabIndex = 1;
            numPartQty.TextAlign = HorizontalAlignment.Center;
            numPartQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numPartPrice
            // 
            numPartPrice.BackColor = Color.White;
            numPartPrice.Font = new Font("Segoe UI", 8F);
            numPartPrice.Location = new Point(5, 5);
            numPartPrice.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numPartPrice.Name = "numPartPrice";
            numPartPrice.Size = new Size(65, 25);
            numPartPrice.TabIndex = 2;
            numPartPrice.TextAlign = HorizontalAlignment.Center;
            // 
            // btnAddPart
            // 
            btnAddPart.BackColor = Color.FromArgb(44, 62, 107);
            btnAddPart.Cursor = Cursors.Hand;
            btnAddPart.FlatAppearance.BorderSize = 0;
            btnAddPart.FlatStyle = FlatStyle.Flat;
            btnAddPart.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnAddPart.ForeColor = Color.White;
            btnAddPart.Location = new Point(5, 40);
            btnAddPart.Name = "btnAddPart";
            btnAddPart.Size = new Size(338, 32);
            btnAddPart.TabIndex = 3;
            btnAddPart.Text = "+  إضافة قطعة";
            btnAddPart.UseVisualStyleBackColor = false;
            // 
            // lblPartsSubtotal
            // 
            lblPartsSubtotal.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblPartsSubtotal.ForeColor = Color.FromArgb(107, 33, 168);
            lblPartsSubtotal.Location = new Point(5, 31);
            lblPartsSubtotal.Name = "lblPartsSubtotal";
            lblPartsSubtotal.Size = new Size(337, 16);
            lblPartsSubtotal.TabIndex = 4;
            lblPartsSubtotal.TextAlign = ContentAlignment.MiddleRight;
            lblPartsSubtotal.Visible = false;
            // 
            // lblSectionDates
            // 
            lblSectionDates.Font = new Font("Segoe UI", 7.5F);
            lblSectionDates.ForeColor = Color.FromArgb(136, 136, 136);
            lblSectionDates.Location = new Point(12, 260);
            lblSectionDates.Name = "lblSectionDates";
            lblSectionDates.Size = new Size(347, 18);
            lblSectionDates.TabIndex = 17;
            lblSectionDates.Text = "التواريخ والتكلفة";
            lblSectionDates.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlDates
            // 
            pnlDates.BackColor = Color.FromArgb(248, 248, 248);
            pnlDates.Controls.Add(boxIn);
            pnlDates.Controls.Add(boxOut);
            pnlDates.Location = new Point(12, 280);
            pnlDates.Name = "pnlDates";
            pnlDates.Size = new Size(347, 92);
            pnlDates.TabIndex = 18;
            // 
            // boxIn
            // 
            boxIn.BackColor = Color.White;
            boxIn.Controls.Add(capIn);
            boxIn.Controls.Add(valDateIn);
            boxIn.Location = new Point(176, 0);
            boxIn.Name = "boxIn";
            boxIn.Size = new Size(171, 88);
            boxIn.TabIndex = 0;
            // 
            // capIn
            // 
            capIn.Font = new Font("Segoe UI", 7.5F);
            capIn.ForeColor = Color.FromArgb(136, 136, 136);
            capIn.Location = new Point(4, 6);
            capIn.Name = "capIn";
            capIn.Size = new Size(163, 18);
            capIn.TabIndex = 0;
            capIn.Text = "تاريخ الاستلام";
            capIn.TextAlign = ContentAlignment.TopRight;
            // 
            // valDateIn
            // 
            valDateIn.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            valDateIn.ForeColor = Color.FromArgb(51, 51, 51);
            valDateIn.Location = new Point(4, 26);
            valDateIn.Name = "valDateIn";
            valDateIn.Size = new Size(163, 58);
            valDateIn.TabIndex = 1;
            valDateIn.Text = "—";
            valDateIn.TextAlign = ContentAlignment.TopRight;
            // 
            // boxOut
            // 
            boxOut.BackColor = Color.White;
            boxOut.Controls.Add(capOut);
            boxOut.Controls.Add(valDateOut);
            boxOut.Location = new Point(0, 0);
            boxOut.Name = "boxOut";
            boxOut.Size = new Size(171, 88);
            boxOut.TabIndex = 1;
            // 
            // capOut
            // 
            capOut.Font = new Font("Segoe UI", 7.5F);
            capOut.ForeColor = Color.FromArgb(136, 136, 136);
            capOut.Location = new Point(4, 6);
            capOut.Name = "capOut";
            capOut.Size = new Size(163, 18);
            capOut.TabIndex = 0;
            capOut.Text = "تاريخ التسليم";
            capOut.TextAlign = ContentAlignment.TopRight;
            // 
            // valDateOut
            // 
            valDateOut.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            valDateOut.ForeColor = Color.FromArgb(51, 51, 51);
            valDateOut.Location = new Point(4, 26);
            valDateOut.Name = "valDateOut";
            valDateOut.Size = new Size(163, 58);
            valDateOut.TabIndex = 1;
            valDateOut.Text = "—";
            valDateOut.TextAlign = ContentAlignment.TopRight;
            // 
            // pnlCost
            // 
            pnlCost.BackColor = Color.White;
            pnlCost.Controls.Add(capCost);
            pnlCost.Controls.Add(valCost);
            pnlCost.Location = new Point(12, 606);
            pnlCost.Name = "pnlCost";
            pnlCost.Size = new Size(347, 68);
            pnlCost.TabIndex = 19;
            // 
            // capCost
            // 
            capCost.Font = new Font("Segoe UI", 7.5F);
            capCost.ForeColor = Color.FromArgb(136, 136, 136);
            capCost.Location = new Point(5, 5);
            capCost.Name = "capCost";
            capCost.Size = new Size(337, 18);
            capCost.TabIndex = 0;
            capCost.Text = "تكلفة التصليح";
            capCost.TextAlign = ContentAlignment.TopRight;
            // 
            // valCost
            // 
            valCost.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            valCost.ForeColor = Color.FromArgb(44, 62, 107);
            valCost.Location = new Point(5, 25);
            valCost.Name = "valCost";
            valCost.Size = new Size(337, 38);
            valCost.TabIndex = 1;
            valCost.Text = "—";
            valCost.TextAlign = ContentAlignment.TopRight;
            // 
            // pnlWarranty
            // 
            pnlWarranty.BackColor = Color.White;
            pnlWarranty.Controls.Add(capWarranty);
            pnlWarranty.Controls.Add(valWarranty);
            pnlWarranty.Location = new Point(12, 672);
            pnlWarranty.Name = "pnlWarranty";
            pnlWarranty.Size = new Size(347, 62);
            pnlWarranty.TabIndex = 20;
            pnlWarranty.Visible = false;
            // 
            // capWarranty
            // 
            capWarranty.Font = new Font("Segoe UI", 7.5F);
            capWarranty.ForeColor = Color.FromArgb(136, 136, 136);
            capWarranty.Location = new Point(5, 5);
            capWarranty.Name = "capWarranty";
            capWarranty.Size = new Size(336, 27);
            capWarranty.TabIndex = 0;
            capWarranty.Text = "الضمان";
            capWarranty.TextAlign = ContentAlignment.TopRight;
            // 
            // valWarranty
            // 
            valWarranty.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            valWarranty.ForeColor = Color.FromArgb(37, 134, 41);
            valWarranty.Location = new Point(5, 32);
            valWarranty.Name = "valWarranty";
            valWarranty.Size = new Size(342, 33);
            valWarranty.TabIndex = 1;
            valWarranty.Text = "—";
            valWarranty.TextAlign = ContentAlignment.TopRight;
            // 
            // pnlSt
            // 
            pnlSt.BackColor = Color.White;
            pnlSt.Controls.Add(capSt);
            pnlSt.Controls.Add(cmbStatus);
            pnlSt.Location = new Point(12, 732);
            pnlSt.Name = "pnlSt";
            pnlSt.Size = new Size(347, 84);
            pnlSt.TabIndex = 21;
            // 
            // capSt
            // 
            capSt.Font = new Font("Segoe UI", 7.5F);
            capSt.ForeColor = Color.FromArgb(136, 136, 136);
            capSt.Location = new Point(5, 5);
            capSt.Name = "capSt";
            capSt.Size = new Size(337, 18);
            capSt.TabIndex = 0;
            capSt.Text = "تغيير الحالة";
            capSt.TextAlign = ContentAlignment.TopRight;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 9F);
            cmbStatus.Items.AddRange(new object[] { "وارد جديد", "قيد الفحص", "تحت الإصلاح", "جاهز", "تم التسليم" });
            cmbStatus.Location = new Point(5, 28);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(337, 28);
            cmbStatus.TabIndex = 1;
            // 
            // btnEditReceipt
            // 
            btnEditReceipt.BackColor = Color.FromArgb(235, 240, 250);
            btnEditReceipt.Cursor = Cursors.Hand;
            btnEditReceipt.FlatAppearance.BorderColor = Color.FromArgb(44, 62, 107);
            btnEditReceipt.FlatStyle = FlatStyle.Flat;
            btnEditReceipt.Font = new Font("Segoe UI", 9F);
            btnEditReceipt.ForeColor = Color.FromArgb(44, 62, 107);
            btnEditReceipt.Location = new Point(12, 826);
            btnEditReceipt.Name = "btnEditReceipt";
            btnEditReceipt.Size = new Size(347, 36);
            btnEditReceipt.TabIndex = 2;
            btnEditReceipt.Text = "✎  تعديل الإيصال";
            btnEditReceipt.UseVisualStyleBackColor = false;
            // 
            // btnWA
            // 
            btnWA.BackColor = Color.FromArgb(44, 62, 107);
            btnWA.Cursor = Cursors.Hand;
            btnWA.FlatAppearance.BorderSize = 0;
            btnWA.FlatStyle = FlatStyle.Flat;
            btnWA.Font = new Font("Segoe UI", 9F);
            btnWA.ForeColor = Color.White;
            btnWA.Location = new Point(12, 868);
            btnWA.Name = "btnWA";
            btnWA.Size = new Size(347, 44);
            btnWA.TabIndex = 0;
            btnWA.Text = "✉  إرسال واتساب";
            btnWA.UseVisualStyleBackColor = false;
            // 
            // btnPr
            // 
            btnPr.BackColor = Color.White;
            btnPr.Cursor = Cursors.Hand;
            btnPr.FlatAppearance.BorderColor = Color.FromArgb(44, 62, 107);
            btnPr.FlatStyle = FlatStyle.Flat;
            btnPr.Font = new Font("Segoe UI", 9F);
            btnPr.ForeColor = Color.FromArgb(44, 62, 107);
            btnPr.Location = new Point(12, 920);
            btnPr.Name = "btnPr";
            btnPr.Size = new Size(347, 44);
            btnPr.TabIndex = 1;
            btnPr.Text = "⊟  طباعة إيصال";
            btnPr.UseVisualStyleBackColor = false;
            // 
            // lblQRTitle
            // 
            lblQRTitle.Font = new Font("Segoe UI", 7.5F);
            lblQRTitle.ForeColor = Color.FromArgb(136, 136, 136);
            lblQRTitle.Location = new Point(12, 978);
            lblQRTitle.Name = "lblQRTitle";
            lblQRTitle.Size = new Size(347, 18);
            lblQRTitle.TabIndex = 22;
            lblQRTitle.Text = "QR للإيصال";
            lblQRTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlQR
            // 
            pnlQR.BackColor = Color.White;
            pnlQR.Location = new Point(120, 998);
            pnlQR.Name = "pnlQR";
            pnlQR.Size = new Size(110, 110);
            pnlQR.TabIndex = 0;
            // 
            // pnlDtlHeader
            // 
            pnlDtlHeader.BackColor = Color.FromArgb(248, 248, 248);
            pnlDtlHeader.Controls.Add(lblDtlTitle);
            pnlDtlHeader.Controls.Add(btnEditAcc);
            pnlDtlHeader.Controls.Add(btnEditField);
            pnlDtlHeader.Dock = DockStyle.Top;
            pnlDtlHeader.Location = new Point(0, 0);
            pnlDtlHeader.Name = "pnlDtlHeader";
            pnlDtlHeader.Size = new Size(369, 42);
            pnlDtlHeader.TabIndex = 1;
            // 
            // lblDtlTitle
            // 
            lblDtlTitle.Dock = DockStyle.Fill;
            lblDtlTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblDtlTitle.ForeColor = Color.FromArgb(44, 62, 107);
            lblDtlTitle.Location = new Point(0, 0);
            lblDtlTitle.Name = "lblDtlTitle";
            lblDtlTitle.Padding = new Padding(0, 0, 10, 0);
            lblDtlTitle.Size = new Size(369, 42);
            lblDtlTitle.TabIndex = 2;
            lblDtlTitle.Text = "تفاصيل الإيصال";
            lblDtlTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnEditAcc
            // 
            btnEditAcc.BackColor = Color.FromArgb(240, 240, 240);
            btnEditAcc.Cursor = Cursors.Hand;
            btnEditAcc.FlatAppearance.BorderColor = Color.FromArgb(208, 208, 208);
            btnEditAcc.FlatStyle = FlatStyle.Flat;
            btnEditAcc.Font = new Font("Segoe UI", 7.5F);
            btnEditAcc.ForeColor = Color.FromArgb(55, 55, 55);
            btnEditAcc.Location = new Point(42, 10);
            btnEditAcc.Name = "btnEditAcc";
            btnEditAcc.Size = new Size(110, 23);
            btnEditAcc.TabIndex = 1;
            btnEditAcc.Text = "≡  تعديل المرفقات";
            btnEditAcc.UseVisualStyleBackColor = false;
            // 
            // btnEditField
            // 
            btnEditField.BackColor = Color.Transparent;
            btnEditField.Cursor = Cursors.Hand;
            btnEditField.FlatAppearance.BorderSize = 0;
            btnEditField.FlatStyle = FlatStyle.Flat;
            btnEditField.Font = new Font("Segoe UI", 12F);
            btnEditField.ForeColor = Color.FromArgb(80, 80, 80);
            btnEditField.Location = new Point(4, 8);
            btnEditField.Name = "btnEditField";
            btnEditField.Size = new Size(34, 28);
            btnEditField.TabIndex = 0;
            btnEditField.Text = "✎";
            btnEditField.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            BackColor = Color.FromArgb(232, 232, 232);
            ClientSize = new Size(1280, 800);
            Controls.Add(tblMain);
            Controls.Add(pnlToolbar);
            Controls.Add(pnlTitleBar);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(960, 600);
            Name = "MainForm";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterScreen;
            Text = " Repair Flow";
            pnlTitleBar.ResumeLayout(false);
            pnlToolbar.ResumeLayout(false);
            pnlToolbar.PerformLayout();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            tblMain.ResumeLayout(false);
            pnlSidebar.ResumeLayout(false);
            pnlMainContent.ResumeLayout(false);
            pnlOrdersView.ResumeLayout(false);
            pnlGridArea.ResumeLayout(false);
            pnlPagination.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            pnlDetail.ResumeLayout(false);
            pnlDetailScroll.ResumeLayout(false);
            pnlParts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvParts).EndInit();
            pnlPartsFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numPartQty).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPartPrice).EndInit();
            pnlDates.ResumeLayout(false);
            boxIn.ResumeLayout(false);
            boxOut.ResumeLayout(false);
            pnlCost.ResumeLayout(false);
            pnlWarranty.ResumeLayout(false);
            pnlSt.ResumeLayout(false);
            pnlDtlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }


        #endregion

        // ─── field declarations 
        private Panel            pnlTitleBar;
        private Label            lblTitle;
        private Panel            pnlDots;
        private Panel            pnlToolbar;
        private Button           btnNew;
        private Panel            pnlSearch;
        private TextBox          txtSearch;
        private Label            lblSearchIcon;
        private Label            lblLogo;
        private Label            lblLogoIcon;
        private TableLayoutPanel tblMain;
        private Panel            pnlMainContent;
        private TableLayoutPanel pnlOrdersView;
        private Panel            pnlSidebar;
        private FlowLayoutPanel  flpFilters;
        private Panel            pnlGridArea;
        private Panel            pnlPagination;
        private Label            lblPagInfo;
        private FontAwesome.Sharp.IconButton btnPrevPage;
        private FontAwesome.Sharp.IconButton btnNextPage;
        private DataGridView     dgvOrders;
        private DataGridViewTextBoxColumn colReceipt, colClient, colDevice;
        private DataGridViewTextBoxColumn colPhone, colDate, colStatus;
        private Panel            pnlDetail;
        private Panel            pnlDtlHeader;
        private Label            lblDtlTitle;
        private Button           btnEditField;
        private Button           btnEditAcc;
        private Panel            pnlDetailScroll;
        private Label            cap1, cap2, cap3, cap4, cap5, cap6, cap7;
        private Label            valReceipt, valClient, valPhone, valDevice;
        private Label            valModel, valFault, valAccessories;
        private Label            lblSectionDates;
        private Panel            pnlDates;
        private Panel            boxIn;
        private Label            capIn, valDateIn;
        private Panel            boxOut;
        private Label            capOut, valDateOut;
        private Panel            pnlCost;
        private Label            capCost, valCost;
        private Panel            pnlWarranty;
        private Label            capWarranty, valWarranty;
        private Panel            pnlSt;
        private Label            capSt;
        private ComboBox         cmbStatus;
        private Button           btnWA, btnPr;
        private Button           btnEditReceipt;
        private Label            lblQRTitle;
        private Panel            pnlQR;
        // ── spare parts section ──
        private Button           btnAccEdit;
        private Label            lblSectionParts;
        private Panel            pnlParts;
        private DataGridView     dgvParts;
        private DataGridViewTextBoxColumn  colPartName;
        private DataGridViewTextBoxColumn  colPartQty;
        private DataGridViewTextBoxColumn  colPartPrice;
        private DataGridViewButtonColumn   colPartDel;
        private Panel            pnlPartsFooter;
        private ComboBox         cmbPartSearch;
        private NumericUpDown    numPartQty;
        private NumericUpDown    numPartPrice;
        private Button           btnAddPart;
        private Label            lblPartsSubtotal;
    }
}
