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
            tlpMainSkeleton.Name = "tlpMainSkeleton";
            tlpMainSkeleton.RowCount = 4;
            tlpMainSkeleton.RowStyles.Add(new RowStyle(SizeType.Absolute, 75F));
            tlpMainSkeleton.RowStyles.Add(new RowStyle(SizeType.Percent, 18.5542164F));
            tlpMainSkeleton.RowStyles.Add(new RowStyle(SizeType.Percent, 13.6144581F));
            tlpMainSkeleton.RowStyles.Add(new RowStyle(SizeType.Percent, 67.83132F));
            tlpMainSkeleton.Size = new Size(1194, 1207);
            tlpMainSkeleton.TabIndex = 0;
            // 
            // pnlHeaderBlock
            // 
            pnlHeaderBlock.Controls.Add(lblModuleTitle);
            pnlHeaderBlock.Controls.Add(lblBreadcrumb);
            pnlHeaderBlock.Dock = DockStyle.Fill;
            pnlHeaderBlock.Location = new Point(3, 3);
            pnlHeaderBlock.Name = "pnlHeaderBlock";
            pnlHeaderBlock.Padding = new Padding(15, 0, 0, 0);
            pnlHeaderBlock.Size = new Size(1188, 69);
            pnlHeaderBlock.TabIndex = 0;
            // 
            // lblModuleTitle
            // 
            lblModuleTitle.AutoSize = true;
            lblModuleTitle.Dock = DockStyle.Top;
            lblModuleTitle.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblModuleTitle.ForeColor = Color.FromArgb(51, 51, 51);
            lblModuleTitle.Location = new Point(15, 31);
            lblModuleTitle.Name = "lblModuleTitle";
            lblModuleTitle.Size = new Size(117, 34);
            lblModuleTitle.TabIndex = 1;
            lblModuleTitle.Text = "Leasing";
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
            tlpMetricsRow.Location = new Point(3, 78);
            tlpMetricsRow.Name = "tlpMetricsRow";
            tlpMetricsRow.RowCount = 1;
            tlpMetricsRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMetricsRow.Size = new Size(1188, 204);
            tlpMetricsRow.TabIndex = 1;
            // 
            // statCardActive
            // 
            statCardActive.CardCaption = "Active";
            statCardActive.CardIcon = Resources.Resources.check;
            statCardActive.CardNumber = "00";
            statCardActive.Dock = DockStyle.Fill;
            statCardActive.Location = new Point(15, 0);
            statCardActive.Margin = new Padding(15, 0, 7, 0);
            statCardActive.Name = "statCardActive";
            statCardActive.Size = new Size(275, 204);
            statCardActive.TabIndex = 0;
            // 
            // statCardPending
            // 
            statCardPending.CardCaption = "Pending";
            statCardPending.CardIcon = Resources.Resources.clock;
            statCardPending.CardNumber = "00";
            statCardPending.Dock = DockStyle.Fill;
            statCardPending.Location = new Point(304, 0);
            statCardPending.Margin = new Padding(7, 0, 7, 0);
            statCardPending.Name = "statCardPending";
            statCardPending.Size = new Size(283, 204);
            statCardPending.TabIndex = 1;
            // 
            // statCardExpired
            // 
            statCardExpired.CardCaption = "Expired";
            statCardExpired.CardIcon = Resources.Resources.exclamation;
            statCardExpired.CardNumber = "00";
            statCardExpired.Dock = DockStyle.Fill;
            statCardExpired.Location = new Point(601, 0);
            statCardExpired.Margin = new Padding(7, 0, 7, 0);
            statCardExpired.Name = "statCardExpired";
            statCardExpired.Size = new Size(283, 204);
            statCardExpired.TabIndex = 2;
            // 
            // statCardTerminated
            // 
            statCardTerminated.BackgroundImage = Resources.Resources.remove;
            statCardTerminated.CardCaption = "Terminated";
            statCardTerminated.CardIcon = Resources.Resources.remove;
            statCardTerminated.CardNumber = "00";
            statCardTerminated.Dock = DockStyle.Fill;
            statCardTerminated.Location = new Point(898, 0);
            statCardTerminated.Margin = new Padding(7, 0, 15, 0);
            statCardTerminated.Name = "statCardTerminated";
            statCardTerminated.Size = new Size(275, 204);
            statCardTerminated.TabIndex = 3;
            // 
            // pnlCommandActionRow
            // 
            pnlCommandActionRow.Controls.Add(txtSearchInput);
            pnlCommandActionRow.Controls.Add(cmbFilterDropdown);
            pnlCommandActionRow.Controls.Add(btnNewLease);
            pnlCommandActionRow.Dock = DockStyle.Fill;
            pnlCommandActionRow.Location = new Point(15, 288);
            pnlCommandActionRow.Margin = new Padding(15, 3, 15, 3);
            pnlCommandActionRow.Name = "pnlCommandActionRow";
            pnlCommandActionRow.Size = new Size(1164, 148);
            pnlCommandActionRow.TabIndex = 2;
            // 
            // txtSearchInput
            // 
            txtSearchInput.Location = new Point(0, 19);
            txtSearchInput.Margin = new Padding(3, 4, 3, 4);
            txtSearchInput.Name = "txtSearchInput";
            txtSearchInput.Size = new Size(663, 34);
            txtSearchInput.StateActive.Border.Color1 = Color.FromArgb(74, 151, 196);
            txtSearchInput.StateActive.Border.Color2 = Color.FromArgb(74, 151, 196);
            txtSearchInput.StateCommon.Back.Color1 = Color.White;
            txtSearchInput.StateCommon.Border.Color1 = Color.FromArgb(222, 226, 230);
            txtSearchInput.StateCommon.Border.Color2 = Color.FromArgb(222, 226, 230);
            txtSearchInput.StateCommon.Border.Rounding = 8F;
            txtSearchInput.StateCommon.Content.Color1 = Color.FromArgb(51, 51, 51);
            txtSearchInput.StateCommon.Content.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearchInput.TabIndex = 0;
            txtSearchInput.Text = "Search tenant, unit or lease...";
            // 
            // cmbFilterDropdown
            // 
            cmbFilterDropdown.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbFilterDropdown.Location = new Point(773, 19);
            cmbFilterDropdown.Margin = new Padding(3, 4, 3, 4);
            cmbFilterDropdown.Name = "cmbFilterDropdown";
            cmbFilterDropdown.Size = new Size(171, 32);
            cmbFilterDropdown.StateActive.ComboBox.Border.Color1 = Color.FromArgb(74, 151, 196);
            cmbFilterDropdown.StateActive.ComboBox.Border.Color2 = Color.FromArgb(74, 151, 196);
            cmbFilterDropdown.StateCommon.ComboBox.Back.Color1 = Color.White;
            cmbFilterDropdown.StateCommon.ComboBox.Border.Color1 = Color.FromArgb(222, 226, 230);
            cmbFilterDropdown.StateCommon.ComboBox.Border.Color2 = Color.FromArgb(222, 226, 230);
            cmbFilterDropdown.StateCommon.ComboBox.Border.Rounding = 8F;
            cmbFilterDropdown.StateCommon.ComboBox.Content.Color1 = Color.FromArgb(51, 51, 51);
            cmbFilterDropdown.StateCommon.ComboBox.Content.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbFilterDropdown.TabIndex = 1;
            cmbFilterDropdown.Text = "Filter";
            // 
            // btnNewLease
            // 
            btnNewLease.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNewLease.Location = new Point(967, 16);
            btnNewLease.Margin = new Padding(3, 4, 3, 4);
            btnNewLease.Name = "btnNewLease";
            btnNewLease.Size = new Size(197, 53);
            btnNewLease.StateCommon.Back.Color1 = Color.FromArgb(141, 198, 63);
            btnNewLease.StateCommon.Back.Color2 = Color.FromArgb(91, 154, 42);
            btnNewLease.StateCommon.Back.ColorAngle = 90F;
            btnNewLease.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Linear;
            btnNewLease.StateCommon.Border.Color1 = Color.FromArgb(91, 154, 42);
            btnNewLease.StateCommon.Border.Color2 = Color.FromArgb(91, 154, 42);
            btnNewLease.StateCommon.Border.Rounding = 8F;
            btnNewLease.StateCommon.Content.ShortText.Color1 = Color.White;
            btnNewLease.StateCommon.Content.ShortText.Font = new Font("Century Gothic", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewLease.StatePressed.Back.Color1 = Color.FromArgb(104, 168, 48);
            btnNewLease.StatePressed.Back.Color2 = Color.FromArgb(74, 130, 34);
            btnNewLease.StateTracking.Back.Color1 = Color.FromArgb(160, 212, 82);
            btnNewLease.StateTracking.Back.Color2 = Color.FromArgb(106, 170, 52);
            btnNewLease.TabIndex = 2;
            btnNewLease.Values.DropDownArrowColor = Color.Empty;
            btnNewLease.Values.Text = "+   New Lease";
            // 
            // roundedPanelTable
            // 
            roundedPanelTable.BackColor = Color.White;
            roundedPanelTable.BorderColor = Color.Transparent;
            roundedPanelTable.BorderRadius = 10;
            roundedPanelTable.Controls.Add(dgvLeases);
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
            // dgvLeases
            // 
            dgvLeases.BackgroundColor = Color.White;
            dgvLeases.BorderStyle = BorderStyle.None;
            dgvLeases.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLeases.ColumnHeadersHeight = 42;
            dgvLeases.Dock = DockStyle.Fill;
            dgvLeases.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvLeases.GridColor = Color.FromArgb(233, 236, 239);
            dgvLeases.Location = new Point(4, 6);
            dgvLeases.Margin = new Padding(0);
            dgvLeases.Name = "dgvLeases";
            dgvLeases.RowHeadersVisible = false;
            dgvLeases.RowHeadersWidth = 51;
            dgvLeases.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLeases.Size = new Size(1156, 750);
            dgvLeases.TabIndex = 3;
            // 
            // LeasingModule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            Controls.Add(tlpMainSkeleton);
            DoubleBuffered = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "LeasingModule";
            Size = new Size(1194, 1207);
            tlpMainSkeleton.ResumeLayout(false);
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
