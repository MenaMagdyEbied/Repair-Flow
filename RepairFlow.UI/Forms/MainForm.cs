// ═══════════════════════════════════════════════════════════════
//  RepairFlow — نظام إدارة الصيانة  |  MainForm.cs
//  منطق الواجهة الكامل — إصدار نهائي
// ═══════════════════════════════════════════════════════════════

namespace RepairFlow.UI.Forms
{
    public partial class MainForm : Form
    {
        // ── status colors ──────────────────────────────────────────────────
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

        // ── active sidebar filter state ────────────────────────────────────
        private Panel?  _activeFilterPanel;
        private Button? _activeFilterBtn;

        // ══════════════════════════════════════════════════════════════════
        //  SPARE PARTS INVENTORY — اسم القطعة | سعر الشراء | نسبة الربح %
        //  سعر البيع = سعر الشراء × (1 + نسبة/100)
        // ══════════════════════════════════════════════════════════════════
        private static readonly (string Name, decimal BuyPrice, int ProfitPct)[] _inventory =
        {
            // ── Samsung ───────────────────────────────────────────────────
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

            // ── iPhone ────────────────────────────────────────────────────
            ("iPhone 15 Pro شاشة",       500,  20),
            ("iPhone 15 شاشة",           420,  20),
            ("iPhone 14 Pro شاشة",       400,  20),
            ("iPhone 14 شاشة",           350,  20),
            ("iPhone 13 شاشة",           300,  20),
            ("iPhone 12 شاشة",           250,  20),
            ("iPhone 11 شاشة",           200,  20),
            ("iPhone 15 Pro بطارية",      90,  25),
            ("iPhone 14 بطارية",           80,  25),
            ("iPhone 13 بطارية",           70,  25),
            ("iPhone شاحن أصلي",          60,  25),

            // ── Huawei ────────────────────────────────────────────────────
            ("Huawei P60 شاشة",          220,  25),
            ("Huawei P50 شاشة",          190,  25),
            ("Huawei Nova 11 شاشة",      150,  25),
            ("Huawei Nova 10 شاشة",      130,  25),
            ("Huawei P60 بطارية",          65,  30),
            ("Huawei شاحن أصلي",          45,  30),

            // ── Oppo ──────────────────────────────────────────────────────
            ("Oppo Find X6 شاشة",        200,  25),
            ("Oppo Reno 10 شاشة",        140,  25),
            ("Oppo A98 شاشة",            110,  25),
            ("Oppo A78 شاشة",             90,  25),
            ("Oppo Reno 10 بطارية",        55,  30),
            ("Oppo شاحن سريع",             40,  30),

            // ── Realme ────────────────────────────────────────────────────
            ("Realme GT5 شاشة",          180,  25),
            ("Realme 11 Pro شاشة",       130,  25),
            ("Realme C55 شاشة",           80,  25),
            ("Realme بطارية",              50,  30),

            // ── Infinix ───────────────────────────────────────────────────
            ("Infinix Note 30 شاشة",     100,  30),
            ("Infinix Hot 30 شاشة",       70,  30),
            ("Infinix Smart 7 شاشة",      55,  30),
            ("Infinix بطارية",             40,  30),

            // ── Sony ──────────────────────────────────────────────────────
            ("Sony Xperia 1 V شاشة",     380,  20),
            ("Sony Xperia 5 V شاشة",     300,  20),
            ("Sony Xperia 10 V شاشة",    180,  20),
            ("Sony بطارية",                75,  25),

            // ── قطع عامة ──────────────────────────────────────────────────
            ("بطارية عامة",                45,  35),
            ("شاشة جرافيك عامة",          60,  30),
            ("ميكروفون",                   25,  40),
            ("سماعة خارجية",               30,  40),
            ("مدخل شاحن",                  35,  35),
            ("زجاج شاشة",                  20,  50),
            ("كاميرا خلفية",               80,  30),
            ("كاميرا أمامية",              50,  30),
            ("لوحة مفاتيح",                30,  35),
            ("شاحن لاسلكي",                55,  30),
        };

