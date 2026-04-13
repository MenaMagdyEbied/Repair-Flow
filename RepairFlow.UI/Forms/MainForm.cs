using FontAwesome.Sharp;
using RepairFlow.BLL.Services;
using RepairFlow.BLL.Services.Interfaces;
using RepairFlow.DAL;
using RepairFlow.DAL.Repositories;
using RepairFlow.Models;
using System.IO;

namespace RepairFlow.UI.Forms
{
    public partial class MainForm : Form
    {
        private static readonly Color BgNew       = Color.FromArgb(232, 240, 252);
        private static readonly Color BgInspect   = Color.FromArgb(255, 248, 222);
        private static readonly Color BgRepair    = Color.FromArgb(252, 232, 230);
        private static readonly Color BgReady     = Color.FromArgb(228, 244, 232);
        private static readonly Color BgDelivered = Color.FromArgb(242, 232, 255);

        private static readonly Color FgNew       = Color.FromArgb(44,  62, 107);
        private static readonly Color FgInspect   = Color.FromArgb(155, 105,   0);
        private static readonly Color FgRepair    = Color.FromArgb(192,  57,  43);
        private static readonly Color FgReady     = Color.FromArgb(37,  134,  41);
        private static readonly Color FgDelivered = Color.FromArgb(107,  33, 168);

        private Panel?  _activeFilterPanel;
        private Button? _activeFilterBtn;
        private Button? _btnLogin;

        private Control? _currentView;

        // Edit
        private bool _isEditing;
        private bool _isLoadingData;
        private int  _editingIndex = -1;
        private TextBox? _txtClient, _txtPhone, _txtDevice, _txtModel, _txtFault, _txtAcc;

        private string _receiptSavePath = @"C:\RepairFlow_Receipts";
        private Label? _lblSavePath;

        // Pagination State
        private int _currentPage         = 1;
        private int _pageSize            = 35;
        private string _currentStatusFilter = "الكل";
        private List<Device> _filteredDevices = new();

        // BLL Services
        private readonly IDeviceService    _deviceService;
        private readonly IWhatsAppService  _waService;
        private readonly IPrintService     _printService;
        private readonly IBackupService    _backupService;
        private readonly ISparePartService _partService;
        private readonly IDashboardService _dashboardService;
        // current user is displayed in the sidebar button; username set via SetLoggedInUser

        private List<Device>    _devices     = new();
        private List<SparePart> _dbInventory = new();
        private decimal _selectedPartUnitPrice;

        // ── Constructor (Full DI — used by Program.cs) ────────────────────────
        private readonly Form _loginForm;

        public MainForm(
            IDeviceService    deviceService,
            ISparePartService partService,
            IDashboardService dashboardService,
            IWhatsAppService  waService,
            IPrintService     printService,
            IBackupService    backupService,
            Form     loginForm)
        {
            InitializeComponent();

            _deviceService    = deviceService;
            _partService      = partService;
            _dashboardService = dashboardService;
            _waService        = waService;
            _printService     = printService;
            _backupService    = backupService;
            _loginForm        = loginForm;

            _currentView = pnlOrdersView;
            BuildSidebar();
            LoadData();
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
            _txtModel  = CreateEditTextBox(valModel);
            _txtFault  = CreateEditTextBox(valFault);
            _txtAcc    = CreateEditTextBox(valAccessories);
        }

        private TextBox CreateEditTextBox(Label target)
        {
            var txt = new TextBox
            {
                Bounds      = target.Bounds,
                Font        = target.Font,
                Visible     = false,
                RightToLeft = RightToLeft.Yes
            };
            target.Parent?.Controls.Add(txt);
            return txt;
        }

