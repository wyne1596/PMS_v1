namespace PMS_v1.Pages
{
    partial class PaymentModule
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            tlpMain = new TableLayoutPanel();
            pnlHeader = new Panel();
            lblBreadcrumb = new Label();
            lblTitle = new Label();
            tlpMetrics = new TableLayoutPanel();
            statCardCompleted = new PMS_v1.UserControls.Statcard();
            statCardPending = new PMS_v1.UserControls.Statcard();
            statCardFailed = new PMS_v1.UserControls.Statcard();
            statCardRefunded = new PMS_v1.UserControls.Statcard();
            pnlActions = new Panel();
            txtSearch = new Krypton.Toolkit.KryptonTextBox();
            cmbFilter = new Krypton.Toolkit.KryptonComboBox();
            btnNewTransaction = new Krypton.Toolkit.KryptonButton();
            roundedPanelTable = new PMS_v1.RoundedPanel();
            dgvPayments = new DataGridView();
            tlpMain.SuspendLayout();
            pnlHeader.SuspendLayout();
            tlpMetrics.SuspendLayout();
            pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbFilter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).BeginInit();
            SuspendLayout();
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(pnlHeader, 0, 0);
            tlpMain.Controls.Add(tlpMetrics, 0, 1);
            tlpMain.Controls.Add(pnlActions, 0, 2);
            tlpMain.Controls.Add(roundedPanelTable, 0, 3);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Padding = new Padding(42, 18, 42, 12);
            tlpMain.RowCount = 4;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.Name = "tlpMain";
            tlpMain.TabIndex = 0;
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblBreadcrumb);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Fill;
            pnlHeader.Name = "pnlHeader";
            pnlHeader.TabIndex = 0;
            // 
            // lblBreadcrumb
            // 
            lblBreadcrumb.AutoSize = true;
            lblBreadcrumb.Font = new Font("Segoe UI", 8.5F);
            lblBreadcrumb.ForeColor = Color.FromArgb(108, 117, 125);
            lblBreadcrumb.Location = new Point(0, 20);
            lblBreadcrumb.Name = "lblBreadcrumb";
            lblBreadcrumb.Text = "Home / Payment";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Location = new Point(0, 43);
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "Payments";
            // 
            // tlpMetrics
            // 
            tlpMetrics.ColumnCount = 4;
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetrics.Controls.Add(statCardCompleted, 0, 0);
            tlpMetrics.Controls.Add(statCardPending, 1, 0);
            tlpMetrics.Controls.Add(statCardFailed, 2, 0);
            tlpMetrics.Controls.Add(statCardRefunded, 3, 0);
            tlpMetrics.Dock = DockStyle.Fill;
            tlpMetrics.Margin = new Padding(0);
            tlpMetrics.Name = "tlpMetrics";
            tlpMetrics.RowCount = 1;
            tlpMetrics.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMetrics.TabIndex = 1;
            // 
            // statCardCompleted
            // 
            statCardCompleted.CardCaption = "Completed";
            statCardCompleted.CardIcon = PMS_v1.Resources.Resources.check;
            statCardCompleted.CardNumber = "12";
            statCardCompleted.Dock = DockStyle.Fill;
            statCardCompleted.Margin = new Padding(8, 0, 8, 0);
            statCardCompleted.Name = "statCardCompleted";
            statCardCompleted.TabIndex = 0;
            // 
            // statCardPending
            // 
            statCardPending.CardCaption = "Pending";
            statCardPending.CardIcon = PMS_v1.Resources.Resources.clock;
            statCardPending.CardNumber = "22";
            statCardPending.Dock = DockStyle.Fill;
            statCardPending.Margin = new Padding(8, 0, 8, 0);
            statCardPending.Name = "statCardPending";
            statCardPending.TabIndex = 1;
            // 
            // statCardFailed
            // 
            statCardFailed.CardCaption = "Failed";
            statCardFailed.CardIcon = PMS_v1.Resources.Resources.remove;
            statCardFailed.CardNumber = "5";
            statCardFailed.Dock = DockStyle.Fill;
            statCardFailed.Margin = new Padding(8, 0, 8, 0);
            statCardFailed.Name = "statCardFailed";
            statCardFailed.TabIndex = 2;
            // 
            // statCardRefunded
            // 
            statCardRefunded.CardCaption = "Refunded";
            statCardRefunded.CardNumber = "0";
            statCardRefunded.Dock = DockStyle.Fill;
            statCardRefunded.Margin = new Padding(8, 0, 8, 0);
            statCardRefunded.Name = "statCardRefunded";
            statCardRefunded.TabIndex = 3;
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(txtSearch);
            pnlActions.Controls.Add(cmbFilter);
            pnlActions.Controls.Add(btnNewTransaction);
            pnlActions.Dock = DockStyle.Fill;
            pnlActions.Name = "pnlActions";
            pnlActions.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(0, 17);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(580, 34);
            txtSearch.StateCommon.Back.Color1 = Color.White;
            txtSearch.StateCommon.Border.Color1 = Color.FromArgb(222, 226, 230);
            txtSearch.StateCommon.Border.Rounding = 12F;
            txtSearch.TabIndex = 0;
            // 
            // cmbFilter
            // 
            cmbFilter.Location = new Point(700, 17);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(150, 34);
            cmbFilter.StateCommon.ComboBox.Back.Color1 = Color.White;
            cmbFilter.StateCommon.ComboBox.Border.Color1 = Color.FromArgb(222, 226, 230);
            cmbFilter.StateCommon.ComboBox.Border.Rounding = 12F;
            cmbFilter.TabIndex = 1;
            // 
            // btnNewTransaction
            // 
            btnNewTransaction.Location = new Point(870, 15);
            btnNewTransaction.Name = "btnNewTransaction";
            btnNewTransaction.Size = new Size(172, 40);
            btnNewTransaction.StateCommon.Back.Color1 = Color.FromArgb(141, 198, 63);
            btnNewTransaction.StateCommon.Back.Color2 = Color.FromArgb(91, 154, 42);
            btnNewTransaction.StateCommon.Back.ColorAngle = 90F;
            btnNewTransaction.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Linear;
            btnNewTransaction.StateCommon.Border.Rounding = 12F;
            btnNewTransaction.StateCommon.Content.ShortText.Color1 = Color.White;
            btnNewTransaction.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNewTransaction.TabIndex = 2;
            btnNewTransaction.Values.DropDownArrowColor = Color.Empty;
            btnNewTransaction.Values.Text = "＋  New Transaction";
            // 
            // roundedPanelTable
            // 
            roundedPanelTable.BackColor = Color.White;
            roundedPanelTable.BorderColor = Color.Transparent;
            roundedPanelTable.BorderRadius = 8;
            roundedPanelTable.Controls.Add(dgvPayments);
            roundedPanelTable.Dock = DockStyle.Fill;
            roundedPanelTable.Margin = new Padding(8);
            roundedPanelTable.Name = "roundedPanelTable";
            roundedPanelTable.Padding = new Padding(5);
            roundedPanelTable.ShadowColor = Color.Black;
            roundedPanelTable.ShadowOffsetY = 2;
            roundedPanelTable.ShadowOpacity = 28;
            roundedPanelTable.ShadowSize = 4;
            roundedPanelTable.TabIndex = 3;
            // 
            // dgvPayments
            // 
            dgvPayments.BackgroundColor = Color.White;
            dgvPayments.BorderStyle = BorderStyle.None;
            dgvPayments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPayments.ColumnHeadersHeight = 42;
            dgvPayments.Dock = DockStyle.Fill;
            dgvPayments.GridColor = Color.FromArgb(233, 236, 239);
            dgvPayments.Margin = new Padding(0);
            dgvPayments.Name = "dgvPayments";
            dgvPayments.RowHeadersVisible = false;
            dgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPayments.TabIndex = 0;
            // 
            // PaymentModule
            // 
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(237, 240, 241);
            Controls.Add(tlpMain);
            MinimumSize = new Size(0, 0);
            Name = "PaymentModule";
            Size = new Size(1150, 938);
            tlpMain.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tlpMetrics.ResumeLayout(false);
            pnlActions.ResumeLayout(false);
            pnlActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cmbFilter).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpMain;
        private Panel pnlHeader;
        private Label lblBreadcrumb;
        private Label lblTitle;
        private TableLayoutPanel tlpMetrics;
        private PMS_v1.UserControls.Statcard statCardCompleted;
        private PMS_v1.UserControls.Statcard statCardPending;
        private PMS_v1.UserControls.Statcard statCardFailed;
        private PMS_v1.UserControls.Statcard statCardRefunded;
        private Panel pnlActions;
        private Krypton.Toolkit.KryptonTextBox txtSearch;
        private Krypton.Toolkit.KryptonComboBox cmbFilter;
        private Krypton.Toolkit.KryptonButton btnNewTransaction;
        private PMS_v1.RoundedPanel roundedPanelTable;
        private DataGridView dgvPayments;
    }
}
