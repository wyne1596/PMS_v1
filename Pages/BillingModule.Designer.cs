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
            lblTitle = new Label();
            lblBreadcrumb = new Label();
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
            roundedPanelTable = new RoundedPanel();
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
            tlpMain.Location = new Point(0, 0);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 4;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 75F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 18.5542164F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 13.6144581F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 67.83132F));
            tlpMain.Size = new Size(1194, 1207);
            tlpMain.TabIndex = 0;
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblBreadcrumb);
            pnlHeader.Dock = DockStyle.Fill;
            pnlHeader.Location = new Point(3, 3);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(15, 0, 0, 0);
            pnlHeader.Size = new Size(1188, 69);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(51, 51, 51);
            lblTitle.Location = new Point(15, 31);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(94, 34);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Billing";
            // 
            // lblBreadcrumb
            // 
            lblBreadcrumb.AutoSize = true;
            lblBreadcrumb.Dock = DockStyle.Top;
            lblBreadcrumb.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBreadcrumb.ForeColor = Color.FromArgb(108, 117, 125);
            lblBreadcrumb.Location = new Point(15, 0);
            lblBreadcrumb.Name = "lblBreadcrumb";
            lblBreadcrumb.Padding = new Padding(3, 0, 0, 11);
            lblBreadcrumb.Size = new Size(110, 31);
            lblBreadcrumb.TabIndex = 1;
            lblBreadcrumb.Text = "Home / Billing";
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
            tlpMetrics.Location = new Point(3, 78);
            tlpMetrics.Name = "tlpMetrics";
            tlpMetrics.RowCount = 1;
            tlpMetrics.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMetrics.Size = new Size(1188, 204);
            tlpMetrics.TabIndex = 1;
            // 
            // statCardPaid
            // 
            statCardPaid.BackgroundImage = Resources.Resources.check;
            statCardPaid.CardCaption = "Paid";
            statCardPaid.CardIcon = Resources.Resources.check;
            statCardPaid.CardNumber = "12";
            statCardPaid.Dock = DockStyle.Fill;
            statCardPaid.Location = new Point(15, 0);
            statCardPaid.Margin = new Padding(15, 0, 7, 0);
            statCardPaid.Name = "statCardPaid";
            statCardPaid.Size = new Size(215, 204);
            statCardPaid.TabIndex = 0;
            // 
            // statCardPartiallyPaid
            // 
            statCardPartiallyPaid.BackgroundImage = Resources.Resources.clock;
            statCardPartiallyPaid.CardCaption = "Partially Paid";
            statCardPartiallyPaid.CardIcon = Resources.Resources.clock;
            statCardPartiallyPaid.CardNumber = "22";
            statCardPartiallyPaid.Dock = DockStyle.Fill;
            statCardPartiallyPaid.Location = new Point(244, 0);
            statCardPartiallyPaid.Margin = new Padding(7, 0, 7, 0);
            statCardPartiallyPaid.Name = "statCardPartiallyPaid";
            statCardPartiallyPaid.Size = new Size(223, 204);
            statCardPartiallyPaid.TabIndex = 1;
            // 
            // statCardUnpaid
            // 
            statCardUnpaid.BackgroundImage = Resources.Resources.exclamation;
            statCardUnpaid.CardCaption = "Unpaid";
            statCardUnpaid.CardIcon = Resources.Resources.exclamation;
            statCardUnpaid.CardNumber = "5";
            statCardUnpaid.Dock = DockStyle.Fill;
            statCardUnpaid.Location = new Point(481, 0);
            statCardUnpaid.Margin = new Padding(7, 0, 7, 0);
            statCardUnpaid.Name = "statCardUnpaid";
            statCardUnpaid.Size = new Size(223, 204);
            statCardUnpaid.TabIndex = 2;
            // 
            // statCardOverdue
            // 
            statCardOverdue.BackgroundImage = Resources.Resources.remove;
            statCardOverdue.CardCaption = "Overdue";
            statCardOverdue.CardIcon = Resources.Resources.remove;
            statCardOverdue.CardNumber = "0";
            statCardOverdue.Dock = DockStyle.Fill;
            statCardOverdue.Location = new Point(718, 0);
            statCardOverdue.Margin = new Padding(7, 0, 7, 0);
            statCardOverdue.Name = "statCardOverdue";
            statCardOverdue.Size = new Size(223, 204);
            statCardOverdue.TabIndex = 3;
            // 
            // statCardCanceled
            // 
            statCardCanceled.BackgroundImage = Resources.Resources.remove;
            statCardCanceled.CardCaption = "Canceled";
            statCardCanceled.CardIcon = Resources.Resources.remove;
            statCardCanceled.CardNumber = "10";
            statCardCanceled.Dock = DockStyle.Fill;
            statCardCanceled.Location = new Point(955, 0);
            statCardCanceled.Margin = new Padding(7, 0, 15, 0);
            statCardCanceled.Name = "statCardCanceled";
            statCardCanceled.Size = new Size(218, 204);
            statCardCanceled.TabIndex = 4;
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(txtSearch);
            pnlActions.Controls.Add(cmbFilter);
            pnlActions.Controls.Add(btnNewBill);
            pnlActions.Dock = DockStyle.Fill;
            pnlActions.Location = new Point(15, 288);
            pnlActions.Margin = new Padding(15, 3, 15, 3);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(1164, 148);
            pnlActions.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(0, 23);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(663, 33);
            txtSearch.StateActive.Border.Color1 = Color.FromArgb(74, 151, 196);
            txtSearch.StateActive.Border.Color2 = Color.FromArgb(74, 151, 196);
            txtSearch.StateCommon.Back.Color1 = Color.White;
            txtSearch.StateCommon.Border.Color1 = Color.FromArgb(222, 226, 230);
            txtSearch.StateCommon.Border.Color2 = Color.FromArgb(222, 226, 230);
            txtSearch.StateCommon.Border.Rounding = 8F;
            txtSearch.StateCommon.Content.Color1 = Color.FromArgb(51, 51, 51);
            txtSearch.StateCommon.Content.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.TabIndex = 0;
            // 
            // cmbFilter
            // 
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.Location = new Point(800, 23);
            cmbFilter.Margin = new Padding(3, 4, 3, 4);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(171, 32);
            cmbFilter.StateActive.ComboBox.Border.Color1 = Color.FromArgb(74, 151, 196);
            cmbFilter.StateActive.ComboBox.Border.Color2 = Color.FromArgb(74, 151, 196);
            cmbFilter.StateCommon.ComboBox.Back.Color1 = Color.White;
            cmbFilter.StateCommon.ComboBox.Border.Color1 = Color.FromArgb(222, 226, 230);
            cmbFilter.StateCommon.ComboBox.Border.Color2 = Color.FromArgb(222, 226, 230);
            cmbFilter.StateCommon.ComboBox.Border.Rounding = 8F;
            cmbFilter.StateCommon.ComboBox.Content.Color1 = Color.FromArgb(51, 51, 51);
            cmbFilter.StateCommon.ComboBox.Content.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbFilter.TabIndex = 1;
            // 
            // btnNewBill
            // 
            btnNewBill.Location = new Point(994, 20);
            btnNewBill.Margin = new Padding(3, 4, 3, 4);
            btnNewBill.Name = "btnNewBill";
            btnNewBill.Size = new Size(197, 53);
            btnNewBill.StateCommon.Back.Color1 = Color.FromArgb(141, 198, 63);
            btnNewBill.StateCommon.Back.Color2 = Color.FromArgb(91, 154, 42);
            btnNewBill.StateCommon.Back.ColorAngle = 90F;
            btnNewBill.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Linear;
            btnNewBill.StateCommon.Border.Color1 = Color.FromArgb(91, 154, 42);
            btnNewBill.StateCommon.Border.Color2 = Color.FromArgb(91, 154, 42);
            btnNewBill.StateCommon.Border.Rounding = 8F;
            btnNewBill.StateCommon.Content.ShortText.Color1 = Color.White;
            btnNewBill.StateCommon.Content.ShortText.Font = new Font("Century Gothic", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewBill.StatePressed.Back.Color1 = Color.FromArgb(104, 168, 48);
            btnNewBill.StatePressed.Back.Color2 = Color.FromArgb(74, 130, 34);
            btnNewBill.StateTracking.Back.Color1 = Color.FromArgb(160, 212, 82);
            btnNewBill.StateTracking.Back.Color2 = Color.FromArgb(106, 170, 52);
            btnNewBill.TabIndex = 2;
            btnNewBill.Values.DropDownArrowColor = Color.Empty;
            btnNewBill.Values.Text = "＋  New Bill";
            // 
            // roundedPanelTable
            // 
            roundedPanelTable.BackColor = Color.White;
            roundedPanelTable.BorderColor = Color.Transparent;
            roundedPanelTable.BorderRadius = 10;
            roundedPanelTable.Controls.Add(dgvBills);
            roundedPanelTable.Dock = DockStyle.Fill;
            roundedPanelTable.Location = new Point(15, 442);
            roundedPanelTable.Margin = new Padding(15, 3, 15, 3);
            roundedPanelTable.Name = "roundedPanelTable";
            roundedPanelTable.ShadowColor = Color.Black;
            roundedPanelTable.ShadowOpacity = 32;
            roundedPanelTable.ShadowSize = 4;
            roundedPanelTable.Size = new Size(1164, 762);
            roundedPanelTable.TabIndex = 3;
            // 
            // dgvBills
            // 
            dgvBills.BackgroundColor = Color.White;
            dgvBills.BorderStyle = BorderStyle.None;
            dgvBills.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvBills.ColumnHeadersHeight = 42;
            dgvBills.Dock = DockStyle.Fill;
            dgvBills.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvBills.GridColor = Color.FromArgb(233, 236, 239);
            dgvBills.Location = new Point(4, 6);
            dgvBills.Margin = new Padding(0);
            dgvBills.Name = "dgvBills";
            dgvBills.RowHeadersVisible = false;
            dgvBills.RowHeadersWidth = 51;
            dgvBills.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBills.Size = new Size(1156, 750);
            dgvBills.TabIndex = 0;
            // 
            // BillingModule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            Controls.Add(tlpMain);
            DoubleBuffered = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "BillingModule";
            Size = new Size(1194, 1207);
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