        // سعر البيع = سعر الشراء + نسبة الربح
        private static decimal SellPrice((string Name, decimal BuyPrice, int ProfitPct) item)
            => Math.Round(item.BuyPrice * (1 + item.ProfitPct / 100m), 0);

        // ── sample data ────────────────────────────────────────────────────
        // Each row: Receipt, Client, Device, Model, Phone, DateIn, Status,
        //           Fault, Accessories, Cost, DateOut, WarrantyMonths
        private readonly string[,] _rows =
        {
            // R                   Client              Device    Model          Phone          DateIn                S               Fault               Acc                           Cost  DateOut               Warranty
            { "SR-2603-004",  "محمد السيد",    "LG",     "180",         "01500950666", "2026/03/05 01:54 ص", "وارد جديد",   "proken screen",    "ريموت ، كابل ، حامل",       "",    "",                    "0" },
            { "SR-2603-003",  "أحمد محمد",     "Samsung","Smart 170",   "01500950666", "2026/03/05 01:54 ص", "وارد جديد",   "proken screen",    "ريموت ، كابل ، حامل",       "",    "",                    "0" },
            { "SR-20260212-4","أمير أحمد",     "سس",     "سسسس",        "01500950666", "2026/02/12",         "وارد جديد",   "",                 "",                           "",    "",                    "0" },
            { "SR-2603-003",  "أحمد محمد",     "Samsung","Smart 170",   "01500950666", "2026/03/05 01:54 ص", "قيد الفحص",  "proken screen",    "ريموت ، كابل ، حامل",       "",    "",                    "0" },
            { "SR-2602-002",  "mhmd",           "220",    "220",         "01211879320", "2026/02/14",         "قيد الفحص",  "",                 "",                           "",    "",                    "0" },
            { "SR-2602-006",  "مممم",           "مم",     "مممممممع",    "01211879522", "2026/02/27 04:08 ص", "جاهز",        "مممم",             "نننننننننننننننننننن",       "14",  "2026/03/03 02:22 ص",  "6" },
            { "SR-2602-001",  "fffkf",          "f",      "f",           "01211879320", "2026/02/10",         "جاهز",        "",                 "",                           "",    "",                    "0" },
            { "SR-2603-002",  "إبراهيم محمد",  "LG",     "Smart 170",   "01111047409", "2026/03/05 01:33 ص", "تم التسليم", "",                 "",                           "600", "2026/03/05 01:34 ص",  "3" },
            { "SR-2603-001",  "mhhhh",          "lg",     "180",         "01500950666", "2026/03/05",         "تم التسليم", "",                 "",                           "",    "",                    "0" },
            { "SR-2602-005",  "السيد محمد",    "LG",     "LG12",        "01500950666", "2026/02/20",         "تم التسليم", "",                 "",                           "600", "2026/03/05",           "3" },
            { "SR-2602-004",  "مريم",           "1200",   "21",          "01211985463", "2026/02/16",         "تم التسليم", "",                 "",                           "",    "",                    "0" },
            { "SR-2602-003",  "mhmg",           "220",    "220",         "01211879320", "2026/02/15",         "تم التسليم", "",                 "",                           "",    "",                    "0" },
            { "SR-20260212-2","mhmd",            "LG",     "270",         "01500950666", "2026/02/12",         "تم التسليم", "",                 "",                           "",    "",                    "0" },
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
            LoadPartsCombo();
            ShowDetail(0);
            WireEvents();
        }