        // ── SIDEBAR ───────────────────────────────────────────────────────────
        private void BuildSidebar()
        {
            Color navy = Color.FromArgb(44, 62, 107);
            Color sideBg = Color.FromArgb(248, 248, 248);

            var counts = _deviceService.GetStatusCounts();

            AddSidebarLabel("الحالات", 8.5f, Color.FromArgb(150, 150, 150),
                            new Padding(0, 10, 0, 6), 222, 20);

            AddFilter(IconChar.Bars, "الكل", navy, counts.GetValueOrDefault("الكل", "0"), true);
            AddFilter(IconChar.Download, "وارد جديد", FgNew, counts.GetValueOrDefault("وارد جديد", "0"), false);
            AddFilter(IconChar.MagnifyingGlass, "قيد الفحص", FgInspect, counts.GetValueOrDefault("قيد الفحص", "0"), false);
            AddFilter(IconChar.Wrench, "تحت الإصلاح", FgRepair, counts.GetValueOrDefault("تحت الإصلاح", "0"), false);
            AddFilter(IconChar.Check, "جاهز", FgReady, counts.GetValueOrDefault("جاهز", "0"), false);
            AddFilter(IconChar.Truck, "تم التسليم", FgDelivered, counts.GetValueOrDefault("تم التسليم", "0"), false);

            AddSeparator(16, 10);

            AddSidebarLabel("المخزون", 7.5f,
                            Color.FromArgb(150, 150, 150), new Padding(4, 0, 4, 4), 214, 18);

            var btnInventory = MakeSidebarBtn("  فتح المخزون", Color.FromArgb(44, 62, 107), Color.White, icon: IconChar.BoxOpen);
            btnInventory.Margin = new Padding(4, 0, 4, 4);
            flpFilters.Controls.Add(btnInventory);

            // ── Dashboard Button (integrates your Form1 dashboard) ────────────
            var btnDash = MakeSidebarBtn("  Dashboard", Color.FromArgb(52, 73, 94), Color.White, icon: IconChar.ChartBar);
            btnDash.Margin = new Padding(4, 0, 4, 6);
            btnDash.Click += (s, e) => ShowDashboardView();
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

            AddSeparator(16, 12);

            // User display button (updated after successful login)
            _btnLogin = MakeSidebarBtn("  اسم المستخدم", Color.FromArgb(46, 204, 113), Color.White, icon: IconChar.SignInAlt);
            _btnLogin.Text = "  اسم المستخدم";
            flpFilters.Controls.Add(_btnLogin);

            // Logout button — show the original login form and close this main form
            var btnLogout = MakeSidebarBtn("  تسجيل الخروج", Color.FromArgb(231, 76, 60), Color.White, icon: IconChar.SignOutAlt);
            btnLogout.Click += (s, e) =>
            {
                try
                {
                    _loginForm?.Show();
                    _loginForm?.BringToFront();
                }
                catch { }
                Close();
            };
            flpFilters.Controls.Add(btnLogout);
        }

        private void AddSidebarLabel(string text, float fontSize, Color fg,
                                     Padding margin, int width, int height)
        {
            flpFilters.Controls.Add(new Label
            {
                Text      = text,
                Font      = new Font("Segoe UI", fontSize),
                ForeColor = fg,
                Size      = new Size(width, height),
                Margin    = margin,
                TextAlign = ContentAlignment.MiddleRight
            });
        }

        private void AddSeparator(int topMargin, int bottomMargin)
        {
            flpFilters.Controls.Add(new Label
            {
                Size      = new Size(214, 1),
                Margin    = new Padding(4, topMargin, 4, bottomMargin),
                BackColor = Color.FromArgb(218, 218, 218)
            });
        }

        private Button MakeSidebarBtn(string text, Color bg, Color fg,
                                      bool bordered = false, IconChar icon = IconChar.None)
        {
            var b = new IconButton
            {
                Text                = text,
                IconChar            = icon,
                IconColor           = fg,
                IconSize            = 18,
                TextImageRelation   = TextImageRelation.TextBeforeImage,
                Size                = new Size(214, 32),
                Margin              = new Padding(4, 0, 4, 5),
                BackColor           = bg,
                ForeColor           = fg,
                FlatStyle           = FlatStyle.Flat,
                Font                = new Font("Segoe UI", 8.5f),
                Cursor              = Cursors.Hand,
                TextAlign           = ContentAlignment.MiddleRight
            };
            b.FlatAppearance.BorderSize = bordered ? 1 : 0;
            if (bordered) b.FlatAppearance.BorderColor = Color.FromArgb(44, 62, 107);
            b.UseVisualStyleBackColor = false;
            return b;
        }

