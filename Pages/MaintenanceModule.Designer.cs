namespace PMS_v1.Pages
{
    partial class MaintenanceModule
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
            tlpMetrics = new TableLayoutPanel();
            statCardCompleted = new PMS_v1.UserControls.Statcard();
            statCardScheduled = new PMS_v1.UserControls.Statcard();
            statCardInProgress = new PMS_v1.UserControls.Statcard();
            statCardCanceled = new PMS_v1.UserControls.AppearanceIconStatcard();
            pnlActions = new Panel();
            txtSearch = new Krypton.Toolkit.KryptonTextBox();
            cmbFilter = new Krypton.Toolkit.KryptonComboBox();
            btnNewRequest = new Krypton.Toolkit.KryptonButton();
            roundedPanelTable = new RoundedPanel();
            dgvRequests = new DataGridView();
            tlpMain.SuspendLayout();
            pnlHeader.SuspendLayout();
            tlpMetrics.SuspendLayout();
            pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbFilter).BeginInit();
            roundedPanelTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).BeginInit();
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
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 160F));
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
            pnlHeader.Dock = DockStyle.Fill;
            pnlHeader.Location = new Point(3, 3);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(17, 0, 0, 0);
            pnlHeader.Size = new Size(1308, 68);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Location = new Point(17, 31);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(211, 37);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Maintenance";
            // 
            // lblBreadcrumb
            // 
            lblBreadcrumb.AutoSize = true;
            lblBreadcrumb.Dock = DockStyle.Top;
            lblBreadcrumb.Font = new Font("Century Gothic", 8.5F);
            lblBreadcrumb.ForeColor = Color.FromArgb(108, 117, 125);
            lblBreadcrumb.Location = new Point(17, 0);
            lblBreadcrumb.Name = "lblBreadcrumb";
            lblBreadcrumb.Padding = new Padding(0, 0, 0, 11);
            lblBreadcrumb.Size = new Size(167, 31);
            lblBreadcrumb.TabIndex = 0;
            lblBreadcrumb.Text = "Home / Maintenance";
            // 
            // tlpMetrics
            // 
            tlpMetrics.ColumnCount = 4;
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetrics.Controls.Add(statCardCompleted, 0, 0);
            tlpMetrics.Controls.Add(statCardScheduled, 1, 0);
            tlpMetrics.Controls.Add(statCardInProgress, 2, 0);
            tlpMetrics.Controls.Add(statCardCanceled, 3, 0);
            tlpMetrics.Dock = DockStyle.Fill;
            tlpMetrics.Location = new Point(3, 77);
            tlpMetrics.Name = "tlpMetrics";
            tlpMetrics.RowCount = 1;
            tlpMetrics.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMetrics.Size = new Size(1308, 154);
            tlpMetrics.TabIndex = 1;
            // 
            // statCardCompleted
            // 
            statCardCompleted.CardCaption = "Completed";
            statCardCompleted.CardIcon = Resources.Resources.check;
            statCardCompleted.CardNumber = "00";
            statCardCompleted.Dock = DockStyle.Fill;
            statCardCompleted.Location = new Point(15, 0);
            statCardCompleted.Margin = new Padding(15, 0, 7, 0);
            statCardCompleted.Name = "statCardCompleted";
            statCardCompleted.Size = new Size(305, 154);
            statCardCompleted.TabIndex = 0;
            // 
            // statCardScheduled
            // 
            statCardScheduled.CardCaption = "Scheduled";
            statCardScheduled.CardIcon = Resources.Resources.clock;
            statCardScheduled.CardNumber = "00";
            statCardScheduled.Dock = DockStyle.Fill;
            statCardScheduled.Location = new Point(334, 0);
            statCardScheduled.Margin = new Padding(7, 0, 7, 0);
            statCardScheduled.Name = "statCardScheduled";
            statCardScheduled.Size = new Size(313, 154);
            statCardScheduled.TabIndex = 1;
            // 
            // statCardInProgress
            // 
            statCardInProgress.CardCaption = "In Progress";
            statCardInProgress.CardIcon = Resources.Resources.hourglass;
            statCardInProgress.CardNumber = "00";
            statCardInProgress.Dock = DockStyle.Fill;
            statCardInProgress.Location = new Point(661, 0);
            statCardInProgress.Margin = new Padding(7, 0, 7, 0);
            statCardInProgress.Name = "statCardInProgress";
            statCardInProgress.Size = new Size(313, 154);
            statCardInProgress.TabIndex = 2;
            // 
            // statCardCanceled
            // 
            statCardCanceled.BackgroundImage = Resources.Resources.remove;
            statCardCanceled.CardCaption = "Canceled";
            statCardCanceled.CardIcon = Resources.Resources.remove;
            statCardCanceled.CardNumber = "00";
            statCardCanceled.Dock = DockStyle.Fill;
            statCardCanceled.Location = new Point(988, 0);
            statCardCanceled.Margin = new Padding(7, 0, 15, 0);
            statCardCanceled.Name = "statCardCanceled";
            statCardCanceled.Size = new Size(305, 154);
            statCardCanceled.TabIndex = 3;
            statCardCanceled.Load += statCardCanceled_Load;
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(txtSearch);
            pnlActions.Controls.Add(cmbFilter);
            pnlActions.Controls.Add(btnNewRequest);
            pnlActions.Dock = DockStyle.Fill;
            pnlActions.Location = new Point(15, 237);
            pnlActions.Margin = new Padding(15, 3, 15, 3);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(1284, 90);
            pnlActions.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.CueHint.Color1 = Color.FromArgb(125, 130, 134);
            txtSearch.CueHint.CueHintText = "⌕  Search maintenance requests...";
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
            // cmbFilter
            // 
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.Location = new Point(800, 23);
            cmbFilter.Margin = new Padding(3, 4, 3, 4);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(171, 34);
            cmbFilter.StateCommon.ComboBox.Back.Color1 = Color.White;
            cmbFilter.StateCommon.ComboBox.Border.Color1 = Color.FromArgb(222, 226, 230);
            cmbFilter.StateCommon.ComboBox.Border.Rounding = 12F;
            cmbFilter.TabIndex = 1;
            // 
            // btnNewRequest
            // 
            btnNewRequest.Location = new Point(994, 20);
            btnNewRequest.Margin = new Padding(3, 4, 3, 4);
            btnNewRequest.Name = "btnNewRequest";
            btnNewRequest.Size = new Size(217, 53);
            btnNewRequest.StateCommon.Back.Color1 = Color.FromArgb(141, 198, 63);
            btnNewRequest.StateCommon.Back.Color2 = Color.FromArgb(91, 154, 42);
            btnNewRequest.StateCommon.Back.ColorAngle = 90F;
            btnNewRequest.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Linear;
            btnNewRequest.StateCommon.Border.Rounding = 12F;
            btnNewRequest.StateCommon.Content.ShortText.Color1 = Color.White;
            btnNewRequest.StateCommon.Content.ShortText.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            btnNewRequest.TabIndex = 2;
            btnNewRequest.Values.DropDownArrowColor = Color.Empty;
            btnNewRequest.Values.Text = "＋  New Requests";
            // 
            // roundedPanelTable
            // 
            roundedPanelTable.BackColor = Color.White;
            roundedPanelTable.BorderColor = Color.Transparent;
            roundedPanelTable.BorderRadius = 8;
            roundedPanelTable.Controls.Add(dgvRequests);
            roundedPanelTable.Dock = DockStyle.Fill;
            roundedPanelTable.Location = new Point(15, 333);
            roundedPanelTable.Margin = new Padding(15, 3, 15, 3);
            roundedPanelTable.Name = "roundedPanelTable";
            roundedPanelTable.Padding = new Padding(6, 7, 6, 7);
            roundedPanelTable.ShadowColor = Color.Black;
            roundedPanelTable.ShadowOpacity = 28;
            roundedPanelTable.ShadowSize = 4;
            roundedPanelTable.Size = new Size(1284, 915);
            roundedPanelTable.TabIndex = 3;
            // 
            // dgvRequests
            // 
            dgvRequests.BackgroundColor = Color.White;
            dgvRequests.BorderStyle = BorderStyle.None;
            dgvRequests.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRequests.ColumnHeadersHeight = 42;
            dgvRequests.Dock = DockStyle.Fill;
            dgvRequests.GridColor = Color.FromArgb(233, 236, 239);
            dgvRequests.Location = new Point(10, 13);
            dgvRequests.Margin = new Padding(0);
            dgvRequests.Name = "dgvRequests";
            dgvRequests.RowHeadersVisible = false;
            dgvRequests.RowHeadersWidth = 51;
            dgvRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequests.Size = new Size(1264, 889);
            dgvRequests.TabIndex = 0;
            // 
            // MaintenanceModule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(237, 240, 241);
            Controls.Add(tlpMain);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MaintenanceModule";
            Size = new Size(1314, 1251);
            tlpMain.ResumeLayout(false);
            tlpMain.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tlpMetrics.ResumeLayout(false);
            pnlActions.ResumeLayout(false);
            pnlActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cmbFilter).EndInit();
            roundedPanelTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRequests).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpMain;
        private Panel pnlHeader;
        private Label lblBreadcrumb;
        private Label lblTitle;
        private TableLayoutPanel tlpMetrics;
        private PMS_v1.UserControls.Statcard statCardCompleted;
        private PMS_v1.UserControls.Statcard statCardScheduled;
        private PMS_v1.UserControls.Statcard statCardInProgress;
        private PMS_v1.UserControls.AppearanceIconStatcard statCardCanceled;
        private Panel pnlActions;
        private Krypton.Toolkit.KryptonTextBox txtSearch;
        private Krypton.Toolkit.KryptonComboBox cmbFilter;
        private Krypton.Toolkit.KryptonButton btnNewRequest;
        private PMS_v1.RoundedPanel roundedPanelTable;
        private DataGridView dgvRequests;
    }
}