        // ══════════════════════════════════════════════════════════════════
        //  SIDEBAR
        // ══════════════════════════════════════════════════════════════════
        private void BuildSidebar()
        {
            Color navy   = Color.FromArgb(44, 62, 107);
            Color sideBg = Color.FromArgb(248, 248, 248);

            // ── section: الحالات ──────────────────────────────────────────
            AddSidebarLabel("الحالات", 8.5f, Color.FromArgb(150, 150, 150),
                            new Padding(0, 10, 0, 6), 192, 20);

            AddFilter("≡",  "الكل",        navy,        CountStatus(""), true);
            AddFilter("📥", "وارد جديد",   FgNew,       CountStatus("وارد جديد"),   false);
            AddFilter("🔍", "قيد الفحص",   FgInspect,   CountStatus("قيد الفحص"),   false);
            AddFilter("🔧", "تحت الإصلاح", FgRepair,    CountStatus("تحت الإصلاح"), false);
            AddFilter("✓",  "جاهز",        FgReady,     CountStatus("جاهز"),         false);
            AddFilter("🚚", "تم التسليم",  FgDelivered, CountStatus("تم التسليم"),   false);

            AddSeparator(16, 10);

            // ── section: المخزون ──────────────────────────────────────────
            int warrantyCount = 1; // placeholder — يتم ربطه بقاعدة البيانات لاحقاً
            AddSidebarLabel($"المخزون (منخفض: 1 | نافد: 1)", 7.5f,
                            Color.FromArgb(150, 150, 150), new Padding(4, 0, 4, 2), 184, 18);
            AddSidebarLabel("الموجود: 3", 8f,
                            Color.FromArgb(51, 51, 51), new Padding(4, 0, 4, 4), 184, 18);

            // ── زر فتح صفحة المخزون ──────────────────────────────────────
            var btnInventory = MakeSidebarBtn("📦  فتح المخزون", Color.FromArgb(44, 62, 107), Color.White);
            btnInventory.Margin = new Padding(4, 0, 4, 4);
            btnInventory.Click += (s, e) =>
                MessageBox.Show("سيتم فتح صفحة إدارة المخزون.", "المخزون",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            flpFilters.Controls.Add(btnInventory);

            // ── زر Dashboard ──────────────────────────────────────────────
            var btnDash = MakeSidebarBtn("📊  Dashboard", Color.FromArgb(52, 73, 94), Color.White);
            btnDash.Margin = new Padding(4, 0, 4, 6);
            btnDash.Click += (s, e) =>
                MessageBox.Show("سيتم فتح لوحة التحكم الرئيسية.", "Dashboard",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            flpFilters.Controls.Add(btnDash);

            AddSeparator(10, 10);

            // ── section: النسخ الاحتياطي ──────────────────────────────────
            AddSidebarLabel("النسخ الاحتياطي", 7.5f,
                            Color.FromArgb(150, 150, 150), new Padding(4, 0, 4, 4), 184, 18);

            var btnBackup = MakeSidebarBtn("💾  Backup", Color.FromArgb(44, 62, 107), Color.White);
            flpFilters.Controls.Add(btnBackup);

            var btnRestore = MakeSidebarBtn("🔄  Restore", Color.FromArgb(52, 152, 219), Color.White);
            flpFilters.Controls.Add(btnRestore);

            AddSeparator(10, 8);

            // ── section: مكان حفظ الإيصالات ──────────────────────────────
            AddSidebarLabel("مكان حفظ الإيصالات", 7.5f,
                            Color.FromArgb(150, 150, 150), new Padding(4, 4, 4, 2), 184, 18);
            AddSidebarLabel("C:", 7.5f,
                            Color.FromArgb(80, 80, 80), new Padding(4, 0, 4, 4), 184, 18);

            var btnOpen = MakeSidebarBtn("📁  فتح المجلد", Color.White,
                                         Color.FromArgb(44, 62, 107), bordered: true);
            flpFilters.Controls.Add(btnOpen);

            var btnChange = MakeSidebarBtn("📍  تغيير المكان", Color.FromArgb(44, 62, 107), Color.White);
            flpFilters.Controls.Add(btnChange);
        }

        private string CountStatus(string s) =>
            s == "" ? _rows.GetLength(0).ToString() :
            Enumerable.Range(0, _rows.GetLength(0))
                      .Count(i => _rows[i, C_Status] == s).ToString();

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
                Size      = new Size(184, 1),
                Margin    = new Padding(4, topMargin, 4, bottomMargin),
                BackColor = Color.FromArgb(218, 218, 218)
            });
        }