        private void AddFilter(IconChar icon, string label, Color badgeColor,
                               string count, bool active)
        {
            Color navy    = Color.FromArgb(44,  62, 107);
            Color sideBg  = Color.FromArgb(248, 248, 248);
            Color activeBg= Color.FromArgb(229, 236, 250);

            var pnl = new Panel
            {
                Size      = new Size(222, 38),
                Margin    = new Padding(0, 0, 0, 3),
                BackColor = active ? activeBg : sideBg,
                Cursor    = Cursors.Hand
            };

            var badge = new Label
            {
                Text      = count,
                Size      = new Size(32, 22),
                Location  = new Point(4, 8),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = badgeColor,
                ForeColor = Color.White,
                Font      = new Font("Segoe UI", 8f, FontStyle.Bold)
            };

            var btn = new IconButton
            {
                Text              = label,
                IconChar          = icon,
                IconColor         = active ? navy : Color.FromArgb(60, 60, 60),
                IconSize          = 18,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                ImageAlign        = ContentAlignment.MiddleLeft,
                TextAlign         = ContentAlignment.MiddleLeft,
                RightToLeft       = RightToLeft.Yes,
                Location          = new Point(36, 0),
                Size              = new Size(186, 38),
                FlatStyle         = FlatStyle.Flat,
                BackColor         = Color.Transparent,
                ForeColor         = active ? navy : Color.FromArgb(60, 60, 60),
                Font              = new Font("Segoe UI", 9.5f, active ? FontStyle.Bold : FontStyle.Regular),
                Cursor            = Cursors.Hand,
                TabStop           = false,
            };
            btn.FlatAppearance.BorderSize = 0;

            pnl.Controls.Add(btn);
            pnl.Controls.Add(badge);
            badge.BringToFront();

            if (active) { _activeFilterPanel = pnl; _activeFilterBtn = btn; }

            string f = label;
            btn.Click   += (s, e) => ApplyFilter(f, pnl, btn);
            pnl.Click   += (s, e) => ApplyFilter(f, pnl, btn);
            badge.Click += (s, e) => ApplyFilter(f, pnl, btn);

            flpFilters.Controls.Add(pnl);
        }

        private void ApplyFilter(string filter, Panel pnl, Button btn)
        {
            Color navy    = Color.FromArgb(44,  62, 107);
            Color sideBg  = Color.FromArgb(248, 248, 248);
            Color activeBg= Color.FromArgb(229, 236, 250);

            if (_activeFilterPanel != null)
            {
                _activeFilterPanel.BackColor = sideBg;
                if (_activeFilterBtn is IconButton oldBtn)
                {
                    oldBtn.ForeColor = Color.FromArgb(60, 60, 60);
                    oldBtn.IconColor = Color.FromArgb(60, 60, 60);
                    oldBtn.Font      = new Font("Segoe UI", 9.5f, FontStyle.Regular);
                }
            }

            pnl.BackColor = activeBg;
            if (btn is IconButton newBtn)
            {
                newBtn.ForeColor = navy;
                newBtn.IconColor = navy;
                newBtn.Font      = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            }
            _activeFilterPanel = pnl;
            _activeFilterBtn   = btn;

            _currentPage = 1;
            LoadData(filter);

            // Switch back to orders view when a status filter is clicked
            if (_currentView != pnlOrdersView)
                SwitchView(pnlOrdersView);
        }

