namespace PMS_v1.Pages.Content.Leasing
{
    partial class LeasingModule
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
            components = new System.ComponentModel.Container();
            tlpMainSkeleton = new TableLayoutPanel();
            pnlHeaderBlock = new Panel();
            lblModuleTitle = new Label();
            lblBreadcrumb = new Label();
            tlpMetricsRow = new TableLayoutPanel();
            statCardActive = new PMS_v1.UserControls.Statcard();
            statCardPending = new PMS_v1.UserControls.Statcard();
            statCardExpired = new PMS_v1.UserControls.Statcard();
            statCardTerminated = new PMS_v1.UserControls.AppearanceIconStatcard();
            pnlCommandActionRow = new Panel();
            txtSearchInput = new Krypton.Toolkit.KryptonTextBox();
            cmbFilterDropdown = new Krypton.Toolkit.KryptonComboBox();
            btnViewLease = new Krypton.Toolkit.KryptonButton();
            btnEditLease = new Krypton.Toolkit.KryptonButton();
            btnNewLease = new Krypton.Toolkit.KryptonButton();
            roundedPanelTable = new RoundedPanel();
            dgvLeases = new DataGridView();
            ctxRow = new ContextMenuStrip(components);
            mnuView = new ToolStripMenuItem();
            mnuEdit = new ToolStripMenuItem();
            tlpMainSkeleton.SuspendLayout();
            pnlHeaderBlock.SuspendLayout();
            tlpMetricsRow.SuspendLayout();
            pnlCommandActionRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbFilterDropdown).BeginInit();
            roundedPanelTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLeases).BeginInit();
            ctxRow.SuspendLayout();
            SuspendLayout();
            // 
            // tlpMainSkeleton
            // 
            tlpMainSkeleton.ColumnCount = 1;
            tlpMainSkeleton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMainSkeleton.Controls.Add(pnlHeaderBlock, 0, 0);
            tlpMainSkeleton.Controls.Add(tlpMetricsRow, 0, 1);
            tlpMainSkeleton.Controls.Add(pnlCommandActionRow, 0, 2);
            tlpMainSkeleton.Controls.Add(roundedPanelTable, 0, 3);
            tlpMainSkeleton.Dock = DockStyle.Fill;
            tlpMainSkeleton.Location = new Point(0, 0);
            tlpMainSkeleton.Name = "tlpMainSkeleton";
            tlpMainSkeleton.RowCount = 4;
            tlpMainSkeleton.RowStyles.Add(new RowStyle());
            tlpMainSkeleton.RowStyles.Add(new RowStyle(SizeType.Absolute, 155F));
            tlpMainSkeleton.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));
            tlpMainSkeleton.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMainSkeleton.Size = new Size(1314, 1251);
            tlpMainSkeleton.TabIndex = 0;
            // 
            // pnlHeaderBlock
            // 
            pnlHeaderBlock.AutoSize = true;
            pnlHeaderBlock.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlHeaderBlock.Controls.Add(lblModuleTitle);
            pnlHeaderBlock.Controls.Add(lblBreadcrumb);
            pnlHeaderBlock.Dock = DockStyle.Fill;
            pnlHeaderBlock.Location = new Point(3, 3);
            pnlHeaderBlock.Name = "pnlHeaderBlock";
            pnlHeaderBlock.Padding = new Padding(15, 0, 0, 0);
            pnlHeaderBlock.Size = new Size(1308, 68);
            pnlHeaderBlock.TabIndex = 0;
            // 
            // lblModuleTitle
            // 
            lblModuleTitle.AutoSize = true;
            lblModuleTitle.Dock = DockStyle.Top;
            lblModuleTitle.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            lblModuleTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblModuleTitle.Location = new Point(15, 31);
            lblModuleTitle.Name = "lblModuleTitle";
            lblModuleTitle.Size = new Size(127, 37);
            lblModuleTitle.TabIndex = 1;
            lblModuleTitle.Text = "Leasing";
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
            lblBreadcrumb.Text = "Home / Leasing";
            // 
            // tlpMetricsRow
            // 
            tlpMetricsRow.ColumnCount = 4;
            tlpMetricsRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetricsRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetricsRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetricsRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetricsRow.Controls.Add(statCardActive, 0, 0);
            tlpMetricsRow.Controls.Add(statCardPending, 1, 0);
            tlpMetricsRow.Controls.Add(statCardExpired, 2, 0);
            tlpMetricsRow.Controls.Add(statCardTerminated, 3, 0);
            tlpMetricsRow.Dock = DockStyle.Fill;
            tlpMetricsRow.Location = new Point(3, 77);
            tlpMetricsRow.Name = "tlpMetricsRow";
            tlpMetricsRow.RowCount = 1;
            tlpMetricsRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMetricsRow.Size = new Size(1308, 149);
            tlpMetricsRow.TabIndex = 1;
            // 
            // statCardActive
            // 
            statCardActive.CardCaption = "Active";
            statCardActive.CardIcon = Resources.Resources.ActiveLease;
            statCardActive.CardNumber = "00";
            statCardActive.Dock = DockStyle.Fill;
            statCardActive.IconSlotPadding = new Padding(6, 16, 6, 16);
            statCardActive.Location = new Point(15, 0);
            statCardActive.Margin = new Padding(15, 0, 7, 0);
            statCardActive.Name = "statCardActive";
            statCardActive.Size = new Size(305, 149);
            statCardActive.TabIndex = 0;
            // 
            // statCardPending
            // 
            statCardPending.CardCaption = "Pending";
            statCardPending.CardIcon = Resources.Resources.PendingLease;
            statCardPending.CardNumber = "00";
            statCardPending.Dock = DockStyle.Fill;
            statCardPending.IconSlotPadding = new Padding(6, 16, 6, 16);
            statCardPending.Location = new Point(334, 0);
            statCardPending.Margin = new Padding(7, 0, 7, 0);
            statCardPending.Name = "statCardPending";
            statCardPending.Size = new Size(313, 149);
            statCardPending.TabIndex = 1;
            // 
            // statCardExpired
            // 
            statCardExpired.CardCaption = "Expired";
            statCardExpired.CardIcon = Resources.Resources.ExpiredLease;
            statCardExpired.CardNumber = "00";
            statCardExpired.Dock = DockStyle.Fill;
            statCardExpired.IconSlotPadding = new Padding(6, 16, 6, 16);
            statCardExpired.Location = new Point(661, 0);
            statCardExpired.Margin = new Padding(7, 0, 7, 0);
            statCardExpired.Name = "statCardExpired";
            statCardExpired.Size = new Size(313, 149);
            statCardExpired.TabIndex = 2;
            // 
            // statCardTerminated
            // 
            statCardTerminated.BackgroundImage = Resources.Resources.TerminatedLease;
            statCardTerminated.CardCaption = "Terminated";
            statCardTerminated.CardIcon = Resources.Resources.TerminatedLease;
            statCardTerminated.CardNumber = "00";
            statCardTerminated.Dock = DockStyle.Fill;
            statCardTerminated.IconSlotPadding = new Padding(6, 16, 6, 16);
            statCardTerminated.Location = new Point(988, 0);
            statCardTerminated.Margin = new Padding(7, 0, 15, 0);
            statCardTerminated.Name = "statCardTerminated";
            statCardTerminated.Size = new Size(305, 149);
            statCardTerminated.TabIndex = 3;
            // 
            // pnlCommandActionRow
            // 
            pnlCommandActionRow.Controls.Add(txtSearchInput);
            pnlCommandActionRow.Controls.Add(cmbFilterDropdown);
            pnlCommandActionRow.Controls.Add(btnViewLease);
            pnlCommandActionRow.Controls.Add(btnEditLease);
            pnlCommandActionRow.Controls.Add(btnNewLease);
            pnlCommandActionRow.Dock = DockStyle.Fill;
            pnlCommandActionRow.Location = new Point(15, 232);
            pnlCommandActionRow.Margin = new Padding(15, 3, 15, 3);
            pnlCommandActionRow.Name = "pnlCommandActionRow";
            pnlCommandActionRow.Size = new Size(1284, 90);
            pnlCommandActionRow.TabIndex = 2;
            // 
            // txtSearchInput
            // 
            txtSearchInput.CueHint.Color1 = Color.FromArgb(125, 130, 134);
            txtSearchInput.CueHint.CueHintText = "⌕  Search tenant, unit or lease...";
            txtSearchInput.CueHint.Font = new Font("Century Gothic", 8.5F);
            txtSearchInput.Location = new Point(0, 19);
            txtSearchInput.Margin = new Padding(3, 4, 3, 4);
            txtSearchInput.Name = "txtSearchInput";
            txtSearchInput.Size = new Size(663, 35);
            txtSearchInput.StateCommon.Back.Color1 = Color.White;
            txtSearchInput.StateCommon.Border.Color1 = Color.FromArgb(222, 226, 230);
            txtSearchInput.StateCommon.Border.Rounding = 12F;
            txtSearchInput.TabIndex = 0;
            // 
            // cmbFilterDropdown
            // 
            cmbFilterDropdown.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbFilterDropdown.Location = new Point(892, 19);
            cmbFilterDropdown.Margin = new Padding(3, 4, 3, 4);
            cmbFilterDropdown.Name = "cmbFilterDropdown";
            cmbFilterDropdown.Size = new Size(171, 34);
            cmbFilterDropdown.StateCommon.ComboBox.Back.Color1 = Color.White;
            cmbFilterDropdown.StateCommon.ComboBox.Border.Color1 = Color.FromArgb(222, 226, 230);
            cmbFilterDropdown.StateCommon.ComboBox.Border.Rounding = 12F;
            cmbFilterDropdown.TabIndex = 1;
            cmbFilterDropdown.Text = "Filter";
            // 
            // btnViewLease
            // 
            btnViewLease.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnViewLease.Location = new Point(940, 16);
            btnViewLease.Margin = new Padding(3, 4, 3, 4);
            btnViewLease.Name = "btnViewLease";
            btnViewLease.Size = new Size(130, 53);
            btnViewLease.StateCommon.Back.Color1 = Color.FromArgb(74, 151, 196);
            btnViewLease.StateCommon.Back.Color2 = Color.FromArgb(52, 120, 165);
            btnViewLease.StateCommon.Back.ColorAngle = 90F;
            btnViewLease.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Linear;
            btnViewLease.StateCommon.Border.Rounding = 12F;
            btnViewLease.StateCommon.Content.ShortText.Color1 = Color.White;
            btnViewLease.StateCommon.Content.ShortText.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            btnViewLease.TabIndex = 3;
            btnViewLease.Values.DropDownArrowColor = Color.Empty;
            btnViewLease.Values.Text = "View Lease";
            btnViewLease.Click += btnViewLease_Click;
            // 
            // btnEditLease
            // 
            btnEditLease.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditLease.Location = new Point(800, 16);
            btnEditLease.Margin = new Padding(3, 4, 3, 4);
            btnEditLease.Name = "btnEditLease";
            btnEditLease.Size = new Size(130, 53);
            btnEditLease.StateCommon.Back.Color1 = Color.FromArgb(74, 151, 196);
            btnEditLease.StateCommon.Back.Color2 = Color.FromArgb(52, 120, 165);
            btnEditLease.StateCommon.Back.ColorAngle = 90F;
            btnEditLease.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Linear;
            btnEditLease.StateCommon.Border.Rounding = 12F;
            btnEditLease.StateCommon.Content.ShortText.Color1 = Color.White;
            btnEditLease.StateCommon.Content.ShortText.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            btnEditLease.TabIndex = 4;
            btnEditLease.Values.DropDownArrowColor = Color.Empty;
            btnEditLease.Values.Text = "Edit Lease";
            btnEditLease.Click += btnEditLease_Click;
            // 
            // btnNewLease
            // 
            btnNewLease.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNewLease.Location = new Point(1086, 16);
            btnNewLease.Margin = new Padding(3, 4, 3, 4);
            btnNewLease.Name = "btnNewLease";
            btnNewLease.Size = new Size(197, 53);
            btnNewLease.StateCommon.Back.Color1 = Color.FromArgb(141, 198, 63);
            btnNewLease.StateCommon.Back.Color2 = Color.FromArgb(91, 154, 42);
            btnNewLease.StateCommon.Back.ColorAngle = 90F;
            btnNewLease.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Linear;
            btnNewLease.StateCommon.Border.Rounding = 12F;
            btnNewLease.StateCommon.Content.ShortText.Color1 = Color.White;
            btnNewLease.StateCommon.Content.ShortText.Font = new Font("Century Gothic", 10.5F, FontStyle.Bold);
            btnNewLease.TabIndex = 2;
            btnNewLease.Values.DropDownArrowColor = Color.Empty;
            btnNewLease.Values.Text = "+   New Lease";
            btnNewLease.Click += btnNewLease_Click_1;
            // 
            // roundedPanelTable
            // 
            roundedPanelTable.BackColor = Color.White;
            roundedPanelTable.BorderColor = Color.Transparent;
            roundedPanelTable.BorderRadius = 10;
            roundedPanelTable.Controls.Add(dgvLeases);
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
            // dgvLeases
            // 
            dgvLeases.BackgroundColor = Color.White;
            dgvLeases.BorderStyle = BorderStyle.None;
            dgvLeases.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLeases.ColumnHeadersHeight = 42;
            dgvLeases.ContextMenuStrip = ctxRow;
            dgvLeases.Dock = DockStyle.Fill;
            dgvLeases.GridColor = Color.FromArgb(233, 236, 239);
            dgvLeases.Location = new Point(10, 13);
            dgvLeases.Margin = new Padding(0);
            dgvLeases.Name = "dgvLeases";
            dgvLeases.RowHeadersVisible = false;
            dgvLeases.RowHeadersWidth = 51;
            dgvLeases.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLeases.Size = new Size(1264, 894);
            dgvLeases.TabIndex = 3;
            // 
            // ctxRow
            // 
            ctxRow.Font = new Font("Century Gothic", 9F);
            ctxRow.ImageScalingSize = new Size(20, 20);
            ctxRow.Items.AddRange(new ToolStripItem[] { mnuView, mnuEdit });
            ctxRow.Name = "ctxRow";
            ctxRow.Size = new Size(164, 52);
            // 
            // mnuView
            // 
            mnuView.Name = "mnuView";
            mnuView.Size = new Size(163, 24);
            mnuView.Text = "View Lease";
            mnuView.Click += mnuView_Click;
            // 
            // mnuEdit
            // 
            mnuEdit.Name = "mnuEdit";
            mnuEdit.Size = new Size(163, 24);
            mnuEdit.Text = "Edit Lease";
            mnuEdit.Click += mnuEdit_Click;
            // 
            // LeasingModule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(237, 240, 241);
            Controls.Add(tlpMainSkeleton);
            Margin = new Padding(3, 4, 3, 4);
            Name = "LeasingModule";
            Size = new Size(1314, 1251);
            tlpMainSkeleton.ResumeLayout(false);
            tlpMainSkeleton.PerformLayout();
            pnlHeaderBlock.ResumeLayout(false);
            pnlHeaderBlock.PerformLayout();
            tlpMetricsRow.ResumeLayout(false);
            pnlCommandActionRow.ResumeLayout(false);
            pnlCommandActionRow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cmbFilterDropdown).EndInit();
            roundedPanelTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLeases).EndInit();
            ctxRow.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpMainSkeleton;
        private System.Windows.Forms.Panel pnlHeaderBlock;
        private System.Windows.Forms.Label lblBreadcrumb;
        private System.Windows.Forms.Label lblModuleTitle;
        private System.Windows.Forms.TableLayoutPanel tlpMetricsRow;
        private PMS_v1.UserControls.Statcard statCardActive;
        private PMS_v1.UserControls.Statcard statCardPending;
        private PMS_v1.UserControls.Statcard statCardExpired;
        private PMS_v1.UserControls.AppearanceIconStatcard statCardTerminated;
        private System.Windows.Forms.Panel pnlCommandActionRow;
        private Krypton.Toolkit.KryptonTextBox txtSearchInput;
        private Krypton.Toolkit.KryptonComboBox cmbFilterDropdown;
        private Krypton.Toolkit.KryptonButton btnNewLease;
        private Krypton.Toolkit.KryptonButton btnViewLease;
        private Krypton.Toolkit.KryptonButton btnEditLease;
        private PMS_v1.RoundedPanel roundedPanelTable;
        private System.Windows.Forms.DataGridView dgvLeases;
        private ContextMenuStrip ctxRow;
        private ToolStripMenuItem mnuView;
        private ToolStripMenuItem mnuEdit;
    }
}