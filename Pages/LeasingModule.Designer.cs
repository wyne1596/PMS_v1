namespace PMS_v1.Pages
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
            btnNewLease = new Krypton.Toolkit.KryptonButton();
            roundedPanelTable = new RoundedPanel();
            dgvLeases = new DataGridView();
            tlpMainSkeleton.SuspendLayout();
            pnlHeaderBlock.SuspendLayout();
            tlpMetricsRow.SuspendLayout();
            pnlCommandActionRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbFilterDropdown).BeginInit();
            roundedPanelTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLeases).BeginInit();
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
            tlpMainSkeleton.Margin = new Padding(3, 2, 3, 2);
            tlpMainSkeleton.Name = "tlpMainSkeleton";
            tlpMainSkeleton.RowCount = 4;
            tlpMainSkeleton.RowStyles.Add(new RowStyle());
            tlpMainSkeleton.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tlpMainSkeleton.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            tlpMainSkeleton.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMainSkeleton.Size = new Size(1150, 938);
            tlpMainSkeleton.TabIndex = 0;
            // 
            // pnlHeaderBlock
            // 
            pnlHeaderBlock.AutoSize = true;
            pnlHeaderBlock.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlHeaderBlock.Controls.Add(lblModuleTitle);
            pnlHeaderBlock.Controls.Add(lblBreadcrumb);
            pnlHeaderBlock.Dock = DockStyle.Fill;
            pnlHeaderBlock.Location = new Point(3, 2);
            pnlHeaderBlock.Margin = new Padding(3, 2, 3, 2);
            pnlHeaderBlock.Name = "pnlHeaderBlock";
            pnlHeaderBlock.Padding = new Padding(13, 0, 0, 0);
            pnlHeaderBlock.Size = new Size(1144, 53);
            pnlHeaderBlock.TabIndex = 0;
            // 
            // lblModuleTitle
            // 
            lblModuleTitle.AutoSize = true;
            lblModuleTitle.Dock = DockStyle.Top;
            lblModuleTitle.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            lblModuleTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblModuleTitle.Location = new Point(13, 25);
            lblModuleTitle.Name = "lblModuleTitle";
            lblModuleTitle.Size = new Size(101, 28);
            lblModuleTitle.TabIndex = 1;
            lblModuleTitle.Text = "Leasing";
            // 
            // lblBreadcrumb
            // 
            lblBreadcrumb.AutoSize = true;
            lblBreadcrumb.Dock = DockStyle.Top;
            lblBreadcrumb.Font = new Font("Century Gothic", 8.5F);
            lblBreadcrumb.ForeColor = Color.FromArgb(108, 117, 125);
            lblBreadcrumb.Location = new Point(13, 0);
            lblBreadcrumb.Name = "lblBreadcrumb";
            lblBreadcrumb.Padding = new Padding(3, 0, 0, 8);
            lblBreadcrumb.Size = new Size(102, 25);
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
            tlpMetricsRow.Location = new Point(3, 59);
            tlpMetricsRow.Margin = new Padding(3, 2, 3, 2);
            tlpMetricsRow.Name = "tlpMetricsRow";
            tlpMetricsRow.RowCount = 1;
            tlpMetricsRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMetricsRow.Size = new Size(1144, 116);
            tlpMetricsRow.TabIndex = 1;
            // 
            // statCardActive
            // 
            statCardActive.CardCaption = "Active";
            statCardActive.CardIcon = Resources.Resources.Icon__8_;
            statCardActive.IconSlotPadding = new Padding(10, 20, 10, 20);
            statCardActive.CardNumber = "00";
            statCardActive.Dock = DockStyle.Fill;
            statCardActive.Location = new Point(13, 0);
            statCardActive.Margin = new Padding(13, 0, 6, 0);
            statCardActive.Name = "statCardActive";
            statCardActive.Size = new Size(267, 116);
            statCardActive.TabIndex = 0;
            statCardActive.Load += statCardActive_Load;
            // 
            // statCardPending
            // 
            statCardPending.CardCaption = "Pending";
            statCardPending.CardIcon = Resources.Resources.Icon__9_;
            statCardPending.IconSlotPadding = new Padding(10, 20, 10, 20);
            statCardPending.CardNumber = "00";
            statCardPending.Dock = DockStyle.Fill;
            statCardPending.Location = new Point(292, 0);
            statCardPending.Margin = new Padding(6, 0, 6, 0);
            statCardPending.Name = "statCardPending";
            statCardPending.Size = new Size(274, 116);
            statCardPending.TabIndex = 1;
            // 
            // statCardExpired
            // 
            statCardExpired.CardCaption = "Expired";
            statCardExpired.CardIcon = Resources.Resources.Icon__10_;
            statCardExpired.IconSlotPadding = new Padding(10, 20, 10, 20);
            statCardExpired.CardNumber = "00";
            statCardExpired.Dock = DockStyle.Fill;
            statCardExpired.Location = new Point(578, 0);
            statCardExpired.Margin = new Padding(6, 0, 6, 0);
            statCardExpired.Name = "statCardExpired";
            statCardExpired.Size = new Size(274, 116);
            statCardExpired.TabIndex = 2;
            // 
            // statCardTerminated
            // 
            statCardTerminated.BackgroundImage = Resources.Resources.Icon__11_;
            statCardTerminated.CardCaption = "Terminated";
            statCardTerminated.CardIcon = Resources.Resources.Icon__11_;
            statCardTerminated.IconSlotPadding = new Padding(10, 20, 10, 20);
            statCardTerminated.CardNumber = "00";
            statCardTerminated.Dock = DockStyle.Fill;
            statCardTerminated.Location = new Point(864, 0);
            statCardTerminated.Margin = new Padding(6, 0, 13, 0);
            statCardTerminated.Name = "statCardTerminated";
            statCardTerminated.Size = new Size(267, 116);
            statCardTerminated.TabIndex = 3;
            // 
            // pnlCommandActionRow
            // 
            pnlCommandActionRow.Controls.Add(txtSearchInput);
            pnlCommandActionRow.Controls.Add(cmbFilterDropdown);
            pnlCommandActionRow.Controls.Add(btnNewLease);
            pnlCommandActionRow.Dock = DockStyle.Fill;
            pnlCommandActionRow.Location = new Point(13, 179);
            pnlCommandActionRow.Margin = new Padding(13, 2, 13, 2);
            pnlCommandActionRow.Name = "pnlCommandActionRow";
            pnlCommandActionRow.Size = new Size(1124, 68);
            pnlCommandActionRow.TabIndex = 2;
            // 
            // txtSearchInput
            // 
            txtSearchInput.CueHint.Color1 = Color.FromArgb(125, 130, 134);
            txtSearchInput.CueHint.CueHintText = "⌕  Search tenant, unit or lease...";
            txtSearchInput.CueHint.Font = new Font("Century Gothic", 8.5F);
            txtSearchInput.Location = new Point(0, 14);
            txtSearchInput.Name = "txtSearchInput";
            txtSearchInput.Size = new Size(580, 31);
            txtSearchInput.StateCommon.Back.Color1 = Color.White;
            txtSearchInput.StateCommon.Border.Color1 = Color.FromArgb(222, 226, 230);
            txtSearchInput.StateCommon.Border.Rounding = 12F;
            txtSearchInput.TabIndex = 0;
            // 
            // cmbFilterDropdown
            // 
            cmbFilterDropdown.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbFilterDropdown.Location = new Point(781, 14);
            cmbFilterDropdown.Name = "cmbFilterDropdown";
            cmbFilterDropdown.Size = new Size(150, 30);
            cmbFilterDropdown.StateCommon.ComboBox.Back.Color1 = Color.White;
            cmbFilterDropdown.StateCommon.ComboBox.Border.Color1 = Color.FromArgb(222, 226, 230);
            cmbFilterDropdown.StateCommon.ComboBox.Border.Rounding = 12F;
            cmbFilterDropdown.TabIndex = 1;
            cmbFilterDropdown.Text = "Filter";
            // 
            // btnNewLease
            // 
            btnNewLease.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNewLease.Location = new Point(951, 12);
            btnNewLease.Name = "btnNewLease";
            btnNewLease.Size = new Size(172, 40);
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
            // 
            // roundedPanelTable
            // 
            roundedPanelTable.BackColor = Color.White;
            roundedPanelTable.BorderColor = Color.Transparent;
            roundedPanelTable.BorderRadius = 8;
            roundedPanelTable.Controls.Add(dgvLeases);
            roundedPanelTable.Dock = DockStyle.Fill;
            roundedPanelTable.Location = new Point(13, 251);
            roundedPanelTable.Margin = new Padding(13, 2, 13, 2);
            roundedPanelTable.Name = "roundedPanelTable";
            roundedPanelTable.Padding = new Padding(5);
            roundedPanelTable.ShadowColor = Color.Black;
            roundedPanelTable.ShadowOpacity = 28;
            roundedPanelTable.ShadowSize = 4;
            roundedPanelTable.Size = new Size(1124, 685);
            roundedPanelTable.TabIndex = 3;
            // 
            // dgvLeases
            // 
            dgvLeases.BackgroundColor = Color.White;
            dgvLeases.BorderStyle = BorderStyle.None;
            dgvLeases.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLeases.ColumnHeadersHeight = 42;
            dgvLeases.Dock = DockStyle.Fill;
            dgvLeases.GridColor = Color.FromArgb(233, 236, 239);
            dgvLeases.Location = new Point(9, 11);
            dgvLeases.Margin = new Padding(0);
            dgvLeases.Name = "dgvLeases";
            dgvLeases.RowHeadersVisible = false;
            dgvLeases.RowHeadersWidth = 51;
            dgvLeases.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLeases.Size = new Size(1106, 663);
            dgvLeases.TabIndex = 3;
            // 
            // LeasingModule
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(237, 240, 241);
            Controls.Add(tlpMainSkeleton);
            Name = "LeasingModule";
            Size = new Size(1150, 938);
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
            ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpMainSkeleton;
        private System.Windows.Forms.Panel pnlHeaderBlock;
        private System.Windows.Forms.Label lblBreadcrumb;
        private System.Windows.Forms.Label lblModuleTitle;
        private System.Windows.Forms.TableLayoutPanel tlpMetricsRow;
        // 🚀 Cleaned-up 4 Statcard Fields
        private PMS_v1.UserControls.Statcard statCardActive;
        private PMS_v1.UserControls.Statcard statCardPending;
        private PMS_v1.UserControls.Statcard statCardExpired;
        private PMS_v1.UserControls.AppearanceIconStatcard statCardTerminated;
        private System.Windows.Forms.Panel pnlCommandActionRow;
        private Krypton.Toolkit.KryptonTextBox txtSearchInput;
        private Krypton.Toolkit.KryptonComboBox cmbFilterDropdown;
        private Krypton.Toolkit.KryptonButton btnNewLease;
        private PMS_v1.RoundedPanel roundedPanelTable;
        private System.Windows.Forms.DataGridView dgvLeases;
    }
}
