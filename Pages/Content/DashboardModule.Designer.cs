namespace PMS_v1.Pages.Content.Dashboard
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
            tlpMain = new TableLayoutPanel();
            pnlHeader = new Panel();
            lblGreeting = new Label();
            lblWelcome = new Label();
            tlpMetrics = new TableLayoutPanel();
            statCardUnpaid = new PMS_v1.UserControls.Statcard();
            statCardExpired = new PMS_v1.UserControls.Statcard();
            statCardOverdue = new PMS_v1.UserControls.Statcard();
            statCardRepairs = new PMS_v1.UserControls.Statcard();
            statCardOccupancy = new PMS_v1.UserControls.Statcard();
            tlpMetrics2 = new TableLayoutPanel();
            statCardVacant = new PMS_v1.UserControls.Statcard();
            statCardCollected = new PMS_v1.UserControls.Statcard();
            statCardDueSoon = new PMS_v1.UserControls.Statcard();
            statCardExpiring = new PMS_v1.UserControls.Statcard();
            statCardUrgent = new PMS_v1.UserControls.Statcard();
            lblNeedsAttention = new Label();
            roundedPanelTable = new RoundedPanel();
            dgvOverdue = new DataGridView();
            tlpMain.SuspendLayout();
            pnlHeader.SuspendLayout();
            tlpMetrics.SuspendLayout();
            tlpMetrics2.SuspendLayout();
            roundedPanelTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOverdue).BeginInit();
            SuspendLayout();
            // 
            // tlpMain
            // 
            tlpMain.BackColor = Color.FromArgb(236, 240, 241);
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(pnlHeader, 0, 0);
            tlpMain.Controls.Add(tlpMetrics, 0, 1);
            tlpMain.Controls.Add(tlpMetrics2, 0, 2);
            tlpMain.Controls.Add(lblNeedsAttention, 0, 3);
            tlpMain.Controls.Add(roundedPanelTable, 0, 4);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 5;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 75F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 155F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 155F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
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
            tlpMetrics.ColumnCount = 5;
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpMetrics.Controls.Add(statCardUnpaid, 0, 0);
            tlpMetrics.Controls.Add(statCardExpired, 1, 0);
            tlpMetrics.Controls.Add(statCardOverdue, 2, 0);
            tlpMetrics.Controls.Add(statCardRepairs, 3, 0);
            tlpMetrics.Controls.Add(statCardOccupancy, 4, 0);
            tlpMetrics.Dock = DockStyle.Fill;
            tlpMetrics.Location = new Point(3, 78);
            tlpMetrics.Name = "tlpMetrics";
            tlpMetrics.RowCount = 1;
            tlpMetrics.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMetrics.Size = new Size(1188, 149);
            tlpMetrics.TabIndex = 1;
            // 
            // statCardUnpaid
            // 
            statCardUnpaid.CardCaption = "Unpaid Balance";
            statCardUnpaid.CardIcon = Resources.Resources.TotalUnpaidBalance;
            statCardUnpaid.CardNumber = "₱0";
            statCardUnpaid.Dock = DockStyle.Fill;
            statCardUnpaid.IconSlotPadding = new Padding(6, 16, 6, 16);
            statCardUnpaid.Location = new Point(17, 0);
            statCardUnpaid.Margin = new Padding(17, 0, 8, 0);
            statCardUnpaid.Name = "statCardUnpaid";
            statCardUnpaid.Size = new Size(212, 149);
            statCardUnpaid.TabIndex = 0;
            // 
            // statCardExpired
            // 
            statCardExpired.CardCaption = "Expired Leases";
            statCardExpired.CardIcon = Resources.Resources.ExpiredLease;
            statCardExpired.CardNumber = "00";
            statCardExpired.Dock = DockStyle.Fill;
            statCardExpired.IconSlotPadding = new Padding(6, 16, 6, 16);
            statCardExpired.Location = new Point(245, 0);
            statCardExpired.Margin = new Padding(8, 0, 8, 0);
            statCardExpired.Name = "statCardExpired";
            statCardExpired.Size = new Size(221, 149);
            statCardExpired.TabIndex = 1;
            // 
            // statCardOverdue
            // 
            statCardOverdue.CardCaption = "Rent Overdue";
            statCardOverdue.CardIcon = Resources.Resources.RentOverdue;
            statCardOverdue.CardNumber = "00";
            statCardOverdue.Dock = DockStyle.Fill;
            statCardOverdue.IconSlotPadding = new Padding(6, 16, 6, 16);
            statCardOverdue.Location = new Point(482, 0);
            statCardOverdue.Margin = new Padding(8, 0, 8, 0);
            statCardOverdue.Name = "statCardOverdue";
            statCardOverdue.Size = new Size(221, 149);
            statCardOverdue.TabIndex = 2;
            // 
            // statCardRepairs
            // 
            statCardRepairs.CardCaption = "Repairs Needed";
            statCardRepairs.CardIcon = Resources.Resources.RepairsNeeded;
            statCardRepairs.CardNumber = "00";
            statCardRepairs.Dock = DockStyle.Fill;
            statCardRepairs.IconSlotPadding = new Padding(6, 16, 6, 16);
            statCardRepairs.Location = new Point(719, 0);
            statCardRepairs.Margin = new Padding(8, 0, 8, 0);
            statCardRepairs.Name = "statCardRepairs";
            statCardRepairs.Size = new Size(221, 149);
            statCardRepairs.TabIndex = 3;
            // 
            // statCardOccupancy
            // 
            statCardOccupancy.CardCaption = "Occupancy";
            statCardOccupancy.CardIcon = Resources.Resources.OccupiedUnit;
            statCardOccupancy.CardNumber = "0 / 0";
            statCardOccupancy.Dock = DockStyle.Fill;
            statCardOccupancy.IconSlotPadding = new Padding(6, 16, 6, 16);
            statCardOccupancy.Location = new Point(956, 0);
            statCardOccupancy.Margin = new Padding(8, 0, 17, 0);
            statCardOccupancy.Name = "statCardOccupancy";
            statCardOccupancy.Size = new Size(215, 149);
            statCardOccupancy.TabIndex = 4;
            // 
            // tlpMetrics2
            // 
            tlpMetrics2.BackColor = Color.FromArgb(236, 240, 241);
            tlpMetrics2.ColumnCount = 5;
            tlpMetrics2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpMetrics2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpMetrics2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpMetrics2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpMetrics2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpMetrics2.Controls.Add(statCardVacant, 0, 0);
            tlpMetrics2.Controls.Add(statCardCollected, 1, 0);
            tlpMetrics2.Controls.Add(statCardDueSoon, 2, 0);
            tlpMetrics2.Controls.Add(statCardExpiring, 3, 0);
            tlpMetrics2.Controls.Add(statCardUrgent, 4, 0);
            tlpMetrics2.Dock = DockStyle.Fill;
            tlpMetrics2.Location = new Point(3, 233);
            tlpMetrics2.Name = "tlpMetrics2";
            tlpMetrics2.RowCount = 1;
            tlpMetrics2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMetrics2.Size = new Size(1188, 149);
            tlpMetrics2.TabIndex = 2;
            // 
            // statCardVacant
            // 
            statCardVacant.CardCaption = "Vacant Units";
            statCardVacant.CardIcon = Resources.Resources.VacantUnits;
            statCardVacant.CardNumber = "00";
            statCardVacant.Dock = DockStyle.Fill;
            statCardVacant.IconSlotPadding = new Padding(6, 16, 6, 16);
            statCardVacant.Location = new Point(17, 0);
            statCardVacant.Margin = new Padding(17, 0, 8, 0);
            statCardVacant.Name = "statCardVacant";
            statCardVacant.Size = new Size(212, 149);
            statCardVacant.TabIndex = 0;
            // 
            // statCardCollected
            // 
            statCardCollected.CardCaption = "Collected This Month";
            statCardCollected.CardIcon = Resources.Resources.PaidBills;
            statCardCollected.CardNumber = "₱0";
            statCardCollected.Dock = DockStyle.Fill;
            statCardCollected.IconSlotPadding = new Padding(6, 16, 6, 16);
            statCardCollected.Location = new Point(245, 0);
            statCardCollected.Margin = new Padding(8, 0, 8, 0);
            statCardCollected.Name = "statCardCollected";
            statCardCollected.Size = new Size(221, 149);
            statCardCollected.TabIndex = 1;
            // 
            // statCardDueSoon
            // 
            statCardDueSoon.CardCaption = "Bills Due Soon";
            statCardDueSoon.CardIcon = Resources.Resources.UnpaidBills;
            statCardDueSoon.CardNumber = "00";
            statCardDueSoon.Dock = DockStyle.Fill;
            statCardDueSoon.IconSlotPadding = new Padding(6, 16, 6, 16);
            statCardDueSoon.Location = new Point(482, 0);
            statCardDueSoon.Margin = new Padding(8, 0, 8, 0);
            statCardDueSoon.Name = "statCardDueSoon";
            statCardDueSoon.Size = new Size(221, 149);
            statCardDueSoon.TabIndex = 2;
            // 
            // statCardExpiring
            // 
            statCardExpiring.CardCaption = "Expiring in 30 Days";
            statCardExpiring.CardIcon = Resources.Resources.Clock;
            statCardExpiring.CardNumber = "00";
            statCardExpiring.Dock = DockStyle.Fill;
            statCardExpiring.IconSlotPadding = new Padding(6, 16, 6, 16);
            statCardExpiring.Location = new Point(719, 0);
            statCardExpiring.Margin = new Padding(8, 0, 8, 0);
            statCardExpiring.Name = "statCardExpiring";
            statCardExpiring.Size = new Size(221, 149);
            statCardExpiring.TabIndex = 3;
            // 
            // statCardUrgent
            // 
            statCardUrgent.CardCaption = "Urgent Repairs";
            statCardUrgent.CardIcon = Resources.Resources.UnderMaintenance;
            statCardUrgent.CardNumber = "00";
            statCardUrgent.Dock = DockStyle.Fill;
            statCardUrgent.IconSlotPadding = new Padding(6, 16, 6, 16);
            statCardUrgent.Location = new Point(956, 0);
            statCardUrgent.Margin = new Padding(8, 0, 17, 0);
            statCardUrgent.Name = "statCardUrgent";
            statCardUrgent.Size = new Size(215, 149);
            statCardUrgent.TabIndex = 4;
            // 
            // lblNeedsAttention
            // 
            lblNeedsAttention.BackColor = Color.FromArgb(236, 240, 241);
            lblNeedsAttention.Dock = DockStyle.Fill;
            lblNeedsAttention.Font = new Font("Century Gothic", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNeedsAttention.ForeColor = Color.FromArgb(51, 51, 51);
            lblNeedsAttention.Location = new Point(0, 385);
            lblNeedsAttention.Margin = new Padding(0);
            lblNeedsAttention.Name = "lblNeedsAttention";
            lblNeedsAttention.Padding = new Padding(15, 0, 0, 0);
            lblNeedsAttention.Size = new Size(1194, 37);
            lblNeedsAttention.TabIndex = 3;
            lblNeedsAttention.Text = "Needs Attention";
            lblNeedsAttention.TextAlign = ContentAlignment.BottomLeft;
            // 
            // roundedPanelTable
            // 
            roundedPanelTable.BackColor = Color.White;
            roundedPanelTable.BorderColor = Color.Transparent;
            roundedPanelTable.BorderRadius = 10;
            roundedPanelTable.Controls.Add(dgvOverdue);
            roundedPanelTable.Dock = DockStyle.Fill;
            roundedPanelTable.Location = new Point(17, 426);
            roundedPanelTable.Margin = new Padding(17, 4, 17, 4);
            roundedPanelTable.Name = "roundedPanelTable";
            roundedPanelTable.Padding = new Padding(7, 9, 7, 9);
            roundedPanelTable.ShadowColor = Color.Black;
            roundedPanelTable.ShadowOpacity = 28;
            roundedPanelTable.ShadowSize = 4;
            roundedPanelTable.Size = new Size(1160, 777);
            roundedPanelTable.TabIndex = 4;
            // 
            // dgvOverdue
            // 
            dgvOverdue.BackgroundColor = Color.White;
            dgvOverdue.BorderStyle = BorderStyle.None;
            dgvOverdue.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvOverdue.ColumnHeadersHeight = 44;
            dgvOverdue.Dock = DockStyle.Fill;
            dgvOverdue.GridColor = Color.FromArgb(233, 236, 239);
            dgvOverdue.Location = new Point(11, 15);
            dgvOverdue.Margin = new Padding(0);
            dgvOverdue.Name = "dgvOverdue";
            dgvOverdue.RowHeadersVisible = false;
            dgvOverdue.RowHeadersWidth = 51;
            dgvOverdue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOverdue.Size = new Size(1138, 747);
            dgvOverdue.TabIndex = 0;
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
            tlpMetrics2.ResumeLayout(false);
            roundedPanelTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOverdue).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpMain;
        private Panel pnlHeader;
        private Label lblWelcome;
        private Label lblGreeting;
        private TableLayoutPanel tlpMetrics;
        private TableLayoutPanel tlpMetrics2;
        private PMS_v1.UserControls.Statcard statCardUnpaid;
        private PMS_v1.UserControls.Statcard statCardExpired;
        private PMS_v1.UserControls.Statcard statCardOverdue;
        private PMS_v1.UserControls.Statcard statCardRepairs;
        private PMS_v1.UserControls.Statcard statCardOccupancy;
        private PMS_v1.UserControls.Statcard statCardVacant;
        private PMS_v1.UserControls.Statcard statCardCollected;
        private PMS_v1.UserControls.Statcard statCardDueSoon;
        private PMS_v1.UserControls.Statcard statCardExpiring;
        private PMS_v1.UserControls.Statcard statCardUrgent;
        private PMS_v1.RoundedPanel roundedPanelTable;
        private DataGridView dgvOverdue;
        private Label lblNeedsAttention;
    }
}