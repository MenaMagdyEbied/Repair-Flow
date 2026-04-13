//using System;
//using System.Drawing;
//using System.Text.RegularExpressions;
//using System.Windows.Forms;
//using Guna.UI2.WinForms;

//namespace testlogin
//{
//    /// <summary>
//    /// Modern Login Form – Guna UI2 WinForms + EF Core Code First.
//    ///
//    /// Validation : Live green/red borders + inline error labels.
//    /// Auth        : On submit, credentials are verified against the Users table
//    ///               via <see cref="DatabaseHelper.AuthenticateUser"/>.
//    ///
//    /// Layout: Centered white rounded card (no split panel).
//    /// </summary>
//    public partial class LoginForm : Form
//    {
//        // ─── Controls ─────────────────────────────────────────────────────────────
//        private Panel        pnlBackground;
//        private Guna2Panel   pnlCard;
//        private Label        lblTitle, lblSubtitle;

//        // Username
//        private Label        lblUsername;
//        private Guna2TextBox txtUsername;
//        private Label        errUsername;

//        // Password
//        private Label        lblPassword;
//        private Guna2TextBox txtPassword;
//        private Label        errPassword;
//        private Label        togPassword;      // eye-icon overlay

//        // Row: Remember + Forgot
//        private Guna2CheckBox  chkRemember;
//        private LinkLabel      lnkForgot;

//        // Actions
//        private Guna2Button    btnLogin;

//        // Divider + social
//        private Panel  pnlDivLeft, pnlDivRight;
//        private Label  lblDivText;
//        private Guna2Button btnGoogle, btnBiometrics;

//        // Footer link
//        private LinkLabel lnkCreateAccount;

//        // ─── Color palette ────────────────────────────────────────────────────────
//        private static readonly Color PageBg        = Color.FromArgb(245, 246, 250);
//        private static readonly Color CardBg        = Color.White;
//        private static readonly Color PrimaryBlue   = Color.FromArgb(37,  99, 235);
//        private static readonly Color DeepBlue      = Color.FromArgb(29,  78, 216);
//        private static readonly Color InputFill     = Color.FromArgb(243, 244, 246);
//        private static readonly Color BorderDefault = Color.FromArgb(209, 213, 219);
//        private static readonly Color BorderValid   = Color.FromArgb(34,  197,  94);
//        private static readonly Color BorderInvalid = Color.FromArgb(239,  68,  68);
//        private static readonly Color DarkText      = Color.FromArgb(17,  24,  39);
//        private static readonly Color MutedText     = Color.FromArgb(107, 114, 128);
//        private static readonly Color LinkBlue      = Color.FromArgb(37,  99, 235);
//        private static readonly Color ErrorRed      = Color.FromArgb(220,  38,  38);
//        private static readonly Color DisabledGray  = Color.FromArgb(156, 163, 175);

//        // ─── Card dimensions ──────────────────────────────────────────────────────
//        private const int CardW = 440;
//        private const int CardH = 610;

//        // ─────────────────────────────────────────────────────────────────────────
//        public LoginForm()
//        {
//            DatabaseHelper.InitializeDatabase();
//            InitializeComponent();
//            BuildUI();
//        }

//        private void InitializeComponent()
//        {
//            //SuspendLayout();
//            //AutoScaleDimensions = new SizeF(7F, 15F);
//            //AutoScaleMode       = AutoScaleMode.Font;
//            //ClientSize          = new Size(1100, 720);
//            //MinimumSize         = new Size(900, 650);
//            //Name                = "LoginForm";
//            //Text                = "Sign In";
//            //StartPosition       = FormStartPosition.CenterScreen;
//            //Font                = new Font("Segoe UI", 9F);
//            //BackColor           = PageBg;
//            //FormBorderStyle     = FormBorderStyle.FixedSingle;
//            //MaximizeBox         = false;
//            //ResumeLayout(false);

