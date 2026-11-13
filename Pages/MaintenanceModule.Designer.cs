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
            lblTitle.Size = new Size(196, 34);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Maintenance";
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
            lblBreadcrumb.Size = new Size(170, 31);
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
            tlpMetrics.Location = new Point(3, 78);
            tlpMetrics.Name = "tlpMetrics";
            tlpMetrics.RowCount = 1;
            tlpMetrics.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMetrics.Size = new Size(1188, 204);
            tlpMetrics.TabIndex = 1;
            // 
            // statCardCompleted
            // 
            statCardCompleted.CardCaption = "Completed";
            statCardCompleted.CardIcon = Resources.Resources.check;
            statCardCompleted.CardNumber = "12";
            statCardCompleted.Dock = DockStyle.Fill;
            statCardCompleted.Location = new Point(15, 0);
            statCardCompleted.Margin = new Padding(15, 0, 7, 0);
            statCardCompleted.Name = "statCardCompleted";
            statCardCompleted.Size = new Size(275, 204);
            statCardCompleted.TabIndex = 0;
            // 
            // statCardScheduled
            // 
            statCardScheduled.CardCaption = "Scheduled";
            statCardScheduled.CardIcon = Resources.Resources.clock;
            statCardScheduled.CardNumber = "22";
            statCardScheduled.Dock = DockStyle.Fill;
            statCardScheduled.Location = new Point(304, 0);
            statCardScheduled.Margin = new Padding(7, 0, 7, 0);
            statCardScheduled.Name = "statCardScheduled";
            statCardScheduled.Size = new Size(283, 204);
            statCardScheduled.TabIndex = 1;
            // 
            // statCardInProgress
            // 
            statCardInProgress.CardCaption = "In Progress";
            statCardInProgress.CardIcon = Resources.Resources.hourglass;
            statCardInProgress.CardNumber = "5";
            statCardInProgress.Dock = DockStyle.Fill;
            statCardInProgress.Location = new Point(601, 0);
            statCardInProgress.Margin = new Padding(7, 0, 7, 0);
            statCardInProgress.Name = "statCardInProgress";
            statCardInProgress.Size = new Size(283, 204);
            statCardInProgress.TabIndex = 2;
            // 
            // statCardCanceled
            // 
            statCardCanceled.BackgroundImage = Resources.Resources.remove;
            statCardCanceled.CardCaption = "Canceled";
            statCardCanceled.CardIcon = Resources.Resources.remove;
            statCardCanceled.CardNumber = "0";
            statCardCanceled.Dock = DockStyle.Fill;
            statCardCanceled.Location = new Point(898, 0);
            statCardCanceled.Margin = new Padding(7, 0, 15, 0);
            statCardCanceled.Name = "statCardCanceled";
            statCardCanceled.Size = new Size(275, 204);
            statCardCanceled.TabIndex = 3;
            statCardCanceled.Load += statCardCanceled_Load;
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(txtSearch);
            pnlActions.Controls.Add(cmbFilter);
            pnlActions.Controls.Add(btnNewRequest);
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
            btnNewRequest.StateCommon.Border.Color1 = Color.FromArgb(91, 154, 42);
            btnNewRequest.StateCommon.Border.Color2 = Color.FromArgb(91, 154, 42);
            btnNewRequest.StateCommon.Border.Rounding = 8F;
            btnNewRequest.StateCommon.Content.ShortText.Color1 = Color.White;
            btnNewRequest.StateCommon.Content.ShortText.Font = new Font("Century Gothic", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewRequest.StatePressed.Back.Color1 = Color.FromArgb(104, 168, 48);
            btnNewRequest.StatePressed.Back.Color2 = Color.FromArgb(74, 130, 34);
            btnNewRequest.StateTracking.Back.Color1 = Color.FromArgb(160, 212, 82);
            btnNewRequest.StateTracking.Back.Color2 = Color.FromArgb(106, 170, 52);
            btnNewRequest.TabIndex = 2;
            btnNewRequest.Values.DropDownArrowColor = Color.Empty;
            btnNewRequest.Values.Text = "＋  New Requests";
            // 
            // roundedPanelTable
            // 
            roundedPanelTable.BackColor = Color.White;
            roundedPanelTable.BorderColor = Color.Transparent;
            roundedPanelTable.BorderRadius = 10;
            roundedPanelTable.Controls.Add(dgvRequests);
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
            // dgvRequests
            // 
            dgvRequests.BackgroundColor = Color.White;
            dgvRequests.BorderStyle = BorderStyle.None;
            dgvRequests.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRequests.ColumnHeadersHeight = 42;
            dgvRequests.Dock = DockStyle.Fill;
            dgvRequests.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvRequests.GridColor = Color.FromArgb(233, 236, 239);
            dgvRequests.Location = new Point(4, 6);
            dgvRequests.Margin = new Padding(0);
            dgvRequests.Name = "dgvRequests";
            dgvRequests.RowHeadersVisible = false;
            dgvRequests.RowHeadersWidth = 51;
            dgvRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequests.Size = new Size(1156, 750);
            dgvRequests.TabIndex = 0;
            // 
            // MaintenanceModule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            Controls.Add(tlpMain);
            DoubleBuffered = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MaintenanceModule";
            Size = new Size(1194, 1207);
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
