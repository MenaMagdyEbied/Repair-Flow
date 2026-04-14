using Guna.UI2.WinForms;
using RepairFlow.Models;
using RepairFlow.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RepairFlow.UI.Forms
{
    /// <summary>
    /// Modern Register Form – Guna UI2 WinForms + EF Core Code First.
    ///
    /// Fields   : First Name · Last Name · Username · Phone · Password · Confirm Password
    /// Validation: Live (TextChanged + Leave) with green/red borders and inline error labels.
    /// Database  : Username uniqueness checked on Leave; user inserted on submit through DbContext.
    ///
    /// Layout: Left blue branding panel | Right white form panel (split card).
    /// </summary>
    public partial class RegisterForm : Form
    {
        // ─── Controls ─────────────────────────────────────────────────────────────
        private Panel      pnlBackground;
        private Guna2Panel pnlCard;
        private Guna2Panel pnlLeft;
        private Panel      pnlRight;

        // Form-field controls
        private Label        lblFirstName,  lblLastName;
        private Guna2TextBox txtFirstName,  txtLastName;
        private Label        errFirstName,  errLastName;

        private Label        lblUsername;
        private Guna2TextBox txtUsername;
        private Label        errUsername;

        private Label        lblPhone;
        private Guna2TextBox txtPhone;
        private Label        errPhone;

        private Label        lblPassword;
        private Guna2TextBox txtPassword;
        private Label        errPassword;
        private Label        togPassword;     // eye icon

        private Label        lblConfirm;
        private Guna2TextBox txtConfirm;
        private Label        errConfirm;
        private Label        togConfirm;      // eye icon

        private Guna2Button btnRegister;
        private LinkLabel   lnkLogin;

        // ─── Color palette (matches LoginForm) ────────────────────────────────────
        private static readonly Color PageBg        = Color.FromArgb(245, 246, 250);
        private static readonly Color CardBg        = Color.White;
        private static readonly Color PrimaryBlue   = Color.FromArgb(37,  99, 235);
        private static readonly Color DeepBlue      = Color.FromArgb(29,  78, 216);
        private static readonly Color InputFill     = Color.FromArgb(243, 244, 246);
        private static readonly Color BorderDefault = Color.FromArgb(209, 213, 219);
        private static readonly Color BorderValid   = Color.FromArgb(34,  197,  94);
        private static readonly Color BorderInvalid = Color.FromArgb(239,  68,  68);
        private static readonly Color DarkText      = Color.FromArgb(17,  24,  39);
        private static readonly Color MutedText     = Color.FromArgb(107, 114, 128);
        private static readonly Color LinkBlue      = Color.FromArgb(37,  99, 235);
        private static readonly Color ErrorRed      = Color.FromArgb(220,  38,  38);
        private static readonly Color DisabledGray  = Color.FromArgb(156, 163, 175);

        // ─── Card dimensions ──────────────────────────────────────────────────────
        private const int CardW  = 920;
        private const int CardH  = 680;
        private const int LeftW  = 340;
        private const int RightW = 580;

        // ─── Username availability state ──────────────────────────────────────────
        // Cached so the button-gate doesn't re-query on every keystroke.
        private bool _usernameAvailable = false;

        // ─────────────────────────────────────────────────────────────────────────
        private readonly Action<string> _openMainForm;

        public RegisterForm(Action<string> openMainForm)
        {
            _openMainForm = openMainForm;
            DatabaseHelper.InitializeDatabase();
            InitializeComponent();
            BuildUI();
        }

        private void InitializeComponent()
        {
        
            SuspendLayout();
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(CardW, CardH);
            MinimumSize = new Size(CardW, CardH);
            MaximumSize = new Size(CardW, CardH);
            Name = "RegisterForm";
            Text = "Create Account";
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 9F);
            BackColor = CardBg;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            ResumeLayout(false);
        }

        // ═════════════════════════════════════════════════════════════════════════
        //  BUILD UI
        // ═════════════════════════════════════════════════════════════════════════

        private void BuildUI()
        {
           
            pnlCard = new Guna2Panel
            {
                Dock = DockStyle.Fill,
                BackColor = CardBg,
                BorderRadius = 20,
                ShadowDecoration = { Enabled = false },
                BorderThickness = 0
            };
            Controls.Add(pnlCard);

            BuildLeftPanel();

            pnlRight = new Panel
            {
                Size = new Size(RightW, CardH),
                Location = new Point(LeftW, 0),
                BackColor = CardBg
            };
            pnlCard.Controls.Add(pnlRight);

            BuildRightPanel();
        }

        // ─── Left branding panel ──────────────────────────────────────────────────
        private void BuildLeftPanel()
        {
            pnlLeft = new Guna2Panel
            {
                Size            = new Size(LeftW + 20, CardH),
                Location        = new Point(0, 0),
                BackColor       = PrimaryBlue,
                BorderRadius    = 20,
                BorderThickness = 0
            };
            pnlCard.Controls.Add(pnlLeft);

            pnlLeft.Controls.Add(new Label
            {
                Text = "AuthPlatform", Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.White, AutoSize = false, Size = new Size(280, 40),
                Location = new Point(32, 52), TextAlign = ContentAlignment.MiddleLeft
            });
            pnlLeft.Controls.Add(new Label
            {
                Text = "Your all-in-one workspace\nfor modern teams.",
                Font = new Font("Segoe UI", 10F), ForeColor = Color.FromArgb(190, 224, 255),
                AutoSize = false, Size = new Size(270, 48), Location = new Point(32, 100),
                TextAlign = ContentAlignment.TopLeft
            });

            string[] features =
            {
                "✦  Secure & encrypted sessions",
                "✦  Seamless biometric login",
                "✦  Team collaboration tools"
            };
            int fy = 200;
            foreach (string f in features)
            {
                pnlLeft.Controls.Add(new Label
                {
                    Text = f, Font = new Font("Segoe UI", 9.5F),
                    ForeColor = Color.FromArgb(219, 234, 254), AutoSize = false,
                    Size = new Size(270, 26), Location = new Point(32, fy),
                    TextAlign = ContentAlignment.MiddleLeft
                });
                fy += 34;
            }

            AddDecorativeCircle(LeftW - 80,  CardH - 140, 180, 30);
            AddDecorativeCircle(LeftW - 120, CardH - 200, 100, 20);
        }

        // ─── Right form panel ─────────────────────────────────────────────────────
        private void BuildRightPanel()
        {
            int x  = 44;
            int cw = RightW - 88;           // 492 px usable width
            int hw = (cw - 12) / 2;         // 240 px – half-width column
            int y  = 32;

            // ── Header ───────────────────────────────────────────────────────────
            pnlRight.Controls.Add(new Label
            {
                Text = "Create Account", Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                ForeColor = DarkText, AutoSize = false, Size = new Size(cw, 44),
                Location = new Point(x, y), TextAlign = ContentAlignment.MiddleLeft
            });
            y += 42;

            pnlRight.Controls.Add(new Label
            {
                Text = "Fill in the details below to get started for free.",
                Font = new Font("Segoe UI", 9.5F), ForeColor = MutedText,
                AutoSize = false, Size = new Size(cw, 18),
                Location = new Point(x, y+2), TextAlign = ContentAlignment.MiddleLeft
            });
            y += 32;

            // ── First Name  |  Last Name ──────────────────────────────────────────
            lblFirstName = MakeLabel("First Name",  x,           y);
            lblLastName  = MakeLabel("Last Name",   x + hw + 12, y);
            pnlRight.Controls.AddRange(new Control[] { lblFirstName, lblLastName });
            y += 20;

            txtFirstName = MakeTextBox(x,           y, hw, "Romany", false);
            txtLastName  = MakeTextBox(x + hw + 12, y, hw, "Malak",  false);
            pnlRight.Controls.AddRange(new Control[] { txtFirstName, txtLastName });
            y += 46;

            errFirstName = MakeErrLabel(x,           y, hw);
            errLastName  = MakeErrLabel(x + hw + 12, y, hw);
            pnlRight.Controls.AddRange(new Control[] { errFirstName, errLastName });
            y += 20;

            // ── Username ──────────────────────────────────────────────────────────
            lblUsername = MakeLabel("Username", x, y);
            pnlRight.Controls.Add(lblUsername);
            y += 20;

            txtUsername = MakeTextBox(x, y, cw, "e.g. romany_malak", false);
            pnlRight.Controls.Add(txtUsername);
            y += 46;

            errUsername = MakeErrLabel(x, y, cw);
            pnlRight.Controls.Add(errUsername);
            y += 20;

            // ── Phone Number ──────────────────────────────────────────────────────
            lblPhone = MakeLabel("Phone Number", x, y);
            pnlRight.Controls.Add(lblPhone);
            y += 20;

            txtPhone = MakeTextBox(x, y, cw, "01006789453", false);
            pnlRight.Controls.Add(txtPhone);
            y += 46;

            errPhone = MakeErrLabel(x, y, cw);
            pnlRight.Controls.Add(errPhone);
            y += 20;

            // ── Password ──────────────────────────────────────────────────────────
            lblPassword = MakeLabel("Password", x, y);
            pnlRight.Controls.Add(lblPassword);
            y += 20;

            txtPassword = MakeTextBox(x, y, cw, "Create a strong password", true);
            pnlRight.Controls.Add(txtPassword);

            togPassword = MakeEyeToggle(x + cw - 34, y + 9);
            togPassword.Click += (s, e) => ToggleVisibility(txtPassword, togPassword);
            pnlRight.Controls.Add(togPassword);
            togPassword.BringToFront();
            y += 46;

            errPassword = MakeErrLabel(x, y, cw);
            pnlRight.Controls.Add(errPassword);
            y += 20;

            // ── Confirm Password ──────────────────────────────────────────────────
            lblConfirm = MakeLabel("Confirm Password", x, y);
            pnlRight.Controls.Add(lblConfirm);
            y += 20;

            txtConfirm = MakeTextBox(x, y, cw, "Re-enter your password", true);
            pnlRight.Controls.Add(txtConfirm);

            togConfirm = MakeEyeToggle(x + cw - 34, y + 9);
            togConfirm.Click += (s, e) => ToggleVisibility(txtConfirm, togConfirm);
            pnlRight.Controls.Add(togConfirm);
            togConfirm.BringToFront();
            y += 46;

            errConfirm = MakeErrLabel(x, y, cw);
            pnlRight.Controls.Add(errConfirm);
            y += 24;

            // ── Create Account button ─────────────────────────────────────────────
            btnRegister = new Guna2Button
            {
                Text         = "Create Account",
                Font         = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor    = Color.White,
                FillColor    = DisabledGray,
                BorderRadius = 10,
                Size         = new Size(cw, 44),
                Location     = new Point(x, y),
                Animated     = true,
                Enabled      = false
            };
            btnRegister.HoverState.FillColor = DisabledGray;
            btnRegister.Click += BtnRegister_Click;
            pnlRight.Controls.Add(btnRegister);
            y += 56;

            // ── Already have an account? ──────────────────────────────────────────
            lnkLogin = new LinkLabel
            {
                Text = "Already have an account? Log in",
                Font = new Font("Segoe UI", 9F), ForeColor = MutedText,
                LinkColor = LinkBlue, ActiveLinkColor = PrimaryBlue,
                AutoSize = false, Size = new Size(cw, 22),
                Location = new Point(x, y), TextAlign = ContentAlignment.MiddleCenter
            };
            lnkLogin.LinkArea = new LinkArea(26, 6);
            lnkLogin.LinkClicked += (s, e) => OpenLogin();
            pnlRight.Controls.Add(lnkLogin);

            // ── Wire all validation events ────────────────────────────────────────
            WireEvents();
        }

        // ═════════════════════════════════════════════════════════════════════════
        //  STEP 1 — WIRE EVENTS
        //
        //  TextChanged  → validate format while the user types (fast, no DB call)
        //  Leave        → full validation when focus moves away (DB call for username)
        // ═════════════════════════════════════════════════════════════════════════
        private void WireEvents()
        {
            // First Name
            txtFirstName.TextChanged += (s, e) => ValidateName(txtFirstName, errFirstName, "First name");
            txtFirstName.Leave       += (s, e) => ValidateName(txtFirstName, errFirstName, "First name");

            // Last Name
            txtLastName.TextChanged += (s, e) => ValidateName(txtLastName, errLastName, "Last name");
            txtLastName.Leave       += (s, e) => ValidateName(txtLastName, errLastName, "Last name");

            // Username – format check on type, DB check on Leave
            txtUsername.TextChanged += (s, e) => ValidateUsernameFormat();
            txtUsername.Leave       += (s, e) => ValidateUsernameFull();
            // Also log the database connection being used when user leaves username field for debug
            txtUsername.Leave += (s, e) =>
            {
                try
                {
                    using var db = new AppDbContext();
                    var conn = db.Database.GetDbConnection();
                    Debug.WriteLine($"[Register] DB={conn.Database}; DataSource={conn.DataSource}");
                }
                catch (Exception ex) { Debug.WriteLine("[Register] DB info error: " + ex.Message); }
            };

            // Phone – block non-digits with KeyPress; full check on change/leave
            txtPhone.KeyPress    += Phone_KeyPress;
            txtPhone.TextChanged += (s, e) => ValidatePhone();
            txtPhone.Leave       += (s, e) => ValidatePhone();

            // Password – re-check confirm whenever password changes
            txtPassword.TextChanged += (s, e) =>
            {
                ValidatePassword();
                if (!string.IsNullOrEmpty(txtConfirm.Text)) ValidateConfirm();
            };
            txtPassword.Leave += (s, e) => ValidatePassword();

            // Confirm Password
            txtConfirm.TextChanged += (s, e) => ValidateConfirm();
            txtConfirm.Leave       += (s, e) => ValidateConfirm();
        }

        // ═════════════════════════════════════════════════════════════════════════
        //  STEP 2 — VALIDATION METHODS
        //
        //  Every method calls Pass() or Fail() which sets the border color,
        //  shows/hides the error label, then calls UpdateButtonState().
        // ═════════════════════════════════════════════════════════════════════════

        // ── First / Last Name ─────────────────────────────────────────────────────
        private bool ValidateName(Guna2TextBox tb, Label err, string field)
        {
            string v = tb.Text.Trim();
            if (string.IsNullOrEmpty(v))
                return Fail(tb, err, $"{field} is required.");
            if (v.Length < 2)
                return Fail(tb, err, $"{field} must be at least 2 characters.");
            if (!Regex.IsMatch(v, @"^[a-zA-Z\s\-']+$"))
                return Fail(tb, err, $"{field} must contain letters only.");
            return Pass(tb, err);
        }

        // ── Username format only (called on TextChanged) ───────────────────────────

        private bool ValidateUsernameFormat()
        {
            string v = txtUsername.Text.Trim();
            if (string.IsNullOrEmpty(v))
                return Fail(txtUsername, errUsername, "Username is required.");
            if (v.Length < 3)
                return Fail(txtUsername, errUsername, "Username must be at least 3 characters.");
            if (v.Length > 50)
                return Fail(txtUsername, errUsername, "Username must be 50 characters or fewer.");
            if (!Regex.IsMatch(v, @"^[a-zA-Z0-9_]+$"))
                return Fail(txtUsername, errUsername, "Only letters, numbers, and underscores allowed.");

            // Format is OK but we haven't done the DB check yet;
            // keep the border neutral until Leave fires.
            ResetBorder(txtUsername, errUsername);
            _usernameAvailable = false;     // re-gate the button until Leave
            UpdateButtonState();
            return false;   // not fully validated yet
        }

        // ── Username full check (format + DB uniqueness, called on Leave) ─────────
        private bool ValidateUsernameFull()
        {
            // Format check first
            string v = txtUsername.Text.Trim();
            if (string.IsNullOrEmpty(v))
                return Fail(txtUsername, errUsername, "Username is required.");
            if (v.Length < 3)
                return Fail(txtUsername, errUsername, "Username must be at least 3 characters.");
            if (v.Length > 50)
                return Fail(txtUsername, errUsername, "Username must be 50 characters or fewer.");
            if (!Regex.IsMatch(v, @"^[a-zA-Z0-9_]+$"))
                return Fail(txtUsername, errUsername, "Only letters, numbers, and underscores allowed.");

            // Database uniqueness check against SQL Users table
            try
            {
                using var db = new AppDbContext();
                // Debug DB connection info
                try { var conn = db.Database.GetDbConnection(); Debug.WriteLine($"[ValidateUsername] DB={conn.Database}; DataSource={conn.DataSource}"); } catch { }

                string normalizedLower = v.ToLower();
                bool exists = db.Users.AsNoTracking()
                                 .Any(u => u.Username.ToLower() == normalizedLower);

                if (exists)
                {
                    _usernameAvailable = false;
                    return Fail(txtUsername, errUsername, $"'{v}' is already taken. Try another.");
                }
            }
            catch (Exception ex)
            {
                // Show DB error in the error label but don't crash
                _usernameAvailable = false;
                return Fail(txtUsername, errUsername, $"Could not verify: {ex.Message}");
            }

            _usernameAvailable = true;
            return Pass(txtUsername, errUsername);
        }

        // ── Phone ─────────────────────────────────────────────────────────────────

        /// <summary>Swallows any non-digit, non-control keystroke.</summary>
        private void Phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private bool ValidatePhone()
        {
            string v = txtPhone.Text.Trim();
            if (string.IsNullOrEmpty(v))
                return Fail(txtPhone, errPhone, "Phone number is required.");
            if (!Regex.IsMatch(v, @"^\d+$"))
                return Fail(txtPhone, errPhone, "Phone must contain digits only.");
            if (v.Length !=11)
                return Fail(txtPhone, errPhone, "Phone must be 11 digits.");
            return Pass(txtPhone, errPhone);
        }

        // ── Password strength ─────────────────────────────────────────────────────
        private bool ValidatePassword()
        {
            string p = txtPassword.Text;
            if (string.IsNullOrEmpty(p))
                return Fail(txtPassword, errPassword, "Password is required.");
            if (p.Length < 8)
                return Fail(txtPassword, errPassword, "Password must be at least 8 characters.");
            if (!Regex.IsMatch(p, @"[A-Z]"))
                return Fail(txtPassword, errPassword, "Must include at least one uppercase letter.");
            if (!Regex.IsMatch(p, @"[a-z]"))
                return Fail(txtPassword, errPassword, "Must include at least one lowercase letter.");
            if (!Regex.IsMatch(p, @"[0-9]"))
                return Fail(txtPassword, errPassword, "Must include at least one number.");
            if (!Regex.IsMatch(p, @"[^a-zA-Z0-9]"))
                return Fail(txtPassword, errPassword, "Must include at least one special character.");
            return Pass(txtPassword, errPassword);
        }

        // ── Confirm Password ──────────────────────────────────────────────────────
        private bool ValidateConfirm()
        {
            string c = txtConfirm.Text;
            if (string.IsNullOrEmpty(c))
                return Fail(txtConfirm, errConfirm, "Please confirm your password.");
            if (txtPassword.Text != c)
                return Fail(txtConfirm, errConfirm, "Passwords do not match.");
            return Pass(txtConfirm, errConfirm);
        }

        // ═════════════════════════════════════════════════════════════════════════
        //  STEP 3 — UI STATE HELPERS
        // ═════════════════════════════════════════════════════════════════════════

        /// <summary>Red border + visible error label. Returns false (for return chaining).</summary>
        private bool Fail(Guna2TextBox tb, Label err, string message)
        {
            tb.BorderColor     = BorderInvalid;
            tb.BorderThickness = 2;
            err.Text           = message;
            err.ForeColor      = ErrorRed;
            err.Visible        = true;
            UpdateButtonState();
            return false;
        }

        /// <summary>Green border + hidden error label. Returns true.</summary>
        private bool Pass(Guna2TextBox tb, Label err)
        {
            tb.BorderColor     = BorderValid;
            tb.BorderThickness = 1;
            err.Text           = "";
            err.Visible        = false;
            UpdateButtonState();
            return true;
        }

        /// <summary>Neutral/default border (used when format is ok but DB check is pending).</summary>
        private static void ResetBorder(Guna2TextBox tb, Label err)
        {
            tb.BorderColor     = Color.FromArgb(209, 213, 219);
            tb.BorderThickness = 1;
            err.Visible        = false;
        }

        /// <summary>
        /// Enables the button only when every field has a green border AND
        /// the username DB check passed.
        /// </summary>
        private void UpdateButtonState()
        {
            bool allGreen = IsGreen(txtFirstName)
                         && IsGreen(txtLastName)
                         && IsGreen(txtUsername)
                         && _usernameAvailable
                         && IsGreen(txtPhone)
                         && IsGreen(txtPassword)
                         && IsGreen(txtConfirm);

            btnRegister.Enabled   = allGreen;
            btnRegister.FillColor = allGreen ? PrimaryBlue : DisabledGray;
            btnRegister.HoverState.FillColor = allGreen ? DeepBlue : DisabledGray;
        }

        private static bool IsGreen(Guna2TextBox tb)
            => tb.BorderColor == Color.FromArgb(34, 197, 94);

        // ─── Show / Hide password ─────────────────────────────────────────────────
        private static void ToggleVisibility(Guna2TextBox tb, Label toggle)
        {
            tb.UseSystemPasswordChar = !tb.UseSystemPasswordChar;
            toggle.Text = tb.UseSystemPasswordChar ? "👁" : "🔓";
        }

        // ═════════════════════════════════════════════════════════════════════════
        //  STEP 4 — REGISTER BUTTON CLICK  (Database INSERT)
        // ═════════════════════════════════════════════════════════════════════════
        private void BtnRegister_Click(object sender, EventArgs e)
        {
            // Final validation pass (guards against edge cases)
            // Use single & so every validator runs and paints its border
            bool ok = ValidateName(txtFirstName, errFirstName, "First name")
                    & ValidateName(txtLastName,  errLastName,  "Last name")
                    & ValidateUsernameFull()
                    & ValidatePhone()
                    & ValidatePassword()
                    & ValidateConfirm();

            if (!ok) return;

            // Build the model (password stays plain-text here; DatabaseHelper will hash it and save as AppUser)
            var user = new AppUser
            {
                FirstName   = txtFirstName.Text.Trim(),
                LastName    = txtLastName.Text.Trim(),
                Username    = txtUsername.Text.Trim(),
                PhoneNumber = txtPhone.Text.Trim(),
                Password    = txtPassword.Text // transient property used for hashing
            };

            try
            {
                btnRegister.Enabled = false;
                btnRegister.Text    = "Creating…";

                bool success;
                // Try saving to SQL Server via AppDbContext first
                try
                {
                    using var db = new AppDbContext();
                    // Double-check username uniqueness against SQL to avoid race conditions
                    string normalized = user.Username.Trim();
                    var conn = db.Database.GetDbConnection();
                    string ds = conn.DataSource ?? "(unknown)";
                    string dbName = conn.Database ?? "(unknown)";

                    // Inform which database we're about to use (temporary debug popup)
                    MessageBox.Show($"Attempting to save to SQL Server:\nServer = {ds}\nDatabase = {dbName}", "DB Target", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (db.Users.AsNoTracking().Any(u => u.Username.ToLower() == normalized.ToLower()))
                        throw new Exception("That username is already taken.");

                    var entity = new AppUser
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Username = user.Username,
                        PhoneNumber = user.PhoneNumber,
                        PasswordHash = DatabaseHelper.HashPassword(user.Password),
                        CreatedAt = DateTime.Now
                    };

                    db.Users.Add(entity);
                    int changed = db.SaveChanges();
                    Debug.WriteLine($"[Register] SQL SaveChanges returned {changed}. New Id={entity.Id}");
                    success = changed > 0;

                    // Show confirmation where it was saved
                    MessageBox.Show($"Saved to SQL Server. Rows affected: {changed}\nNew User Id: {entity.Id}\nServer = {ds}\nDatabase = {dbName}", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception sqlEx)
                {
                    // If SQL save fails, fall back to DatabaseHelper (JSON) and show/log
                    Debug.WriteLine("SQL save failed: " + sqlEx.Message + "\n" + sqlEx.StackTrace);
                    MessageBox.Show("SQL save failed: " + sqlEx.Message + "\nFalling back to local storage.", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    try
                    {
                        success = DatabaseHelper.RegisterUser(user);
                    }
                    catch (Exception jsonEx)
                    {
                        Debug.WriteLine("JSON fallback failed: " + jsonEx.Message + "\n" + jsonEx.StackTrace);
                        throw; // let outer catch show the error
                    }
                }

                if (success)
                {
                    MessageBox.Show(
                              $"Welcome, {user.FirstName}!\nYour account has been created successfully.",
                              "Registration Successful",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);

                    Hide();
                    _openMainForm.Invoke(user.Username);
                }
                else
                {
                    MessageBox.Show("Registration failed. Please try again.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Registration Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnRegister.Enabled = true;
                btnRegister.Text    = "Create Account";
            }
        }

        // ═════════════════════════════════════════════════════════════════════════
        //  FACTORY HELPERS
        // ═════════════════════════════════════════════════════════════════════════

        private Label MakeLabel(string text, int x, int y) => new Label
        {
            Text = text, Font = new Font("Segoe UI", 9F),
            ForeColor = DarkText, AutoSize = true,
            Location = new Point(x, y)
        };

        private Label MakeErrLabel(int x, int y, int width) => new Label
        {
            Text = "", Font = new Font("Segoe UI", 7.5F),
            ForeColor = ErrorRed, AutoSize = false,
            Size = new Size(width, 16),
            Location = new Point(x, y), Visible = false
        };

        private Guna2TextBox MakeTextBox(int x, int y, int width, string placeholder, bool isPassword)
            => new Guna2TextBox
            {
                Size                  = new Size(width, 44),
                Location              = new Point(x, y),
                PlaceholderText       = placeholder,
                Font                  = new Font("Segoe UI", 10F),
                ForeColor             = DarkText,
                PlaceholderForeColor  = Color.FromArgb(156, 163, 175),
                FillColor             = InputFill,
                BorderColor           = BorderDefault,
                BorderRadius          = 8,
                BorderThickness       = 1,
                UseSystemPasswordChar = isPassword,
                Padding               = new Padding(10, 0, isPassword ? 38 : 10, 0)
            };

        private Label MakeEyeToggle(int x, int y) => new Label
        {
            Text = "👁", Size = new Size(28, 28),
            Location = new Point(x, y), Cursor = Cursors.Hand,
            TextAlign = ContentAlignment.MiddleCenter,
            BackColor = Color.Transparent, ForeColor = MutedText,
            Font = new Font("Segoe UI", 11F)
        };

        private void AddDecorativeCircle(int cx, int cy, int size, int alpha)
        {
            var p = new Panel
            {
                Size = new Size(size, size),
                Location = new Point(cx, cy),
                BackColor = Color.Transparent
            };
            p.Paint += (s, e) =>
            {
                using var b = new SolidBrush(Color.FromArgb(alpha, 255, 255, 255));
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.FillEllipse(b, 0, 0, size, size);
            };
            pnlLeft.Controls.Add(p);
            p.BringToFront();
        }

        private void CenterCard() => pnlCard.Location = new Point(
            (pnlBackground.Width  - CardW) / 2,
            (pnlBackground.Height - CardH) / 2);

        // ─── Navigation ───────────────────────────────────────────────────────────
        private void OpenLogin()
        {
            var loginForm = new LoginForm(_openMainForm);
            loginForm.Show();
            Hide();
        }
    }
}