//            SuspendLayout();
//            AutoScaleDimensions = new SizeF(7F, 15F);
//            AutoScaleMode = AutoScaleMode.Font;
//            ClientSize = new Size(CardW, CardH);
//            MinimumSize = new Size(CardW, CardH);
//            MaximumSize = new Size(CardW, CardH);
//            Name = "LoginForm";
//            Text = "Sign In";
//            StartPosition = FormStartPosition.CenterScreen;
//            Font = new Font("Segoe UI", 9F);
//            BackColor = CardBg;
//            FormBorderStyle = FormBorderStyle.FixedSingle;
//            MaximizeBox = false;
//            ResumeLayout(false);
//        }

//        // ═════════════════════════════════════════════════════════════════════════
//        //  BUILD UI
//        // ═════════════════════════════════════════════════════════════════════════
//        private void BuildUI()
//        {
//            //pnlBackground = new Panel { Dock = DockStyle.Fill, BackColor = PageBg };
//            //Controls.Add(pnlBackground);

//            //pnlCard = new Guna2Panel
//            //{
//            //    Size             = new Size(CardW, CardH),
//            //    BackColor        = CardBg,
//            //    BorderRadius     = 20,
//            //    ShadowDecoration = { Enabled = true, Color = Color.FromArgb(30, 0, 0, 0), Depth = 20 },
//            //    BorderThickness  = 0,
//            //    Anchor           = AnchorStyles.None
//            //};
//            //CenterCard();
//            //pnlBackground.Controls.Add(pnlCard);
//            //pnlBackground.Resize += (s, e) => CenterCard();

//            //int x  = 36;
//            //int cw = 368;
//            //int y  = 42;
//            pnlCard = new Guna2Panel
//            {
//                Dock = DockStyle.Fill,
//                BackColor = CardBg,
//                BorderRadius = 20,
//                ShadowDecoration = { Enabled = false },
//                BorderThickness = 0
//            };
//            Controls.Add(pnlCard);

//            int x = 36;
//            int cw = 368;
//            int y = 42;

//            // ── Title ─────────────────────────────────────────────────────────────
//            lblTitle = new Label
//            {
//                Text = "Welcome back",
//                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
//                ForeColor = DarkText, AutoSize = false,
//                Size = new Size(cw, 38), Location = new Point(x, y),
//                TextAlign = ContentAlignment.MiddleLeft
//            };
//            pnlCard.Controls.Add(lblTitle);
//            y += 44;

//            // ── Subtitle ──────────────────────────────────────────────────────────
//            lblSubtitle = new Label
//            {
//                Text = "Enter your credentials to sign in.",
//                Font = new Font("Segoe UI", 9.5F), ForeColor = MutedText,
//                AutoSize = false, Size = new Size(cw, 20),
//                Location = new Point(x, y), TextAlign = ContentAlignment.MiddleLeft
//            };
//            pnlCard.Controls.Add(lblSubtitle);
//            y += 34;

//            // ── Username ──────────────────────────────────────────────────────────
//            lblUsername = MakeLabel("Username", x, y);
//            pnlCard.Controls.Add(lblUsername);
//            y += 22;

//            txtUsername = MakeTextBox(x, y, cw, "Enter your username", false);
//            pnlCard.Controls.Add(txtUsername);
//            y += 46;

//            errUsername = MakeErrLabel(x, y, cw);
//            pnlCard.Controls.Add(errUsername);
//            y += 18;

//            // ── Password ──────────────────────────────────────────────────────────
//            lblPassword = MakeLabel("Password", x, y);
//            pnlCard.Controls.Add(lblPassword);
//            y += 22;

//            txtPassword = MakeTextBox(x, y, cw, "Enter your password", true);
//            pnlCard.Controls.Add(txtPassword);

//            togPassword = MakeEyeToggle(x + cw - 34, y + 9);
//            togPassword.Click += (s, e) => ToggleVisibility(txtPassword, togPassword);
//            pnlCard.Controls.Add(togPassword);
//            togPassword.BringToFront();
//            y += 46;

