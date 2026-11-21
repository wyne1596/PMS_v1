namespace PMS_v1.Pages
{
    partial class ResidentsModule
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
            components = new System.ComponentModel.Container();
            tlpMain = new TableLayoutPanel();
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblBreadcrumb = new Label();
            tlpMetrics = new TableLayoutPanel();
            statCardTotal = new PMS_v1.UserControls.AppearanceIconStatcard();
            statCardWithLease = new PMS_v1.UserControls.AppearanceIconStatcard();
            statCardNoLease = new PMS_v1.UserControls.AppearanceIconStatcard();
            statCardNew = new PMS_v1.UserControls.AppearanceIconStatcard();
            pnlActions = new Panel();
            txtSearch = new Krypton.Toolkit.KryptonTextBox();
            cmbFilter = new Krypton.Toolkit.KryptonComboBox();
            btnNewResident = new Krypton.Toolkit.KryptonButton();
            btnEditResident = new Krypton.Toolkit.KryptonButton();
            btnDeleteResident = new Krypton.Toolkit.KryptonButton();
            roundedPanelTable = new RoundedPanel();
            dgvResidents = new DataGridView();
            ctxRow = new ContextMenuStrip(components);
            mnuEdit = new ToolStripMenuItem();
            mnuDelete = new ToolStripMenuItem();
            tlpMain.SuspendLayout();
            pnlHeader.SuspendLayout();
            tlpMetrics.SuspendLayout();
            pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbFilter).BeginInit();
            roundedPanelTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResidents).BeginInit();
            ctxRow.SuspendLayout();
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
            lblTitle.Size = new Size(152, 37);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Residents";
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
            lblBreadcrumb.Size = new Size(138, 31);
            lblBreadcrumb.TabIndex = 0;
            lblBreadcrumb.Text = "Home / Residents";
            // 
            // tlpMetrics
            // 
            tlpMetrics.ColumnCount = 4;
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetrics.Controls.Add(statCardTotal, 0, 0);
            tlpMetrics.Controls.Add(statCardWithLease, 1, 0);
            tlpMetrics.Controls.Add(statCardNoLease, 2, 0);
            tlpMetrics.Controls.Add(statCardNew, 3, 0);
            tlpMetrics.Dock = DockStyle.Fill;
            tlpMetrics.Location = new Point(3, 77);
            tlpMetrics.Name = "tlpMetrics";
            tlpMetrics.RowCount = 1;
            tlpMetrics.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMetrics.Size = new Size(1308, 149);
            tlpMetrics.TabIndex = 1;
            // 
            // statCardTotal
            // 
            statCardTotal.CardCaption = "Total Residents";
            statCardTotal.CardIcon = null;
            statCardTotal.CardNumber = "00";
            statCardTotal.Dock = DockStyle.Fill;
            statCardTotal.IconSlotPadding = new Padding(6, 16, 6, 16);
            statCardTotal.Location = new Point(15, 0);
            statCardTotal.Margin = new Padding(15, 0, 7, 0);
            statCardTotal.Name = "statCardTotal";
            statCardTotal.Size = new Size(305, 149);
            statCardTotal.TabIndex = 0;
            // 
            // statCardWithLease
            // 
            statCardWithLease.CardCaption = "With Active Lease";
            statCardWithLease.CardIcon = null;
            statCardWithLease.CardNumber = "00";
            statCardWithLease.Dock = DockStyle.Fill;
            statCardWithLease.IconSlotPadding = new Padding(6, 16, 6, 16);
            statCardWithLease.Location = new Point(334, 0);
            statCardWithLease.Margin = new Padding(7, 0, 7, 0);
            statCardWithLease.Name = "statCardWithLease";
            statCardWithLease.Size = new Size(313, 149);
            statCardWithLease.TabIndex = 1;
            // 
            // statCardNoLease
            // 
            statCardNoLease.CardCaption = "No Active Lease";
            statCardNoLease.CardIcon = null;
            statCardNoLease.CardNumber = "00";
            statCardNoLease.Dock = DockStyle.Fill;
            statCardNoLease.IconSlotPadding = new Padding(6, 16, 6, 16);
            statCardNoLease.Location = new Point(661, 0);
            statCardNoLease.Margin = new Padding(7, 0, 7, 0);
            statCardNoLease.Name = "statCardNoLease";
            statCardNoLease.Size = new Size(313, 149);
            statCardNoLease.TabIndex = 2;
            // 
            // statCardNew
            // 
            statCardNew.CardCaption = "Added This Month";
            statCardNew.CardIcon = null;
            statCardNew.CardNumber = "00";
            statCardNew.Dock = DockStyle.Fill;
            statCardNew.IconSlotPadding = new Padding(6, 16, 6, 16);
            statCardNew.Location = new Point(988, 0);
            statCardNew.Margin = new Padding(7, 0, 15, 0);
            statCardNew.Name = "statCardNew";
            statCardNew.Size = new Size(305, 149);
            statCardNew.TabIndex = 3;
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(txtSearch);
            pnlActions.Controls.Add(cmbFilter);
            pnlActions.Controls.Add(btnNewResident);
            pnlActions.Controls.Add(btnEditResident);
            pnlActions.Controls.Add(btnDeleteResident);
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
            txtSearch.CueHint.CueHintText = "⌕  Search resident, contact or email...";
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
            cmbFilter.Location = new Point(669, 24);
            cmbFilter.Margin = new Padding(3, 4, 3, 4);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(171, 34);
            cmbFilter.StateCommon.ComboBox.Back.Color1 = Color.White;
            cmbFilter.StateCommon.ComboBox.Border.Color1 = Color.FromArgb(222, 226, 230);
            cmbFilter.StateCommon.ComboBox.Border.Rounding = 12F;
            cmbFilter.TabIndex = 1;
            // 
            // btnNewResident
            // 
            btnNewResident.Location = new Point(1084, 20);
            btnNewResident.Margin = new Padding(3, 4, 3, 4);
            btnNewResident.Name = "btnNewResident";
            btnNewResident.Size = new Size(190, 53);
            btnNewResident.StateCommon.Back.Color1 = Color.FromArgb(141, 198, 63);
            btnNewResident.StateCommon.Back.Color2 = Color.FromArgb(91, 154, 42);
            btnNewResident.StateCommon.Back.ColorAngle = 90F;
            btnNewResident.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Linear;
            btnNewResident.StateCommon.Border.Rounding = 12F;
            btnNewResident.StateCommon.Content.ShortText.Color1 = Color.White;
            btnNewResident.StateCommon.Content.ShortText.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            btnNewResident.TabIndex = 2;
            btnNewResident.Values.DropDownArrowColor = Color.Empty;
            btnNewResident.Values.Text = "＋  New Resident";
            btnNewResident.Click += btnNewResident_Click;
            // 
            // btnEditResident
            // 
            btnEditResident.Location = new Point(846, 20);
            btnEditResident.Name = "btnEditResident";
            btnEditResident.Size = new Size(110, 53);
            btnEditResident.StateCommon.Back.Color1 = Color.FromArgb(74, 151, 196);
            btnEditResident.StateCommon.Back.Color2 = Color.FromArgb(52, 120, 165);
            btnEditResident.StateCommon.Back.ColorAngle = 90F;
            btnEditResident.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Linear;
            btnEditResident.StateCommon.Border.Rounding = 12F;
            btnEditResident.StateCommon.Content.ShortText.Color1 = Color.White;
            btnEditResident.StateCommon.Content.ShortText.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            btnEditResident.TabIndex = 3;
            btnEditResident.Values.DropDownArrowColor = Color.Empty;
            btnEditResident.Values.Text = "Edit";
            btnEditResident.Click += btnEditResident_Click;
            // 
            // btnDeleteResident
            // 
            btnDeleteResident.Location = new Point(962, 20);
            btnDeleteResident.Name = "btnDeleteResident";
            btnDeleteResident.Size = new Size(110, 53);
            btnDeleteResident.StateCommon.Back.Color1 = Color.FromArgb(226, 92, 88);
            btnDeleteResident.StateCommon.Back.Color2 = Color.FromArgb(192, 57, 53);
            btnDeleteResident.StateCommon.Back.ColorAngle = 90F;
            btnDeleteResident.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Linear;
            btnDeleteResident.StateCommon.Border.Rounding = 12F;
            btnDeleteResident.StateCommon.Content.ShortText.Color1 = Color.White;
            btnDeleteResident.StateCommon.Content.ShortText.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            btnDeleteResident.TabIndex = 4;
            btnDeleteResident.Values.DropDownArrowColor = Color.Empty;
            btnDeleteResident.Values.Text = "Delete";
            btnDeleteResident.Click += btnDeleteResident_Click;
            // 
            // roundedPanelTable
            // 
            roundedPanelTable.BackColor = Color.White;
            roundedPanelTable.BorderColor = Color.Transparent;
            roundedPanelTable.BorderRadius = 10;
            roundedPanelTable.Controls.Add(dgvResidents);
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
            // dgvResidents
            // 
            dgvResidents.BackgroundColor = Color.White;
            dgvResidents.BorderStyle = BorderStyle.None;
            dgvResidents.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvResidents.ColumnHeadersHeight = 42;
            dgvResidents.ContextMenuStrip = ctxRow;
            dgvResidents.Dock = DockStyle.Fill;
            dgvResidents.GridColor = Color.FromArgb(233, 236, 239);
            dgvResidents.Location = new Point(10, 13);
            dgvResidents.Margin = new Padding(0);
            dgvResidents.Name = "dgvResidents";
            dgvResidents.RowHeadersVisible = false;
            dgvResidents.RowHeadersWidth = 51;
            dgvResidents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResidents.Size = new Size(1264, 894);
            dgvResidents.TabIndex = 0;
            // 
            // ctxRow
            // 
            ctxRow.Font = new Font("Century Gothic", 9F);
            ctxRow.ImageScalingSize = new Size(20, 20);
            ctxRow.Items.AddRange(new ToolStripItem[] { mnuEdit, mnuDelete });
            ctxRow.Name = "ctxRow";
            ctxRow.Size = new Size(128, 52);
            // 
            // mnuEdit
            // 
            mnuEdit.Name = "mnuEdit";
            mnuEdit.Size = new Size(127, 24);
            mnuEdit.Text = "Edit";
            mnuEdit.Click += mnuEdit_Click;
            // 
            // mnuDelete
            // 
            mnuDelete.Name = "mnuDelete";
            mnuDelete.Size = new Size(127, 24);
            mnuDelete.Text = "Delete";
            mnuDelete.Click += mnuDelete_Click;
            // 
            // ResidentsModule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(237, 240, 241);
            Controls.Add(tlpMain);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ResidentsModule";
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
            ((System.ComponentModel.ISupportInitialize)dgvResidents).EndInit();
            ctxRow.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpMain;
        private Panel pnlHeader;
        private Label lblBreadcrumb;
        private Label lblTitle;
        private TableLayoutPanel tlpMetrics;
        private PMS_v1.UserControls.AppearanceIconStatcard statCardTotal;
        private PMS_v1.UserControls.AppearanceIconStatcard statCardWithLease;
        private PMS_v1.UserControls.AppearanceIconStatcard statCardNoLease;
        private PMS_v1.UserControls.AppearanceIconStatcard statCardNew;
        private Panel pnlActions;
        private Krypton.Toolkit.KryptonTextBox txtSearch;
        private Krypton.Toolkit.KryptonComboBox cmbFilter;
        private Krypton.Toolkit.KryptonButton btnNewResident;
        private Krypton.Toolkit.KryptonButton btnEditResident;
        private Krypton.Toolkit.KryptonButton btnDeleteResident;
        private PMS_v1.RoundedPanel roundedPanelTable;
        private DataGridView dgvResidents;
        private ContextMenuStrip ctxRow;
        private ToolStripMenuItem mnuEdit;
        private ToolStripMenuItem mnuDelete;
    }
}