        private Button MakeSidebarBtn(string text, Color bg, Color fg, bool bordered = false)
        {
            var b = new Button
            {
                Text      = text,
                Size      = new Size(184, 30),
                Margin    = new Padding(4, 0, 4, 5),
                BackColor = bg,
                ForeColor = fg,
                FlatStyle = FlatStyle.Flat,
                Font      = new Font("Segoe UI", 8.5f),
                Cursor    = Cursors.Hand
            };
            b.FlatAppearance.BorderSize = bordered ? 1 : 0;
            if (bordered) b.FlatAppearance.BorderColor = Color.FromArgb(44, 62, 107);
            b.UseVisualStyleBackColor = false;
            return b;
        }

        private void AddFilter(string icon, string label, Color badgeColor,
                               string count, bool active)
        {
            Color navy     = Color.FromArgb(44, 62, 107);
            Color sideBg   = Color.FromArgb(248, 248, 248);
            Color activeBg = Color.FromArgb(229, 236, 250);

            var pnl = new Panel
            {
                Size      = new Size(192, 38),
                Margin    = new Padding(0, 0, 0, 3),
                BackColor = active ? activeBg : sideBg,
                Cursor    = Cursors.Hand
            };

            // Badge — على اليسار الفعلي (x=4) = أقصى اليسار بصرياً في RTL
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

            // النص — من x=38 لآخر الـ panel = أقصى اليمين بصرياً
            var btn = new Button
            {
                Text      = label,
                Location  = new Point(38, 0),
                Size      = new Size(154, 38),
                TextAlign = ContentAlignment.MiddleRight,
                Padding   = new Padding(0, 0, 8, 0),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = active ? navy : Color.FromArgb(60, 60, 60),
                Font      = new Font("Segoe UI", 9.5f,
                                active ? FontStyle.Bold : FontStyle.Regular),
                Cursor    = Cursors.Hand,
                TabStop   = false
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
            Color navy    = Color.FromArgb(44, 62, 107);
            Color sideBg  = Color.FromArgb(248, 248, 248);
            Color activeBg= Color.FromArgb(229, 236, 250);

            // reset previous
            if (_activeFilterPanel != null)
            {
                _activeFilterPanel.BackColor = sideBg;
                if (_activeFilterBtn != null)
                {
                    _activeFilterBtn.ForeColor = Color.FromArgb(60, 60, 60);
                    _activeFilterBtn.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
                }
            }

            // activate new
            pnl.BackColor = activeBg;
            btn.ForeColor = navy;
            btn.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            _activeFilterPanel = pnl;
            _activeFilterBtn   = btn;

            // filter rows
            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                string s = row.Cells["colStatus"].Value?.ToString() ?? "";
                row.Visible = (filter == "الكل") || (s == filter);
            }
        }

        // ══════════════════════════════════════════════════════════════════
        //  DATA
        // ══════════════════════════════════════════════════════════════════
        private void LoadData()
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

        // ══════════════════════════════════════════════════════════════════
        //  DETAIL PANEL
        // ══════════════════════════════════════════════════════════════════
        private void ShowDetail(int dataIndex)
        {
            if (dataIndex < 0 || dataIndex >= _rows.GetLength(0)) return;

            string receipt  = _rows[dataIndex, C_Receipt];
            string client   = _rows[dataIndex, C_Client];
            string phone    = _rows[dataIndex, C_Phone];
            string device   = _rows[dataIndex, C_Device];
            string model    = _rows[dataIndex, C_Model];
            string fault    = _rows[dataIndex, C_Fault];
            string acc      = _rows[dataIndex, C_Acc];
            string dateIn   = _rows[dataIndex, C_DateIn];
            string dateOut  = _rows[dataIndex, C_DateOut];
            string cost     = _rows[dataIndex, C_Cost];
            string status   = _rows[dataIndex, C_Status];
            string warranty = _rows[dataIndex, C_Warranty];

            valReceipt.Text     = receipt;
            valClient.Text      = client;
            valPhone.Text       = phone;
            valDevice.Text      = device;
            valModel.Text       = model;
            valFault.Text       = string.IsNullOrEmpty(fault)   ? "—" : fault;
            valAccessories.Text = string.IsNullOrEmpty(acc)     ? "—" : acc;
            valDateIn.Text      = string.IsNullOrEmpty(dateIn)  ? "—" : dateIn;
            valDateOut.Text     = string.IsNullOrEmpty(dateOut) ? "لم يتم التسليم" : dateOut;
            valCost.Text        = string.IsNullOrEmpty(cost)    ? "—" : $"{cost} ج";

            // warranty — show only when non-zero
            int wMonths = int.TryParse(warranty, out int w) ? w : 0;
            pnlWarranty.Visible = wMonths > 0;
            if (wMonths > 0)
                valWarranty.Text = $"{wMonths} شهور";

            // status combo
            int si = cmbStatus.Items.IndexOf(status);
            if (si >= 0) cmbStatus.SelectedIndex = si;
            var (cbBg, cbFg) = StatusColors(status);
            cmbStatus.BackColor = cbBg;
            cmbStatus.ForeColor = cbFg;

            pnlQR.Invalidate();
        }