//            errPassword = MakeErrLabel(x, y, cw);
//            pnlCard.Controls.Add(errPassword);
//            y += 22;

//            // ── Remember + Forgot row ─────────────────────────────────────────────
//            chkRemember = new Guna2CheckBox
//            {
//                Text = "Remember for 30 days",
//                Font = new Font("Segoe UI", 9F),
//                ForeColor = DarkText, AutoSize = false,
//                Size = new Size(200, 24), Location = new Point(x, y + 2)
//            };
//            pnlCard.Controls.Add(chkRemember);

//            lnkForgot = new LinkLabel
//            {
//                Text = "Forgot Password?",
//                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
//                LinkColor = LinkBlue, ActiveLinkColor = PrimaryBlue,
//                VisitedLinkColor = LinkBlue, AutoSize = true,
//                Location = new Point(x + cw - 108, y + 4)
//            };
//            lnkForgot.LinkClicked += (s, e) =>
//                MessageBox.Show("Password reset flow is not implemented yet.", "Forgot Password",
//                    MessageBoxButtons.OK, MessageBoxIcon.Information);
//            pnlCard.Controls.Add(lnkForgot);
//            y += 42;

//            // ── Log In button (disabled until both fields are valid) ───────────────
//            btnLogin = new Guna2Button
//            {
//                Text         = "Log In",
//                Font         = new Font("Segoe UI", 10.5F, FontStyle.Bold),
//                ForeColor    = Color.White,
//                FillColor    = DisabledGray,
//                BorderRadius = 10,
//                Size         = new Size(cw, 46),
//                Location     = new Point(x, y),
//                Animated     = true,
//                Enabled      = false
//            };
//            btnLogin.HoverState.FillColor = DisabledGray;
//            btnLogin.Click += BtnLogin_Click;
//            pnlCard.Controls.Add(btnLogin);
//            y += 56;

//            // ── Divider ───────────────────────────────────────────────────────────
//            pnlDivLeft = new Panel
//            {
//                BackColor = BorderDefault, Size = new Size(130, 1),
//                Location  = new Point(x, y + 9)
//            };
//            pnlCard.Controls.Add(pnlDivLeft);

//            lblDivText = new Label
//            {
//                Text = "OR CONTINUE WITH",
//                Font = new Font("Segoe UI", 7.5F), ForeColor = MutedText,
//                AutoSize = true, Location = new Point(x + 138, y + 2)
//            };
//            pnlCard.Controls.Add(lblDivText);

//            pnlDivRight = new Panel
//            {
//                BackColor = BorderDefault, Size = new Size(130, 1),
//                Location  = new Point(x + 238, y + 9)
//            };
//            pnlCard.Controls.Add(pnlDivRight);
//            y += 30;

//            // ── Social buttons ────────────────────────────────────────────────────
//            int bw = (cw - 12) / 2;

//            btnGoogle = MakeOutlineButton("🔍  Google", x, y, bw);
//            btnGoogle.Click += (s, e) =>
//                MessageBox.Show("Google SSO is not yet implemented.", "Social Login",
//                    MessageBoxButtons.OK, MessageBoxIcon.Information);
//            pnlCard.Controls.Add(btnGoogle);

//            btnBiometrics = MakeOutlineButton("🪪  Biometrics", x + bw + 12, y, bw);
//            btnBiometrics.Click += (s, e) =>
//                MessageBox.Show("Biometric auth is not yet implemented.", "Biometrics",
//                    MessageBoxButtons.OK, MessageBoxIcon.Information);
//            pnlCard.Controls.Add(btnBiometrics);
//            y += 58;

//            // ── Create account link ───────────────────────────────────────────────
//            lnkCreateAccount = new LinkLabel
//            {
//                Text = "New to the platform? Create an account",
//                Font = new Font("Segoe UI", 9F), ForeColor = MutedText,
//                LinkColor = LinkBlue, ActiveLinkColor = PrimaryBlue,
//                AutoSize = false, Size = new Size(cw, 22),
//                Location = new Point(x, y), TextAlign = ContentAlignment.MiddleCenter
//            };
//            lnkCreateAccount.LinkArea = new LinkArea(22, 16);
//            lnkCreateAccount.LinkClicked += (s, e) => OpenRegister();
//            pnlCard.Controls.Add(lnkCreateAccount);

