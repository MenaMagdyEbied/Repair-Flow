namespace RepairFlow.UI.Forms
{
    public partial class MainForm : Form
    {
        private static readonly Color BgNew = Color.FromArgb(232, 240, 252);
        private static readonly Color BgInspect = Color.FromArgb(255, 248, 222);
        private static readonly Color BgRepair = Color.FromArgb(252, 232, 230);
        private static readonly Color BgReady = Color.FromArgb(228, 244, 232);
        private static readonly Color BgDelivered = Color.FromArgb(242, 232, 255);

        private static readonly Color FgNew = Color.FromArgb(44, 62, 107);
        private static readonly Color FgInspect = Color.FromArgb(155, 105, 0);
        private static readonly Color FgRepair = Color.FromArgb(192, 57, 43);
        private static readonly Color FgReady = Color.FromArgb(37, 134, 41);
        private static readonly Color FgDelivered = Color.FromArgb(107, 33, 168);

        //  active sidebar filter state 
        private Panel?  _activeFilterPanel;
        private Button? _activeFilterBtn;

      
        private static readonly (string Name, decimal BuyPrice, int ProfitPct)[] _inventory =
        {
            ("Samsung S24 شاشة",         320,  25),
            ("Samsung S24 Ultra شاشة",   450,  25),
            ("Samsung S23 شاشة",         280,  25),
            ("Samsung S22 شاشة",         240,  25),
            ("Samsung A54 شاشة",         180,  25),
            ("Samsung A34 شاشة",         150,  25),
            ("Samsung A14 شاشة",         100,  25),
            ("Samsung S24 بطارية",         80,  30),
            ("Samsung S23 بطارية",         70,  30),
            ("Samsung A54 بطارية",         60,  30),
            ("Samsung شاحن أصلي",          50,  30),
            ("Samsung سماعة داخلية",       40,  30),

        private string _receiptSavePath = @"C:\RepairFlow_Receipts";
        private Label? _lblSavePath;

        // Pagination State
        private int _currentPage = 1;
        private int _pageSize = 35;
        private string _currentStatusFilter = "الكل";
        private List<Device> _filteredDevices = new();

            
            ("Oppo Find X6 شاشة",        200,  25),
            ("Oppo Reno 10 شاشة",        140,  25),
            ("Oppo A98 شاشة",            110,  25),
            ("Oppo A78 شاشة",             90,  25),
            ("Oppo Reno 10 بطارية",        55,  30),
            ("Oppo شاحن سريع",             40,  30),

        // -----------------------------------------------
        public MainForm()
        {
            InitializeComponent();

            ("Infinix Note 30 شاشة",     100,  30),
            ("Infinix Hot 30 شاشة",       70,  30),
            ("Infinix Smart 7 شاشة",      55,  30),
            ("Infinix بطارية",             40,  30),

            
            ("Sony Xperia 1 V شاشة",     380,  20),
            ("Sony Xperia 5 V شاشة",     300,  20),
            ("Sony Xperia 10 V شاشة",    180,  20),
            ("Sony بطارية",                75,  25),

            _deviceService = new DeviceService(deviceRepo, partRepo, customerRepo);
            _partService   = new SparePartService(partRepo);

            _waService = new WhatsAppService();
            _printService = new PrintService();
            _backupService = new BackupService();

        private readonly string[,] _rows =
        {
            // R                   Client              Device    Model          Phone          DateIn                S               Fault               Acc                           Cost  DateOut               Warranty
            { "SR-2603-004",  " محمد حمدي",    "LG",     "180",         "01500950666", "2026/03/05 01:54 ص", "وارد جديد",   "proken screen",    "ريموت ، كابل ، حامل",       "",    "",                    "0" },
            { "SR-2603-003",  "عمرو محمد",     "Samsung","Smart 170",   "01500950666", "2026/03/05 01:54 ص", "وارد جديد",   "proken screen",    "ريموت ، كابل ، حامل",       "",    "",                    "0" },
            { "SR-20260212-4","امير أحمد",     "Samsung",     "S25",        "01500950666", "2026/02/12",         "وارد جديد",   "",                 "",                           "",    "",                    "0" },
            { "SR-2603-003",  "فارس محمد",     "Samsung","Smart 170",   "01500950666", "2026/03/05 01:54 ص", "قيد الفحص",  "proken screen",    "ريموت ، كابل ، حامل",       "",    "",                    "0" },
            { "SR-2602-002",  "محمود جمال",           "220",    "220",         "01211879320", "2026/02/14",         "قيد الفحص",  "",                 "",                           "",    "",                    "0" },
            { "SR-2602-006",  "تامر محمود",           "Samsung",     "S24",    "01211879522", "2026/02/27 04:08 ص", "جاهز",        "مممم",             "نننننننننننننننننننن",       "14",  "2026/03/03 02:22 ص",  "6" },
            { "SR-2602-001",  "مصطفي محمود",          "Samsung",      "S23",           "01211879320", "2026/02/10",         "جاهز",        "",                 "",                           "",    "",                    "0" },
            { "SR-2603-002",  "إبراهيم محمد",  "LG",     "Smart 170",   "01111047409", "2026/03/05 01:33 ص", "تم التسليم", "",                 "",                           "600", "2026/03/05 01:34 ص",  "3" },
            { "SR-2603-001",  "مينا اشرف",          "lg",     "180",         "01500950666", "2026/03/05",         "تم التسليم", "",                 "",                           "",    "",                    "0" },
            { "SR-2602-005",  "حمدين محمد",    "LG",     "LG12",        "01500950666", "2026/02/20",         "تم التسليم", "",                 "",                           "600", "2026/03/05",           "3" },
            { "SR-2602-004",  "مريم جمال",           "1200",   "21",          "01211985463", "2026/02/16",         "تم التسليم", "",                 "",                           "",    "",                    "0" },
            { "SR-2602-003",  "ساندي اشرف",           "220",    "220",         "01211879320", "2026/02/15",         "تم التسليم", "",                 "",                           "",    "",                    "0" },
            { "SR-20260212-2","اميره محمد",            "LG",     "270",         "01500950666", "2026/02/12",         "تم التسليم", "",                 "",                           "",    "",                    "0" },
        };

        // column indices in _rows
        private const int C_Receipt=0, C_Client=1, C_Device=2, C_Model=3, C_Phone=4;
        private const int C_DateIn=5, C_Status=6, C_Fault=7, C_Acc=8;
        private const int C_Cost=9, C_DateOut=10, C_Warranty=11;

        // ─────────────────────────────────────────────────────────────────
        public MainForm()
        {
            InitializeComponent();
            BuildSidebar();
            LoadData();
            BuildSidebar();
            RefreshSidebarCounts();
            LoadPartsCombo();
            InitializeEditControls();
            ShowDetail(0);
            WireEvents();
        }

        private void InitializeEditControls()
        {
            _txtClient = CreateEditTextBox(valClient);
            _txtPhone  = CreateEditTextBox(valPhone);
            _txtDevice = CreateEditTextBox(valDevice);
            _txtModel = CreateEditTextBox(valModel);
            _txtFault = CreateEditTextBox(valFault);
            _txtAcc = CreateEditTextBox(valAccessories);
        }

        private TextBox CreateEditTextBox(Label target)
        {
            var txt = new TextBox
            {
                Bounds = target.Bounds,
                Font = target.Font,
                Visible = false,
                RightToLeft = RightToLeft.Yes
            };
            target.Parent?.Controls.Add(txt);
            return txt;
        }

        // SIDEBAR
        private void BuildSidebar()
        {
            Color navy = Color.FromArgb(44, 62, 107);
            Color sideBg = Color.FromArgb(248, 248, 248);

            var counts = _deviceService.GetStatusCounts();

            AddSidebarLabel("الحالات", 8.5f, Color.FromArgb(150, 150, 150),
                            new Padding(0, 10, 0, 6), 222, 20);

            AddFilter("≡",  "الكل",        navy,        CountStatus(""), true);
            AddFilter("📥", "وارد جديد",   FgNew,       CountStatus("وارد جديد"),   false);
            AddFilter("🔍", "قيد الفحص",   FgInspect,   CountStatus("قيد الفحص"),   false);
            AddFilter("🔧", "تحت الإصلاح", FgRepair,    CountStatus("تحت الإصلاح"), false);
            AddFilter("✓",  "جاهز",        FgReady,     CountStatus("جاهز"),         false);
            AddFilter("🚚", "تم التسليم",  FgDelivered, CountStatus("تم التسليم"),   false);

            AddSeparator(16, 10);

            
            int warrantyCount = 1; 
            AddSidebarLabel($"المخزون (منخفض: 1 | نافد: 1)", 7.5f,
                            Color.FromArgb(150, 150, 150), new Padding(4, 0, 4, 2), 184, 18);
            AddSidebarLabel("الموجود: 3", 8f,
                            Color.FromArgb(51, 51, 51), new Padding(4, 0, 4, 4), 184, 18);


            var btnInventory = MakeSidebarBtn("📦  فتح المخزون", Color.FromArgb(44, 62, 107), Color.White);
            btnInventory.Margin = new Padding(4, 0, 4, 4);
            flpFilters.Controls.Add(btnInventory);

           
            var btnDash = MakeSidebarBtn("📊  Dashboard", Color.FromArgb(52, 73, 94), Color.White);
            btnDash.Margin = new Padding(4, 0, 4, 6);
            flpFilters.Controls.Add(btnDash);

            AddSeparator(10, 10);

            AddSidebarLabel("النسخ الاحتياطي", 7.5f,
                            Color.FromArgb(150, 150, 150), new Padding(4, 0, 4, 4), 214, 18);

            var btnBackup = MakeSidebarBtn("  Backup", Color.FromArgb(44, 62, 107), Color.White, icon: IconChar.CloudArrowDown);
            btnBackup.Click += (s, e) => DoBackup();
            flpFilters.Controls.Add(btnBackup);

            var btnRestore = MakeSidebarBtn("  Restore", Color.FromArgb(52, 152, 219), Color.White, icon: IconChar.RotateLeft);
            btnRestore.Click += (s, e) => DoRestore();
            flpFilters.Controls.Add(btnRestore);

            AddSeparator(10, 8);

            AddSidebarLabel("مكان حفظ الإيصالات", 7.5f,
                            Color.FromArgb(150, 150, 150), new Padding(4, 4, 4, 2), 214, 18);

            _lblSavePath = new Label
            {
                Text = _receiptSavePath,
                Font = new Font("Segoe UI", 7.5f),
                ForeColor = Color.FromArgb(80, 80, 80),
                Size = new Size(214, 18),
                Margin = new Padding(4, 0, 4, 4),
                TextAlign = ContentAlignment.MiddleRight,
                AutoEllipsis = true,
            };
            flpFilters.Controls.Add(_lblSavePath);

            var btnOpen = MakeSidebarBtn("  فتح المجلد", Color.White, Color.FromArgb(44, 62, 107), true, icon: IconChar.FolderOpen);
            btnOpen.Click += (s, e) => OpenReceiptsFolder();
            flpFilters.Controls.Add(btnOpen);

            var btnChange = MakeSidebarBtn("  تغيير المكان", Color.FromArgb(44, 62, 107), Color.White, icon: IconChar.LocationDot);
            btnChange.Click += (s, e) => ChangeReceiptsFolder();
            flpFilters.Controls.Add(btnChange);

        private string CountStatus(string s) =>
            s == "" ? _rows.GetLength(0).ToString() :
            Enumerable.Range(0, _rows.GetLength(0))
                      .Count(i => _rows[i, C_Status] == s).ToString();

            var btnLogin = MakeSidebarBtn("  اسم المستخدم", Color.FromArgb(46, 204, 113), Color.White, icon: IconChar.SignInAlt);
            flpFilters.Controls.Add(btnLogin);

            var btnLogout = MakeSidebarBtn("  تسجيل الخروج", Color.FromArgb(231, 76, 60), Color.White, icon: IconChar.SignOutAlt);
            flpFilters.Controls.Add(btnLogout);
        }

        private void AddSidebarLabel(string text, float fontSize, Color fg,
         Padding margin, int width, int height)
        {
            flpFilters.Controls.Add(new Label
            {
                Text = text,
                Font = new Font("Segoe UI", fontSize),
                ForeColor = fg,
                Size = new Size(width, height),
                Margin = margin,
                TextAlign = ContentAlignment.MiddleRight
            });
        }

        private void AddSeparator(int topMargin, int bottomMargin)
        {
            flpFilters.Controls.Add(new Label
            {
                Size = new Size(214, 1),
                Margin = new Padding(4, topMargin, 4, bottomMargin),
                BackColor = Color.FromArgb(218, 218, 218)
            });
        }

        private Button MakeSidebarBtn(string text, Color bg, Color fg, bool bordered = false, IconChar icon = IconChar.None)
        {
            var b = new IconButton
            {
                Text = text,
                IconChar = icon,
                IconColor = fg,
                IconSize = 18,
                TextImageRelation = TextImageRelation.TextBeforeImage,
                Size = new Size(214, 32),
                Margin = new Padding(4, 0, 4, 5),
                BackColor = bg,
                ForeColor = fg,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8.5f),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleRight
            };
            b.FlatAppearance.BorderSize = bordered ? 1 : 0;
            if (bordered) b.FlatAppearance.BorderColor = Color.FromArgb(44, 62, 107);
            b.UseVisualStyleBackColor = false;
            return b;
        }

        private void AddFilter(IconChar icon, string label, Color badgeColor,
                               string count, bool active)
        {
            Color navy = Color.FromArgb(44, 62, 107);
            Color sideBg = Color.FromArgb(248, 248, 248);
            Color activeBg = Color.FromArgb(229, 236, 250);

            var pnl = new Panel
            {
                Size = new Size(222, 38),
                Margin = new Padding(0, 0, 0, 3),
                BackColor = active ? activeBg : sideBg,
                Cursor = Cursors.Hand
            };

            var badge = new Label
            {
                Text = count,
                Size = new Size(32, 22),
                Location = new Point(4, 8),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = badgeColor,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8f, FontStyle.Bold)
            };

            var btn = new IconButton
            {
                Text = label,
                IconChar = icon,
                IconColor = active ? navy : Color.FromArgb(60, 60, 60),
                IconSize = 18,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                ImageAlign = ContentAlignment.MiddleLeft, // Visual Right in RTL
                TextAlign = ContentAlignment.MiddleLeft,  // Visual Right in RTL
                RightToLeft = RightToLeft.Yes,
                Location = new Point(36, 0),
                Size = new Size(186, 38),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = active ? navy : Color.FromArgb(60, 60, 60),
                Font = new Font("Segoe UI", 9.5f, active ? FontStyle.Bold : FontStyle.Regular),
                Cursor = Cursors.Hand,
                TabStop = false,
                Padding = new Padding(0, 0, 0, 0)
            };
            btn.FlatAppearance.BorderSize = 0;

            pnl.Controls.Add(btn);
            pnl.Controls.Add(badge);
            badge.BringToFront();

            if (active) { _activeFilterPanel = pnl; _activeFilterBtn = btn; }

            string f = label;
            btn.Click += (s, e) => ApplyFilter(f, pnl, btn);
            pnl.Click += (s, e) => ApplyFilter(f, pnl, btn);
            badge.Click += (s, e) => ApplyFilter(f, pnl, btn);

            flpFilters.Controls.Add(pnl);
        }

        private void ApplyFilter(string filter, Panel pnl, Button btn)
        {
            Color navy = Color.FromArgb(44, 62, 107);
            Color sideBg = Color.FromArgb(248, 248, 248);
            Color activeBg = Color.FromArgb(229, 236, 250);

            if (_activeFilterPanel != null)
            {
                _activeFilterPanel.BackColor = sideBg;
                if (_activeFilterBtn is IconButton oldBtn)
                {
                    oldBtn.ForeColor = Color.FromArgb(60, 60, 60);
                    oldBtn.IconColor = Color.FromArgb(60, 60, 60);
                    oldBtn.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
                }
            }

            pnl.BackColor = activeBg;
            if (btn is IconButton newBtn)
            {
                newBtn.ForeColor = navy;
                newBtn.IconColor = navy;
                newBtn.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            }
            _activeFilterPanel = pnl;
            _activeFilterBtn   = btn;

            _currentPage = 1; // Reset to page 1 on filter change
            LoadData(filter);
        }

        private void LoadData(string statusFilter = "الكل")
        {
            dgvOrders.Rows.Clear();
            int n = _rows.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                string device = $"{_rows[i, C_Device]} • {_rows[i, C_Model]}";
                int idx = dgvOrders.Rows.Add(
                    _rows[i, C_Receipt],
                    _rows[i, C_Client],
                    device,
                    _rows[i, C_Phone],
                    _rows[i, C_DateIn].Split(' ')[0],   // date only
                    _rows[i, C_Status]);

                // colour status cell
                var (bg, fg) = StatusColors(_rows[i, C_Status]);
                var cell = dgvOrders.Rows[idx].Cells["colStatus"];
                cell.Style.BackColor = bg;
                cell.Style.ForeColor = fg;
                cell.Style.Font      = new Font("Segoe UI", 8.5f, FontStyle.Bold);
                cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvOrders.Rows.Count > 0)
                dgvOrders.Rows[0].Selected = true;

            lblPagInfo.Text = $"الموجود: {n}";
        }

        private void ShowDetail(int gridRowIndex)
        {
            if (dataIndex < 0 || dataIndex >= _rows.GetLength(0)) return;

            string receipt = _rows[dataIndex, C_Receipt];
            string client = _rows[dataIndex, C_Client];
            string phone = _rows[dataIndex, C_Phone];
            string device = _rows[dataIndex, C_Device];
            string model = _rows[dataIndex, C_Model];
            string fault = _rows[dataIndex, C_Fault];
            string acc = _rows[dataIndex, C_Acc];
            string dateIn = _rows[dataIndex, C_DateIn];
            string dateOut = _rows[dataIndex, C_DateOut];
            string cost = _rows[dataIndex, C_Cost];
            string status = _rows[dataIndex, C_Status];
            string warranty = _rows[dataIndex, C_Warranty];

            valReceipt.Text = receipt;
            valClient.Text = client;
            valPhone.Text = phone;
            valDevice.Text = device;
            valModel.Text = model;
            valFault.Text = string.IsNullOrEmpty(fault)   ? "—" : fault;
            valAccessories.Text = string.IsNullOrEmpty(acc)     ? "—" : acc;
            valDateIn.Text = string.IsNullOrEmpty(dateIn)  ? "—" : dateIn;
            valDateOut.Text = string.IsNullOrEmpty(dateOut) ? "لم يتم التسليم" : dateOut;
            valCost.Text = string.IsNullOrEmpty(cost)    ? "—" : $"{cost} ج";

            int wMonths = int.TryParse(warranty, out int w) ? w : 0;
            pnlWarranty.Visible = wMonths > 0;
            if (wMonths > 0)
                valWarranty.Text = $"{wMonths} شهور";

            // status combo
            int si = cmbStatus.Items.IndexOf(status);
            if (si >= 0) cmbStatus.SelectedIndex = si;
            var (cbBg, cbFg) = StatusColors(statusAr);
            cmbStatus.BackColor = cbBg;
            cmbStatus.ForeColor = cbFg;

            dgvParts.Rows.Clear();
            foreach (var sp in d.DeviceSpareParts)
            {
                int rIdx = dgvParts.Rows.Add(sp.SparePart?.Name, sp.QuantityUsed, sp.UnitPrice);
                dgvParts.Rows[rIdx].Tag = sp.Id;
            }
            ResizeParts();
            RecalcParts();

            pnlQR.Invalidate();
        }

      
        private void WireEvents()
        {
            //  title bar
            pnlTitleBar.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Fill(e.Graphics, Color.FromArgb(255, 95, 87), 8, 9, 12);
                Fill(e.Graphics, Color.FromArgb(255, 189, 46), 26, 9, 12);
                Fill(e.Graphics, Color.FromArgb(39, 201, 63), 44, 9, 12);
            };

            pnlToolbar.Paint += (s, e) =>
            {
                using var p = new Pen(Color.FromArgb(215, 215, 215));
                e.Graphics.DrawLine(p, 0, pnlToolbar.Height - 1, pnlToolbar.Width, pnlToolbar.Height - 1);
            };

            pnlSearch.Paint += (s, e) =>
            {
                using var p = new Pen(Color.FromArgb(200, 200, 200));
                e.Graphics.DrawRectangle(p, 0, 0, pnlSearch.Width - 1, pnlSearch.Height - 1);
            };

            pnlSidebar.Paint += (s, e) =>
            {
                using var p = new Pen(Color.FromArgb(218, 218, 218));
                e.Graphics.DrawLine(p, pnlSidebar.Width - 1, 0, pnlSidebar.Width - 1, pnlSidebar.Height);
            };

            btnNextPage.Click += (s, e) => {
                _currentPage++;
                LoadData(_currentStatusFilter);
            };

            btnPrevPage.Click += (s, e) => {
                _currentPage--;
                LoadData(_currentStatusFilter);
            };

            pnlDetail.Paint += (s, e) =>
            {
                using var p = new Pen(Color.FromArgb(218, 218, 218));
                e.Graphics.DrawLine(p, 0, 0, 0, pnlDetail.Height);
            };

            pnlDtlHeader.Paint += (s, e) =>
            {
                using var p = new Pen(Color.FromArgb(218, 218, 218));
                e.Graphics.DrawLine(p, 0, pnlDtlHeader.Height - 1, dgvOrders.Width, pnlDtlHeader.Height - 1);
            };

            // box borders 
            boxIn.Paint  += PanelBorder;
            boxOut.Paint += PanelBorder;
            pnlCost.Paint += PanelBorder;
            pnlWarranty.Paint += PanelBorder;
            pnlSt.Paint += PanelBorder;
            pnlParts.Paint += PanelBorder;

            pnlQR.Paint += QrPaint;

            dgvOrders.SelectionChanged += DgvOrders_SelectionChanged;

            txtSearch.TextChanged += (s, e) =>
            {
                string q = txtSearch.Text.Trim().ToLower();
                foreach (DataGridViewRow row in dgvOrders.Rows)
                {
                    if (string.IsNullOrEmpty(q)) { row.Visible = true; continue; }
                    bool hit = false;
                    foreach (DataGridViewCell cell in row.Cells)
                        if (cell.Value?.ToString()?.ToLower().Contains(q) == true)
                        { hit = true; break; }
                    row.Visible = hit;
                }
            };


           
            //  spare parts combo 
            cmbPartSearch.SelectedIndexChanged += CmbPartSearch_SelectedIndexChanged;
            cmbPartSearch.TextChanged += (s, e) =>
            {
                string typed = cmbPartSearch.Text.Trim();
                var found = _dbInventory.FirstOrDefault(i => i.Name.Equals(typed, StringComparison.OrdinalIgnoreCase));
                if (found != null)
                {
                    _selectedPartUnitPrice = found.SellingPrice;
                    numPartPrice.Value = _selectedPartUnitPrice * numPartQty.Value;
                }
            };

    
            btnAddPart.Click += BtnAddPart_Click;
            dgvParts.CellClick += DgvParts_CellClick;

            cmbStatus.SelectedIndexChanged += (s, e) =>
            {
                if (dgvOrders.SelectedRows.Count == 0) return;
                int idx = dgvOrders.SelectedRows[0].Index;
                string receipt = dgvOrders.Rows[idx].Cells[0].Value?.ToString() ?? "";
                string selAr = cmbStatus.SelectedItem?.ToString() ?? "";
                
                var (bg, fg) = StatusColors(selAr);
                cmbStatus.BackColor = bg;
                cmbStatus.ForeColor = fg;

                _deviceService.UpdateStatus(receipt, selAr);
                
                var updated = _deviceService.GetDeviceByReceipt(receipt);
                if (updated != null)
                {
                    // Update the row in the grid
                    dgvOrders.Rows[idx].Cells["colStatus"].Value = selAr;
                    dgvOrders.Rows[idx].Cells["colStatus"].Style.BackColor = bg;
                    dgvOrders.Rows[idx].Cells["colStatus"].Style.ForeColor = fg;
                    valDateOut.Text = updated.DeliveredAt?.ToString("yyyy/MM/dd hh:mm tt") ?? "لم يتم التسليم";

                    // Sync with our master list and filtered list to keep data consistent
                    int masterIdx = _devices.FindIndex(x => x.ReceiptNumber == receipt);
                    if (masterIdx >= 0) _devices[masterIdx] = updated;

                    int filterIdx = _filteredDevices.FindIndex(x => x.ReceiptNumber == receipt);
                    if (filterIdx >= 0) _filteredDevices[filterIdx] = updated;
                }
                RefreshSidebarCounts();
            };

            btnWA.Click += (s, e) => {
                if (dgvOrders.SelectedRows.Count == 0 || _isLoadingData) return;
                int idx = dgvOrders.SelectedRows[0].Index;
                string receipt = dgvOrders.Rows[idx].Cells[0].Value?.ToString() ?? "";
                var d = _filteredDevices.FirstOrDefault(x => x.ReceiptNumber == receipt);
                if (d == null) return;

                string url = _waService.GenerateWhatsAppUrl(d);
                if (!string.IsNullOrEmpty(url)) 
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = url, UseShellExecute = true });
            };

            btnPr.Click += (s, e) => {
                 if (dgvOrders.SelectedRows.Count == 0 || _isLoadingData) return;
                 int idx = dgvOrders.SelectedRows[0].Index;
                 string receipt = dgvOrders.Rows[idx].Cells[0].Value?.ToString() ?? "";
                 var d = _filteredDevices.FirstOrDefault(x => x.ReceiptNumber == receipt);
                 if (d == null) return;
                 
                 _printService.PreviewReceipt(d);
            };

            btnEditReceipt.Click += btnEdit_Click;

            Resize += (s, e) =>
            {
                int right = pnlToolbar.Width - 8;
                lblLogoIcon.Location = new Point(right - 32, lblLogoIcon.Location.Y);
                lblLogo.Location = new Point(right - 32 - lblLogo.Width - 6, lblLogo.Location.Y);
            };
        }

        private void btnEdit_Click(object? sender, EventArgs e)
        {
            ToggleEditMode();
        }

        private static void Fill(Graphics g, Color c, int x, int y, int d)
        {
            using var b = new SolidBrush(c);
            g.FillEllipse(b, x, y, d, d);
        }

        private static void PanelBorder(object? s, PaintEventArgs e)
        {
            if (s is not Panel p) return;
            using var pen = new Pen(Color.FromArgb(218, 218, 218));
            e.Graphics.DrawRectangle(pen, 0, 0, p.Width - 1, p.Height - 1);
        }

        private void QrPaint(object? s, PaintEventArgs e)
        {
            if (s is not Panel p) return;
            using var border = new Pen(Color.FromArgb(218, 218, 218));
            e.Graphics.DrawRectangle(border, 0, 0, p.Width - 1, p.Height - 1);

            using var brush = new SolidBrush(Color.Black);
            int seed = valReceipt.Text.GetHashCode();
            var rng = new Random(seed);
            int cs = 5, m = 4;
            int cols = (p.Width - m * 2) / cs;
            int rows = (p.Height - m * 2) / cs;
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                {
                    bool corner = (r < 4 && c < 4) || (r < 4 && c >= cols - 4) || (r >= rows - 4 && c < 4);
                    if (corner || rng.Next(4) == 0)
                        e.Graphics.FillRectangle(brush, m + c * cs, m + r * cs, cs - 1, cs - 1);
                }
        }

        private static (Color bg, Color fg) StatusColors(string s) => s switch
        {
            "وارد جديد"  => (BgNew, FgNew),
            "قيد الفحص" => (BgInspect, FgInspect),
            "تحت الإصلاح" => (BgRepair, FgRepair),
            "جاهز"  => (BgReady, FgReady),
            "تم التسليم"  => (BgDelivered, FgDelivered),_=> (Color.White,  Color.Black)
        };

       
      // SPARE PARTS LOGIC
        private void LoadPartsCombo()
        {
            cmbPartSearch.Items.Clear();
            _dbInventory = _partService.GetInventory();
            foreach (var item in _dbInventory)
                cmbPartSearch.Items.Add(item.Name);
        }

        private void CmbPartSearch_SelectedIndexChanged(object? s, EventArgs e)
        {
            string selected = cmbPartSearch.Text.Trim();
            var found = _dbInventory.FirstOrDefault(i => i.Name == selected);
            if (found != null)
            {
                _selectedPartUnitPrice = found.SellingPrice;
                numPartPrice.Value = _selectedPartUnitPrice * numPartQty.Value;
            }
        }

        private void BtnAddPart_Click(object? s, EventArgs e)
        {
            string name  = cmbPartSearch.Text.Trim();
            int    qty   = (int)numPartQty.Value;
            decimal price= numPartPrice.Value;

            if (string.IsNullOrEmpty(name))
            {
                cmbPartSearch.BackColor = Color.FromArgb(255, 235, 235);
                cmbPartSearch.Focus();
                return;
            }
            cmbPartSearch.BackColor = Color.White;

            decimal unitPrice = (qty > 0) ? price / qty : price;
            _deviceService.AddSparePart(valReceipt.Text, name, qty, unitPrice);

            cmbPartSearch.Text = "";
            numPartQty.Value  = 1;
            numPartPrice.Value  = 0;
            cmbPartSearch.Focus();
        }

        private void DgvParts_CellClick(object? s, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != dgvParts.Columns["colPartDel"]!.Index) return;
            if (e.RowIndex < 0) return;

            if (dgvParts.Rows[e.RowIndex].Tag is int dpId)
            {
                _deviceService.RemoveSparePart(valReceipt.Text, dpId);
                if (dgvOrders.SelectedRows.Count > 0)
                    ShowDetail(dgvOrders.SelectedRows[0].Index);
            }
        }

        private void RecalcParts()
        {
            decimal subtotal = 0m;
            foreach (DataGridViewRow row in dgvParts.Rows)
            {
                if (row.IsNewRow) continue;
                decimal.TryParse(row.Cells["colPartQty"].Value?.ToString(),   out decimal qty);
                decimal.TryParse(row.Cells["colPartPrice"].Value?.ToString(),  out decimal price);
                subtotal += qty * price;
            }

            if (subtotal > 0)
            {
                lblPartsSubtotal.Text = $"إجمالي تكلفة القطع (داخلي): {subtotal:0} ج";
                lblPartsSubtotal.Visible = true;
            }
            else
            {
                lblPartsSubtotal.Text  = "";
                lblPartsSubtotal.Visible = false;
            }
        }

      
        private void ResizeParts()
        {
            int headerH = dgvParts.ColumnHeadersHeight;
            int rowH = dgvParts.RowTemplate.Height;
            int rowCount = dgvParts.Rows.Count;
            int gridH = headerH + (rowCount * rowH);
            dgvParts.Size = new Size(dgvParts.Width, gridH);
            pnlParts.Size = new Size(pnlParts.Width, gridH + pnlPartsFooter.Height + 2);
            ShiftControlsBelow(pnlParts);
        }

      
        private void ShiftControlsBelow(Control targetCtrl)
        {
            var below = pnlDetailScroll.Controls
                .Cast<Control>()
                .Where(c => c != targetCtrl && c.Top >= targetCtrl.Top + 1)
                .OrderBy(c => c.Top)
                .ToList();

            int nextY = targetCtrl.Bottom + 10;
            foreach (var ctrl in below)
            {
                ctrl.Top = nextY;
                nextY   += ctrl.Height + (ctrl == pnlDates   ? 8  :
                              ctrl == pnlCost     ? 6  :
                              ctrl == pnlWarranty ? 6  :
                              ctrl == pnlSt       ? 10 :
                              ctrl == btnWA       ? 8  :
                              ctrl == btnPr       ? 14 :
                              ctrl == lblQRTitle  ? 20 :
                              ctrl == pnlQR       ? 10 : 8);
            }
            d.DeviceName = _txtDevice!.Text;
            d.Model = _txtModel!.Text;
            d.Fault = _txtFault!.Text;
            d.Accessories = _txtAcc!.Text;

            _deviceService.UpdateDeviceDetails(d);
            ShowDetail(_editingIndex);
            LoadData(); // Refresh grid
        }
    }
}
