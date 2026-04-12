using System;
using System.Drawing;
using System.Windows.Forms;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using RepairFlow.BLL.Services.Interfaces;
using RepairFlow.Models;

namespace RepairFlow.UI.Forms
{
    public partial class Form1 : Form
    {
       
        private readonly IDashboardService _dashboardService;

        private TableLayoutPanel? tblStats;
        private TableLayoutPanel? tblCharts;
        private TableLayoutPanel? tblBottom;

        private CartesianChart? chartRevenue;
        private PieChart?       chartStatus;
        private CartesianChart? chartDevices;

        private DataGridView? dgvReceipts;
        private Panel?        pnlInventory;

        private Label? lblAvgRepairValue;
        private Label? lblAvgRepairTrend;
        private Label? lblRevenueValue;
        private Label? lblRevenueTrend;
        private Label? lblDeliveredValue;
        private Label? lblDeliveredTrend;
        private Label? lblReceiptsValue;
        private Label? lblReceiptsTrend;

     
        public Form1(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;

            InitializeComponent();
            AutoScroll  = true;
            MinimumSize = new Size(1150, 750);
            Text        = "RepairFlow - لوحة التحكم";
            RightToLeft = RightToLeft.Yes;

            InitializeMainLayout();
            SetupStatisticCards();
            SetupCharts();
            SetupBottomSection();
            LoadDashboardData();
        }

   
        public Panel BuildDashboardPanel(Action onGoHome)
        {
           
            tblStats = null; tblCharts = null; tblBottom = null;
            chartRevenue = null; chartStatus = null; chartDevices = null;
            dgvReceipts = null; pnlInventory = null;

           
            var root = new Panel
            {
                Dock      = DockStyle.Fill,
                BackColor = Color.FromArgb(248, 250, 252),
            };

         
            var topBar = new Panel
            {
                Dock      = DockStyle.Top,
                Height    = 48,
                BackColor = Color.FromArgb(44, 62, 107),
                Padding   = new Padding(10, 6, 10, 6),
            };

            var lblTitle = new Label
            {
                Text      = "📊  لوحة التحكم",
                Dock      = DockStyle.Fill,
                ForeColor = Color.White,
                Font      = new Font("Segoe UI", 13f, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleRight,
                RightToLeft = RightToLeft.Yes,
            };

            var btnHome = new Button
            {
                Text      = "🏠  الرئيسية",
                Dock      = DockStyle.Left,
                Width     = 130,
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font      = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                Cursor    = Cursors.Hand,
            };
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.Click += (s, e) => onGoHome();

            topBar.Controls.Add(lblTitle);
            topBar.Controls.Add(btnHome);

           
            var scrollArea = new Panel
            {
                Dock      = DockStyle.Fill,
                AutoScroll = true,
                Padding   = new Padding(12),
                BackColor = Color.FromArgb(248, 250, 252),
            };

            var mainLayout = new TableLayoutPanel
            {
                Dock        = DockStyle.Top,
                AutoSize    = true,
                RowCount    = 3,
                ColumnCount = 1,
            };
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 360F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 420F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            tblStats  = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 4 };
            for (int i = 0; i < 4; i++)
                tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));

