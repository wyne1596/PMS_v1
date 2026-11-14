namespace PMS_v1.Pages
{
    partial class DashboardModule
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tlpMain = new TableLayoutPanel();
            pnlHeader = new Panel();
            lblGreeting = new Label();
            lblWelcome = new Label();
            tlpMetrics = new TableLayoutPanel();
            statCardUnpaid = new PMS_v1.UserControls.Statcard();
            statCardExpired = new PMS_v1.UserControls.Statcard();
            statCardOverdue = new PMS_v1.UserControls.Statcard();
            statCardRepairs = new PMS_v1.UserControls.Statcard();
            lblRecentTransactions = new Label();
            roundedPanelTable = new RoundedPanel();
            dgvRecent = new DataGridView();
            colTenant = new DataGridViewTextBoxColumn();
            colUnit = new DataGridViewTextBoxColumn();
            colLeaseEnds = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            tlpMain.SuspendLayout();
            pnlHeader.SuspendLayout();
            tlpMetrics.SuspendLayout();
            roundedPanelTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecent).BeginInit();
            SuspendLayout();
            // 
            // tlpMain
            // 
            tlpMain.BackColor = Color.FromArgb(236, 240, 241);
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(pnlHeader, 0, 0);
            tlpMain.Controls.Add(tlpMetrics, 0, 1);
            tlpMain.Controls.Add(lblRecentTransactions, 0, 2);
            tlpMain.Controls.Add(roundedPanelTable, 0, 3);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 4;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 75F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 18.55422F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 5.38869238F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 76.0600739F));
            tlpMain.Size = new Size(1194, 1207);
            tlpMain.TabIndex = 0;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(236, 240, 241);
            pnlHeader.Controls.Add(lblGreeting);
            pnlHeader.Controls.Add(lblWelcome);
            pnlHeader.Dock = DockStyle.Fill;
            pnlHeader.Location = new Point(3, 3);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(15, 0, 0, 0);
            pnlHeader.Size = new Size(1188, 69);
            pnlHeader.TabIndex = 0;
            // 
            // lblGreeting
            // 
            lblGreeting.AutoSize = true;
            lblGreeting.BackColor = Color.FromArgb(236, 240, 241);
            lblGreeting.Dock = DockStyle.Top;
            lblGreeting.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGreeting.ForeColor = Color.FromArgb(51, 51, 51);
            lblGreeting.Location = new Point(15, 31);
            lblGreeting.Name = "lblGreeting";
            lblGreeting.Size = new Size(165, 34);
            lblGreeting.TabIndex = 1;
            lblGreeting.Text = "Hello, User!";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.BackColor = Color.FromArgb(236, 240, 241);
            lblWelcome.Dock = DockStyle.Top;
            lblWelcome.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.FromArgb(108, 117, 125);
            lblWelcome.Location = new Point(15, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Padding = new Padding(3, 0, 0, 11);
            lblWelcome.Size = new Size(218, 31);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome to the dashboard.";
            // 
            // tlpMetrics
            // 
            tlpMetrics.BackColor = Color.FromArgb(236, 240, 241);
            tlpMetrics.ColumnCount = 4;
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetrics.Controls.Add(statCardUnpaid, 0, 0);
            tlpMetrics.Controls.Add(statCardExpired, 1, 0);
            tlpMetrics.Controls.Add(statCardOverdue, 2, 0);
            tlpMetrics.Controls.Add(statCardRepairs, 3, 0);
            tlpMetrics.Dock = DockStyle.Fill;
            tlpMetrics.Location = new Point(3, 78);
            tlpMetrics.Name = "tlpMetrics";
            tlpMetrics.RowCount = 1;
            tlpMetrics.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMetrics.Size = new Size(1188, 204);
            tlpMetrics.TabIndex = 1;
            // 
            // statCardUnpaid
            // 
            statCardUnpaid.CardCaption = "Total Unpaid Balance";
            statCardUnpaid.CardIcon = Resources.Resources.exclamation;
            statCardUnpaid.CardNumber = "₱00";
            statCardUnpaid.Dock = DockStyle.Fill;
            statCardUnpaid.Location = new Point(15, 0);
            statCardUnpaid.Margin = new Padding(15, 0, 7, 0);
            statCardUnpaid.Name = "statCardUnpaid";
            statCardUnpaid.Size = new Size(275, 204);
            statCardUnpaid.TabIndex = 0;
            // 
            // statCardExpired
            // 
            statCardExpired.CardCaption = "Expired Leases";
            statCardExpired.CardIcon = Resources.Resources.hourglass;
            statCardExpired.CardNumber = "00";
            statCardExpired.Dock = DockStyle.Fill;
            statCardExpired.Location = new Point(304, 0);
            statCardExpired.Margin = new Padding(7, 0, 7, 0);
            statCardExpired.Name = "statCardExpired";
            statCardExpired.Size = new Size(283, 204);
            statCardExpired.TabIndex = 1;
            // 
            // statCardOverdue
            // 
            statCardOverdue.CardCaption = "Rent Overdue";
            statCardOverdue.CardIcon = Resources.Resources.clock;
            statCardOverdue.CardNumber = "00";
            statCardOverdue.Dock = DockStyle.Fill;
            statCardOverdue.Location = new Point(601, 0);
            statCardOverdue.Margin = new Padding(7, 0, 7, 0);
            statCardOverdue.Name = "statCardOverdue";
            statCardOverdue.Size = new Size(283, 204);
            statCardOverdue.TabIndex = 2;
            // 
            // statCardRepairs
            // 
            statCardRepairs.CardCaption = "Repairs Needed";
            statCardRepairs.CardIcon = Resources.Resources.remove;
            statCardRepairs.CardNumber = "00";
            statCardRepairs.Dock = DockStyle.Fill;
            statCardRepairs.Location = new Point(898, 0);
            statCardRepairs.Margin = new Padding(7, 0, 15, 0);
            statCardRepairs.Name = "statCardRepairs";
            statCardRepairs.Size = new Size(275, 204);
            statCardRepairs.TabIndex = 3;
            // 
            // lblRecentTransactions
            // 
            lblRecentTransactions.BackColor = Color.FromArgb(236, 240, 241);
            lblRecentTransactions.Dock = DockStyle.Fill;
            lblRecentTransactions.Font = new Font("Century Gothic", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecentTransactions.ForeColor = Color.FromArgb(51, 51, 51);
            lblRecentTransactions.Location = new Point(0, 285);
            lblRecentTransactions.Margin = new Padding(0);
            lblRecentTransactions.Name = "lblRecentTransactions";
            lblRecentTransactions.Size = new Size(1194, 60);
            lblRecentTransactions.TabIndex = 2;
            lblRecentTransactions.Text = "Recent Transactions";
            lblRecentTransactions.TextAlign = ContentAlignment.BottomLeft;
            // 
            // roundedPanelTable
            // 
            roundedPanelTable.BackColor = Color.White;
            roundedPanelTable.BorderColor = Color.Transparent;
            roundedPanelTable.BorderRadius = 10;
            roundedPanelTable.Controls.Add(dgvRecent);
            roundedPanelTable.Dock = DockStyle.Fill;
            roundedPanelTable.Location = new Point(15, 348);
            roundedPanelTable.Margin = new Padding(15, 3, 15, 3);
            roundedPanelTable.Name = "roundedPanelTable";
            roundedPanelTable.ShadowColor = Color.Black;
            roundedPanelTable.ShadowOpacity = 32;
            roundedPanelTable.ShadowSize = 4;
            roundedPanelTable.Size = new Size(1164, 856);
            roundedPanelTable.TabIndex = 3;
            // 
            // dgvRecent
            // 
            dgvRecent.AllowUserToAddRows = false;
            dgvRecent.AllowUserToDeleteRows = false;
            dgvRecent.AllowUserToResizeRows = false;
            dgvRecent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecent.BackgroundColor = Color.White;
            dgvRecent.BorderStyle = BorderStyle.None;
            dgvRecent.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRecent.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(74, 151, 196);
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(14, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(74, 151, 196);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvRecent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvRecent.ColumnHeadersHeight = 44;
            dgvRecent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRecent.Columns.AddRange(new DataGridViewColumn[] { colTenant, colUnit, colLeaseEnds, colStatus });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(51, 51, 51);
            dataGridViewCellStyle2.Padding = new Padding(14, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(215, 235, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(51, 51, 51);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvRecent.DefaultCellStyle = dataGridViewCellStyle2;
            dgvRecent.Dock = DockStyle.Fill;
            dgvRecent.EnableHeadersVisualStyles = false;
            dgvRecent.GridColor = Color.FromArgb(233, 236, 239);
            dgvRecent.Location = new Point(4, 6);
            dgvRecent.Margin = new Padding(3, 4, 3, 4);
            dgvRecent.MultiSelect = false;
            dgvRecent.Name = "dgvRecent";
            dgvRecent.ReadOnly = true;
            dgvRecent.RowHeadersVisible = false;
            dgvRecent.RowHeadersWidth = 51;
            dgvRecent.RowTemplate.Height = 46;
            dgvRecent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecent.Size = new Size(1156, 844);
            dgvRecent.TabIndex = 0;
            // 
            // colTenant
            // 
            colTenant.FillWeight = 40F;
            colTenant.HeaderText = "TENANT";
            colTenant.MinimumWidth = 6;
            colTenant.Name = "colTenant";
            colTenant.ReadOnly = true;
            // 
            // colUnit
            // 
            colUnit.FillWeight = 18F;
            colUnit.HeaderText = "UNIT";
            colUnit.MinimumWidth = 6;
            colUnit.Name = "colUnit";
            colUnit.ReadOnly = true;
            // 
            // colLeaseEnds
            // 
            colLeaseEnds.FillWeight = 24F;
            colLeaseEnds.HeaderText = "LEASE ENDS";
            colLeaseEnds.MinimumWidth = 6;
            colLeaseEnds.Name = "colLeaseEnds";
            colLeaseEnds.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.FillWeight = 18F;
            colStatus.HeaderText = "STATUS";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // DashboardModule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            Controls.Add(tlpMain);
            DoubleBuffered = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "DashboardModule";
            Size = new Size(1194, 1207);
            tlpMain.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tlpMetrics.ResumeLayout(false);
            roundedPanelTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRecent).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpMain;
        private Panel pnlHeader;
        private Label lblWelcome;
        private Label lblGreeting;
        private TableLayoutPanel tlpMetrics;
        private PMS_v1.UserControls.Statcard statCardUnpaid;
        private PMS_v1.UserControls.Statcard statCardExpired;
        private PMS_v1.UserControls.Statcard statCardOverdue;
        private PMS_v1.UserControls.Statcard statCardRepairs;
        private PMS_v1.RoundedPanel roundedPanelTable;
        private DataGridView dgvRecent;
        private DataGridViewTextBoxColumn colTenant;
        private DataGridViewTextBoxColumn colUnit;
        private DataGridViewTextBoxColumn colLeaseEnds;
        private DataGridViewTextBoxColumn colStatus;
        private Label lblRecentTransactions;
    }
}
