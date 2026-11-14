using System.Drawing;
using System.Windows.Forms;

namespace PMS_v1.Pages
{
    partial class Dashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            tlpMain = new TableLayoutPanel();
            pnlGreeting = new Panel();
            lblWelcome = new Label();
            lblGreeting = new Label();
            tlpSummary = new TableLayoutPanel();
            statCardBalance = new PMS_v1.UserControls.Statcard();
            statCardExpiredLeases = new PMS_v1.UserControls.Statcard();
            statCardRentOverdue = new PMS_v1.UserControls.Statcard();
            statCardRepairs = new PMS_v1.UserControls.Statcard();
            pnlChart = new RoundedPanel();
            tlpChartLayout = new TableLayoutPanel();
            pnlChartHeader = new Panel();
            lblChartTitle = new Label();
            cmbChartPeriod = new Krypton.Toolkit.KryptonComboBox();
            rentCollectionChart = new PMS_v1.UserControls.RentCollectionChart();
            pnlTransactions = new RoundedPanel();
            tlpTransactionsLayout = new TableLayoutPanel();
            pnlTransactionsHeader = new Panel();
            lblTransactionsTitle = new Label();
            lnkViewAll = new LinkLabel();
            dgvTransactions = new DataGridView();
            tlpMain.SuspendLayout();
            pnlGreeting.SuspendLayout();
            tlpSummary.SuspendLayout();
            pnlChart.SuspendLayout();
            tlpChartLayout.SuspendLayout();
            pnlChartHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbChartPeriod).BeginInit();
            pnlTransactions.SuspendLayout();
            tlpTransactionsLayout.SuspendLayout();
            pnlTransactionsHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            SuspendLayout();
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(pnlGreeting, 0, 0);
            tlpMain.Controls.Add(tlpSummary, 0, 1);
            tlpMain.Controls.Add(pnlChart, 0, 2);
            tlpMain.Controls.Add(pnlTransactions, 0, 3);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Name = "tlpMain";
            tlpMain.Padding = new Padding(42, 12, 42, 18);
            tlpMain.RowCount = 4;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 108F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            tlpMain.Size = new Size(1150, 938);
            tlpMain.TabIndex = 0;
            // 
            // pnlGreeting
            // 
            pnlGreeting.Controls.Add(lblWelcome);
            pnlGreeting.Controls.Add(lblGreeting);
            pnlGreeting.Dock = DockStyle.Fill;
            pnlGreeting.Location = new Point(45, 15);
            pnlGreeting.Name = "pnlGreeting";
            pnlGreeting.Size = new Size(1060, 66);
            pnlGreeting.TabIndex = 0;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 8F);
            lblWelcome.ForeColor = Color.FromArgb(108, 117, 125);
            lblWelcome.Location = new Point(0, 7);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(150, 13);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome to the dashboard.";
            // 
            // lblGreeting
            // 
            lblGreeting.AutoSize = true;
            lblGreeting.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblGreeting.ForeColor = Color.FromArgb(33, 37, 41);
            lblGreeting.Location = new Point(0, 26);
            lblGreeting.Name = "lblGreeting";
            lblGreeting.Size = new Size(147, 32);
            lblGreeting.TabIndex = 1;
            lblGreeting.Text = "Hello, User!";
            // 
            // tlpSummary
            // 
            tlpSummary.ColumnCount = 4;
            tlpSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpSummary.Controls.Add(statCardBalance, 0, 0);
            tlpSummary.Controls.Add(statCardExpiredLeases, 1, 0);
            tlpSummary.Controls.Add(statCardRentOverdue, 2, 0);
            tlpSummary.Controls.Add(statCardRepairs, 3, 0);
            tlpSummary.Dock = DockStyle.Fill;
            tlpSummary.Location = new Point(42, 84);
            tlpSummary.Margin = new Padding(0);
            tlpSummary.Name = "tlpSummary";
            tlpSummary.RowCount = 1;
            tlpSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpSummary.Size = new Size(1066, 108);
            tlpSummary.TabIndex = 1;
            // 
            // statCardBalance
            // 
            statCardBalance.CardCaption = "Total Unpaid Balance";
            statCardBalance.CardIcon = Resources.Resources.pound;
            statCardBalance.CardNumber = "00";
            statCardBalance.Dock = DockStyle.Fill;
            statCardBalance.Location = new Point(8, 0);
            statCardBalance.Margin = new Padding(8, 0, 8, 0);
            statCardBalance.Name = "statCardBalance";
            statCardBalance.Size = new Size(250, 108);
            statCardBalance.TabIndex = 0;
            // 
            // statCardExpiredLeases
            // 
            statCardExpiredLeases.CardCaption = "Expired Leases";
            statCardExpiredLeases.CardIcon = Resources.Resources.attention;
            statCardExpiredLeases.CardNumber = "00";
            statCardExpiredLeases.Dock = DockStyle.Fill;
            statCardExpiredLeases.Location = new Point(274, 0);
            statCardExpiredLeases.Margin = new Padding(8, 0, 8, 0);
            statCardExpiredLeases.Name = "statCardExpiredLeases";
            statCardExpiredLeases.Size = new Size(250, 108);
            statCardExpiredLeases.TabIndex = 1;
            // 
            // statCardRentOverdue
            // 
            statCardRentOverdue.CardCaption = "Rent Overdue";
            statCardRentOverdue.CardIcon = Resources.Resources.clock;
            statCardRentOverdue.CardNumber = "00";
            statCardRentOverdue.Dock = DockStyle.Fill;
            statCardRentOverdue.Location = new Point(540, 0);
            statCardRentOverdue.Margin = new Padding(8, 0, 8, 0);
            statCardRentOverdue.Name = "statCardRentOverdue";
            statCardRentOverdue.Size = new Size(250, 108);
            statCardRentOverdue.TabIndex = 2;
            // 
            // statCardRepairs
            // 
            statCardRepairs.CardCaption = "Repairs Needed";
            statCardRepairs.CardIcon = Resources.Resources.Settings1;
            statCardRepairs.CardNumber = "00";
            statCardRepairs.Dock = DockStyle.Fill;
            statCardRepairs.Location = new Point(806, 0);
            statCardRepairs.Margin = new Padding(8, 0, 8, 0);
            statCardRepairs.Name = "statCardRepairs";
            statCardRepairs.Size = new Size(252, 108);
            statCardRepairs.TabIndex = 3;
            // 
            // pnlChart
            // 
            pnlChart.BackColor = Color.White;
            pnlChart.BorderColor = Color.FromArgb(230, 233, 236);
            pnlChart.BorderRadius = 12;
            pnlChart.BorderThickness = 1;
            pnlChart.Controls.Add(tlpChartLayout);
            pnlChart.Dock = DockStyle.Fill;
            pnlChart.Location = new Point(50, 196);
            pnlChart.Margin = new Padding(8, 4, 8, 10);
            pnlChart.Name = "pnlChart";
            pnlChart.Padding = new Padding(18, 12, 18, 10);
            pnlChart.ShadowColor = Color.Black;
            pnlChart.ShadowOpacity = 22;
            pnlChart.ShadowSize = 3;
            pnlChart.Size = new Size(1050, 386);
            pnlChart.TabIndex = 2;
            // 
            // tlpChartLayout
            // 
            tlpChartLayout.ColumnCount = 1;
            tlpChartLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpChartLayout.Controls.Add(pnlChartHeader, 0, 0);
            tlpChartLayout.Controls.Add(rentCollectionChart, 0, 1);
            tlpChartLayout.Dock = DockStyle.Fill;
            tlpChartLayout.Location = new Point(21, 17);
            tlpChartLayout.Margin = new Padding(0);
            tlpChartLayout.Name = "tlpChartLayout";
            tlpChartLayout.RowCount = 2;
            tlpChartLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tlpChartLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpChartLayout.Size = new Size(1008, 354);
            tlpChartLayout.TabIndex = 0;
            // 
            // pnlChartHeader
            // 
            pnlChartHeader.Controls.Add(lblChartTitle);
            pnlChartHeader.Controls.Add(cmbChartPeriod);
            pnlChartHeader.Dock = DockStyle.Fill;
            pnlChartHeader.Location = new Point(3, 3);
            pnlChartHeader.Name = "pnlChartHeader";
            pnlChartHeader.Size = new Size(1002, 26);
            pnlChartHeader.TabIndex = 0;
            // 
            // lblChartTitle
            // 
            lblChartTitle.AutoSize = true;
            lblChartTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblChartTitle.ForeColor = Color.FromArgb(44, 49, 53);
            lblChartTitle.Location = new Point(0, 4);
            lblChartTitle.Name = "lblChartTitle";
            lblChartTitle.Size = new Size(110, 19);
            lblChartTitle.TabIndex = 0;
            lblChartTitle.Text = "Rent Collection";
            // 
            // cmbChartPeriod
            // 
            cmbChartPeriod.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbChartPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbChartPeriod.Items.AddRange(new object[] { "Monthly", "Quarterly", "Yearly" });
            cmbChartPeriod.Location = new Point(1642, 0);
            cmbChartPeriod.Name = "cmbChartPeriod";
            cmbChartPeriod.Size = new Size(130, 28);
            cmbChartPeriod.StateCommon.ComboBox.Back.Color1 = Color.White;
            cmbChartPeriod.StateCommon.ComboBox.Border.Color1 = Color.FromArgb(222, 226, 230);
            cmbChartPeriod.StateCommon.ComboBox.Border.Rounding = 8F;
            cmbChartPeriod.TabIndex = 1;
            cmbChartPeriod.Text = "Monthly";
            // 
            // rentCollectionChart
            // 
            rentCollectionChart.BackColor = Color.White;
            rentCollectionChart.Dock = DockStyle.Fill;
            rentCollectionChart.ForeColor = Color.FromArgb(95, 101, 107);
            rentCollectionChart.Location = new Point(3, 35);
            rentCollectionChart.MinimumSize = new Size(280, 150);
            rentCollectionChart.Name = "rentCollectionChart";
            rentCollectionChart.Size = new Size(1002, 316);
            rentCollectionChart.TabIndex = 0;
            // 
            // pnlTransactions
            // 
            pnlTransactions.BackColor = Color.White;
            pnlTransactions.BorderColor = Color.FromArgb(230, 233, 236);
            pnlTransactions.BorderRadius = 12;
            pnlTransactions.BorderThickness = 1;
            pnlTransactions.Controls.Add(tlpTransactionsLayout);
            pnlTransactions.Dock = DockStyle.Fill;
            pnlTransactions.Location = new Point(50, 596);
            pnlTransactions.Margin = new Padding(8, 4, 8, 8);
            pnlTransactions.Name = "pnlTransactions";
            pnlTransactions.Padding = new Padding(14, 8, 14, 8);
            pnlTransactions.ShadowColor = Color.Black;
            pnlTransactions.ShadowOpacity = 22;
            pnlTransactions.ShadowSize = 3;
            pnlTransactions.Size = new Size(1050, 316);
            pnlTransactions.TabIndex = 3;
            // 
            // tlpTransactionsLayout
            // 
            tlpTransactionsLayout.ColumnCount = 1;
            tlpTransactionsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpTransactionsLayout.Controls.Add(pnlTransactionsHeader, 0, 0);
            tlpTransactionsLayout.Controls.Add(dgvTransactions, 0, 1);
            tlpTransactionsLayout.Dock = DockStyle.Fill;
            tlpTransactionsLayout.Location = new Point(17, 13);
            tlpTransactionsLayout.Margin = new Padding(0);
            tlpTransactionsLayout.Name = "tlpTransactionsLayout";
            tlpTransactionsLayout.RowCount = 2;
            tlpTransactionsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpTransactionsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpTransactionsLayout.Size = new Size(1016, 290);
            tlpTransactionsLayout.TabIndex = 0;
            // 
            // pnlTransactionsHeader
            // 
            pnlTransactionsHeader.Controls.Add(lblTransactionsTitle);
            pnlTransactionsHeader.Controls.Add(lnkViewAll);
            pnlTransactionsHeader.Dock = DockStyle.Fill;
            pnlTransactionsHeader.Location = new Point(3, 3);
            pnlTransactionsHeader.Name = "pnlTransactionsHeader";
            pnlTransactionsHeader.Size = new Size(1010, 24);
            pnlTransactionsHeader.TabIndex = 0;
            // 
            // lblTransactionsTitle
            // 
            lblTransactionsTitle.AutoSize = true;
            lblTransactionsTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTransactionsTitle.ForeColor = Color.FromArgb(44, 49, 53);
            lblTransactionsTitle.Location = new Point(0, 5);
            lblTransactionsTitle.Name = "lblTransactionsTitle";
            lblTransactionsTitle.Size = new Size(118, 15);
            lblTransactionsTitle.TabIndex = 0;
            lblTransactionsTitle.Text = "Recent Transactions";
            // 
            // lnkViewAll
            // 
            lnkViewAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lnkViewAll.AutoSize = true;
            lnkViewAll.Font = new Font("Segoe UI", 8F);
            lnkViewAll.LinkColor = Color.FromArgb(108, 117, 125);
            lnkViewAll.Location = new Point(1728, 5);
            lnkViewAll.Name = "lnkViewAll";
            lnkViewAll.Size = new Size(48, 13);
            lnkViewAll.TabIndex = 1;
            lnkViewAll.TabStop = true;
            lnkViewAll.Text = "View All";
            // 
            // dgvTransactions
            // 
            dgvTransactions.BackgroundColor = Color.White;
            dgvTransactions.BorderStyle = BorderStyle.None;
            dgvTransactions.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTransactions.ColumnHeadersHeight = 32;
            dgvTransactions.Dock = DockStyle.Fill;
            dgvTransactions.GridColor = Color.FromArgb(233, 236, 239);
            dgvTransactions.Location = new Point(0, 30);
            dgvTransactions.Margin = new Padding(0);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.RowHeadersVisible = false;
            dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransactions.Size = new Size(1016, 260);
            dgvTransactions.TabIndex = 0;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 248);
            Controls.Add(tlpMain);
            Name = "Dashboard";
            Size = new Size(1150, 938);
            tlpMain.ResumeLayout(false);
            pnlGreeting.ResumeLayout(false);
            pnlGreeting.PerformLayout();
            tlpSummary.ResumeLayout(false);
            pnlChart.ResumeLayout(false);
            tlpChartLayout.ResumeLayout(false);
            pnlChartHeader.ResumeLayout(false);
            pnlChartHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cmbChartPeriod).EndInit();
            pnlTransactions.ResumeLayout(false);
            tlpTransactionsLayout.ResumeLayout(false);
            pnlTransactionsHeader.ResumeLayout(false);
            pnlTransactionsHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpMain;
        private Panel pnlGreeting;
        private Label lblWelcome;
        private Label lblGreeting;
        private TableLayoutPanel tlpSummary;
        private UserControls.Statcard statCardBalance;
        private UserControls.Statcard statCardExpiredLeases;
        private UserControls.Statcard statCardRentOverdue;
        private UserControls.Statcard statCardRepairs;
        private RoundedPanel pnlChart;
        private TableLayoutPanel tlpChartLayout;
        private Panel pnlChartHeader;
        private Label lblChartTitle;
        private Krypton.Toolkit.KryptonComboBox cmbChartPeriod;
        private UserControls.RentCollectionChart rentCollectionChart;
        private RoundedPanel pnlTransactions;
        private TableLayoutPanel tlpTransactionsLayout;
        private Panel pnlTransactionsHeader;
        private Label lblTransactionsTitle;
        private LinkLabel lnkViewAll;
        private DataGridView dgvTransactions;
    }
}
