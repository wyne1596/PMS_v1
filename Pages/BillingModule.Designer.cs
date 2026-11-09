namespace PMS_v1.Pages
{
    partial class BillingModule
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
            pnlHeader = new Panel();
            lblBreadcrumb = new Label();
            lblTitle = new Label();
            tlpMetrics = new TableLayoutPanel();
            statCardPaid = new PMS_v1.UserControls.AppearanceIconStatcard();
            statCardPartiallyPaid = new PMS_v1.UserControls.AppearanceIconStatcard();
            statCardUnpaid = new PMS_v1.UserControls.AppearanceIconStatcard();
            statCardOverdue = new PMS_v1.UserControls.AppearanceIconStatcard();
            statCardCanceled = new PMS_v1.UserControls.AppearanceIconStatcard();
            pnlActions = new Panel();
            txtSearch = new Krypton.Toolkit.KryptonTextBox();
            cmbFilter = new Krypton.Toolkit.KryptonComboBox();
            btnNewBill = new Krypton.Toolkit.KryptonButton();
            roundedPanelTable = new PMS_v1.RoundedPanel();
            dgvBills = new DataGridView();
            tlpMain.SuspendLayout();
            pnlHeader.SuspendLayout();
            tlpMetrics.SuspendLayout();
            pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbFilter).BeginInit();
            roundedPanelTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBills).BeginInit();
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
            lblBreadcrumb.Text = "Home / Billing";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Location = new Point(0, 43);
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "Billing";
            // 
            // tlpMetrics
            // 
            tlpMetrics.ColumnCount = 5;
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpMetrics.Controls.Add(statCardPaid, 0, 0);
            tlpMetrics.Controls.Add(statCardPartiallyPaid, 1, 0);
            tlpMetrics.Controls.Add(statCardUnpaid, 2, 0);
            tlpMetrics.Controls.Add(statCardOverdue, 3, 0);
            tlpMetrics.Controls.Add(statCardCanceled, 4, 0);
            tlpMetrics.Dock = DockStyle.Fill;
            tlpMetrics.Margin = Padding.Empty;
            tlpMetrics.Name = "tlpMetrics";
            tlpMetrics.RowCount = 1;
            tlpMetrics.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMetrics.TabIndex = 1;
            // 
            // statCardPaid
            // 
            statCardPaid.BackgroundImage = Resources.Resources.check;
            statCardPaid.CardCaption = "Paid";
            statCardPaid.CardNumber = "00";
            statCardPaid.Dock = DockStyle.Fill;
            statCardPaid.Location = new Point(8, 0);
            statCardPaid.Margin = new Padding(8, 0, 8, 0);
            statCardPaid.Name = "statCardPaid";
            statCardPaid.Size = new Size(197, 120);
            statCardPaid.TabIndex = 0;
            // 
            // statCardPartiallyPaid
            // 
            statCardPartiallyPaid.BackgroundImage = Resources.Resources.clock;
            statCardPartiallyPaid.CardCaption = "Partially Paid";
            statCardPartiallyPaid.CardNumber = "00";
            statCardPartiallyPaid.Dock = DockStyle.Fill;
            statCardPartiallyPaid.Location = new Point(221, 0);
            statCardPartiallyPaid.Margin = new Padding(8, 0, 8, 0);
            statCardPartiallyPaid.Name = "statCardPartiallyPaid";
            statCardPartiallyPaid.Size = new Size(197, 120);
            statCardPartiallyPaid.TabIndex = 1;
            // 
            // statCardUnpaid
            // 
            statCardUnpaid.BackgroundImage = Resources.Resources.exclamation;
            statCardUnpaid.CardCaption = "Unpaid";
            statCardUnpaid.CardNumber = "00";
            statCardUnpaid.Dock = DockStyle.Fill;
            statCardUnpaid.Location = new Point(434, 0);
            statCardUnpaid.Margin = new Padding(8, 0, 8, 0);
            statCardUnpaid.Name = "statCardUnpaid";
            statCardUnpaid.Size = new Size(197, 120);
            statCardUnpaid.TabIndex = 2;
            // 
            // statCardOverdue
            // 
            statCardOverdue.BackgroundImage = Resources.Resources.remove;
            statCardOverdue.CardCaption = "Overdue";
            statCardOverdue.CardNumber = "00";
            statCardOverdue.Dock = DockStyle.Fill;
            statCardOverdue.Location = new Point(647, 0);
            statCardOverdue.Margin = new Padding(8, 0, 8, 0);
            statCardOverdue.Name = "statCardOverdue";
            statCardOverdue.Size = new Size(197, 120);
            statCardOverdue.TabIndex = 3;
            // 
            // statCardCanceled
            // 
            statCardCanceled.BackgroundImage = Resources.Resources.remove;
            statCardCanceled.CardCaption = "Canceled";
            statCardCanceled.CardNumber = "00";
            statCardCanceled.Dock = DockStyle.Fill;
            statCardCanceled.Location = new Point(860, 0);
            statCardCanceled.Margin = new Padding(8, 0, 8, 0);
            statCardCanceled.Name = "statCardCanceled";
            statCardCanceled.Size = new Size(197, 120);
            statCardCanceled.TabIndex = 4;
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(txtSearch);
            pnlActions.Controls.Add(cmbFilter);
            pnlActions.Controls.Add(btnNewBill);
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
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.Location = new Point(700, 17);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(150, 34);
            cmbFilter.StateCommon.ComboBox.Back.Color1 = Color.White;
            cmbFilter.StateCommon.ComboBox.Border.Color1 = Color.FromArgb(222, 226, 230);
            cmbFilter.StateCommon.ComboBox.Border.Rounding = 12F;
            cmbFilter.TabIndex = 1;
            // 
            // btnNewBill
            // 
            btnNewBill.Location = new Point(870, 15);
            btnNewBill.Name = "btnNewBill";
            btnNewBill.Size = new Size(172, 40);
            btnNewBill.StateCommon.Back.Color1 = Color.FromArgb(141, 198, 63);
            btnNewBill.StateCommon.Back.Color2 = Color.FromArgb(91, 154, 42);
            btnNewBill.StateCommon.Back.ColorAngle = 90F;
            btnNewBill.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Linear;
            btnNewBill.StateCommon.Border.Rounding = 12F;
            btnNewBill.StateCommon.Content.ShortText.Color1 = Color.White;
            btnNewBill.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNewBill.TabIndex = 2;
            btnNewBill.Values.DropDownArrowColor = Color.Empty;
            btnNewBill.Values.Text = "＋  New Bill";
            // 
            // roundedPanelTable
            // 
            roundedPanelTable.BackColor = Color.White;
            roundedPanelTable.BorderColor = Color.Transparent;
            roundedPanelTable.BorderRadius = 8;
            roundedPanelTable.Controls.Add(dgvBills);
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
            // dgvBills
            // 
            dgvBills.BackgroundColor = Color.White;
            dgvBills.BorderStyle = BorderStyle.None;
            dgvBills.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvBills.ColumnHeadersHeight = 42;
            dgvBills.Dock = DockStyle.Fill;
            dgvBills.GridColor = Color.FromArgb(233, 236, 239);
            dgvBills.Margin = Padding.Empty;
            dgvBills.Name = "dgvBills";
            dgvBills.RowHeadersVisible = false;
            dgvBills.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBills.TabIndex = 0;
            // 
            // BillingModule
            // 
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(237, 240, 241);
            Controls.Add(tlpMain);
            MinimumSize = new Size(0, 0);
            Name = "BillingModule";
            Size = new Size(1150, 938);
            tlpMain.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tlpMetrics.ResumeLayout(false);
            pnlActions.ResumeLayout(false);
            pnlActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cmbFilter).EndInit();
            roundedPanelTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBills).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpMain;
        private Panel pnlHeader;
        private Label lblBreadcrumb;
        private Label lblTitle;
        private TableLayoutPanel tlpMetrics;
        private PMS_v1.UserControls.AppearanceIconStatcard statCardPaid;
        private PMS_v1.UserControls.AppearanceIconStatcard statCardPartiallyPaid;
        private PMS_v1.UserControls.AppearanceIconStatcard statCardUnpaid;
        private PMS_v1.UserControls.AppearanceIconStatcard statCardOverdue;
        private PMS_v1.UserControls.AppearanceIconStatcard statCardCanceled;
        private Panel pnlActions;
        private Krypton.Toolkit.KryptonTextBox txtSearch;
        private Krypton.Toolkit.KryptonComboBox cmbFilter;
        private Krypton.Toolkit.KryptonButton btnNewBill;
        private PMS_v1.RoundedPanel roundedPanelTable;
        private DataGridView dgvBills;
    }
}
