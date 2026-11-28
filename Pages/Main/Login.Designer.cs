namespace PMS_v1.Pages.Main
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlBackground = new Krypton.Toolkit.KryptonPanel();
            pnlLogin = new Panel();
            tlpCenter = new TableLayoutPanel();
            pnlLoginhere = new TableLayoutPanel();
            label1 = new Label();
            lblUsername = new Krypton.Toolkit.KryptonLabel();
            txtUsername = new Krypton.Toolkit.KryptonTextBox();
            lblPassword = new Krypton.Toolkit.KryptonLabel();
            txtPassword = new Krypton.Toolkit.KryptonTextBox();
            btnShowHidePass = new Krypton.Toolkit.ButtonSpecAny();
            btnLogin = new Krypton.Toolkit.KryptonButton();
            panel6 = new FlowLayoutPanel();
            label2 = new Label();
            lnklblSignUp = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pnlBackground).BeginInit();
            pnlLogin.SuspendLayout();
            tlpCenter.SuspendLayout();
            pnlLoginhere.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBackground
            // 
            pnlBackground.Dock = DockStyle.Fill;
            pnlBackground.Location = new Point(0, 0);
            pnlBackground.Margin = new Padding(4);
            pnlBackground.Name = "pnlBackground";
            pnlBackground.Size = new Size(1422, 978);
            pnlBackground.StateCommon.Color1 = Color.SteelBlue;
            pnlBackground.StateCommon.Color2 = Color.PaleTurquoise;
            pnlBackground.StateCommon.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Linear50;
            pnlBackground.StateCommon.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.HighQuality;
            pnlBackground.StateCommon.Image = Resources.Resources.Background;
            pnlBackground.StateCommon.ImageStyle = Krypton.Toolkit.PaletteImageStyle.TileFlipY;
            pnlBackground.TabIndex = 0;
            // 
            // pnlLogin
            // 
            pnlLogin.BackColor = Color.White;
            pnlLogin.Controls.Add(tlpCenter);
            pnlLogin.Dock = DockStyle.Right;
            pnlLogin.Location = new Point(784, 0);
            pnlLogin.Margin = new Padding(4);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(638, 978);
            pnlLogin.TabIndex = 1;
            // 
            // tlpCenter
            // 
            tlpCenter.BackColor = Color.White;
            tlpCenter.ColumnCount = 1;
            tlpCenter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpCenter.Controls.Add(pnlLoginhere, 0, 1);
            tlpCenter.Dock = DockStyle.Fill;
            tlpCenter.Location = new Point(0, 0);
            tlpCenter.Margin = new Padding(4);
            tlpCenter.Name = "tlpCenter";
            tlpCenter.RowCount = 3;
            tlpCenter.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpCenter.RowStyles.Add(new RowStyle());
            tlpCenter.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpCenter.Size = new Size(638, 978);
            tlpCenter.TabIndex = 0;
            // 
            // pnlLoginhere
            // 
            pnlLoginhere.Anchor = AnchorStyles.None;
            pnlLoginhere.AutoSize = true;
            pnlLoginhere.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlLoginhere.BackColor = Color.White;
            pnlLoginhere.ColumnCount = 1;
            pnlLoginhere.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 522F));
            pnlLoginhere.Controls.Add(label1, 0, 0);
            pnlLoginhere.Controls.Add(lblUsername, 0, 1);
            pnlLoginhere.Controls.Add(txtUsername, 0, 2);
            pnlLoginhere.Controls.Add(lblPassword, 0, 3);
            pnlLoginhere.Controls.Add(txtPassword, 0, 4);
            pnlLoginhere.Controls.Add(btnLogin, 0, 5);
            pnlLoginhere.Controls.Add(panel6, 0, 6);
            pnlLoginhere.Location = new Point(58, 269);
            pnlLoginhere.Margin = new Padding(4);
            pnlLoginhere.Name = "pnlLoginhere";
            pnlLoginhere.RowCount = 7;
            pnlLoginhere.RowStyles.Add(new RowStyle());
            pnlLoginhere.RowStyles.Add(new RowStyle());
            pnlLoginhere.RowStyles.Add(new RowStyle());
            pnlLoginhere.RowStyles.Add(new RowStyle());
            pnlLoginhere.RowStyles.Add(new RowStyle());
            pnlLoginhere.RowStyles.Add(new RowStyle(SizeType.Absolute, 118F));
            pnlLoginhere.RowStyles.Add(new RowStyle());
            pnlLoginhere.Size = new Size(522, 439);
            pnlLoginhere.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(0, 0, 0, 8);
            label1.Name = "label1";
            label1.Size = new Size(104, 40);
            label1.TabIndex = 0;
            label1.Text = "Login";
            // 
            // lblUsername
            // 
            lblUsername.Anchor = AnchorStyles.Left;
            lblUsername.Location = new Point(0, 60);
            lblUsername.Margin = new Padding(0, 12, 0, 2);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(111, 25);
            lblUsername.StateCommon.LongText.Color1 = Color.Red;
            lblUsername.StateCommon.ShortText.Color1 = Color.DimGray;
            lblUsername.StateCommon.ShortText.Color2 = Color.Red;
            lblUsername.StateCommon.ShortText.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.TabIndex = 1;
            lblUsername.Values.ExtraText = "*";
            lblUsername.Values.Text = "Username ";
            // 
            // txtUsername
            // 
            txtUsername.CueHint.Color1 = Color.DarkGray;
            txtUsername.CueHint.CueHintText = "Enter Username";
            txtUsername.CueHint.Font = new Font("Century Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Dock = DockStyle.Fill;
            txtUsername.Location = new Point(0, 87);
            txtUsername.Margin = new Padding(0, 0, 0, 8);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(522, 79);
            txtUsername.StateCommon.Back.Color1 = SystemColors.ControlLight;
            txtUsername.StateCommon.Border.Color1 = SystemColors.ControlLight;
            txtUsername.StateCommon.Border.Color2 = SystemColors.ControlLight;
            txtUsername.StateCommon.Border.Rounding = 3F;
            txtUsername.StateCommon.Border.Width = 20;
            txtUsername.StateCommon.Content.Color1 = Color.Black;
            txtUsername.StateCommon.Content.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.StateCommon.Content.Padding = new Padding(6, -1, -1, -1);
            txtUsername.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.Anchor = AnchorStyles.Left;
            lblPassword.Location = new Point(0, 186);
            lblPassword.Margin = new Padding(0, 12, 0, 2);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(104, 25);
            lblPassword.StateCommon.LongText.Color1 = Color.Red;
            lblPassword.StateCommon.ShortText.Color1 = Color.DimGray;
            lblPassword.StateCommon.ShortText.Color2 = Color.Red;
            lblPassword.StateCommon.ShortText.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.TabIndex = 3;
            lblPassword.Values.ExtraText = "*";
            lblPassword.Values.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.ButtonSpecs.Add(btnShowHidePass);
            txtPassword.CueHint.Color1 = Color.DarkGray;
            txtPassword.CueHint.CueHintText = "Enter Password";
            txtPassword.CueHint.Font = new Font("Century Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Dock = DockStyle.Fill;
            txtPassword.Location = new Point(0, 213);
            txtPassword.Margin = new Padding(0, 0, 0, 8);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(522, 79);
            txtPassword.StateCommon.Back.Color1 = SystemColors.ControlLight;
            txtPassword.StateCommon.Border.Color1 = SystemColors.ControlLight;
            txtPassword.StateCommon.Border.Color2 = SystemColors.ControlLight;
            txtPassword.StateCommon.Border.Rounding = 3F;
            txtPassword.StateCommon.Border.Width = 20;
            txtPassword.StateCommon.Content.Color1 = Color.Black;
            txtPassword.StateCommon.Content.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.StateCommon.Content.Padding = new Padding(6, -1, -1, -1);
            txtPassword.TabIndex = 4;
            // 
            // btnShowHidePass
            // 
            btnShowHidePass.ColorMap = Color.White;
            btnShowHidePass.Edge = Krypton.Toolkit.PaletteRelativeEdgeAlign.Far;
            btnShowHidePass.Image = Resources.Resources.EyeClose;
            btnShowHidePass.ImageTransparentColor = Color.Transparent;
            btnShowHidePass.Style = Krypton.Toolkit.PaletteButtonStyle.ButtonSpec;
            btnShowHidePass.ToolTipShadow = false;
            btnShowHidePass.Type = Krypton.Toolkit.PaletteButtonSpecStyle.Open;
            btnShowHidePass.UniqueName = "172cf345460948dc8c54dfb80c1c8a81";
            // 
            // btnLogin
            // 
            btnLogin.Dock = DockStyle.Fill;
            btnLogin.Location = new Point(0, 320);
            btnLogin.Margin = new Padding(0, 20, 0, 18);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(522, 80);
            btnLogin.StateCommon.Back.Color1 = Color.Transparent;
            btnLogin.StateCommon.Back.Color2 = Color.Transparent;
            btnLogin.StateCommon.Back.Image = Resources.Resources.ButtonBlue;
            btnLogin.StateCommon.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Stretch;
            btnLogin.StateCommon.Border.Color1 = Color.FromArgb(224, 224, 224);
            btnLogin.StateCommon.Border.Color2 = Color.FromArgb(224, 224, 224);
            btnLogin.StateCommon.Border.Rounding = 60F;
            btnLogin.StateCommon.Content.Image.ImageColorMap = Color.Silver;
            btnLogin.StateCommon.Content.Image.ImageColorTo = Color.Silver;
            btnLogin.StateCommon.Content.ShortText.Color1 = Color.White;
            btnLogin.StateCommon.Content.ShortText.Color2 = Color.Gainsboro;
            btnLogin.StateCommon.Content.ShortText.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.TabIndex = 5;
            btnLogin.Values.DropDownArrowColor = Color.Empty;
            btnLogin.Values.Text = "Login\r\n";
            btnLogin.Click += btnLogin_Click;
            // 
            // panel6
            // 
            panel6.AutoSize = true;
            panel6.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel6.Controls.Add(label2);
            panel6.Controls.Add(lnklblSignUp);
            panel6.Location = new Point(0, 418);
            panel6.Margin = new Padding(0);
            panel6.Name = "panel6";
            panel6.Size = new Size(338, 21);
            panel6.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 10.2F);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(0, 0);
            label2.Margin = new Padding(0, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(217, 21);
            label2.TabIndex = 0;
            label2.Text = "Don't have an account?";
            // 
            // lnklblSignUp
            // 
            lnklblSignUp.AutoSize = true;
            lnklblSignUp.Font = new Font("Century Gothic", 10.2F);
            lnklblSignUp.ForeColor = Color.Black;
            lnklblSignUp.Location = new Point(222, 0);
            lnklblSignUp.Margin = new Padding(0);
            lnklblSignUp.Name = "lnklblSignUp";
            lnklblSignUp.Size = new Size(116, 21);
            lnklblSignUp.TabIndex = 1;
            lnklblSignUp.TabStop = true;
            lnklblSignUp.Text = "Sign up here.";
            lnklblSignUp.LinkClicked += lnklblSignUp_LinkClicked;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1422, 978);
            Controls.Add(pnlLogin);
            Controls.Add(pnlBackground);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MinimumSize = new Size(996, 788);
            Name = "Login";
            Text = "Login";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pnlBackground).EndInit();
            pnlLogin.ResumeLayout(false);
            tlpCenter.ResumeLayout(false);
            tlpCenter.PerformLayout();
            pnlLoginhere.ResumeLayout(false);
            pnlLoginhere.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Krypton.Toolkit.KryptonPanel pnlBackground;
        private Panel pnlLogin;
        private TableLayoutPanel tlpCenter;
        private TableLayoutPanel pnlLoginhere;
        private Label label1;
        private Krypton.Toolkit.KryptonLabel lblUsername;
        private Krypton.Toolkit.KryptonTextBox txtUsername;
        private Krypton.Toolkit.KryptonLabel lblPassword;
        private Krypton.Toolkit.KryptonTextBox txtPassword;
        private Krypton.Toolkit.ButtonSpecAny btnShowHidePass;
        private Krypton.Toolkit.KryptonButton btnLogin;
        private FlowLayoutPanel panel6;
        private Label label2;
        private LinkLabel lnklblSignUp;
    }
}