        // ══════════════════════════════════════════════════════════════════
        //  EVENT WIRING
        // ══════════════════════════════════════════════════════════════════
        private void WireEvents()
        {
            // ── title bar — macOS dots ──────────────────────────────────
            pnlTitleBar.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Fill(e.Graphics, Color.FromArgb(255, 95, 87),  8, 9, 12);
                Fill(e.Graphics, Color.FromArgb(255, 189, 46), 26, 9, 12);
                Fill(e.Graphics, Color.FromArgb(39, 201, 63),  44, 9, 12);
            };

            // ── toolbar bottom line ─────────────────────────────────────
            pnlToolbar.Paint += (s, e) =>
            {
                using var p = new Pen(Color.FromArgb(215, 215, 215));
                e.Graphics.DrawLine(p, 0, pnlToolbar.Height - 1,
                                       pnlToolbar.Width, pnlToolbar.Height - 1);
            };

            // ── search box border ───────────────────────────────────────
            pnlSearch.Paint += (s, e) =>
            {
                using var p = new Pen(Color.FromArgb(200, 200, 200));
                e.Graphics.DrawRectangle(p, 0, 0,
                    pnlSearch.Width - 1, pnlSearch.Height - 1);
            };

            // ── sidebar right border ────────────────────────────────────
            pnlSidebar.Paint += (s, e) =>
            {
                using var p = new Pen(Color.FromArgb(218, 218, 218));
                e.Graphics.DrawLine(p, pnlSidebar.Width - 1, 0,
                                       pnlSidebar.Width - 1, pnlSidebar.Height);
            };

            // ── detail left border + header bottom line ─────────────────
            pnlDetail.Paint += (s, e) =>
            {
                using var p = new Pen(Color.FromArgb(218, 218, 218));
                e.Graphics.DrawLine(p, 0, 0, 0, pnlDetail.Height);
            };
            pnlDtlHeader.Paint += (s, e) =>
            {
                using var p = new Pen(Color.FromArgb(218, 218, 218));
                e.Graphics.DrawLine(p, 0, pnlDtlHeader.Height - 1,
                                       pnlDtlHeader.Width, pnlDtlHeader.Height - 1);
            };

            // ── box borders ─────────────────────────────────────────────
            boxIn.Paint  += PanelBorder;
            boxOut.Paint += PanelBorder;
            pnlCost.Paint      += PanelBorder;
            pnlWarranty.Paint  += PanelBorder;
            pnlSt.Paint        += PanelBorder;
            pnlParts.Paint     += PanelBorder;

            // ── QR ──────────────────────────────────────────────────────
            pnlQR.Paint += QrPaint;

            // ── grid selection ──────────────────────────────────────────
            dgvOrders.SelectionChanged += (s, e) =>
            {
                if (dgvOrders.SelectedRows.Count > 0)
                    ShowDetail(dgvOrders.SelectedRows[0].Index);
            };

            // ── search ──────────────────────────────────────────────────
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

