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
            lblBreadcrumb = new Label();
            lblTitle = new Label();
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
            tlpMain.Padding = new Padding(42, 18, 42, 12);
            tlpMain.RowCount = 4;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.Size = new Size(1150, 938);
            tlpMain.TabIndex = 0;
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblBreadcrumb);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Fill;
            pnlHeader.Location = new Point(45, 21);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1060, 90);
            pnlHeader.TabIndex = 0;
            // 
            // lblBreadcrumb
            // 
            lblBreadcrumb.AutoSize = true;
            lblBreadcrumb.Font = new Font("Segoe UI", 8.5F);
            lblBreadcrumb.ForeColor = Color.FromArgb(108, 117, 125);
            lblBreadcrumb.Location = new Point(0, 20);
            lblBreadcrumb.Name = "lblBreadcrumb";
            lblBreadcrumb.Size = new Size(120, 15);
            lblBreadcrumb.TabIndex = 0;
            lblBreadcrumb.Text = "Home / Maintenance";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Location = new Point(0, 43);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(162, 32);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Maintenance";
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
            tlpMetrics.Location = new Point(42, 114);
            tlpMetrics.Margin = new Padding(0);
            tlpMetrics.Name = "tlpMetrics";
            tlpMetrics.RowCount = 1;
            tlpMetrics.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMetrics.Size = new Size(1066, 120);
            tlpMetrics.TabIndex = 1;
            // 
            // statCardCompleted
            // 
            statCardCompleted.CardCaption = "Completed";
            statCardCompleted.CardIcon = Resources.Resources.check;
            statCardCompleted.CardNumber = "00";
            statCardCompleted.Dock = DockStyle.Fill;
            statCardCompleted.Location = new Point(8, 0);
            statCardCompleted.Margin = new Padding(8, 0, 8, 0);
            statCardCompleted.Name = "statCardCompleted";
            statCardCompleted.Size = new Size(250, 120);
            statCardCompleted.TabIndex = 0;
            // 
            // statCardScheduled
            // 
            statCardScheduled.CardCaption = "Scheduled";
            statCardScheduled.CardIcon = Resources.Resources.clock;
            statCardScheduled.CardNumber = "00";
            statCardScheduled.Dock = DockStyle.Fill;
            statCardScheduled.Location = new Point(274, 0);
            statCardScheduled.Margin = new Padding(8, 0, 8, 0);
            statCardScheduled.Name = "statCardScheduled";
            statCardScheduled.Size = new Size(250, 120);
            statCardScheduled.TabIndex = 1;
            // 
            // statCardInProgress
            // 
            statCardInProgress.CardCaption = "In Progress";
            statCardInProgress.CardIcon = Resources.Resources.hourglass;
            statCardInProgress.CardNumber = "00";
            statCardInProgress.Dock = DockStyle.Fill;
            statCardInProgress.Location = new Point(540, 0);
            statCardInProgress.Margin = new Padding(8, 0, 8, 0);
            statCardInProgress.Name = "statCardInProgress";
            statCardInProgress.Size = new Size(250, 120);
            statCardInProgress.TabIndex = 2;
            // 
            // statCardCanceled
            // 
            statCardCanceled.BackgroundImage = Resources.Resources.remove;
            statCardCanceled.CardCaption = "Canceled";
            statCardCanceled.CardNumber = "00";
            statCardCanceled.Dock = DockStyle.Fill;
            statCardCanceled.Location = new Point(806, 0);
            statCardCanceled.Margin = new Padding(8, 0, 8, 0);
            statCardCanceled.Name = "statCardCanceled";
            statCardCanceled.Size = new Size(252, 120);
            statCardCanceled.TabIndex = 3;
            statCardCanceled.Load += statCardCanceled_Load;
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(txtSearch);
            pnlActions.Controls.Add(cmbFilter);
            pnlActions.Controls.Add(btnNewRequest);
            pnlActions.Dock = DockStyle.Fill;
            pnlActions.Location = new Point(45, 237);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(1060, 66);
            pnlActions.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(0, 17);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(580, 31);
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
            cmbFilter.Size = new Size(150, 30);
            cmbFilter.StateCommon.ComboBox.Back.Color1 = Color.White;
            cmbFilter.StateCommon.ComboBox.Border.Color1 = Color.FromArgb(222, 226, 230);
            cmbFilter.StateCommon.ComboBox.Border.Rounding = 12F;
            cmbFilter.TabIndex = 1;
            // 
            // btnNewRequest
            // 
            btnNewRequest.Location = new Point(870, 15);
            btnNewRequest.Name = "btnNewRequest";
            btnNewRequest.Size = new Size(190, 40);
            btnNewRequest.StateCommon.Back.Color1 = Color.FromArgb(141, 198, 63);
            btnNewRequest.StateCommon.Back.Color2 = Color.FromArgb(91, 154, 42);
            btnNewRequest.StateCommon.Back.ColorAngle = 90F;
            btnNewRequest.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Linear;
            btnNewRequest.StateCommon.Border.Rounding = 12F;
            btnNewRequest.StateCommon.Content.ShortText.Color1 = Color.White;
            btnNewRequest.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
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
            roundedPanelTable.Location = new Point(50, 314);
            roundedPanelTable.Margin = new Padding(8);
            roundedPanelTable.Name = "roundedPanelTable";
            roundedPanelTable.Padding = new Padding(5);
            roundedPanelTable.ShadowColor = Color.Black;
            roundedPanelTable.ShadowOpacity = 28;
            roundedPanelTable.ShadowSize = 4;
            roundedPanelTable.Size = new Size(1050, 604);
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
            dgvRequests.Location = new Point(9, 11);
            dgvRequests.Margin = new Padding(0);
            dgvRequests.Name = "dgvRequests";
            dgvRequests.RowHeadersVisible = false;
            dgvRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequests.Size = new Size(1032, 582);
            dgvRequests.TabIndex = 0;
            // 
            // MaintenanceModule
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(237, 240, 241);
            Controls.Add(tlpMain);
            Name = "MaintenanceModule";
            Size = new Size(1150, 938);
            tlpMain.ResumeLayout(false);
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
