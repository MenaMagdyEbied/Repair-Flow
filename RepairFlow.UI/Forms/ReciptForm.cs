namespace RepairFlow.UI.Forms
{
    public partial class ReciptForm : Form
    {
        public ReciptForm()
        {
            InitializeComponent();
        }

        // ── Button Events ─────────────────────────────────────────────────────

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string customerName = txtCustomerName.Text;
            string phone = txtPhone.Text;
            string placeholder1 = (string)txtCustomerName.Tag;
            string placeholder2 = (string)txtPhone.Tag;

            // 1. اسم العميل validation
            if (customerName == placeholder1 || string.IsNullOrWhiteSpace(customerName))
            {
                MessageBox.Show("يرجى إدخال اسم العميل.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validation for customer name: must have first and last name with space
            string[] nameParts = customerName.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (nameParts.Length != 2 || string.IsNullOrWhiteSpace(nameParts[0]) || string.IsNullOrWhiteSpace(nameParts[1]))
            {
                MessageBox.Show("اسم العميل يجب أن يحتوي على الاسم الأول والأخير مفصولين بمسافة .", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. رقم الهاتف validation
            if (phone == placeholder2 || string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("يرجى إدخال رقم الهاتف.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validation for phone number: must start with 01, 11 digits, no characters
            if (!phone.StartsWith("01") || phone.Length != 11 || !phone.All(char.IsDigit))
            {
                MessageBox.Show("رقم الهاتف يجب ان يحتوي علي 11 رقم فقط ولا يحتوي علي اي رموز او احرف ", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. الجهاز validation
            if (cboBrand.SelectedItem == null || cboBrand.SelectedIndex == -1)
            {
                MessageBox.Show("يجب ان تختار", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. الموديل validation
            string placeholder3 = (string)txtModel.Tag;
            if (txtModel.Text == placeholder3 || string.IsNullOrWhiteSpace(txtModel.Text))
            {
                MessageBox.Show("تنبيه يجب كتابه اسم الموديل", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 5. وصف العطل validation
            string faultPlaceholder = (string)rtbFaultDesc.Tag;
            if (rtbFaultDesc.Text == faultPlaceholder || string.IsNullOrWhiteSpace(rtbFaultDesc.Text))
            {
                MessageBox.Show("يجب كتابه ما هو العطل", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string brand = cboBrand.SelectedItem != null ? cboBrand.SelectedItem.ToString() : "";
            string model = txtModel.Text == (string)txtModel.Tag ? "" : txtModel.Text;
            string date = dtpReceiveDate.Value.ToShortDateString();

            MessageBox.Show(
                "تم حفظ الإيصال بنجاح!\n\n" +
                "العميل: " + customerName + "\n" +
                "الهاتف: " + phone + "\n" +
                "الجهاز: " + brand + " - " + model + "\n" +
                "تاريخ الاستلام: " + date,
                "تم الحفظ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ── TextBox Placeholder Events ────────────────────────────────────────

        private void txtCustomerName_GotFocus(object sender, EventArgs e)
        {
            ClearPlaceholder(txtCustomerName);
        }
        private void txtCustomerName_LostFocus(object sender, EventArgs e)
        {
            RestorePlaceholder(txtCustomerName);
        }

        private void txtPhone_GotFocus(object sender, EventArgs e)
        {
            ClearPlaceholder(txtPhone);
        }
        private void txtPhone_LostFocus(object sender, EventArgs e)
        {
            RestorePlaceholder(txtPhone);
        }

        private void txtModel_GotFocus(object sender, EventArgs e)
        {
            ClearPlaceholder(txtModel);
        }
        private void txtModel_LostFocus(object sender, EventArgs e)
        {
            RestorePlaceholder(txtModel);
        }

        private void txtExpectedCost_GotFocus(object sender, EventArgs e)
        {
            ClearPlaceholder(txtExpectedCost);
        }
        private void txtExpectedCost_LostFocus(object sender, EventArgs e)
        {
            RestorePlaceholder(txtExpectedCost);
        }

        // ── RichTextBox Placeholder Events ────────────────────────────────────

        private void rtbFaultDesc_GotFocus(object sender, EventArgs e)
        {
            ClearRichPlaceholder(rtbFaultDesc);
        }
        private void rtbFaultDesc_LostFocus(object sender, EventArgs e)
        {
            RestoreRichPlaceholder(rtbFaultDesc);
        }

        private void rtbAccessories_GotFocus(object sender, EventArgs e)
        {
            ClearRichPlaceholder(rtbAccessories);
        }
        private void rtbAccessories_LostFocus(object sender, EventArgs e)
        {
            RestoreRichPlaceholder(rtbAccessories);
        }

        // ── Placeholder Helpers ───────────────────────────────────────────────

        private void ClearPlaceholder(TextBox tb)
        {
            string placeholder = (string)tb.Tag;
            if (tb.Text == placeholder)
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }

        private void RestorePlaceholder(TextBox tb)
        {
            string placeholder = (string)tb.Tag;
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = placeholder;
                tb.ForeColor = Color.Gray;
            }
        }

        private void ClearRichPlaceholder(RichTextBox rtb)
        {
            string placeholder = (string)rtb.Tag;
            if (rtb.Text == placeholder)
            {
                rtb.Text = "";
                rtb.ForeColor = Color.Black;
            }
        }

        private void RestoreRichPlaceholder(RichTextBox rtb)
        {
            string placeholder = (string)rtb.Tag;
            if (string.IsNullOrWhiteSpace(rtb.Text))
            {
                rtb.Text = placeholder;
                rtb.ForeColor = Color.Gray;
            }
        }
    }
}