            tblCharts = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2 };
            tblCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            tblBottom = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 2 };
            tblBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tblBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tblBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            tblBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));

            mainLayout.Controls.Add(tblStats,  0, 0);
            mainLayout.Controls.Add(tblCharts, 0, 1);
            mainLayout.Controls.Add(tblBottom, 0, 2);

            SetupStatisticCards();
            SetupCharts();
            SetupBottomSection();

            scrollArea.Controls.Add(mainLayout);
            root.Controls.Add(scrollArea);
            root.Controls.Add(topBar);   

           
            LoadDashboardData();

            return root;
        }


        private void InitializeMainLayout()
        {
            var mainContainer = new Panel
            {
                Dock       = DockStyle.Fill,
                AutoScroll = true,
                Padding    = new Padding(15),
                BackColor  = Color.FromArgb(248, 250, 252)
            };

            var mainLayout = new TableLayoutPanel
            {
                Dock        = DockStyle.Top,
                AutoSize    = true,
                RowCount    = 3,
                ColumnCount = 1
            };
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 360F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 420F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            tblStats  = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 4 };
            for (int i = 0; i < 4; i++)
                tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));

            tblCharts = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2 };
            tblCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            tblBottom = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 2 };
            tblBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tblBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tblBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            tblBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));

            mainLayout.Controls.Add(tblStats,  0, 0);
            mainLayout.Controls.Add(tblCharts, 0, 1);
            mainLayout.Controls.Add(tblBottom, 0, 2);

            mainContainer.Controls.Add(mainLayout);
            Controls.Clear();
            Controls.Add(mainContainer);
        }

        private void SetupStatisticCards()
        {
            var card1 = CreateStatCard("متوسط وقت الإصلاح", "...", "...",
                Color.DarkBlue, Color.Gray, out lblAvgRepairValue, out lblAvgRepairTrend);
            var card2 = CreateStatCard("إجمالي الإيرادات", "...", "...",
                Color.DarkBlue, Color.Gray, out lblRevenueValue, out lblRevenueTrend);
            var card3 = CreateStatCard("تم التسليم", "...", "...",
                Color.DarkBlue, Color.Gray, out lblDeliveredValue, out lblDeliveredTrend);
            var card4 = CreateStatCard("إجمالي الإيصالات", "...", "...",
                Color.DarkBlue, Color.Gray, out lblReceiptsValue, out lblReceiptsTrend);

            tblStats!.Controls.Add(card1, 0, 0);
            tblStats.Controls.Add(card2, 1, 0);
            tblStats.Controls.Add(card3, 2, 0);
            tblStats.Controls.Add(card4, 3, 0);
        }

        private Panel CreateStatCard(string title, string value, string trend,
            Color valColor, Color trendColor, out Label lblValue, out Label lblTrend)
        {
            var card = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Margin = new Padding(7) };

            var lblT = new Label
            {
                Text = title, Dock = DockStyle.Top, Height = 24,
                Font = new Font("Segoe UI", 9f), ForeColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleRight
            };
            lblValue = new Label
            {
                Text = value, Dock = DockStyle.Top, Height = 45,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = valColor, TextAlign = ContentAlignment.MiddleRight
            };
            lblTrend = new Label
            {
                Text = trend, Dock = DockStyle.Bottom, Height = 22,
                ForeColor = trendColor, Font = new Font("Segoe UI", 8.5f),
                TextAlign = ContentAlignment.MiddleRight
            };

            card.Controls.Add(lblTrend);
            card.Controls.Add(lblValue);
            card.Controls.Add(lblT);
            return card;
        }

       
        private void SetupCharts()
        {
            var pnlRev = CreateChartPanel("الإيرادات الشهرية (آخر 6 أشهر)");
            chartRevenue = new CartesianChart { Dock = DockStyle.Fill };
            pnlRev.Controls.Add(chartRevenue);
            tblCharts!.Controls.Add(pnlRev, 0, 0);

            var pnlStat = CreateChartPanel("الإيصالات حسب الحالة");
            chartStatus = new PieChart { Dock = DockStyle.Fill };
            pnlStat.Controls.Add(chartStatus);
            tblCharts.Controls.Add(pnlStat, 1, 0);
        }

        private Panel CreateChartPanel(string title)
        {
            var pnl = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Margin = new Padding(8) };
            pnl.Controls.Add(new Label
            {
                Text = title, Dock = DockStyle.Top, Height = 32,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 60),
                TextAlign = ContentAlignment.MiddleRight
            });
            return pnl;
        }


        private void SetupBottomSection()
        {
            SetupReceiptsTable();
            SetupInventoryWidget();
            SetupDevicesChart();
        }

        private void SetupReceiptsTable()
        {
            var pnl = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Margin = new Padding(8) };
            pnl.Controls.Add(new Label
            {
                Text = "آخر الإيصالات", Dock = DockStyle.Top, Height = 32,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 60),
                TextAlign = ContentAlignment.MiddleRight
            });

            dgvReceipts = new DataGridView
            {
                Dock                = DockStyle.Fill,
                BackgroundColor     = Color.White,
                ReadOnly            = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RightToLeft         = RightToLeft.Yes,
                ColumnHeadersHeight = 32,
                RowTemplate         = { Height = 28 },
                BorderStyle         = BorderStyle.None,
                GridColor           = Color.FromArgb(230, 230, 240),
                SelectionMode       = DataGridViewSelectionMode.FullRowSelect
            };
            dgvReceipts.ColumnHeadersDefaultCellStyle.Font        = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvReceipts.DefaultCellStyle.Font                     = new Font("Segoe UI", 9);
            dgvReceipts.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);

            dgvReceipts.Columns.Add("ReceiptNumber", "رقم الإيصال");
            dgvReceipts.Columns.Add("CustomerName",  "اسم العميل");
            dgvReceipts.Columns.Add("CustomerPhone", "الهاتف");
            dgvReceipts.Columns.Add("DeviceName",    "الجهاز");
            dgvReceipts.Columns.Add("Status",        "الحالة");
            dgvReceipts.Columns.Add("ReceivedAt",    "تاريخ الاستلام");
            dgvReceipts.Columns.Add("RepairCost",    "التكلفة");

            pnl.Controls.Add(dgvReceipts);
            tblBottom!.Controls.Add(pnl, 0, 0);
            tblBottom.SetColumnSpan(pnl, 1);
        }

        private void SetupInventoryWidget()
        {
            pnlInventory = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Margin = new Padding(8) };
            pnlInventory.Controls.Add(new Label
            {
                Text = "المخزون", Dock = DockStyle.Top, Height = 32,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 60),
                TextAlign = ContentAlignment.MiddleRight
            });
            tblBottom!.Controls.Add(pnlInventory, 1, 0);
        }

        private void SetupDevicesChart()
        {
            var pnlDev = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Margin = new Padding(8) };
            pnlDev.Controls.Add(new Label
            {
                Text = "أكثر الأجهزة صيانة", Dock = DockStyle.Top, Height = 32,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 60),
                TextAlign = ContentAlignment.MiddleRight
            });
            chartDevices = new CartesianChart { Dock = DockStyle.Fill };
            pnlDev.Controls.Add(chartDevices);
            tblBottom!.Controls.Add(pnlDev, 0, 1);
            tblBottom.SetColumnSpan(pnlDev, 2);
        }

        
        private void LoadDashboardData()
        {
            try
            {
                var stats = _dashboardService.GetDashboardStats();
                PopulateStatCards(stats);
                PopulateRevenueChart(stats);
                PopulateStatusChart(stats);
                PopulateReceiptsGrid(stats);
                PopulateInventoryWidget(stats);
                PopulateDevicesChart(stats);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"خطأ في تحميل بيانات لوحة التحكم:\n{ex.Message}",
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateStatCards(DashboardStats s)
        {
            lblAvgRepairValue!.Text     = $"{s.AverageRepairDays} يوم";
            lblAvgRepairTrend!.Text     = s.AverageRepairDays > 0
                ? $"بناءً على {s.DeliveredCount} جهاز مسلَّم" : "لا توجد بيانات بعد";
            lblAvgRepairTrend.ForeColor = Color.SlateGray;

            lblRevenueValue!.Text       = $"{s.TotalRevenue:N0} ج";
            lblRevenueTrend!.Text       = $"من {s.DeliveredCount} جهاز مسلَّم";
            lblRevenueTrend.ForeColor   = s.TotalRevenue > 0 ? Color.Green : Color.Gray;

            lblDeliveredValue!.Text     = s.DeliveredCount.ToString();
            var pct = s.TotalReceipts > 0 ? (int)((double)s.DeliveredCount / s.TotalReceipts * 100) : 0;
            lblDeliveredTrend!.Text     = $"▲ {pct}% من الإجمالي";
            lblDeliveredTrend.ForeColor = Color.Green;

            lblReceiptsValue!.Text      = s.TotalReceipts.ToString();
            lblReceiptsTrend!.Text      =
                $"جديد:{s.NewArrivalCount}  فحص:{s.UnderInspectionCount}  " +
                $"إصلاح:{s.UnderRepairCount}  جاهز:{s.ReadyCount}";
            lblReceiptsTrend.ForeColor  = Color.SteelBlue;
        }

        private void PopulateRevenueChart(DashboardStats s)
        {
            if (chartRevenue == null || !s.MonthlyRevenues.Any()) return;
            chartRevenue.Series = new ISeries[]
            {
                new ColumnSeries<decimal>
                {
                    Name   = "الإيرادات",
                    Values = s.MonthlyRevenues.Select(m => m.Revenue).ToArray()
                }
            };
            chartRevenue.XAxes = new Axis[]
            {
                new Axis { Labels = s.MonthlyRevenues.Select(m => m.MonthLabel).ToArray() }
            };
        }

        private void PopulateStatusChart(DashboardStats s)
        {
            if (chartStatus == null) return;
            chartStatus.Series = new ISeries[]
            {
                new PieSeries<int> { Name = "وارد جديد",   Values = new[] { s.NewArrivalCount } },
                new PieSeries<int> { Name = "قيد الفحص",   Values = new[] { s.UnderInspectionCount } },
                new PieSeries<int> { Name = "تحت الإصلاح", Values = new[] { s.UnderRepairCount } },
                new PieSeries<int> { Name = "جاهز",         Values = new[] { s.ReadyCount } },
                new PieSeries<int> { Name = "تم التسليم",   Values = new[] { s.DeliveredCount } }
            };
        }

        private void PopulateReceiptsGrid(DashboardStats s)
        {
            if (dgvReceipts == null) return;
            dgvReceipts.Rows.Clear();
            foreach (var r in s.RecentReceipts)
            {
                dgvReceipts.Rows.Add(
                    r.ReceiptNumber, r.CustomerName, r.CustomerPhone,
                    r.DeviceName, r.StatusArabic,
                    r.ReceivedAt.ToString("yyyy/MM/dd"),
                    r.RepairCost.HasValue ? $"{r.RepairCost:N0} ج" : "-");

                var row = dgvReceipts.Rows[dgvReceipts.Rows.Count - 1];
                row.DefaultCellStyle.ForeColor = r.StatusArabic switch
                {
                    "تم التسليم"   => Color.Green,
                    "جاهز"         => Color.DarkBlue,
                    "تحت الإصلاح" => Color.DarkOrange,
                    _              => Color.Black
                };
            }
        }

        private void PopulateInventoryWidget(DashboardStats s)
        {
            if (pnlInventory == null) return;
            var toRemove = pnlInventory.Controls.OfType<Panel>()
                           .Where(p => p.Tag?.ToString() == "data").ToList();
            foreach (var p in toRemove) pnlInventory.Controls.Remove(p);

            var items = new[]
            {
                ("إجمالي الأصناف",     $"{s.TotalSparePartsCount} صنف",  Color.DarkBlue),
                ("مخزون منخفض",        $"{s.LowStockCount} صنف",         Color.Orange),
                ("نفذ من المخزون",     $"{s.OutOfStockCount} صنف",        Color.Red),
                ("قيمة المخزون الكلية", $"{s.TotalInventoryValue:N0} ج",  Color.DarkGreen),
            };

            int y = 38;
            foreach (var (title, val, color) in items)
            {
                var row = new Panel
                {
                    Location = new Point(8, y),
                    Size     = new Size(pnlInventory.Width - 16, 40),
                    Anchor   = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                    Tag      = "data"
                };
                row.Controls.Add(new Label
                {
                    Text = title, Location = new Point(0, 0), Size = new Size(160, 38),
                    Font = new Font("Segoe UI", 9), ForeColor = Color.Gray,
                    TextAlign = ContentAlignment.MiddleRight
                });
                row.Controls.Add(new Label
                {
                    Text = val, Location = new Point(165, 0), Size = new Size(120, 38),
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = color, TextAlign = ContentAlignment.MiddleLeft
                });
                pnlInventory.Controls.Add(row);
                y += 48;
            }
        }

        private void PopulateDevicesChart(DashboardStats s)
        {
            if (chartDevices == null || !s.TopDevices.Any()) return;
            chartDevices.Series = new ISeries[]
            {
                new ColumnSeries<int>
                {
                    Name   = "عدد مرات الصيانة",
                    Values = s.TopDevices.Select(d => d.Count).ToArray()
                }
            };
            chartDevices.XAxes = new Axis[]
            {
                new Axis { Labels = s.TopDevices.Select(d => d.DeviceName).ToArray() }
            };
        }
    }
}
