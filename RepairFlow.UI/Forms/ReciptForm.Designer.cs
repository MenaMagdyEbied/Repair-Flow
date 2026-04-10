namespace RepairFlow.UI.Forms
{
    partial class ReciptForm
    {
        private System.ComponentModel.IContainer components = null;

        // ── Controls ──────────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Panel pnlSeparator;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TableLayoutPanel grid;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtExpectedCost;

        private System.Windows.Forms.ComboBox cboBrand;
        private System.Windows.Forms.ComboBox cboWarranty;
        private System.Windows.Forms.ComboBox cboInitialStatus;

        private System.Windows.Forms.RichTextBox rtbFaultDesc;
        private System.Windows.Forms.RichTextBox rtbAccessories;

        private System.Windows.Forms.DateTimePicker dtpReceiveDate;

        // Labels for grid
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblFault;
        private System.Windows.Forms.Label lblAccessories;
        private System.Windows.Forms.Label lblWarranty;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlTopBar = new Panel();
            pnlButtons = new Panel();
            btnSave = new Button();
            btnCancel = new Button();
            pnlSeparator = new Panel();
            pnlMain = new Panel();
            grid = new TableLayoutPanel();
            lblCustomerName = new Label();
            txtCustomerName = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblBrand = new Label();
            cboBrand = new ComboBox();
            lblModel = new Label();
            txtModel = new TextBox();
            lblFault = new Label();
            rtbFaultDesc = new RichTextBox();
            lblAccessories = new Label();
            rtbAccessories = new RichTextBox();
            lblWarranty = new Label();
            cboWarranty = new ComboBox();
            lblCost = new Label();
            txtExpectedCost = new TextBox();
            lblStatus = new Label();
            cboInitialStatus = new ComboBox();
            lblDate = new Label();
            dtpReceiveDate = new DateTimePicker();
            lblTitle = new Label();
            pnlButtons.SuspendLayout();
            pnlMain.SuspendLayout();
            grid.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTopBar
            // 
            pnlTopBar.BackColor = Color.FromArgb(44, 62, 107);
            pnlTopBar.Dock = DockStyle.Top;
            pnlTopBar.Location = new Point(0, 0);
            pnlTopBar.Name = "pnlTopBar";
            pnlTopBar.Size = new Size(900, 45);
            pnlTopBar.TabIndex = 4;
            // 
            // pnlButtons
            // 
            pnlButtons.BackColor = Color.White;
            pnlButtons.Controls.Add(btnSave);
            pnlButtons.Controls.Add(btnCancel);
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.Location = new Point(0, 440);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Padding = new Padding(10);
            pnlButtons.Size = new Size(900, 60);
            pnlButtons.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(44, 62, 107);
            btnSave.Cursor = Cursors.Hand;
            btnSave.Dock = DockStyle.Right;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(620, 10);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(180, 40);
            btnSave.TabIndex = 0;
            btnSave.Text = "+ حفظ وإنشاء إيصال";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightSlateGray;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Dock = DockStyle.Right;
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(220, 220, 220);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(800, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 40);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "إلغاء";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // pnlSeparator
            // 
            pnlSeparator.BackColor = Color.FromArgb(220, 220, 220);
            pnlSeparator.Dock = DockStyle.Bottom;
            pnlSeparator.Location = new Point(0, 439);
            pnlSeparator.Name = "pnlSeparator";
            pnlSeparator.Size = new Size(900, 1);
            pnlSeparator.TabIndex = 1;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.White;
            pnlMain.Controls.Add(grid);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 90);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(20, 10, 20, 10);
            pnlMain.Size = new Size(900, 349);
            pnlMain.TabIndex = 0;
            // 
            // grid
            // 
            grid.AutoSize = true;
            grid.BackColor = Color.White;
            grid.ColumnCount = 4;
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            grid.Controls.Add(lblCustomerName, 0, 0);
            grid.Controls.Add(txtCustomerName, 1, 0);
            grid.Controls.Add(lblPhone, 2, 0);
            grid.Controls.Add(txtPhone, 3, 0);
            grid.Controls.Add(lblBrand, 0, 1);
            grid.Controls.Add(cboBrand, 1, 1);
            grid.Controls.Add(lblModel, 2, 1);
            grid.Controls.Add(txtModel, 3, 1);
            grid.Controls.Add(lblFault, 0, 2);
            grid.Controls.Add(rtbFaultDesc, 1, 2);
            grid.Controls.Add(lblAccessories, 0, 3);
            grid.Controls.Add(rtbAccessories, 1, 3);
            grid.Controls.Add(lblWarranty, 0, 4);
            grid.Controls.Add(cboWarranty, 1, 4);
            grid.Controls.Add(lblCost, 2, 4);
            grid.Controls.Add(txtExpectedCost, 3, 4);
            grid.Controls.Add(lblStatus, 0, 5);
            grid.Controls.Add(cboInitialStatus, 1, 5);
            grid.Controls.Add(lblDate, 2, 5);
            grid.Controls.Add(dtpReceiveDate, 3, 5);
            grid.Dock = DockStyle.Top;
            grid.Location = new Point(20, 10);
            grid.Name = "grid";
            grid.RowCount = 6;
            grid.RowStyles.Add(new RowStyle());
            grid.RowStyles.Add(new RowStyle());
            grid.RowStyles.Add(new RowStyle());
            grid.RowStyles.Add(new RowStyle());
            grid.RowStyles.Add(new RowStyle());
            grid.RowStyles.Add(new RowStyle());
            grid.Size = new Size(860, 312);
            grid.TabIndex = 0;
            // 
            // lblCustomerName
            // 
            lblCustomerName.Dock = DockStyle.Fill;
            lblCustomerName.Font = new Font("Segoe UI", 9.5F);
            lblCustomerName.ForeColor = Color.Black;
            lblCustomerName.Location = new Point(739, 6);
            lblCustomerName.Margin = new Padding(4, 6, 8, 6);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.RightToLeft = RightToLeft.Yes;
            lblCustomerName.Size = new Size(117, 30);
            lblCustomerName.TabIndex = 0;
            lblCustomerName.Text = "اسم العميل *";
            lblCustomerName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtCustomerName
            // 
            txtCustomerName.BackColor = Color.WhiteSmoke;
            txtCustomerName.BorderStyle = BorderStyle.FixedSingle;
            txtCustomerName.Dock = DockStyle.Fill;
            txtCustomerName.Font = new Font("Segoe UI", 10F);
            txtCustomerName.ForeColor = Color.Gray;
            txtCustomerName.Location = new Point(434, 6);
            txtCustomerName.Margin = new Padding(4, 6, 4, 6);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.RightToLeft = RightToLeft.Yes;
            txtCustomerName.Size = new Size(293, 30);
            txtCustomerName.TabIndex = 1;
            txtCustomerName.Tag = "نوريهان هانئ";
            txtCustomerName.Text = "نوريهان هانئ";
            txtCustomerName.GotFocus += txtCustomerName_GotFocus;
            txtCustomerName.LostFocus += txtCustomerName_LostFocus;
            // 
            // lblPhone
            // 
            lblPhone.Dock = DockStyle.Fill;
            lblPhone.Font = new Font("Segoe UI", 9.5F);
            lblPhone.ForeColor = Color.Black;
            lblPhone.Location = new Point(309, 6);
            lblPhone.Margin = new Padding(4, 6, 8, 6);
            lblPhone.Name = "lblPhone";
            lblPhone.RightToLeft = RightToLeft.Yes;
            lblPhone.Size = new Size(117, 30);
            lblPhone.TabIndex = 2;
            lblPhone.Text = "رقم الهاتف *";
            lblPhone.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtPhone
            // 
            txtPhone.BackColor = Color.WhiteSmoke;
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Dock = DockStyle.Fill;
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.ForeColor = Color.Gray;
            txtPhone.Location = new Point(4, 6);
            txtPhone.Margin = new Padding(4, 6, 4, 6);
            txtPhone.Name = "txtPhone";
            txtPhone.RightToLeft = RightToLeft.Yes;
            txtPhone.Size = new Size(293, 30);
            txtPhone.TabIndex = 3;
            txtPhone.Tag = "01xxxxxxxxx";
            txtPhone.Text = "01xxxxxxxxx";
            txtPhone.GotFocus += txtPhone_GotFocus;
            txtPhone.LostFocus += txtPhone_LostFocus;
            // 
            // lblBrand
            // 
            lblBrand.Dock = DockStyle.Fill;
            lblBrand.Font = new Font("Segoe UI", 9.5F);
            lblBrand.ForeColor = Color.Black;
            lblBrand.Location = new Point(739, 48);
            lblBrand.Margin = new Padding(4, 6, 8, 6);
            lblBrand.Name = "lblBrand";
            lblBrand.RightToLeft = RightToLeft.Yes;
            lblBrand.Size = new Size(117, 31);
            lblBrand.TabIndex = 4;
            lblBrand.Text = "الجهاز (الماركة) *";
            lblBrand.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboBrand
            // 
            cboBrand.BackColor = Color.WhiteSmoke;
            cboBrand.Dock = DockStyle.Fill;
            cboBrand.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBrand.FlatStyle = FlatStyle.Flat;
            cboBrand.Font = new Font("Segoe UI", 10F);
            cboBrand.Items.AddRange(new object[] { "Samsung", "Iphone", "Huawei", "Oppo", "Nokia", "اخري" });
            cboBrand.Location = new Point(434, 48);
            cboBrand.Margin = new Padding(4, 6, 4, 6);
            cboBrand.Name = "cboBrand";
            cboBrand.RightToLeft = RightToLeft.Yes;
            cboBrand.Size = new Size(293, 31);
            cboBrand.TabIndex = 5;
            // 
            // lblModel
            // 
            lblModel.Dock = DockStyle.Fill;
            lblModel.Font = new Font("Segoe UI", 9.5F);
            lblModel.ForeColor = Color.Black;
            lblModel.Location = new Point(309, 48);
            lblModel.Margin = new Padding(4, 6, 8, 6);
            lblModel.Name = "lblModel";
            lblModel.RightToLeft = RightToLeft.Yes;
            lblModel.Size = new Size(117, 31);
            lblModel.TabIndex = 6;
            lblModel.Text = "الموديل *";
            lblModel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtModel
            // 
            txtModel.BackColor = Color.WhiteSmoke;
            txtModel.BorderStyle = BorderStyle.FixedSingle;
            txtModel.Dock = DockStyle.Fill;
            txtModel.Font = new Font("Segoe UI", 10F);
            txtModel.ForeColor = Color.Gray;
            txtModel.Location = new Point(4, 48);
            txtModel.Margin = new Padding(4, 6, 4, 6);
            txtModel.Name = "txtModel";
            txtModel.RightToLeft = RightToLeft.Yes;
            txtModel.Size = new Size(293, 30);
            txtModel.TabIndex = 7;
            txtModel.Tag = "اكتب الموديل هنا...";
            txtModel.Text = "اكتب الموديل هنا...";
            txtModel.GotFocus += txtModel_GotFocus;
            txtModel.LostFocus += txtModel_LostFocus;
            // 
            // lblFault
            // 
            lblFault.Dock = DockStyle.Fill;
            lblFault.Font = new Font("Segoe UI", 9.5F);
            lblFault.ForeColor = Color.Black;
            lblFault.Location = new Point(739, 91);
            lblFault.Margin = new Padding(4, 6, 8, 6);
            lblFault.Name = "lblFault";
            lblFault.RightToLeft = RightToLeft.Yes;
            lblFault.Size = new Size(117, 66);
            lblFault.TabIndex = 8;
            lblFault.Text = "وصف العطل *";
            lblFault.TextAlign = ContentAlignment.MiddleRight;
            // 
            // rtbFaultDesc
            // 
            rtbFaultDesc.BackColor = Color.WhiteSmoke;
            rtbFaultDesc.BorderStyle = BorderStyle.FixedSingle;
            grid.SetColumnSpan(rtbFaultDesc, 3);
            rtbFaultDesc.Dock = DockStyle.Fill;
            rtbFaultDesc.Font = new Font("Segoe UI", 10F);
            rtbFaultDesc.ForeColor = Color.Gray;
            rtbFaultDesc.Location = new Point(4, 89);
            rtbFaultDesc.Margin = new Padding(4);
            rtbFaultDesc.Name = "rtbFaultDesc";
            rtbFaultDesc.RightToLeft = RightToLeft.Yes;
            rtbFaultDesc.Size = new Size(723, 70);
            rtbFaultDesc.TabIndex = 9;
            rtbFaultDesc.Tag = "اشرح المشكلة بالتفصيل...";
            rtbFaultDesc.Text = "";
            rtbFaultDesc.GotFocus += rtbFaultDesc_GotFocus;
            rtbFaultDesc.LostFocus += rtbFaultDesc_LostFocus;
            // 
            // lblAccessories
            // 
            lblAccessories.Dock = DockStyle.Fill;
            lblAccessories.Font = new Font("Segoe UI", 9.5F);
            lblAccessories.ForeColor = Color.Black;
            lblAccessories.Location = new Point(739, 169);
            lblAccessories.Margin = new Padding(4, 6, 8, 6);
            lblAccessories.Name = "lblAccessories";
            lblAccessories.RightToLeft = RightToLeft.Yes;
            lblAccessories.Size = new Size(117, 51);
            lblAccessories.TabIndex = 10;
            lblAccessories.Text = "المرفقات / الملحقات";
            lblAccessories.TextAlign = ContentAlignment.MiddleRight;
            // 
            // rtbAccessories
            // 
            rtbAccessories.BackColor = Color.WhiteSmoke;
            rtbAccessories.BorderStyle = BorderStyle.FixedSingle;
            grid.SetColumnSpan(rtbAccessories, 3);
            rtbAccessories.Dock = DockStyle.Fill;
            rtbAccessories.Font = new Font("Segoe UI", 10F);
            rtbAccessories.ForeColor = Color.Gray;
            rtbAccessories.Location = new Point(4, 167);
            rtbAccessories.Margin = new Padding(4);
            rtbAccessories.Name = "rtbAccessories";
            rtbAccessories.RightToLeft = RightToLeft.Yes;
            rtbAccessories.Size = new Size(723, 55);
            rtbAccessories.TabIndex = 11;
            rtbAccessories.Tag = "ريموت، كابل، حامل...";
            rtbAccessories.Text = "";
            rtbAccessories.GotFocus += rtbAccessories_GotFocus;
            rtbAccessories.LostFocus += rtbAccessories_LostFocus;
            // 
            // lblWarranty
            // 
            lblWarranty.Dock = DockStyle.Fill;
            lblWarranty.Font = new Font("Segoe UI", 9.5F);
            lblWarranty.ForeColor = Color.Black;
            lblWarranty.Location = new Point(739, 232);
            lblWarranty.Margin = new Padding(4, 6, 8, 6);
            lblWarranty.Name = "lblWarranty";
            lblWarranty.RightToLeft = RightToLeft.Yes;
            lblWarranty.Size = new Size(117, 31);
            lblWarranty.TabIndex = 12;
            lblWarranty.Text = "الضمان";
            lblWarranty.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboWarranty
            // 
            cboWarranty.BackColor = Color.WhiteSmoke;
            cboWarranty.Dock = DockStyle.Fill;
            cboWarranty.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWarranty.FlatStyle = FlatStyle.Flat;
            cboWarranty.Font = new Font("Segoe UI", 10F);
            cboWarranty.Items.AddRange(new object[] { "بدون ضمان", "ضمان 3 أشهر", "ضمان 6 أشهر", "ضمان سنة" });
            cboWarranty.Location = new Point(434, 232);
            cboWarranty.Margin = new Padding(4, 6, 4, 6);
            cboWarranty.Name = "cboWarranty";
            cboWarranty.RightToLeft = RightToLeft.Yes;
            cboWarranty.Size = new Size(293, 31);
            cboWarranty.TabIndex = 13;
            // 
            // lblCost
            // 
            lblCost.Dock = DockStyle.Fill;
            lblCost.Font = new Font("Segoe UI", 9.5F);
            lblCost.ForeColor = Color.Black;
            lblCost.Location = new Point(309, 232);
            lblCost.Margin = new Padding(4, 6, 8, 6);
            lblCost.Name = "lblCost";
            lblCost.RightToLeft = RightToLeft.Yes;
            lblCost.Size = new Size(117, 31);
            lblCost.TabIndex = 14;
            lblCost.Text = "تكلفة التصليح المتوقعة (ج)";
            lblCost.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtExpectedCost
            // 
            txtExpectedCost.BackColor = Color.WhiteSmoke;
            txtExpectedCost.BorderStyle = BorderStyle.FixedSingle;
            txtExpectedCost.Dock = DockStyle.Fill;
            txtExpectedCost.Font = new Font("Segoe UI", 10F);
            txtExpectedCost.ForeColor = Color.Gray;
            txtExpectedCost.Location = new Point(4, 232);
            txtExpectedCost.Margin = new Padding(4, 6, 4, 6);
            txtExpectedCost.Name = "txtExpectedCost";
            txtExpectedCost.RightToLeft = RightToLeft.Yes;
            txtExpectedCost.Size = new Size(293, 30);
            txtExpectedCost.TabIndex = 15;
            txtExpectedCost.Tag = "0";
            txtExpectedCost.Text = "0";
            txtExpectedCost.GotFocus += txtExpectedCost_GotFocus;
            txtExpectedCost.LostFocus += txtExpectedCost_LostFocus;
            // 
            // lblStatus
            // 
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Font = new Font("Segoe UI", 9.5F);
            lblStatus.ForeColor = Color.Black;
            lblStatus.Location = new Point(739, 275);
            lblStatus.Margin = new Padding(4, 6, 8, 6);
            lblStatus.Name = "lblStatus";
            lblStatus.RightToLeft = RightToLeft.Yes;
            lblStatus.Size = new Size(117, 31);
            lblStatus.TabIndex = 16;
            lblStatus.Text = "الحالة الأولية";
            lblStatus.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboInitialStatus
            // 
            cboInitialStatus.BackColor = Color.WhiteSmoke;
            cboInitialStatus.Dock = DockStyle.Fill;
            cboInitialStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboInitialStatus.FlatStyle = FlatStyle.Flat;
            cboInitialStatus.Font = new Font("Segoe UI", 10F);
            cboInitialStatus.Items.AddRange(new object[] { "وارد جديد", "قيد الإصلاح", "جاهز للتسليم", "تم التسليم" });
            cboInitialStatus.Location = new Point(434, 275);
            cboInitialStatus.Margin = new Padding(4, 6, 4, 6);
            cboInitialStatus.Name = "cboInitialStatus";
            cboInitialStatus.RightToLeft = RightToLeft.Yes;
            cboInitialStatus.Size = new Size(293, 31);
            cboInitialStatus.TabIndex = 17;
            // 
            // lblDate
            // 
            lblDate.Dock = DockStyle.Fill;
            lblDate.Font = new Font("Segoe UI", 9.5F);
            lblDate.ForeColor = Color.Black;
            lblDate.Location = new Point(309, 275);
            lblDate.Margin = new Padding(4, 6, 8, 6);
            lblDate.Name = "lblDate";
            lblDate.RightToLeft = RightToLeft.Yes;
            lblDate.Size = new Size(117, 31);
            lblDate.TabIndex = 18;
            lblDate.Text = "تاريخ الاستلام";
            lblDate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpReceiveDate
            // 
            dtpReceiveDate.CalendarMonthBackground = Color.WhiteSmoke;
            dtpReceiveDate.Dock = DockStyle.Fill;
            dtpReceiveDate.Font = new Font("Segoe UI", 10F);
            dtpReceiveDate.Format = DateTimePickerFormat.Short;
            dtpReceiveDate.Location = new Point(4, 275);
            dtpReceiveDate.Margin = new Padding(4, 6, 4, 6);
            dtpReceiveDate.Name = "dtpReceiveDate";
            dtpReceiveDate.RightToLeft = RightToLeft.Yes;
            dtpReceiveDate.Size = new Size(293, 30);
            dtpReceiveDate.TabIndex = 19;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitle.Location = new Point(0, 45);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(0, 0, 20, 0);
            lblTitle.RightToLeft = RightToLeft.Yes;
            lblTitle.Size = new Size(900, 45);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "بيانات الإيصال الجديد";
            lblTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ReciptForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(900, 500);
            ControlBox = false;
            Controls.Add(pnlMain);
            Controls.Add(pnlSeparator);
            Controls.Add(pnlButtons);
            Controls.Add(lblTitle);
            Controls.Add(pnlTopBar);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(500, 200);
            Name = "ReciptForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "بيانات الإيصال الجديد";
            pnlButtons.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            grid.ResumeLayout(false);
            grid.PerformLayout();
            ResumeLayout(false);
        }
    }
}