        private void LoadData(string statusFilter = "الكل")
        {
            if (_isLoadingData) return;
            _isLoadingData = true;
            _currentStatusFilter = statusFilter;

            try
            {
                dgvOrders.SelectionChanged -= DgvOrders_SelectionChanged;
                dgvOrders.Rows.Clear();

                var all = _deviceService.GetAllDevices();

                _filteredDevices = all.Where(d => {
                    string sAr = MapStatusToArabic(d.Status);
                    return statusFilter == "الكل" || sAr == statusFilter;
                }).ToList();

                int totalCount = _filteredDevices.Count;
                int totalPages = (int)Math.Ceiling(totalCount / (double)_pageSize);
                if (totalPages == 0) totalPages = 1;
                if (_currentPage > totalPages) _currentPage = totalPages;
                if (_currentPage < 1)          _currentPage = 1;

                var pageData = _filteredDevices
                    .Skip((_currentPage - 1) * _pageSize)
                    .Take(_pageSize)
                    .ToList();

                foreach (var d in pageData)
                {
                    string statusAr  = MapStatusToArabic(d.Status);
                    string deviceName = $"{(d.DeviceName ?? "-")} • {(d.Model ?? "-")}";
                    int idx = dgvOrders.Rows.Add(
                        d.ReceiptNumber,
                        d.Customer?.Name ?? "-",
                        deviceName,
                        d.Customer?.Phone ?? "-",
                        d.ReceivedAt.ToString("yyyy/MM/dd"),
                        statusAr);

                    var (bg, fg) = StatusColors(statusAr);
                    var cell = dgvOrders.Rows[idx].Cells["colStatus"];
                    cell.Style.BackColor = bg;
                    cell.Style.ForeColor = fg;
                    cell.Style.Font      = new Font("Segoe UI", 8.5f, FontStyle.Bold);
                    cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                lblPagInfo.Text         = $"صفحة {_currentPage} من {totalPages}  |  المجموع: {totalCount}";
                btnPrevPage.Enabled     = _currentPage > 1;
                btnNextPage.Enabled     = _currentPage < totalPages;
                btnPrevPage.IconColor   = btnPrevPage.Enabled ? Color.FromArgb(44, 62, 107) : Color.Silver;
                btnNextPage.IconColor   = btnNextPage.Enabled ? Color.FromArgb(44, 62, 107) : Color.Silver;

                if (dgvOrders.Rows.Count > 0)
                    dgvOrders.Rows[0].Selected = true;
            }
            finally
            {
                dgvOrders.SelectionChanged += DgvOrders_SelectionChanged;
                _isLoadingData = false;
            }
        }

        private void DgvOrders_SelectionChanged(object? s, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
                ShowDetail(dgvOrders.SelectedRows[0].Index);
        }

        private void ShowDetail(int gridRowIndex)
        {
            if (gridRowIndex < 0 || gridRowIndex >= dgvOrders.Rows.Count) return;
            _editingIndex = gridRowIndex;

            string receipt = dgvOrders.Rows[gridRowIndex].Cells[0].Value?.ToString() ?? "";
            var d = _filteredDevices.FirstOrDefault(x => x.ReceiptNumber == receipt);
            if (d == null) return;

            valReceipt.Text     = d.ReceiptNumber;
            valClient.Text      = d.Customer?.Name ?? "-";
            valPhone.Text       = d.Customer?.Phone ?? "-";
            valDevice.Text      = d.DeviceName ?? "-";
            valModel.Text       = d.Model ?? "-";
            valFault.Text       = string.IsNullOrEmpty(d.Fault) ? "—" : d.Fault;
            valAccessories.Text = string.IsNullOrEmpty(d.Accessories) ? "—" : d.Accessories;

            _txtClient!.Text = d.Customer?.Name;
            _txtPhone!.Text  = d.Customer?.Phone;
            _txtDevice!.Text = d.DeviceName;
            _txtModel!.Text  = d.Model;
            _txtFault!.Text  = d.Fault;
            _txtAcc!.Text    = d.Accessories;

            valDateIn.Text  = d.ReceivedAt.ToString("yyyy/MM/dd hh:mm tt");
            valDateOut.Text = d.DeliveredAt?.ToString("yyyy/MM/dd hh:mm tt") ?? "لم يتم التسليم";
            valCost.Text    = d.RepairCost == null ? "—" : $"{d.RepairCost:0} ج";

            pnlWarranty.Visible = d.WarrantyMonths > 0;
            if (d.WarrantyMonths > 0)
                valWarranty.Text = $"{d.WarrantyMonths} شهور";

            string statusAr = MapStatusToArabic(d.Status);
            int si = cmbStatus.Items.IndexOf(statusAr);
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
            pnlTitleBar.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Fill(e.Graphics, Color.FromArgb(255, 95,  87),  8, 9, 12);
                Fill(e.Graphics, Color.FromArgb(255, 189, 46), 26, 9, 12);
                Fill(e.Graphics, Color.FromArgb(39,  201, 63), 44, 9, 12);
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

            btnNextPage.Click += (s, e) => { _currentPage++; LoadData(_currentStatusFilter); };
            btnPrevPage.Click += (s, e) => { _currentPage--; LoadData(_currentStatusFilter); };

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

            boxIn.Paint      += PanelBorder;
            boxOut.Paint     += PanelBorder;
            pnlCost.Paint    += PanelBorder;
            pnlWarranty.Paint += PanelBorder;
            pnlSt.Paint      += PanelBorder;
            pnlParts.Paint   += PanelBorder;
            pnlQR.Paint      += QrPaint;

            dgvOrders.SelectionChanged += DgvOrders_SelectionChanged;

            btnNew.Click += (s, e) =>
            {
                string nextReceipt = _deviceService.GenerateReceiptNumber();
                var form = new ReciptForm(this, nextReceipt, _deviceService);
                form.ShowDialog(this);
            };

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

            numPartQty.ValueChanged += (s, e) =>
            {
                numPartPrice.Value = _selectedPartUnitPrice * numPartQty.Value;
            };

            cmbPartSearch.SelectedIndexChanged += CmbPartSearch_SelectedIndexChanged;
            btnAddPart.Click   += BtnAddPart_Click;
            dgvParts.CellClick += DgvParts_CellClick;

            cmbStatus.SelectedIndexChanged += (s, e) =>
            {
                if (dgvOrders.SelectedRows.Count == 0) return;
                int idx     = dgvOrders.SelectedRows[0].Index;
                string receipt = dgvOrders.Rows[idx].Cells[0].Value?.ToString() ?? "";
                string selAr   = cmbStatus.SelectedItem?.ToString() ?? "";

                var (bg, fg) = StatusColors(selAr);
                cmbStatus.BackColor = bg;
                cmbStatus.ForeColor = fg;

                _deviceService.UpdateStatus(receipt, selAr);

                var updated = _deviceService.GetDeviceByReceipt(receipt);
                if (updated != null)
                {
                    dgvOrders.Rows[idx].Cells["colStatus"].Value           = selAr;
                    dgvOrders.Rows[idx].Cells["colStatus"].Style.BackColor = bg;
                    dgvOrders.Rows[idx].Cells["colStatus"].Style.ForeColor = fg;
                    valDateOut.Text = updated.DeliveredAt?.ToString("yyyy/MM/dd hh:mm tt") ?? "لم يتم التسليم";

                    int masterIdx = _devices.FindIndex(x => x.ReceiptNumber == receipt);
                    if (masterIdx >= 0) _devices[masterIdx] = updated;

                    int filterIdx = _filteredDevices.FindIndex(x => x.ReceiptNumber == receipt);
                    if (filterIdx >= 0) _filteredDevices[filterIdx] = updated;
                }
                RefreshSidebarCounts();
            };

            btnWA.Click += (s, e) =>
            {
                if (dgvOrders.SelectedRows.Count == 0 || _isLoadingData) return;
                int idx     = dgvOrders.SelectedRows[0].Index;
                string receipt = dgvOrders.Rows[idx].Cells[0].Value?.ToString() ?? "";
                var d = _filteredDevices.FirstOrDefault(x => x.ReceiptNumber == receipt);
                if (d == null) return;
                string url = _waService.GenerateWhatsAppUrl(d);
                if (!string.IsNullOrEmpty(url))
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = url, UseShellExecute = true });
            };

