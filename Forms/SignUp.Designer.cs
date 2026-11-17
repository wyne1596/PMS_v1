namespace PMS_v1.Forms
{
    partial class SignUp
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
            btnSignUp = new Krypton.Toolkit.KryptonButton();
            panel6 = new FlowLayoutPanel();
            label2 = new Label();
            lnklblLogin = new LinkLabel();
            lblUsername = new Krypton.Toolkit.KryptonLabel();
            txtEmployeeNumber = new Krypton.Toolkit.KryptonTextBox();
            kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            txtLastName = new Krypton.Toolkit.KryptonTextBox();
            kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            txtUsername = new Krypton.Toolkit.KryptonTextBox();
            kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            txtPassword = new Krypton.Toolkit.KryptonTextBox();
            kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            txtRePassword = new Krypton.Toolkit.KryptonTextBox();
            btnShowHidePass1 = new Krypton.Toolkit.ButtonSpecAny();
            btnShowHidePass2 = new Krypton.Toolkit.ButtonSpecAny();
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
            pnlBackground.StateCommon.Image = Resources.Resources.BG;
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
            pnlLoginhere.Controls.Add(txtEmployeeNumber, 0, 2);
            pnlLoginhere.Controls.Add(kryptonLabel1, 0, 3);
            pnlLoginhere.Controls.Add(txtLastName, 0, 4);
            pnlLoginhere.Controls.Add(kryptonLabel2, 0, 5);
            pnlLoginhere.Controls.Add(txtUsername, 0, 6);
            pnlLoginhere.Controls.Add(kryptonLabel3, 0, 7);
            pnlLoginhere.Controls.Add(txtPassword, 0, 8);
            pnlLoginhere.Controls.Add(kryptonLabel4, 0, 9);
            pnlLoginhere.Controls.Add(txtRePassword, 0, 10);
            pnlLoginhere.Controls.Add(btnSignUp, 0, 11);
            pnlLoginhere.Controls.Add(panel6, 0, 12);
            pnlLoginhere.Location = new Point(46, 80);
            pnlLoginhere.Name = "pnlLoginhere";
            pnlLoginhere.RowCount = 13;
            pnlLoginhere.RowStyles.Add(new RowStyle());
            pnlLoginhere.RowStyles.Add(new RowStyle());
            pnlLoginhere.RowStyles.Add(new RowStyle());
            pnlLoginhere.RowStyles.Add(new RowStyle());
            pnlLoginhere.RowStyles.Add(new RowStyle());
            pnlLoginhere.RowStyles.Add(new RowStyle());
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
            label1.Text = "Sign-Up";
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
            lblUsername.Values.Text = "Employee Number ";
            lblUsername.Anchor = AnchorStyles.Left;
            lblUsername.Location = new Point(0, 60);
            lblUsername.Margin = new Padding(0, 10, 0, 2);
            lblUsername.Size = new Size(94, 24);
            lblUsername.TabIndex = 1;
            // 
            // txtEmployeeNumber
            // 
            txtEmployeeNumber.CueHint.Color1 = Color.DarkGray;
            txtEmployeeNumber.CueHint.CueHintText = "20##-#####";
            txtEmployeeNumber.CueHint.Font = new Font("Century Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmployeeNumber.Name = "txtEmployeeNumber";
            txtEmployeeNumber.StateCommon.Back.Color1 = SystemColors.ControlLight;
            txtEmployeeNumber.StateCommon.Border.Color1 = SystemColors.ControlLight;
            txtEmployeeNumber.StateCommon.Border.Color2 = SystemColors.ControlLight;
            txtEmployeeNumber.StateCommon.Border.Rounding = 3F;
            txtEmployeeNumber.StateCommon.Border.Width = 15;
            txtEmployeeNumber.StateCommon.Content.Color1 = Color.Black;
            txtEmployeeNumber.StateCommon.Content.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmployeeNumber.StateCommon.Content.Padding = new Padding(6, -1, -1, -1);
            txtEmployeeNumber.Dock = DockStyle.Fill;
            txtEmployeeNumber.Location = new Point(0, 88);
            txtEmployeeNumber.Margin = new Padding(0, 0, 0, 6);
            txtEmployeeNumber.Size = new Size(418, 55);
            txtEmployeeNumber.TabIndex = 2;
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.StateCommon.LongText.Color1 = Color.Red;
            kryptonLabel1.StateCommon.ShortText.Color1 = Color.DimGray;
            kryptonLabel1.StateCommon.ShortText.Color2 = Color.Red;
            kryptonLabel1.StateCommon.ShortText.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            kryptonLabel1.Values.ExtraText = "*";
            kryptonLabel1.Values.Text = "Last Name";
            kryptonLabel1.Anchor = AnchorStyles.Left;
            kryptonLabel1.Location = new Point(0, 60);
            kryptonLabel1.Margin = new Padding(0, 10, 0, 2);
            kryptonLabel1.Size = new Size(94, 24);
            kryptonLabel1.TabIndex = 3;
            // 
            // txtLastName
            // 
            txtLastName.CueHint.Color1 = Color.DarkGray;
            txtLastName.CueHint.CueHintText = "Enter Last Name";
            txtLastName.CueHint.Font = new Font("Century Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLastName.Name = "txtLastName";
            txtLastName.StateCommon.Back.Color1 = SystemColors.ControlLight;
            txtLastName.StateCommon.Border.Color1 = SystemColors.ControlLight;
            txtLastName.StateCommon.Border.Color2 = SystemColors.ControlLight;
            txtLastName.StateCommon.Border.Rounding = 3F;
            txtLastName.StateCommon.Border.Width = 15;
            txtLastName.StateCommon.Content.Color1 = Color.Black;
            txtLastName.StateCommon.Content.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLastName.StateCommon.Content.Padding = new Padding(6, -1, -1, -1);
            txtLastName.Dock = DockStyle.Fill;
            txtLastName.Location = new Point(0, 88);
            txtLastName.Margin = new Padding(0, 0, 0, 6);
            txtLastName.Size = new Size(418, 55);
            txtLastName.TabIndex = 4;
            // 
            // kryptonLabel2
            // 
            kryptonLabel2.Name = "kryptonLabel2";
            kryptonLabel2.StateCommon.LongText.Color1 = Color.Red;
            kryptonLabel2.StateCommon.ShortText.Color1 = Color.DimGray;
            kryptonLabel2.StateCommon.ShortText.Color2 = Color.Red;
            kryptonLabel2.StateCommon.ShortText.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            kryptonLabel2.Values.ExtraText = "*";
            kryptonLabel2.Values.Text = "Username";
            kryptonLabel2.Anchor = AnchorStyles.Left;
            kryptonLabel2.Location = new Point(0, 60);
            kryptonLabel2.Margin = new Padding(0, 10, 0, 2);
            kryptonLabel2.Size = new Size(94, 24);
            kryptonLabel2.TabIndex = 5;
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
            txtUsername.StateCommon.Border.Width = 15;
            txtUsername.StateCommon.Content.Color1 = Color.Black;
            txtUsername.StateCommon.Content.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.StateCommon.Content.Padding = new Padding(6, -1, -1, -1);
            txtUsername.Dock = DockStyle.Fill;
            txtUsername.Location = new Point(0, 88);
            txtUsername.Margin = new Padding(0, 0, 0, 6);
            txtUsername.Size = new Size(418, 55);
            txtUsername.TabIndex = 6;
            // 
            // kryptonLabel3
            // 
            kryptonLabel3.Name = "kryptonLabel3";
            kryptonLabel3.StateCommon.LongText.Color1 = Color.Red;
            kryptonLabel3.StateCommon.ShortText.Color1 = Color.DimGray;
            kryptonLabel3.StateCommon.ShortText.Color2 = Color.Red;
            kryptonLabel3.StateCommon.ShortText.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            kryptonLabel3.Values.ExtraText = "*";
            kryptonLabel3.Values.Text = "Password";
            kryptonLabel3.Anchor = AnchorStyles.Left;
            kryptonLabel3.Location = new Point(0, 60);
            kryptonLabel3.Margin = new Padding(0, 10, 0, 2);
            kryptonLabel3.Size = new Size(94, 24);
            kryptonLabel3.TabIndex = 7;
            // 
            // txtPassword
            // 
            txtPassword.ButtonSpecs.Add(btnShowHidePass1);
            txtPassword.CueHint.Color1 = Color.DarkGray;
            txtPassword.CueHint.CueHintText = "Enter Password";
            txtPassword.CueHint.Font = new Font("Century Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Name = "txtPassword";
            txtPassword.StateCommon.Back.Color1 = SystemColors.ControlLight;
            txtPassword.StateCommon.Border.Color1 = SystemColors.ControlLight;
            txtPassword.StateCommon.Border.Color2 = SystemColors.ControlLight;
            txtPassword.StateCommon.Border.Rounding = 3F;
            txtPassword.StateCommon.Border.Width = 15;
            txtPassword.StateCommon.Content.Color1 = Color.Black;
            txtPassword.StateCommon.Content.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.StateCommon.Content.Padding = new Padding(6, -1, -1, -1);
            txtPassword.Dock = DockStyle.Fill;
            txtPassword.Location = new Point(0, 88);
            txtPassword.Margin = new Padding(0, 0, 0, 6);
            txtPassword.Size = new Size(418, 55);
            txtPassword.TabIndex = 8;
            // 
            // kryptonLabel4
            // 
            kryptonLabel4.Name = "kryptonLabel4";
            kryptonLabel4.StateCommon.LongText.Color1 = Color.Red;
            kryptonLabel4.StateCommon.ShortText.Color1 = Color.DimGray;
            kryptonLabel4.StateCommon.ShortText.Color2 = Color.Red;
            kryptonLabel4.StateCommon.ShortText.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            kryptonLabel4.Values.ExtraText = "*";
            kryptonLabel4.Values.Text = "Re-Type Password";
            kryptonLabel4.Anchor = AnchorStyles.Left;
            kryptonLabel4.Location = new Point(0, 60);
            kryptonLabel4.Margin = new Padding(0, 10, 0, 2);
            kryptonLabel4.Size = new Size(94, 24);
            kryptonLabel4.TabIndex = 9;
            // 
            // txtRePassword
            // 
            txtRePassword.ButtonSpecs.Add(btnShowHidePass2);
            txtRePassword.CueHint.Color1 = Color.DarkGray;
            txtRePassword.CueHint.CueHintText = "Enter Password";
            txtRePassword.CueHint.Font = new Font("Century Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRePassword.Name = "txtRePassword";
            txtRePassword.StateCommon.Back.Color1 = SystemColors.ControlLight;
            txtRePassword.StateCommon.Border.Color1 = SystemColors.ControlLight;
            txtRePassword.StateCommon.Border.Color2 = SystemColors.ControlLight;
            txtRePassword.StateCommon.Border.Rounding = 3F;
            txtRePassword.StateCommon.Border.Width = 15;
            txtRePassword.StateCommon.Content.Color1 = Color.Black;
            txtRePassword.StateCommon.Content.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRePassword.StateCommon.Content.Padding = new Padding(6, -1, -1, -1);
            txtRePassword.Dock = DockStyle.Fill;
            txtRePassword.Location = new Point(0, 88);
            txtRePassword.Margin = new Padding(0, 0, 0, 6);
            txtRePassword.Size = new Size(418, 55);
            txtRePassword.TabIndex = 10;
            // 
            // btnShowHidePass1
            // 
            btnShowHidePass1.Image = Resources.Resources.EyeClose;
            btnShowHidePass1.Style = Krypton.Toolkit.PaletteButtonStyle.ButtonSpec;
            btnShowHidePass1.Type = Krypton.Toolkit.PaletteButtonSpecStyle.Open;
            btnShowHidePass1.UniqueName = "a464c704ba654ef58c36e20eec395c30";
            // 
            // btnShowHidePass2
            // 
            btnShowHidePass2.Image = Resources.Resources.EyeClose;
            btnShowHidePass2.Style = Krypton.Toolkit.PaletteButtonStyle.ButtonSpec;
            btnShowHidePass2.Type = Krypton.Toolkit.PaletteButtonSpecStyle.Open;
            btnShowHidePass2.UniqueName = "e25f25fd495f49d0ab0dfc2fca307470";
            // 
            // btnSignUp
            // 
            btnSignUp.Name = "btnSignUp";
            btnSignUp.StateCommon.Back.Color1 = Color.Transparent;
            btnSignUp.StateCommon.Back.Color2 = Color.Transparent;
            btnSignUp.StateCommon.Back.Image = Resources.Resources.ButtonBlue;
            btnSignUp.StateCommon.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Stretch;
            btnSignUp.StateCommon.Border.Color1 = Color.FromArgb(224, 224, 224);
            btnSignUp.StateCommon.Border.Color2 = Color.FromArgb(224, 224, 224);
            btnSignUp.StateCommon.Border.Rounding = 60F;
            btnSignUp.StateCommon.Content.Image.ImageColorMap = Color.Silver;
            btnSignUp.StateCommon.Content.Image.ImageColorTo = Color.Silver;
            btnSignUp.StateCommon.Content.ShortText.Color1 = Color.White;
            btnSignUp.StateCommon.Content.ShortText.Color2 = Color.Gainsboro;
            btnSignUp.StateCommon.Content.ShortText.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSignUp.Values.DropDownArrowColor = Color.Empty;
            btnSignUp.Values.Text = "Sign-Up";
            btnSignUp.Click += btnSignUp_Click;
            btnSignUp.Dock = DockStyle.Fill;
            btnSignUp.Location = new Point(0, 0);
            btnSignUp.Margin = new Padding(0, 16, 0, 14);
            btnSignUp.Size = new Size(418, 64);
            btnSignUp.TabIndex = 11;
            // 
            // panel6
            // 
            panel6.AutoSize = true;
            panel6.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel6.Controls.Add(label2);
            panel6.Controls.Add(lnklblLogin);
            panel6.Location = new Point(0, 0);
            panel6.Margin = new Padding(0);
            panel6.Name = "panel6";
            panel6.Size = new Size(260, 24);
            panel6.TabIndex = 12;
            // 
            // label2
            // 
            label2.Font = new Font("Century Gothic", 10.2F);
            label2.ForeColor = Color.Black;
            label2.Name = "label2";
            label2.Text = "Already have an account?";
            label2.AutoSize = true;
            label2.Location = new Point(0, 0);
            label2.Margin = new Padding(0, 0, 4, 0);
            label2.TabIndex = 0;
            // 
            // lnklblLogin
            // 
            lnklblLogin.Font = new Font("Century Gothic", 10.2F);
            lnklblLogin.ForeColor = Color.Black;
            lnklblLogin.Name = "lnklblLogin";
            lnklblLogin.TabStop = true;
            lnklblLogin.Text = "Login here.";
            lnklblLogin.LinkClicked += lnklblLogin_LinkClicked;
            lnklblLogin.AutoSize = true;
            lnklblLogin.Location = new Point(0, 0);
            lnklblLogin.Margin = new Padding(0);
            lnklblLogin.TabIndex = 1;
            // 
            // SignUp
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1138, 782);
            Controls.Add(pnlLogin);
            Controls.Add(pnlBackground);
            MinimumSize = new Size(800, 640);
            Name = "SignUp";
            Text = "SignUp";
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
        private Krypton.Toolkit.KryptonTextBox txtEmployeeNumber;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonTextBox txtLastName;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonTextBox txtUsername;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonTextBox txtPassword;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonTextBox txtRePassword;
        private Krypton.Toolkit.ButtonSpecAny btnShowHidePass1;
        private Krypton.Toolkit.ButtonSpecAny btnShowHidePass2;
        private Krypton.Toolkit.KryptonButton btnSignUp;
        private FlowLayoutPanel panel6;
        private Label label2;
        private LinkLabel lnklblLogin;
    }
}
