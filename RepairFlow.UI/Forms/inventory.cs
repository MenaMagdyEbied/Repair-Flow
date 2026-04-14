using RepairFlow.BLL.Services.Interfaces;
using RepairFlow.DAL;
using RepairFlow.DAL.Repositories;
using RepairFlow.Models;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace finalProject
{
    public partial class Inventory : Form
    {
      
        private readonly ISparePartService _partService;
        private Control _previousView;
        private readonly SparePartRepository _repo;
        private List<SparePart> _allParts;
        private BindingSource _bs;
        private System.Windows.Forms.Timer _searchTimer;

        public Inventory( ISparePartService partService , Control previousView)
        {
            InitializeComponent();
            _previousView = previousView;
            // Apply color customizations
            header.BackColor = ColorTranslator.FromHtml("#2C3E6B");
            back.BackColor = ColorTranslator.FromHtml("#566589");
            add_product.BackColor = ColorTranslator.FromHtml("#2C3E6B");
            products_num.ForeColor = ColorTranslator.FromHtml("#2C3E6B");
            label5.ForeColor = ColorTranslator.FromHtml("#B07D00");
            label7.ForeColor = ColorTranslator.FromHtml("#C0392B");

            // Apply rounded corners
            roundedElement(right_panel, 20);
            roundedElement(left_panel, 20);
            roundedElement(middle_panel, 20);
            roundedElement(add_product, 10);
            roundedElement(label8, 10);
            roundedElement(search, 10);
            roundedElement(back, 10);
            roundedElement(label9, 10);
            roundedElement(label18, 10);
            roundedElement(label23, 10);
            roundedElement(label31, 10);
            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = false;

            // Initialize responsive table column styles

            var control = tableLayoutPanel1.GetControlFromPosition(0, 1);
            string p_name = control.Text;
            _partService = partService;
            var context = new AppDbContext(); 
            _repo = new SparePartRepository(context);

            _bs = new BindingSource();
            _searchTimer = new System.Windows.Forms.Timer();
            _searchTimer.Interval = 300; // ms
            _searchTimer.Tick += (s, e) => {
                _searchTimer.Stop();
                ApplySearchFilter();
            };

           
            partsGrid.Visible = true;
            partsGrid.Dock = DockStyle.Top;
            partsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            partsGrid.DataSource = _bs;
           
            partsGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 244, 255);
            partsGrid.DefaultCellStyle.SelectionForeColor = Color.Black;
           
            partsGrid.RowTemplate.Height = 30;
            partsGrid.AllowUserToResizeRows = false;
            partsGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
           // EditProduct.Show();
        }


        /// <summary>
        /// Initialize table column styles to auto-fit content width
        /// </summary>

        //  Dictionary<Control, Rectangle> originalBounds = new Dictionary<Control, Rectangle>();
        //private void Form1_Load(object sender, EventArgs e)
        //{

        //    FormResize();
        //}
        //private void FormResize()
        //{
        //    float xRatio = (float)this.Width / 800;
        //    float yRatio = (float)this.Height / 600;

        //    float scale = Math.Min(xRatio, yRatio);

        //    foreach (Control c in this.Controls)
        //    {
        //        Rectangle r = originalBounds[c];

        //        c.Left = (int)(r.X * scale);
        //        c.Top = (int)(r.Y * scale);
        //        c.Width = (int)(r.Width * scale);
        //        c.Height = (int)(r.Height * scale);
        //    }
        //}

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
        

        //public void HighLightRow(TableLayoutPanel table, int rowIndex, Color color)
        //{
        //    foreach (Control ctrl in table.Controls)
        //    {

        //        if (table.GetRow(ctrl) == rowIndex)
        //        {
        //            ctrl.BackColor = color;
        //        }
        //    }


        //}
        Color defaultColor = Color.White;
        //public void hoverEffect(TableLayoutPanel table, Color defaultColor)
        //{
        //    foreach (Control ctrl in table.Controls)
        //    {
        //        ctrl.MouseEnter += (s, e) =>
        //        {
        //            int row = table.GetRow((Control)s);
        //            HighLightRow(table, row, Color.Gainsboro);
        //        };
        //        ctrl.MouseLeave += (s, e) =>
        //        {
        //            int row = table.GetRow((Control)s);
        //            HighLightRow(table, row, defaultColor);
        //        };
        //    }
        //}
        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (_previousView != null)
            {
                _previousView.Show();
                _previousView.BringToFront();
                _previousView.Focus();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
       
        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (_previousView != null)
            {
                _previousView.Show();
                _previousView.BringToFront();
            }

        }
       

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void add_product_Click(object sender, EventArgs e)
        {
            addProduct addProduct = new addProduct();
            var res = addProduct.ShowDialog();
            if (res == DialogResult.OK)
            {
                _ = LoadDataAsync();
            }

        }

        private async void Inventory_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private Task LoadDataAsync()
        {
            return Task.Run(() =>
            {
                _allParts = _repo.GetAll() ?? new List<SparePart>();
                if (!IsHandleCreated) return;
                Invoke(() =>
                {
                    _bs.DataSource = new BindingList<SparePart>(_allParts);
                    products_num.Text = _allParts.Count.ToString();
                    // calculate counts for low stock and out of stock
                    var lowCount = _allParts.Count(p => p.Quantity < p.AlertThreshold && p.Quantity > 0);
                    var outCount = _allParts.Count(p => p.Quantity == 0);
                    label5.Text = lowCount.ToString();
                    label7.Text = outCount.ToString();
      
                    try
                    {
               
                    partsGrid.Columns["colName"].HeaderText = "الاسم";
                    partsGrid.Columns["colType"].HeaderText = "النوع";
                    partsGrid.Columns["colQuantity"].HeaderText = "الكمية";
                    partsGrid.Columns["colPurchase"].HeaderText = "سعر الشراء";
                    partsGrid.Columns["colSelling"].HeaderText = "سعر البيع";
                    partsGrid.Columns["colAlert"].HeaderText = "حد التنبيه";
                    partsGrid.Columns["colFlag"].HeaderText = "الحالة";
                    try
                    {
                        partsGrid.Columns["colName"].DisplayIndex = 0;
                        partsGrid.Columns["colType"].DisplayIndex = 1;
                        partsGrid.Columns["colQuantity"].DisplayIndex = 2;
                        partsGrid.Columns["colPurchase"].DisplayIndex = 3;
                        partsGrid.Columns["colSelling"].DisplayIndex = 4;
                        partsGrid.Columns["colAlert"].DisplayIndex = 5;
                        partsGrid.Columns["colFlag"].DisplayIndex = 6;
                        partsGrid.Columns["colEdit"].DisplayIndex = 7;
                        partsGrid.Columns["colDelete"].DisplayIndex = 8;
                    }
                    catch { }
                    if (partsGrid.ColumnHeadersVisible == false) partsGrid.ColumnHeadersVisible = true;
                    ResizeGridToRows();
                    UpdateCountsAndAlert();
                    }
                    catch { }
                });
            });
        }

        private void ResizeGridToRows()
        {
            if (partsGrid == null) return;
            try
            {
                partsGrid.SuspendLayout();
                int totalHeight = partsGrid.ColumnHeadersVisible ? partsGrid.ColumnHeadersHeight : 0;
                foreach (DataGridViewRow r in partsGrid.Rows)
                {
                    totalHeight += r.Height;
                }
                // padding
                totalHeight += partsGrid.Margin.Top + partsGrid.Margin.Bottom + 4;
                int maxHeight = this.ClientSize.Height - partsGrid.Location.Y - 20;
                partsGrid.Height = Math.Min(Math.Max(totalHeight, partsGrid.ColumnHeadersHeight + 40), maxHeight);
                // ensure vertical scrollbar visibility when needed
                partsGrid.ScrollBars = totalHeight > partsGrid.Height ? ScrollBars.Vertical : ScrollBars.None;
            }
            finally
            {
                partsGrid.ResumeLayout();
            }
        }
        

        private void AddCell(string text, int col, int row)
        {
            var lbl = new Label
            {
                Text = text,
                AutoSize = true,
                Margin = new Padding(5),
                ForeColor = Color.DimGray
            };

            tableLayoutPanel1.Controls.Add(lbl, col, row);
        }
        private void search_TextChanged(object sender, EventArgs e)
        {
            // Debounce rapid keystrokes
            _searchTimer.Stop();
            _searchTimer.Start();
        }

        private void ApplySearchFilter()
        {
            var query = search.Text?.Trim().ToLower() ?? string.Empty;
            List<SparePart> filtered;
            if (string.IsNullOrEmpty(query))
            {
                filtered = _allParts;
            }
            else
            {
                filtered = _allParts.Where(p =>
                    (p.Name ?? string.Empty).ToLower().Contains(query) ||
                    (p.Type ?? string.Empty).ToLower().Contains(query) ||
                    (p.Code ?? string.Empty).ToLower().Contains(query)
                ).ToList();
            }

            _bs.DataSource = new BindingList<SparePart>(filtered);
            products_num.Text = filtered.Count.ToString();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {
           
        }
        
        private void PartsGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            return;
        }

        private void PartsGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                var grid = partsGrid;
                if (grid == null || grid.DataSource == null) return;
                if (e.RowIndex >= grid.Rows.Count) return;

                var item = grid.Rows[e.RowIndex].DataBoundItem as SparePart;
                if (item == null) return;

                if (grid.Rows[e.RowIndex].Selected)
                {
                    e.CellStyle.SelectionBackColor = Color.FromArgb(230, 244, 255);
                }

                if (grid.Columns[e.ColumnIndex].Name == "colFlag")
                {
                    if (item.Quantity < item.AlertThreshold)
                    {
                        e.Value = "منخفض"; // Arabic for low
                        e.CellStyle.BackColor = Color.LightPink;
                        e.CellStyle.ForeColor = label31.ForeColor;
                    }
                    else
                    {
                        e.Value = "متوفر"; // Arabic for available
                        e.CellStyle.BackColor = Color.AntiqueWhite;
                        e.CellStyle.ForeColor = label31.ForeColor;
                    }
                    e.FormattingApplied = true;
                }
            }
            catch
            {
            }
        }

        private void PartsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var colName = partsGrid.Columns[e.ColumnIndex].Name;
            var sp = partsGrid.Rows[e.RowIndex].DataBoundItem as SparePart;
            if (sp == null) return;

            if (colName == "colEdit")
            {
                EditProduct edit = new EditProduct(sp.Id, sp.Name, sp.Type, sp.Quantity.ToString(), sp.PurchasePrice.ToString(), sp.SellingPrice.ToString());

                EventHandler<SparePart> handler = (sender, updated) =>
                {
                    if (updated == null) return;
                    var bsList = _bs.DataSource as BindingList<SparePart>;
                    if (bsList != null)
                    {
                        var existing = bsList.FirstOrDefault(x => x.Id == updated.Id);
                        if (existing != null)
                        {
                            existing.Name = updated.Name;
                            existing.Type = updated.Type;
                            existing.Quantity = updated.Quantity;
                            existing.PurchasePrice = updated.PurchasePrice;
                            existing.SellingPrice = updated.SellingPrice;
                            _bs.ResetBindings(false);
                        }
                        else
                        {
                            bsList.Add(updated);
                            _bs.ResetBindings(false);
                        }

                        var masterIdx = _allParts.FindIndex(x => x.Id == updated.Id);
                        if (masterIdx >= 0) _allParts[masterIdx] = updated;
                        else _allParts.Add(updated);
                    }
                    else
                    {
                        // fallback: reload whole list
                        _ = LoadDataAsync();
                    }

                    ResizeGridToRows();
                    UpdateCountsAndAlert();
                };

                edit.Saved += handler;
                edit.ShowDialog();
                edit.Saved -= handler;
            }
            else if (colName == "colDelete")
            {
                var res = MessageBox.Show($"هل تريد حذف المنتج '{sp.Name}'؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    var entity = _repo.GetById(sp.Id);
                    if (entity != null)
                        _repo.Delete(entity);
                    var bsList = _bs.DataSource as BindingList<SparePart>;
                    if (bsList != null)
                    {
                        var found = bsList.FirstOrDefault(p => p.Id == sp.Id);
                        if (found != null)
                        {
                            bsList.Remove(found);
                            _bs.ResetBindings(false);
                        }
                    }
                    else
                    {
                        _allParts.RemoveAll(p => p.Id == sp.Id);
                        ApplySearchFilter();
                    }
                    ResizeGridToRows();
                    // update counters
                    var lowCount2 = (_bs.DataSource as BindingList<SparePart>)?.Count(p => p.Quantity < p.AlertThreshold && p.Quantity > 0) ?? _allParts.Count(p => p.Quantity < p.AlertThreshold && p.Quantity > 0);
                    var outCount2 = (_bs.DataSource as BindingList<SparePart>)?.Count(p => p.Quantity == 0) ?? _allParts.Count(p => p.Quantity == 0);
                label5.Text = lowCount2.ToString();
                label7.Text = outCount2.ToString();
                // update total products display
                products_num.Text = (_bs.DataSource as BindingList<SparePart>)?.Count.ToString() ?? _allParts.Count.ToString();
                    UpdateCountsAndAlert();
                }
            }
        }

        private void UpdateCountsAndAlert()
        {
            var list = _bs.DataSource as BindingList<SparePart> ?? new BindingList<SparePart>(_allParts);
            int available = list.Count(p => p.Quantity > p.AlertThreshold);
            int low = list.Count(p => p.Quantity < p.AlertThreshold && p.Quantity > 0);
            label9.Text = $"تنبيه : يوجد {available} منتج متوفر و {low} منتج منخفض . يرجى مراجعة المخزون ⚠️";
            products_num.Text = list.Count.ToString();
            int outOfStock = list.Count(p => p.Quantity == 0);
            int lowAndOut = low + outOfStock;
            label8.Text = $"({lowAndOut}) المنخفض والنافد فقط";
            try
            {
                label5.Text = low.ToString();
                label7.Text = outOfStock.ToString();
            }
            catch { }
        }

        private void PartsGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && partsGrid.Columns[e.ColumnIndex].Name == "colActions")
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);
                var g = e.Graphics;
                var rect = new Rectangle(e.CellBounds.X + 4, e.CellBounds.Y + 4, e.CellBounds.Width - 8, e.CellBounds.Height - 8);
                using (var brush = new SolidBrush(panel2.BackColor))
                using (var pen = new Pen(Color.LightGray))
                {
                    g.FillRectangle(brush, rect);
                    g.DrawRectangle(pen, rect);
                }
                TextRenderer.DrawText(g, "…", this.Font, rect, Color.DimGray, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }
    }
}