            btnPr.Click += (s, e) =>
            {
                if (dgvOrders.SelectedRows.Count == 0 || _isLoadingData) return;
                int idx     = dgvOrders.SelectedRows[0].Index;
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
                lblLogo.Location     = new Point(right - 32 - lblLogo.Width - 6, lblLogo.Location.Y);
            };
        }

        private void btnEdit_Click(object? sender, EventArgs e) => ToggleEditMode();

        // ── Dashboard Integration ─────────────────────────────────────────────
        /// <summary>
        /// Shows the Dashboard panel (Form1 logic) inside the main content area.
        /// Called when the user clicks "Dashboard" in the sidebar.
        /// </summary>
        private void ShowDashboardView()
        {
            var dashForm = new Form1(_dashboardService);
            var dashPanel = dashForm.BuildDashboardPanel(onGoHome: () => SwitchView(pnlOrdersView));
            SwitchView(dashPanel);
        }

        /// <summary>
        /// Swaps the visible content panel in the main area.
        /// </summary>
        private void SwitchView(Control newView)
        {
            if (_currentView != null)
            {
                pnlMainContent.Controls.Remove(_currentView);
                if (_currentView != pnlOrdersView)
                    _currentView.Dispose();
            }
            newView.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(newView);
            _currentView = newView;
        }

        // ── Parts ─────────────────────────────────────────────────────────────
        private void CmbPartSearch_SelectedIndexChanged(object? s, EventArgs e)
        {
            string selected = cmbPartSearch.Text.Trim();
            var found = _dbInventory.FirstOrDefault(i => i.Name == selected);
            if (found != null)
            {
                _selectedPartUnitPrice = found.SellingPrice;
                numPartPrice.Value     = _selectedPartUnitPrice * numPartQty.Value;
            }
        }