//            // ── Wire validation events ────────────────────────────────────────────
//            WireEvents();
//        }

//        // ═════════════════════════════════════════════════════════════════════════
//        //  STEP 1 — WIRE EVENTS
//        // ═════════════════════════════════════════════════════════════════════════
//        private void WireEvents()
//        {
//            txtUsername.TextChanged += (s, e) => ValidateUsername();
//            txtUsername.Leave       += (s, e) => ValidateUsername();

//            txtPassword.TextChanged += (s, e) => ValidatePassword();
//            txtPassword.Leave       += (s, e) => ValidatePassword();
//        }

//        // ═════════════════════════════════════════════════════════════════════════
//        //  STEP 2 — VALIDATION METHODS
//        // ═════════════════════════════════════════════════════════════════════════

//        private bool ValidateUsername()
//        {
//            string v = txtUsername.Text.Trim();
//            if (string.IsNullOrEmpty(v))
//                return Fail(txtUsername, errUsername, "Username is required.");
//            if (!Regex.IsMatch(v, @"^[a-zA-Z0-9_]+$"))
//                return Fail(txtUsername, errUsername, "Only letters, numbers, and underscores allowed.");
//            return Pass(txtUsername, errUsername);
//        }

//        private bool ValidatePassword()
//        {
//            string p = txtPassword.Text;
//            if (string.IsNullOrEmpty(p))
//                return Fail(txtPassword, errPassword, "Password is required.");
//            if (p.Length < 1)
//                return Fail(txtPassword, errPassword, "Password cannot be empty.");
//            return Pass(txtPassword, errPassword);
//        }

//        // ═════════════════════════════════════════════════════════════════════════
//        //  STEP 3 — UI STATE HELPERS
//        // ═════════════════════════════════════════════════════════════════════════

//        private bool Fail(Guna2TextBox tb, Label err, string message)
//        {
//            tb.BorderColor     = BorderInvalid;
//            tb.BorderThickness = 2;
//            err.Text           = message;
//            err.ForeColor      = ErrorRed;
//            err.Visible        = true;
//            UpdateButtonState();
//            return false;
//        }

//        private bool Pass(Guna2TextBox tb, Label err)
//        {
//            tb.BorderColor     = BorderValid;
//            tb.BorderThickness = 1;
//            err.Text           = "";
//            err.Visible        = false;
//            UpdateButtonState();
//            return true;
//        }

//        /// <summary>
//        /// Enables the Log In button only when both fields are green.
//        /// </summary>
//        private void UpdateButtonState()
//        {
//            bool ok = IsGreen(txtUsername) && IsGreen(txtPassword);
//            btnLogin.Enabled   = ok;
//            btnLogin.FillColor = ok ? PrimaryBlue : DisabledGray;
//            btnLogin.HoverState.FillColor = ok ? DeepBlue : DisabledGray;
//        }

//        private static bool IsGreen(Guna2TextBox tb)
//            => tb.BorderColor == Color.FromArgb(34, 197, 94);

//        private static void ToggleVisibility(Guna2TextBox tb, Label toggle)
//        {
//            tb.UseSystemPasswordChar = !tb.UseSystemPasswordChar;
//            toggle.Text = tb.UseSystemPasswordChar ? "👁" : "🔓";
//        }

//        // ═════════════════════════════════════════════════════════════════════════
//        //  STEP 4 — LOGIN BUTTON CLICK  (Database Authentication)
//        // ═════════════════════════════════════════════════════════════════════════
//        private void BtnLogin_Click(object sender, EventArgs e)
//        {
//            // Final validation guard
//            bool ok = ValidateUsername() & ValidatePassword();
//            if (!ok) return;

