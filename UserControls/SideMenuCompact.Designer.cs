namespace PMS_v1.UserControls
{
    partial class SideMenuCompact
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlFoot = new Panel();
            btnLogout = new Button();
            btnSettings = new Button();
            pnlMenu = new Panel();
            btnReports = new Button();
            btnMaintenance = new Button();
            btnPayment = new Button();
            btnBilling = new Button();
            btnLeasing = new Button();
            btnUnits = new Button();
            btnDashboard = new Button();
            pnlDivider = new Panel();
            pnlHead = new Panel();
            pnlFoot.SuspendLayout();
            pnlMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFoot
            // 
            pnlFoot.BackColor = Color.Transparent;
            pnlFoot.Controls.Add(btnLogout);
            pnlFoot.Controls.Add(btnSettings);
            pnlFoot.Dock = DockStyle.Bottom;
            pnlFoot.Location = new Point(0, 839);
            pnlFoot.Name = "pnlFoot";
            pnlFoot.Size = new Size(95, 186);
            pnlFoot.TabIndex = 6;
            // 
            // btnLogout
            // 
            btnLogout.Dock = DockStyle.Top;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Image = Resources.Resources.Logout;
            btnLogout.Location = new Point(0, 80);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(95, 80);
            btnLogout.TabIndex = 8;
            btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnSettings
            // 
            btnSettings.Dock = DockStyle.Top;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSettings.ForeColor = Color.White;
            btnSettings.Image = Resources.Resources.Settings;
            btnSettings.Location = new Point(0, 0);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(95, 80);
            btnSettings.TabIndex = 7;
            btnSettings.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSettings.UseVisualStyleBackColor = true;
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.Transparent;
            pnlMenu.Controls.Add(btnReports);
            pnlMenu.Controls.Add(btnMaintenance);
            pnlMenu.Controls.Add(btnPayment);
            pnlMenu.Controls.Add(btnBilling);
            pnlMenu.Controls.Add(btnLeasing);
            pnlMenu.Controls.Add(btnUnits);
            pnlMenu.Controls.Add(btnDashboard);
            pnlMenu.Dock = DockStyle.Fill;
            pnlMenu.Location = new Point(0, 149);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Padding = new Padding(0, 20, 0, 0);
            pnlMenu.Size = new Size(95, 690);
            pnlMenu.TabIndex = 7;
            // 
            // btnReports
            // 
            btnReports.Dock = DockStyle.Top;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReports.ForeColor = Color.White;
            btnReports.Image = Resources.Resources.Reports;
            btnReports.Location = new Point(0, 500);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(95, 80);
            btnReports.TabIndex = 6;
            btnReports.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReports.UseVisualStyleBackColor = true;
            // 
            // btnMaintenance
            // 
            btnMaintenance.Dock = DockStyle.Top;
            btnMaintenance.FlatAppearance.BorderSize = 0;
            btnMaintenance.FlatStyle = FlatStyle.Flat;
            btnMaintenance.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMaintenance.ForeColor = Color.White;
            btnMaintenance.Image = Resources.Resources.Maintenance1;
            btnMaintenance.Location = new Point(0, 420);
            btnMaintenance.Name = "btnMaintenance";
            btnMaintenance.Size = new Size(95, 80);
            btnMaintenance.TabIndex = 5;
            btnMaintenance.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMaintenance.UseVisualStyleBackColor = true;
            // 
            // btnPayment
            // 
            btnPayment.Dock = DockStyle.Top;
            btnPayment.FlatAppearance.BorderSize = 0;
            btnPayment.FlatStyle = FlatStyle.Flat;
            btnPayment.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPayment.ForeColor = Color.White;
            btnPayment.Image = Resources.Resources.Payment1;
            btnPayment.Location = new Point(0, 340);
            btnPayment.Name = "btnPayment";
            btnPayment.Size = new Size(95, 80);
            btnPayment.TabIndex = 4;
            btnPayment.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPayment.UseVisualStyleBackColor = true;
            // 
            // btnBilling
            // 
            btnBilling.Dock = DockStyle.Top;
            btnBilling.FlatAppearance.BorderSize = 0;
            btnBilling.FlatStyle = FlatStyle.Flat;
            btnBilling.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBilling.ForeColor = Color.White;
            btnBilling.Image = Resources.Resources.bill1;
            btnBilling.Location = new Point(0, 260);
            btnBilling.Name = "btnBilling";
            btnBilling.Size = new Size(95, 80);
            btnBilling.TabIndex = 3;
            btnBilling.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBilling.UseVisualStyleBackColor = true;
            // 
            // btnLeasing
            // 
            btnLeasing.Dock = DockStyle.Top;
            btnLeasing.FlatAppearance.BorderSize = 0;
            btnLeasing.FlatStyle = FlatStyle.Flat;
            btnLeasing.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLeasing.ForeColor = Color.White;
            btnLeasing.Image = Resources.Resources.Lease;
            btnLeasing.Location = new Point(0, 180);
            btnLeasing.Name = "btnLeasing";
            btnLeasing.Size = new Size(95, 80);
            btnLeasing.TabIndex = 2;
            btnLeasing.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLeasing.UseVisualStyleBackColor = true;
            // 
            // btnUnits
            // 
            btnUnits.Dock = DockStyle.Top;
            btnUnits.FlatAppearance.BorderSize = 0;
            btnUnits.FlatStyle = FlatStyle.Flat;
            btnUnits.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUnits.ForeColor = Color.White;
            btnUnits.Image = Resources.Resources.Property;
            btnUnits.Location = new Point(0, 100);
            btnUnits.Name = "btnUnits";
            btnUnits.Size = new Size(95, 80);
            btnUnits.TabIndex = 1;
            btnUnits.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUnits.UseVisualStyleBackColor = true;
            // 
            // btnDashboard
            // 
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Image = Resources.Resources.Icon;
            btnDashboard.Location = new Point(0, 20);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(95, 80);
            btnDashboard.TabIndex = 0;
            btnDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDashboard.UseVisualStyleBackColor = true;
            // 
            // pnlDivider
            // 
            pnlDivider.BackColor = Color.Transparent;
            pnlDivider.BackgroundImage = Resources.Resources.DividerCompact;
            pnlDivider.BackgroundImageLayout = ImageLayout.Center;
            pnlDivider.Dock = DockStyle.Top;
            pnlDivider.Location = new Point(0, 109);
            pnlDivider.Name = "pnlDivider";
            pnlDivider.Size = new Size(95, 40);
            pnlDivider.TabIndex = 5;
            // 
            // pnlHead
            // 
            pnlHead.BackColor = Color.Transparent;
            pnlHead.BackgroundImage = Resources.Resources.Logo;
            pnlHead.BackgroundImageLayout = ImageLayout.Center;
            pnlHead.Dock = DockStyle.Top;
            pnlHead.Location = new Point(0, 0);
            pnlHead.Name = "pnlHead";
            pnlHead.Size = new Size(95, 109);
            pnlHead.TabIndex = 4;
            // 
            // SideMenuCompact
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(pnlMenu);
            Controls.Add(pnlFoot);
            Controls.Add(pnlDivider);
            Controls.Add(pnlHead);
            DoubleBuffered = true;
            Name = "SideMenuCompact";
            Size = new Size(95, 1025);
            pnlFoot.ResumeLayout(false);
            pnlMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlFoot;
        private Button btnLogout;
        private Button btnSettings;
        private Panel pnlMenu;
        private Button btnReports;
        private Button btnMaintenance;
        private Button btnPayment;
        private Button btnBilling;
        private Button btnLeasing;
        private Button btnUnits;
        private Button btnDashboard;
        private Panel pnlDivider;
        private Panel pnlHead;
    }
}