        private void BtnAddPart_Click(object? s, EventArgs e)
        {
            string name  = cmbPartSearch.Text.Trim();
            int    qty   = (int)numPartQty.Value;
            decimal price = numPartPrice.Value;

            if (string.IsNullOrEmpty(name))
            {
                cmbPartSearch.BackColor = Color.FromArgb(255, 235, 235);
                cmbPartSearch.Focus();
                return;
            }
            cmbPartSearch.BackColor = Color.White;

            decimal unitPrice = (qty > 0) ? price / qty : price;
            _deviceService.AddSparePart(valReceipt.Text, name, qty, unitPrice);

            cmbPartSearch.Text  = "";
            numPartQty.Value    = 1;
            numPartPrice.Value  = 0;

            if (dgvOrders.SelectedRows.Count > 0)
                ShowDetail(dgvOrders.SelectedRows[0].Index);

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
                decimal.TryParse(row.Cells[2].Value?.ToString(), out decimal qty);
                decimal.TryParse(row.Cells[3].Value?.ToString(), out decimal price);
                subtotal += qty * price;
            }

            if (subtotal > 0)
            {
                lblPartsSubtotal.Text    = $"إجمالي تكلفة القطع (داخلي): {subtotal:0} ج";
                lblPartsSubtotal.Visible = true;
            }
            else
            {
                lblPartsSubtotal.Visible = false;
            }
        }

        private void ResizeParts()
        {
            int headerH  = dgvParts.ColumnHeadersHeight;
            int rowH     = dgvParts.RowTemplate.Height;
            int rowCount = dgvParts.Rows.Count;
            int gridH    = headerH + (rowCount * rowH);
            dgvParts.Size    = new Size(dgvParts.Width, gridH);
            pnlParts.Size    = new Size(pnlParts.Width, gridH + pnlPartsFooter.Height + 2);
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
                nextY   += ctrl.Height + 10;
            }
        }

        // ── Called by ReciptForm after saving a new device ────────────────────
        public void AddNewDevice(Device device)
        {
            LoadData(_currentStatusFilter);
            RefreshSidebarCounts();
            if (dgvOrders.Rows.Count > 0)
                dgvOrders.Rows[0].Selected = true;
        }

        // ── Backup & Restore ──────────────────────────────────────────────────
        private void DoBackup()
        {
            using var save = new SaveFileDialog { Filter = "Backup File (*.json)|*.json", Title = "حفظ نسخة احتياطية" };
            if (save.ShowDialog() == DialogResult.OK)
            {
                try   { _backupService.Backup(save.FileName, _devices); MessageBox.Show("تم الحفظ بنجاح", "نجاح"); }
                catch (Exception ex) { MessageBox.Show("خطأ:\n" + ex.Message, "خطأ"); }
            }
        }

        private void DoRestore()
        {
            using var open = new OpenFileDialog { Filter = "Backup File (*.json)|*.json", Title = "استرجاع نسخة احتياطية" };
            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var restored = _backupService.Restore(open.FileName);
                    if (restored != null)
                    {
                        foreach (var d in restored) _deviceService.UpdateDeviceDetails(d);
                        LoadData();
                        MessageBox.Show("تم الاسترجاع بنجاح", "نجاح");
                    }
                }
                catch (Exception ex) { MessageBox.Show("خطأ:\n" + ex.Message, "خطأ"); }
            }
        }

        // ── Receipts Folder ───────────────────────────────────────────────────
        private void OpenReceiptsFolder()
        {
            try
            {
                if (!Directory.Exists(_receiptSavePath)) Directory.CreateDirectory(_receiptSavePath);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    { FileName = _receiptSavePath, UseShellExecute = true });
            }
            catch (Exception ex) { MessageBox.Show("تعذر فتح المجلد:\n" + ex.Message, "خطأ"); }
        }

        private void ChangeReceiptsFolder()
        {
            using var dlg = new FolderBrowserDialog { SelectedPath = _receiptSavePath };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _receiptSavePath = dlg.SelectedPath;
                if (_lblSavePath != null) _lblSavePath.Text = _receiptSavePath;
            }
        }

        // ── Edit Mode ─────────────────────────────────────────────────────────
        private void ToggleEditMode()
        {
            _isEditing = !_isEditing;
            btnEditReceipt.Text      = _isEditing ? "حفظ التغييرات" : "تعديل البيانات";
            btnEditReceipt.BackColor = _isEditing ? Color.FromArgb(39, 201, 63) : Color.FromArgb(44, 62, 107);
            btnEditReceipt.ForeColor = Color.White;

            ToggleControlPair(valClient,      _txtClient!);
            ToggleControlPair(valPhone,       _txtPhone!);
            ToggleControlPair(valDevice,      _txtDevice!);
            ToggleControlPair(valModel,       _txtModel!);
            ToggleControlPair(valFault,       _txtFault!);
            ToggleControlPair(valAccessories, _txtAcc!);

            if (!_isEditing && _editingIndex >= 0)
            {
                SaveCurrentEdits();
                MessageBox.Show("تم حفظ التعديلات بنجاح.", "تعديل");
            }
        }

        private void ToggleControlPair(Label lbl, TextBox txt)
        {
            lbl.Visible = !_isEditing;
            txt.Visible =  _isEditing;
            if (_isEditing) txt.Text = lbl.Text == "—" ? "" : lbl.Text;
        }

        private void SaveCurrentEdits()
        {
            if (_editingIndex < 0 || _editingIndex >= _devices.Count) return;
            var d = _devices[_editingIndex];

            if (d.Customer != null)
            {
                d.Customer.Name  = _txtClient!.Text;
                d.Customer.Phone = _txtPhone!.Text;
            }
            d.DeviceName  = _txtDevice!.Text;
            d.Model       = _txtModel!.Text;
            d.Fault       = _txtFault!.Text;
            d.Accessories = _txtAcc!.Text;

            _deviceService.UpdateDeviceDetails(d);
            ShowDetail(_editingIndex);
            LoadData();
        }

        // ── Helpers ───────────────────────────────────────────────────────────
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
            var rng  = new Random(seed);
            int cs = 5, m = 4;
            int cols = (p.Width  - m * 2) / cs;
            int rows = (p.Height - m * 2) / cs;
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                {
                    bool corner = (r < 4 && c < 4) || (r < 4 && c >= cols - 4) || (r >= rows - 4 && c < 4);
                    if (corner || rng.Next(4) == 0)
                        e.Graphics.FillRectangle(brush, m + c*cs, m + r*cs, cs-1, cs-1);
                }
        }

        private static (Color bg, Color fg) StatusColors(string s) => s switch
        {
            "وارد جديد"    => (BgNew,       FgNew),
            "قيد الفحص"    => (BgInspect,   FgInspect),
            "تحت الإصلاح" => (BgRepair,    FgRepair),
            "جاهز"         => (BgReady,     FgReady),
            "تم التسليم"   => (BgDelivered, FgDelivered),
            _              => (Color.White, Color.Black)
        };

        private string MapStatusToArabic(RepairStatus s) => s switch
        {
            RepairStatus.NewArrival       => "وارد جديد",
            RepairStatus.UnderInspection  => "قيد الفحص",
            RepairStatus.UnderRepair      => "تحت الإصلاح",
            RepairStatus.Ready            => "جاهز",
            RepairStatus.Delivered        => "تم التسليم",
            _                             => "وارد جديد"
        };

        private void RefreshSidebarCounts()
        {
            var counts = _deviceService.GetStatusCounts();
            foreach (Control c in flpFilters.Controls)
            {
                if (c is Panel p)
                {
                    var lblCount = p.Controls.OfType<Label>().FirstOrDefault(l => l.Location.X == 4);
                    var btn      = p.Controls.OfType<IconButton>().FirstOrDefault();
                    if (lblCount != null && btn != null)
                        lblCount.Text = counts.GetValueOrDefault(btn.Text, "0");
                }
            }
        }

        private void LoadPartsCombo()
        {
            cmbPartSearch.Items.Clear();
            _dbInventory = _partService.GetInventory();
            foreach (var item in _dbInventory)
                cmbPartSearch.Items.Add(item.Name);
        }

        // Set the logged-in username to display in the sidebar button
        public void SetLoggedInUser(string username)
        {
            if (_btnLogin != null)
            {
                _btnLogin.Text = $"  {username}";
            }
        }
    }
}
