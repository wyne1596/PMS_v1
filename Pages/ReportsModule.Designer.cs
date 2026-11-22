namespace PMS_v1.Pages
{
    partial class ReportsModule
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
            lblTitle = new Label();
            lblBreadcrumb = new Label();
            lblRange = new Label();
            tlpMetrics = new TableLayoutPanel();
            statCardCollected = new PMS_v1.UserControls.AppearanceIconStatcard();
            statCardBills = new PMS_v1.UserControls.AppearanceIconStatcard();
            statCardOutstanding = new PMS_v1.UserControls.AppearanceIconStatcard();
            statCardAverage = new PMS_v1.UserControls.AppearanceIconStatcard();
            pnlActions = new Panel();
            txtSearch = new Krypton.Toolkit.KryptonTextBox();
            cmbPeriod = new Krypton.Toolkit.KryptonComboBox();
            roundedPanelTable = new RoundedPanel();
            dgvReport = new DataGridView();
            tlpMain.SuspendLayout();
            pnlHeader.SuspendLayout();
            tlpMetrics.SuspendLayout();
            pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbPeriod).BeginInit();
            roundedPanelTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
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
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 155F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.Size = new Size(1314, 1251);
            tlpMain.TabIndex = 0;
            // 
            // pnlHeader
            // 
            pnlHeader.AutoSize = true;
            pnlHeader.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblBreadcrumb);
            pnlHeader.Controls.Add(lblRange);
            pnlHeader.Dock = DockStyle.Fill;
            pnlHeader.Location = new Point(3, 3);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(15, 0, 0, 0);
            pnlHeader.Size = new Size(1308, 68);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Location = new Point(15, 31);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(124, 37);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Reports";
            // 
            // lblBreadcrumb
            // 
            lblBreadcrumb.AutoSize = true;
            lblBreadcrumb.Dock = DockStyle.Top;
            lblBreadcrumb.Font = new Font("Century Gothic", 8.5F);
            lblBreadcrumb.ForeColor = Color.FromArgb(108, 117, 125);
            lblBreadcrumb.Location = new Point(15, 0);
            lblBreadcrumb.Name = "lblBreadcrumb";
            lblBreadcrumb.Padding = new Padding(3, 0, 0, 11);
            lblBreadcrumb.Size = new Size(125, 31);
            lblBreadcrumb.TabIndex = 0;
            lblBreadcrumb.Text = "Home / Reports";
            // 
            // lblRange
            // 
            lblRange.AutoSize = true;
            lblRange.Dock = DockStyle.Right;
            lblRange.Font = new Font("Century Gothic", 9.5F);
            lblRange.ForeColor = Color.FromArgb(108, 117, 125);
            lblRange.Location = new Point(1293, 0);
            lblRange.Name = "lblRange";
            lblRange.Padding = new Padding(0, 0, 15, 8);
            lblRange.Size = new Size(15, 29);
            lblRange.TabIndex = 2;
            lblRange.TextAlign = ContentAlignment.BottomRight;
            // 
            // tlpMetrics
            // 
            tlpMetrics.ColumnCount = 4;
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetrics.Controls.Add(statCardCollected, 0, 0);
            tlpMetrics.Controls.Add(statCardBills, 1, 0);
            tlpMetrics.Controls.Add(statCardOutstanding, 2, 0);
            tlpMetrics.Controls.Add(statCardAverage, 3, 0);
            tlpMetrics.Dock = DockStyle.Fill;
            tlpMetrics.Location = new Point(3, 77);
            tlpMetrics.Name = "tlpMetrics";
            tlpMetrics.RowCount = 1;
            tlpMetrics.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMetrics.Size = new Size(1308, 149);
            tlpMetrics.TabIndex = 1;
            // 
            // statCardCollected
            // 
            statCardCollected.CardCaption = "Total Collected";
            statCardCollected.CardIcon = null;
            statCardCollected.CardNumber = "₱0";
            statCardCollected.Dock = DockStyle.Fill;
            statCardCollected.IconSlotPadding = new Padding(6, 16, 6, 16);
            statCardCollected.Location = new Point(15, 0);
            statCardCollected.Margin = new Padding(15, 0, 7, 0);
            statCardCollected.Name = "statCardCollected";
            statCardCollected.Size = new Size(305, 149);
            statCardCollected.TabIndex = 0;
            // 
            // statCardBills
            // 
            statCardBills.CardCaption = "Payments";
            statCardBills.CardIcon = null;
            statCardBills.CardNumber = "0";
            statCardBills.Dock = DockStyle.Fill;
            statCardBills.IconSlotPadding = new Padding(6, 16, 6, 16);
            statCardBills.Location = new Point(334, 0);
            statCardBills.Margin = new Padding(7, 0, 7, 0);
            statCardBills.Name = "statCardBills";
            statCardBills.Size = new Size(313, 149);
            statCardBills.TabIndex = 1;
            // 
            // statCardOutstanding
            // 
            statCardOutstanding.CardCaption = "Still Owed";
            statCardOutstanding.CardIcon = null;
            statCardOutstanding.CardNumber = "₱0";
            statCardOutstanding.Dock = DockStyle.Fill;
            statCardOutstanding.IconSlotPadding = new Padding(6, 16, 6, 16);
            statCardOutstanding.Location = new Point(661, 0);
            statCardOutstanding.Margin = new Padding(7, 0, 7, 0);
            statCardOutstanding.Name = "statCardOutstanding";
            statCardOutstanding.Size = new Size(313, 149);
            statCardOutstanding.TabIndex = 2;
            // 
            // statCardAverage
            // 
            statCardAverage.CardCaption = "Avg. Payment";
            statCardAverage.CardIcon = null;
            statCardAverage.CardNumber = "₱0";
            statCardAverage.Dock = DockStyle.Fill;
            statCardAverage.IconSlotPadding = new Padding(6, 16, 6, 16);
            statCardAverage.Location = new Point(988, 0);
            statCardAverage.Margin = new Padding(7, 0, 15, 0);
            statCardAverage.Name = "statCardAverage";
            statCardAverage.Size = new Size(305, 149);
            statCardAverage.TabIndex = 3;
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(txtSearch);
            pnlActions.Controls.Add(cmbPeriod);
            pnlActions.Dock = DockStyle.Fill;
            pnlActions.Location = new Point(15, 232);
            pnlActions.Margin = new Padding(15, 3, 15, 3);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(1284, 90);
            pnlActions.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.CueHint.Color1 = Color.FromArgb(125, 130, 134);
            txtSearch.CueHint.CueHintText = "⌕  Search reference, tenant or unit...";
            txtSearch.CueHint.Font = new Font("Century Gothic", 8.5F);
            txtSearch.Location = new Point(0, 23);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(663, 35);
            txtSearch.StateCommon.Back.Color1 = Color.White;
            txtSearch.StateCommon.Border.Color1 = Color.FromArgb(222, 226, 230);
            txtSearch.StateCommon.Border.Rounding = 12F;
            txtSearch.TabIndex = 0;
            // 
            // cmbPeriod
            // 
            cmbPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPeriod.Location = new Point(1103, 24);
            cmbPeriod.Margin = new Padding(3, 4, 3, 4);
            cmbPeriod.Name = "cmbPeriod";
            cmbPeriod.Size = new Size(171, 34);
            cmbPeriod.StateCommon.ComboBox.Back.Color1 = Color.White;
            cmbPeriod.StateCommon.ComboBox.Border.Color1 = Color.FromArgb(222, 226, 230);
            cmbPeriod.StateCommon.ComboBox.Border.Rounding = 12F;
            cmbPeriod.TabIndex = 1;
            // 
            // roundedPanelTable
            // 
            roundedPanelTable.BackColor = Color.White;
            roundedPanelTable.BorderColor = Color.Transparent;
            roundedPanelTable.BorderRadius = 10;
            roundedPanelTable.Controls.Add(dgvReport);
            roundedPanelTable.Dock = DockStyle.Fill;
            roundedPanelTable.Location = new Point(15, 328);
            roundedPanelTable.Margin = new Padding(15, 3, 15, 3);
            roundedPanelTable.Name = "roundedPanelTable";
            roundedPanelTable.Padding = new Padding(6, 7, 6, 7);
            roundedPanelTable.ShadowColor = Color.Black;
            roundedPanelTable.ShadowOpacity = 28;
            roundedPanelTable.ShadowSize = 4;
            roundedPanelTable.Size = new Size(1284, 920);
            roundedPanelTable.TabIndex = 3;
            // 
            // dgvReport
            // 
            dgvReport.BackgroundColor = Color.White;
            dgvReport.BorderStyle = BorderStyle.None;
            dgvReport.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReport.ColumnHeadersHeight = 42;
            dgvReport.Dock = DockStyle.Fill;
            dgvReport.GridColor = Color.FromArgb(233, 236, 239);
            dgvReport.Location = new Point(10, 13);
            dgvReport.Margin = new Padding(0);
            dgvReport.Name = "dgvReport";
            dgvReport.RowHeadersVisible = false;
            dgvReport.RowHeadersWidth = 51;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReport.Size = new Size(1264, 894);
            dgvReport.TabIndex = 0;
            // 
            // ReportsModule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(237, 240, 241);
            Controls.Add(tlpMain);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ReportsModule";
            Size = new Size(1314, 1251);
            tlpMain.ResumeLayout(false);
            tlpMain.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tlpMetrics.ResumeLayout(false);
            pnlActions.ResumeLayout(false);
            pnlActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cmbPeriod).EndInit();
            roundedPanelTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpMain;
        private Panel pnlHeader;
        private Label lblBreadcrumb;
        private Label lblTitle;
        private Label lblRange;
        private TableLayoutPanel tlpMetrics;
        private PMS_v1.UserControls.AppearanceIconStatcard statCardCollected;
        private PMS_v1.UserControls.AppearanceIconStatcard statCardBills;
        private PMS_v1.UserControls.AppearanceIconStatcard statCardOutstanding;
        private PMS_v1.UserControls.AppearanceIconStatcard statCardAverage;
        private Panel pnlActions;
        private Krypton.Toolkit.KryptonTextBox txtSearch;
        private Krypton.Toolkit.KryptonComboBox cmbPeriod;
        private PMS_v1.RoundedPanel roundedPanelTable;
        private DataGridView dgvReport;
    }
}