//            string username = txtUsername.Text.Trim();
//            string password = txtPassword.Text;

//            try
//            {
//                btnLogin.Enabled = false;
//                btnLogin.Text    = "Signing in…";

//                UserModel? user = DatabaseHelper.AuthenticateUser(username, password);

//                if (user == null)
//                {
//                    // ── Wrong credentials ─────────────────────────────────────────
//                    // Mark both fields red but do NOT reveal which one is wrong
//                    // (that would expose valid usernames to attackers).
//                    Fail(txtUsername, errUsername, "");
//                    Fail(txtPassword, errPassword, "Incorrect username or password.");

//                    // Shake the card slightly for visual feedback
//                    ShakeCard();
//                }
//                else
//                {
//                    // ── Success ───────────────────────────────────────────────────
//                    MessageBox.Show(
//                        $"Welcome back, {user.FirstName} {user.LastName}!\n" +
//                        $"You are now signed in as @{user.Username}.",
//                        "Login Successful",
//                        MessageBoxButtons.OK,
//                        MessageBoxIcon.Information);

//                    // TODO: Open your main application form here
//                    // new DashboardForm(user).Show();
//                    // Hide();
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(
//                    $"Login error:\n{ex.Message}",
//                    "Error",
//                    MessageBoxButtons.OK,
//                    MessageBoxIcon.Error);
//            }
//            finally
//            {
//                btnLogin.Enabled = true;
//                btnLogin.Text    = "Log In";
//            }
//        }

//        // ─── Card shake animation (wrong credentials feedback) ────────────────────
//        private async void ShakeCard()
//        {
//            int origX = pnlCard.Left;
//            int[] offsets = { -8, 8, -6, 6, -4, 4, 0 };
//            foreach (int offset in offsets)
//            {
//                pnlCard.Left = origX + offset;
//                await System.Threading.Tasks.Task.Delay(30);
//            }
//            pnlCard.Left = origX;
//        }

//        // ═════════════════════════════════════════════════════════════════════════
//        //  FACTORY HELPERS
//        // ═════════════════════════════════════════════════════════════════════════

//        private Label MakeLabel(string text, int x, int y) => new Label
//        {
//            Text = text, Font = new Font("Segoe UI", 9F),
//            ForeColor = DarkText, AutoSize = true,
//            Location = new Point(x, y)
//        };

//        private Label MakeErrLabel(int x, int y, int width) => new Label
//        {
//            Text = "", Font = new Font("Segoe UI", 7.5F),
//            ForeColor = ErrorRed, AutoSize = false,
//            Size = new Size(width, 16),
//            Location = new Point(x, y), Visible = false
//        };

//        private Guna2TextBox MakeTextBox(int x, int y, int width, string placeholder, bool isPassword)
//            => new Guna2TextBox
//            {
//                Size                  = new Size(width, 44),
//                Location              = new Point(x, y),
//                PlaceholderText       = placeholder,
//                Font                  = new Font("Segoe UI", 10F),
//                ForeColor             = DarkText,
//                PlaceholderForeColor  = Color.FromArgb(156, 163, 175),
//                FillColor             = InputFill,
//                BorderColor           = BorderDefault,
//                BorderRadius          = 8,
//                BorderThickness       = 1,
//                UseSystemPasswordChar = isPassword,
//                Padding               = new Padding(10, 0, isPassword ? 38 : 10, 0)
//            };

//        private Label MakeEyeToggle(int x, int y) => new Label
//        {
//            Text = "👁", Size = new Size(28, 28),
//            Location = new Point(x, y), Cursor = Cursors.Hand,
//            TextAlign = ContentAlignment.MiddleCenter,
//            BackColor = Color.Transparent, ForeColor = MutedText,
//            Font = new Font("Segoe UI", 11F)
//        };

//        private Guna2Button MakeOutlineButton(string text, int x, int y, int width)
//            => new Guna2Button
//            {
//                Text = text, Font = new Font("Segoe UI", 9.5F),
//                ForeColor = DarkText, FillColor = Color.White,
//                BorderColor = BorderDefault, BorderThickness = 1,
//                BorderRadius = 10, Size = new Size(width, 44),
//                Location = new Point(x, y), Animated = true,
//                HoverState = { FillColor = Color.FromArgb(249, 250, 251) }
//            };

//        // ─── Navigation ───────────────────────────────────────────────────────────
//        private void CenterCard() => pnlCard.Location = new Point(
//            (pnlBackground.Width  - CardW) / 2,
//            (pnlBackground.Height - CardH) / 2);

//        private void OpenRegister()
//        {
//            new RegisterForm().Show();
//            Hide();
//        }
//    }
//}




using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using RepairFlow.Models;

namespace RepairFlow.UI.Forms
{
    

    
        public partial class LoginForm : Form
        {
        private readonly Action<string> _openMainForm; // Added for navigation after login (passes username)

        // Controls
        private Guna2Panel pnlCard;
            private Label lblTitle, lblSubtitle;

            private Label lblUsername;
            private Guna2TextBox txtUsername;
            private Label errUsername;

            private Label lblPassword;
            private Guna2TextBox txtPassword;
            private Label errPassword;
            private Label togPassword;

            private Guna2CheckBox chkRemember;
            private LinkLabel lnkForgot;

            private Guna2Button btnLogin;
            private LinkLabel lnkCreateAccount;

            // Colors
            private static readonly Color CardBg = Color.White;
            private static readonly Color PrimaryBlue = Color.FromArgb(37, 99, 235);
            private static readonly Color DeepBlue = Color.FromArgb(29, 78, 216);
            private static readonly Color InputFill = Color.FromArgb(243, 244, 246);
            private static readonly Color BorderDefault = Color.FromArgb(209, 213, 219);
            private static readonly Color BorderValid = Color.FromArgb(34, 197, 94);
            private static readonly Color BorderInvalid = Color.FromArgb(239, 68, 68);
            private static readonly Color DarkText = Color.FromArgb(17, 24, 39);
            private static readonly Color MutedText = Color.FromArgb(107, 114, 128);
            private static readonly Color LinkBlue = Color.FromArgb(37, 99, 235);
            private static readonly Color ErrorRed = Color.FromArgb(220, 38, 38);
            private static readonly Color DisabledGray = Color.FromArgb(156, 163, 175);

            // Dimensions
            private const int CardW = 440;
            private const int CardH = 610;

            public LoginForm(Action<string> openMainForm)
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
                Name = "LoginForm";
                Text = "Sign In";
                StartPosition = FormStartPosition.CenterScreen;
                Font = new Font("Segoe UI", 9F);
                BackColor = CardBg;
                FormBorderStyle = FormBorderStyle.FixedSingle;
                MaximizeBox = false;
                ResumeLayout(false);
            }

            private void BuildUI()
            {
                pnlCard = new Guna2Panel
                {
                    Dock = DockStyle.Fill,
                    BackColor = CardBg,
                    BorderRadius = 20,
                    BorderThickness = 0
                };
                Controls.Add(pnlCard);

                int x = 36;
                int cw = 368;
                int y = 42;

                lblTitle = new Label
                {
                    Text = "Welcome Back",
                    Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                    ForeColor = DarkText,
                    AutoSize = false,
                    Size = new Size(cw, 50),
                    Location = new Point(x, y),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                pnlCard.Controls.Add(lblTitle);
                y += 44;

                lblSubtitle = new Label
                {
                    Text = "Enter your credentials to sign in.",
                    Font = new Font("Segoe UI", 9.5F),
                    ForeColor = MutedText,
                    AutoSize = false,
                    Size = new Size(cw, 20),
                    Location = new Point(x, y),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                pnlCard.Controls.Add(lblSubtitle);
                y += 34;

                lblUsername = MakeLabel("Username", x, y);
                pnlCard.Controls.Add(lblUsername);
                y += 22;

                txtUsername = MakeTextBox(x, y, cw, "Enter your username", false);
                pnlCard.Controls.Add(txtUsername);
                y += 46;

                errUsername = MakeErrLabel(x, y, cw);
                pnlCard.Controls.Add(errUsername);
                y += 18;

                lblPassword = MakeLabel("Password", x, y);
                pnlCard.Controls.Add(lblPassword);
                y += 22;

                txtPassword = MakeTextBox(x, y, cw, "Enter your password", true);
                pnlCard.Controls.Add(txtPassword);

                togPassword = MakeEyeToggle(x + cw - 34, y + 9);
                togPassword.Click += (s, e) => ToggleVisibility(txtPassword, togPassword);
                pnlCard.Controls.Add(togPassword);
                togPassword.BringToFront();
                y += 46;

                errPassword = MakeErrLabel(x, y, cw);
                pnlCard.Controls.Add(errPassword);
                y += 22;

                chkRemember = new Guna2CheckBox
                {
                    Text = "Remember for 30 days",
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = DarkText,
                    AutoSize = false,
                    Size = new Size(200, 24),
                    Location = new Point(x, y + 2)
                };
                pnlCard.Controls.Add(chkRemember);

                lnkForgot = new LinkLabel
                {
                    Text = "Forgot Password?",
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    LinkColor = LinkBlue,
                    ActiveLinkColor = PrimaryBlue,
                    VisitedLinkColor = LinkBlue,
                    AutoSize = true,
                    Location = new Point(x + cw - 108, y + 4)
                };
                lnkForgot.LinkClicked += (s, e) =>
                    MessageBox.Show(
                        "Password reset flow is not implemented yet.",
                        "Forgot Password",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                pnlCard.Controls.Add(lnkForgot);
                y += 42;

                btnLogin = new Guna2Button
                {
                    Text = "Log In",
                    Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                    ForeColor = Color.White,
                    FillColor = DisabledGray,
                    BorderRadius = 10,
                    Size = new Size(cw, 46),
                    Location = new Point(x, y),
                    Animated = true,
                    Enabled = false
                };
                btnLogin.HoverState.FillColor = DisabledGray;
                btnLogin.Click += BtnLogin_Click;
                pnlCard.Controls.Add(btnLogin);
                y += 56;

                lnkCreateAccount = new LinkLabel
                {
                    Text = "New to the platform? Create an account",
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = MutedText,
                    LinkColor = LinkBlue,
                    ActiveLinkColor = PrimaryBlue,
                    AutoSize = false,
                    Size = new Size(cw, 22),
                    Location = new Point(x, y),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                lnkCreateAccount.LinkArea = new LinkArea(22, 16);
                lnkCreateAccount.LinkClicked += (s, e) => OpenRegister();
                pnlCard.Controls.Add(lnkCreateAccount);

                WireEvents();
            }

            private void WireEvents()
            {
                txtUsername.TextChanged += (s, e) => ValidateUsername();
                txtUsername.Leave += (s, e) => ValidateUsername();

                txtPassword.TextChanged += (s, e) => ValidatePassword();
                txtPassword.Leave += (s, e) => ValidatePassword();
            }

            private bool ValidateUsername()
            {
                string v = txtUsername.Text.Trim();

                if (string.IsNullOrEmpty(v))
                    return Fail(txtUsername, errUsername, "Username is required.");

                if (!Regex.IsMatch(v, @"^[a-zA-Z0-9_]+$"))
                    return Fail(txtUsername, errUsername, "Only letters, numbers, and underscores allowed.");

                return Pass(txtUsername, errUsername);
            }

            private bool ValidatePassword()
            {
                string p = txtPassword.Text;

                if (string.IsNullOrEmpty(p))
                    return Fail(txtPassword, errPassword, "Password is required.");

                return Pass(txtPassword, errPassword);
            }

            private bool Fail(Guna2TextBox tb, Label err, string message)
            {
                tb.BorderColor = BorderInvalid;
                tb.BorderThickness = 2;
                err.Text = message;
                err.ForeColor = ErrorRed;
                err.Visible = true;
                UpdateButtonState();
                return false;
            }

            private bool Pass(Guna2TextBox tb, Label err)
            {
                tb.BorderColor = BorderValid;
                tb.BorderThickness = 1;
                err.Text = "";
                err.Visible = false;
                UpdateButtonState();
                return true;
            }

            private void UpdateButtonState()
            {
                bool ok = IsGreen(txtUsername) && IsGreen(txtPassword);
                btnLogin.Enabled = ok;
                btnLogin.FillColor = ok ? PrimaryBlue : DisabledGray;
                btnLogin.HoverState.FillColor = ok ? DeepBlue : DisabledGray;
            }

            private static bool IsGreen(Guna2TextBox tb)
                => tb.BorderColor == Color.FromArgb(34, 197, 94);

            private static void ToggleVisibility(Guna2TextBox tb, Label toggle)
            {
                tb.UseSystemPasswordChar = !tb.UseSystemPasswordChar;
                toggle.Text = tb.UseSystemPasswordChar ? "👁" : "🔓";
            }

            private void BtnLogin_Click(object sender, EventArgs e)
            {
                bool ok = ValidateUsername() & ValidatePassword();
                if (!ok) return;

                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text;

                try
                {
                    btnLogin.Enabled = false;
                    btnLogin.Text = "Signing in...";

                    UserModel? user = DatabaseHelper.AuthenticateUser(username, password);

                    if (user == null)
                    {
                        Fail(txtUsername, errUsername, "");
                        Fail(txtPassword, errPassword, "Incorrect username or password.");
                        ShakeCard();
                    }
                    else
                    {
                        MessageBox.Show(
                            $"Welcome, {user.FirstName} {user.LastName}!\nYou are now signed in as @{user.Username}.",
                            "Login Successful",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                    // Hide this login form and notify Program with the logged-in username
                    Hide();
                    _openMainForm.Invoke(user.Username);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Login error:\n{ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    btnLogin.Enabled = true;
                    btnLogin.Text = "Log In";
                }
            }

            private async void ShakeCard()
            {
                int origX = pnlCard.Left;
                int[] offsets = { -8, 8, -6, 6, -4, 4, 0 };

                foreach (int offset in offsets)
                {
                    pnlCard.Left = origX + offset;
                    await System.Threading.Tasks.Task.Delay(30);
                }

                pnlCard.Left = origX;
            }

            private Label MakeLabel(string text, int x, int y) => new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 9F),
                ForeColor = DarkText,
                AutoSize = true,
                Location = new Point(x, y)
            };

            private Label MakeErrLabel(int x, int y, int width) => new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 7.5F),
                ForeColor = ErrorRed,
                AutoSize = false,
                Size = new Size(width, 16),
                Location = new Point(x, y),
                Visible = false
            };

            private Guna2TextBox MakeTextBox(int x, int y, int width, string placeholder, bool isPassword)
                => new Guna2TextBox
                {
                    Size = new Size(width, 44),
                    Location = new Point(x, y),
                    PlaceholderText = placeholder,
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = DarkText,
                    PlaceholderForeColor = Color.FromArgb(156, 163, 175),
                    FillColor = InputFill,
                    BorderColor = BorderDefault,
                    BorderRadius = 8,
                    BorderThickness = 1,
                    UseSystemPasswordChar = isPassword,
                    Padding = new Padding(10, 0, isPassword ? 38 : 10, 0)
                };

            private Label MakeEyeToggle(int x, int y) => new Label
            {
                Text = "👁",
                Size = new Size(28, 28),
                Location = new Point(x, y),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent,
                ForeColor = MutedText,
                Font = new Font("Segoe UI", 11F)
            };

            private void OpenRegister()
            {
                var registerForm = new RegisterForm(_openMainForm);
                registerForm.Show();
                Hide();
            }
        }
    
}














