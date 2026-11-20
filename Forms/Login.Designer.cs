namespace PMS_v1.Forms
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
            btnLogin = new Krypton.Toolkit.KryptonButton();
            panel6 = new FlowLayoutPanel();
            label2 = new Label();
            lnklblSignUp = new LinkLabel();
            lblUsername = new Krypton.Toolkit.KryptonLabel();
            txtUsername = new Krypton.Toolkit.KryptonTextBox();
            lblPassword = new Krypton.Toolkit.KryptonLabel();
            txtPassword = new Krypton.Toolkit.KryptonTextBox();
            btnShowHidePass = new Krypton.Toolkit.ButtonSpecAny();
            ((System.ComponentModel.ISupportInitialize)pnlBackground).BeginInit();
            pnlLogin.SuspendLayout();
            tlpCenter.SuspendLayout();
            pnlLoginhere.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBackground
            // 
            pnlBackground.Name = "pnlBackground";
            pnlBackground.StateCommon.Color1 = Color.SteelBlue;
            pnlBackground.StateCommon.Color2 = Color.PaleTurquoise;
            pnlBackground.StateCommon.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Linear50;
            pnlBackground.StateCommon.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.HighQuality;
            pnlBackground.StateCommon.Image = Resources.Resources.Background;
            pnlBackground.StateCommon.ImageStyle = Krypton.Toolkit.PaletteImageStyle.TileFlipY;
            pnlBackground.Dock = DockStyle.Fill;
            pnlBackground.Location = new Point(0, 0);
            pnlBackground.Size = new Size(1138, 782);
            pnlBackground.TabIndex = 0;
            // 
            // pnlLogin
            // 
            pnlLogin.BackColor = Color.White;
            pnlLogin.Controls.Add(tlpCenter);
            pnlLogin.Dock = DockStyle.Right;
            pnlLogin.Location = new Point(628, 0);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(510, 782);
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
            tlpCenter.Name = "tlpCenter";
            tlpCenter.RowCount = 3;
            tlpCenter.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpCenter.RowStyles.Add(new RowStyle());
            tlpCenter.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpCenter.Size = new Size(510, 782);
            tlpCenter.TabIndex = 0;
            // 
            // pnlLoginhere
            // 
            pnlLoginhere.Anchor = AnchorStyles.None;
            pnlLoginhere.AutoSize = true;
            pnlLoginhere.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlLoginhere.BackColor = Color.White;
            pnlLoginhere.ColumnCount = 1;
            pnlLoginhere.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 418F));
            pnlLoginhere.Controls.Add(label1, 0, 0);
            pnlLoginhere.Controls.Add(lblUsername, 0, 1);
            pnlLoginhere.Controls.Add(txtUsername, 0, 2);
            pnlLoginhere.Controls.Add(lblPassword, 0, 3);
            pnlLoginhere.Controls.Add(txtPassword, 0, 4);
            pnlLoginhere.Controls.Add(btnLogin, 0, 5);
            pnlLoginhere.Controls.Add(panel6, 0, 6);
            pnlLoginhere.Location = new Point(46, 80);
            pnlLoginhere.Name = "pnlLoginhere";
            pnlLoginhere.RowCount = 7;
            pnlLoginhere.RowStyles.Add(new RowStyle());
            pnlLoginhere.RowStyles.Add(new RowStyle());
            pnlLoginhere.RowStyles.Add(new RowStyle());
            pnlLoginhere.RowStyles.Add(new RowStyle());
            pnlLoginhere.RowStyles.Add(new RowStyle());
            pnlLoginhere.RowStyles.Add(new RowStyle(SizeType.Absolute, 94F));
            pnlLoginhere.RowStyles.Add(new RowStyle());
            pnlLoginhere.Size = new Size(418, 600);
            pnlLoginhere.TabIndex = 0;
            // 
            // label1
            // 
            label1.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Name = "label1";
            label1.Text = "Login";
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(0, 0, 0, 6);
            label1.TabIndex = 0;
            // 
            // lblUsername
            // 
            lblUsername.Name = "lblUsername";
            lblUsername.StateCommon.LongText.Color1 = Color.Red;
            lblUsername.StateCommon.ShortText.Color1 = Color.DimGray;
            lblUsername.StateCommon.ShortText.Color2 = Color.Red;
            lblUsername.StateCommon.ShortText.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.Values.ExtraText = "*";
            lblUsername.Values.Text = "Username ";
            lblUsername.Anchor = AnchorStyles.Left;
            lblUsername.Location = new Point(0, 60);
            lblUsername.Margin = new Padding(0, 10, 0, 2);
            lblUsername.Size = new Size(94, 24);
            lblUsername.TabIndex = 1;
            // 
            // txtUsername
            // 
            txtUsername.CueHint.Color1 = Color.DarkGray;
            txtUsername.CueHint.CueHintText = "Enter Username";
            txtUsername.CueHint.Font = new Font("Century Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Name = "txtUsername";
            txtUsername.StateCommon.Back.Color1 = SystemColors.ControlLight;
            txtUsername.StateCommon.Border.Color1 = SystemColors.ControlLight;
            txtUsername.StateCommon.Border.Color2 = SystemColors.ControlLight;
            txtUsername.StateCommon.Border.Rounding = 3F;
            txtUsername.StateCommon.Border.Width = 20;
            txtUsername.StateCommon.Content.Color1 = Color.Black;
            txtUsername.StateCommon.Content.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.StateCommon.Content.Padding = new Padding(6, -1, -1, -1);
            txtUsername.Dock = DockStyle.Fill;
            txtUsername.Location = new Point(0, 88);
            txtUsername.Margin = new Padding(0, 0, 0, 6);
            txtUsername.Size = new Size(418, 63);
            txtUsername.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.Name = "lblPassword";
            lblPassword.StateCommon.LongText.Color1 = Color.Red;
            lblPassword.StateCommon.ShortText.Color1 = Color.DimGray;
            lblPassword.StateCommon.ShortText.Color2 = Color.Red;
            lblPassword.StateCommon.ShortText.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.Values.ExtraText = "*";
            lblPassword.Values.Text = "Password";
            lblPassword.Anchor = AnchorStyles.Left;
            lblPassword.Location = new Point(0, 60);
            lblPassword.Margin = new Padding(0, 10, 0, 2);
            lblPassword.Size = new Size(94, 24);
            lblPassword.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.ButtonSpecs.Add(btnShowHidePass);
            txtPassword.CueHint.Color1 = Color.DarkGray;
            txtPassword.CueHint.CueHintText = "Enter Password";
            txtPassword.CueHint.Font = new Font("Century Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Name = "txtPassword";
            txtPassword.StateCommon.Back.Color1 = SystemColors.ControlLight;
            txtPassword.StateCommon.Border.Color1 = SystemColors.ControlLight;
            txtPassword.StateCommon.Border.Color2 = SystemColors.ControlLight;
            txtPassword.StateCommon.Border.Rounding = 3F;
            txtPassword.StateCommon.Border.Width = 20;
            txtPassword.StateCommon.Content.Color1 = Color.Black;
            txtPassword.StateCommon.Content.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.StateCommon.Content.Padding = new Padding(6, -1, -1, -1);
            txtPassword.Dock = DockStyle.Fill;
            txtPassword.Location = new Point(0, 88);
            txtPassword.Margin = new Padding(0, 0, 0, 6);
            txtPassword.Size = new Size(418, 63);
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
            btnLogin.Name = "btnLogin";
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
            btnLogin.Values.DropDownArrowColor = Color.Empty;
            btnLogin.Values.Text = "Login\r\n";
            btnLogin.Click += btnLogin_Click;
            btnLogin.Dock = DockStyle.Fill;
            btnLogin.Location = new Point(0, 0);
            btnLogin.Margin = new Padding(0, 16, 0, 14);
            btnLogin.Size = new Size(418, 64);
            btnLogin.TabIndex = 5;
            // 
            // panel6
            // 
            panel6.AutoSize = true;
            panel6.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel6.Controls.Add(label2);
            panel6.Controls.Add(lnklblSignUp);
            panel6.Location = new Point(0, 0);
            panel6.Margin = new Padding(0);
            panel6.Name = "panel6";
            panel6.Size = new Size(260, 24);
            panel6.TabIndex = 6;
            // 
            // label2
            // 
            label2.Font = new Font("Century Gothic", 10.2F);
            label2.ForeColor = Color.Black;
            label2.Name = "label2";
            label2.Text = "Don't have an account?";
            label2.AutoSize = true;
            label2.Location = new Point(0, 0);
            label2.Margin = new Padding(0, 0, 4, 0);
            label2.TabIndex = 0;
            // 
            // lnklblSignUp
            // 
            lnklblSignUp.Font = new Font("Century Gothic", 10.2F);
            lnklblSignUp.ForeColor = Color.Black;
            lnklblSignUp.Name = "lnklblSignUp";
            lnklblSignUp.TabStop = true;
            lnklblSignUp.Text = "Sign up here.";
            lnklblSignUp.LinkClicked += lnklblSignUp_LinkClicked;
            lnklblSignUp.AutoSize = true;
            lnklblSignUp.Location = new Point(0, 0);
            lnklblSignUp.Margin = new Padding(0);
            lnklblSignUp.TabIndex = 1;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1138, 782);
            Controls.Add(pnlLogin);
            Controls.Add(pnlBackground);
            MinimumSize = new Size(800, 640);
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