            // ── buttons ─────────────────────────────────────────────────
            btnNew.Click += (s, e) =>
                MessageBox.Show("سيتم فتح نموذج استلام جهاز جديد.", "استلام جهاز",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnWA.Click += (s, e) =>
                MessageBox.Show("سيتم إرسال رسالة واتساب للعميل.", "إرسال واتساب",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnPr.Click += (s, e) =>
                MessageBox.Show("سيتم طباعة الإيصال.", "طباعة إيصال",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnEditField.Click += (s, e) =>
                MessageBox.Show("سيتم فتح نموذج تعديل بيانات الجهاز.", "تعديل",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnEditAcc.Click += (s, e) =>
                MessageBox.Show("سيتم فتح نموذج تعديل المرفقات.", "تعديل المرفقات",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            // ── btnEditReceipt — تعديل الإيصال قبل الطباعة ──────────────
            btnEditReceipt.Click += (s, e) =>
                MessageBox.Show("سيتم فتح نموذج تعديل بيانات الإيصال كاملاً.", "تعديل الإيصال",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            // ── btnAccEdit (next to accessories field) ───────────────────
            btnAccEdit.Click += (s, e) =>
                MessageBox.Show("سيتم فتح نموذج تعديل المرفقات.", "تعديل المرفقات",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            // ── spare parts combo — auto-fill price on selection ──────────
            cmbPartSearch.SelectedIndexChanged += CmbPartSearch_SelectedIndexChanged;
            cmbPartSearch.TextChanged += (s, e) =>
            {
                // لو المستخدم بيكتب يدوياً — صفر السعر لحد ما يختار
                string typed = cmbPartSearch.Text.Trim();
                var found = _inventory.FirstOrDefault(i => i.Name == typed);
                if (found != default)
                    numPartPrice.Value = SellPrice(found);
            };

            // ── spare parts: add button ───────────────────────────────────
            btnAddPart.Click += BtnAddPart_Click;

            // ── spare parts: delete button in grid ───────────────────────
            dgvParts.CellClick += DgvParts_CellClick;

            // ── spare parts: cell edit recalculates ──────────────────────
            dgvParts.CellEndEdit += (s, e) => RecalcParts();

            // ── status combo ─────────────────────────────────────────────
            cmbStatus.SelectedIndexChanged += (s, e) =>
            {
                string sel = cmbStatus.SelectedItem?.ToString() ?? "";
                var (bg, fg) = StatusColors(sel);
                cmbStatus.BackColor = bg;
                cmbStatus.ForeColor = fg;
            };

            // ── form resize — reposition logo ────────────────────────────
            Resize += (s, e) =>
            {
                int right = pnlToolbar.Width - 8;
                lblLogoIcon.Location = new Point(right - 32, lblLogoIcon.Location.Y);
                lblLogo.Location     = new Point(right - 32 - lblLogo.Width - 6, lblLogo.Location.Y);
            };
        }

        // ── drawing helpers ───────────────────────────────────────────────
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

        private static void QrPaint(object? s, PaintEventArgs e)
        {
            if (s is not Panel p) return;
            using var border = new Pen(Color.FromArgb(218, 218, 218));
            e.Graphics.DrawRectangle(border, 0, 0, p.Width - 1, p.Height - 1);

            using var brush = new SolidBrush(Color.FromArgb(44, 62, 107));
            var rng = new Random(42);
            int cs = 5, m = 4;
            int cols = (p.Width  - m * 2) / cs;
            int rows = (p.Height - m * 2) / cs;
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                {
                    bool corner =
                        (r < 4 && c < 4) ||
                        (r < 4 && c >= cols - 4) ||
                        (r >= rows - 4 && c < 4);
                    if (corner || rng.Next(4) == 0)
                        e.Graphics.FillRectangle(brush, m + c*cs, m + r*cs, cs-1, cs-1);
                }
        }

        // ── status colors ─────────────────────────────────────────────────
        private static (Color bg, Color fg) StatusColors(string s) => s switch
        {
            "وارد جديد"   => (BgNew,       FgNew),
            "قيد الفحص"   => (BgInspect,   FgInspect),
            "تحت الإصلاح" => (BgRepair,    FgRepair),
            "جاهز"        => (BgReady,     FgReady),
            "تم التسليم"  => (BgDelivered, FgDelivered),
            _             => (Color.White,  Color.Black)
        };

        // ══════════════════════════════════════════════════════════════════
        //  قطع الغيار — SPARE PARTS LOGIC
        // ══════════════════════════════════════════════════════════════════
        //  SPARE PARTS — قطع الغيار
        // ══════════════════════════════════════════════════════════════════

        /// <summary>تحميل قائمة قطع الغيار في الـ ComboBox</summary>
        private void LoadPartsCombo()
        {
            cmbPartSearch.Items.Clear();
            foreach (var item in _inventory)
                cmbPartSearch.Items.Add(item.Name);
        }

        /// <summary>لما المستخدم يختار قطعة — يظهر سعر البيع تلقائياً</summary>
        private void CmbPartSearch_SelectedIndexChanged(object? s, EventArgs e)
        {
            string selected = cmbPartSearch.Text.Trim();
            var found = _inventory.FirstOrDefault(i => i.Name == selected);
            if (found != default)
                numPartPrice.Value = SellPrice(found);
        }

        /// <summary>إضافة قطعة للإيصال</summary>
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

            dgvParts.Rows.Add(name, qty, price.ToString("0"));

            cmbPartSearch.Text     = "";
            numPartQty.Value       = 1;
            numPartPrice.Value     = 0;
            cmbPartSearch.Focus();

            ResizeParts();
            RecalcParts();
        }

        /// <summary>
        /// حذف صف عند الضغط على زر ✕
        /// </summary>
        private void DgvParts_CellClick(object? s, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != dgvParts.Columns["colPartDel"]!.Index) return;
            if (e.RowIndex < 0) return;

            dgvParts.Rows.RemoveAt(e.RowIndex);
            ResizeParts();
            RecalcParts();
        }

        /// <summary>
        /// إعادة حساب المجموع الداخلي لتكلفة القطع
        /// </summary>
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
                lblPartsSubtotal.Text    = $"إجمالي تكلفة القطع (داخلي): {subtotal:0} ج";
                lblPartsSubtotal.Visible = true;
            }
            else
            {
                lblPartsSubtotal.Text    = "";
                lblPartsSubtotal.Visible = false;
            }

            // NOTE: لا نلمس valCost تلقائياً — المالك يحدد السعر النهائي للعميل يدوياً
        }

        /// <summary>
        /// تعديل ارتفاع dgvParts و pnlParts ليتسع لعدد الصفوف الحالي
        /// </summary>
        private void ResizeParts()
        {
            int headerH  = dgvParts.ColumnHeadersHeight;
            int rowH     = dgvParts.RowTemplate.Height;
            int rowCount = dgvParts.Rows.Count;

            // grid height = header + rows (min: header only = 26)
            int gridH    = headerH + (rowCount * rowH);
            dgvParts.Size = new Size(dgvParts.Width, gridH);

            // footer height: name row(22) + gap(4) + subtotal(16) + gap(2) + btn(22) + padding(10) = 76
            // subtotal label only takes space when visible — footer height stays fixed
            int footerH = pnlPartsFooter.Height;

            // outer panel height = grid + footer + 2px border
            pnlParts.Size = new Size(pnlParts.Width, gridH + footerH + 2);

            // Reposition every control below pnlParts in pnlDetailScroll
            ShiftControlsBelow(pnlParts);
        }

        /// <summary>
        /// يحرّك كل عنصر في pnlDetailScroll أسفل targetCtrl لأعلى/أسفل عند تغيير حجمه
        /// </summary>
        private void ShiftControlsBelow(Control targetCtrl)
        {
            // collect all direct children of pnlDetailScroll sorted by Y
            var below = pnlDetailScroll.Controls
                .Cast<Control>()
                .Where(c => c != targetCtrl && c.Top >= targetCtrl.Top + 1)
                .OrderBy(c => c.Top)
                .ToList();

            int nextY = targetCtrl.Bottom + 10;   // same gap used in designer
            foreach (var ctrl in below)
            {
                int oldY = ctrl.Top;
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
        }
    }
}
