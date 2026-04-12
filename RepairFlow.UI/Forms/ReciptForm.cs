using RepairFlow.BLL.Services.Interfaces;

namespace RepairFlow.UI.Forms
{
    public partial class ReciptForm : Form
    {
        private readonly MainForm _mainForm;
        private readonly string _receiptNumber;
        private readonly IDeviceService _deviceService;

        public ReciptForm(MainForm mainForm, string receiptNumber, IDeviceService deviceService)
        {
            InitializeComponent();
            _mainForm      = mainForm;
            _receiptNumber = receiptNumber;
            _deviceService = deviceService;
        }

        // ── Button Events ─────────────────────────────────────────────────────

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();

        private void btnSave_Click(object sender, EventArgs e)
        {
            string customerName = txtCustomerName.Text;
            string phone        = txtPhone.Text;
            string brand        = cboBrand.SelectedItem?.ToString() ?? "";
            string model        = txtModel.Text == (string)txtModel.Tag ? "" : txtModel.Text;
            string fault        = rtbFaultDesc.Text == (string)rtbFaultDesc.Tag ? "" : rtbFaultDesc.Text;
            string acc          = rtbAccessories.Text == (string)rtbAccessories.Tag ? "" : rtbAccessories.Text;

            string costPlaceholder = txtExpectedCost.Tag as string ?? "";
            string costText = txtExpectedCost.Text == costPlaceholder ? "" : txtExpectedCost.Text;
            decimal? repairCost = null;
            if (!string.IsNullOrWhiteSpace(costText) && decimal.TryParse(costText, out decimal parsedCost))
                repairCost = parsedCost;

            string warrantyText = cboWarranty.Text;
            string statusText   = cboInitialStatus.Text;
            DateTime receivedAt = dtpReceiveDate.Value;

            try
            {
                var device = _deviceService.AddDevice(
                    _receiptNumber, customerName.Trim(), phone,
                    brand, model, fault, acc,
                    repairCost, warrantyText, statusText, receivedAt);

                _mainForm.AddNewDevice(device);

                MessageBox.Show(
                    "تم حفظ الإيصال بنجاح وإضافته للقائمة!\n\n" +
                    "رقم الإيصال: " + _receiptNumber + "\n" +
                    "العميل: " + customerName + "\n" +
                    "الهاتف: " + phone + "\n" +
                    "الجهاز: " + brand + " - " + model + "\n" +
                    "تاريخ الاستلام: " + receivedAt.ToString("yyyy/MM/dd"),
                    "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ── TextBox Placeholder Events ────────────────────────────────────────

        private void txtCustomerName_GotFocus(object sender, EventArgs e) => ClearPlaceholder(txtCustomerName);
        private void txtCustomerName_LostFocus(object sender, EventArgs e) => RestorePlaceholder(txtCustomerName);
        private void txtPhone_GotFocus(object sender, EventArgs e)         => ClearPlaceholder(txtPhone);
        private void txtPhone_LostFocus(object sender, EventArgs e)        => RestorePlaceholder(txtPhone);
        private void txtModel_GotFocus(object sender, EventArgs e)         => ClearPlaceholder(txtModel);
        private void txtModel_LostFocus(object sender, EventArgs e)        => RestorePlaceholder(txtModel);
        private void txtExpectedCost_GotFocus(object sender, EventArgs e)  => ClearPlaceholder(txtExpectedCost);
        private void txtExpectedCost_LostFocus(object sender, EventArgs e) => RestorePlaceholder(txtExpectedCost);

        // ── RichTextBox Placeholder Events ────────────────────────────────────

        private void rtbFaultDesc_GotFocus(object sender, EventArgs e)    => ClearRichPlaceholder(rtbFaultDesc);
        private void rtbFaultDesc_LostFocus(object sender, EventArgs e)   => RestoreRichPlaceholder(rtbFaultDesc);
        private void rtbAccessories_GotFocus(object sender, EventArgs e)  => ClearRichPlaceholder(rtbAccessories);
        private void rtbAccessories_LostFocus(object sender, EventArgs e) => RestoreRichPlaceholder(rtbAccessories);

        // ── Placeholder Helpers ───────────────────────────────────────────────

        private static void ClearPlaceholder(TextBox tb)
        {
            if (tb.Text == (string)tb.Tag) { tb.Text = ""; tb.ForeColor = Color.Black; }
        }

        private static void RestorePlaceholder(TextBox tb)
        {
            if (string.IsNullOrWhiteSpace(tb.Text)) { tb.Text = (string)tb.Tag; tb.ForeColor = Color.Gray; }
        }

        private static void ClearRichPlaceholder(RichTextBox rtb)
        {
            if (rtb.Text == (string)rtb.Tag) { rtb.Text = ""; rtb.ForeColor = Color.Black; }
        }

        private static void RestoreRichPlaceholder(RichTextBox rtb)
        {
            if (string.IsNullOrWhiteSpace(rtb.Text)) { rtb.Text = (string)rtb.Tag; rtb.ForeColor = Color.Gray; }
        }
    }
}
