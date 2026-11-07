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
            lblBreadcrumb = new Label();
            lblModuleTitle = new Label();
            tlpMetricsRow = new TableLayoutPanel();
            rgbActiveCard = new Krypton.Toolkit.KryptonGroupBox();
            rgbPendingCard = new Krypton.Toolkit.KryptonGroupBox();
            rgbExpiredCard = new Krypton.Toolkit.KryptonGroupBox();
            rgbTerminatedCard = new Krypton.Toolkit.KryptonGroupBox();
            pnlCommandActionRow = new Panel();
            txtSearchInput = new Krypton.Toolkit.KryptonTextBox();
            cmbFilterDropdown = new Krypton.Toolkit.KryptonComboBox();
            btnNewLease = new Krypton.Toolkit.KryptonButton();
            dgvLeases = new DataGridView();
            tlpMainSkeleton.SuspendLayout();
            pnlHeaderBlock.SuspendLayout();
            tlpMetricsRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)rgbActiveCard).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rgbActiveCard.Panel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rgbPendingCard).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rgbPendingCard.Panel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rgbExpiredCard).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rgbExpiredCard.Panel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rgbTerminatedCard).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rgbTerminatedCard.Panel).BeginInit();
            pnlCommandActionRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbFilterDropdown).BeginInit();
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
            tlpMainSkeleton.Controls.Add(dgvLeases, 0, 3);
            tlpMainSkeleton.Dock = DockStyle.Fill;
            tlpMainSkeleton.Location = new Point(0, 0);
            tlpMainSkeleton.Margin = new Padding(3, 4, 3, 4);
            tlpMainSkeleton.Name = "tlpMainSkeleton";
            tlpMainSkeleton.RowCount = 4;
            tlpMainSkeleton.RowStyles.Add(new RowStyle(SizeType.Absolute, 105F));
            tlpMainSkeleton.RowStyles.Add(new RowStyle(SizeType.Absolute, 160F));
            tlpMainSkeleton.RowStyles.Add(new RowStyle(SizeType.Absolute, 87F));
            tlpMainSkeleton.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMainSkeleton.Size = new Size(1314, 1251);
            tlpMainSkeleton.TabIndex = 0;
            // 
            // pnlHeaderBlock
            // 
            pnlHeaderBlock.Controls.Add(lblBreadcrumb);
            pnlHeaderBlock.Controls.Add(lblModuleTitle);
            pnlHeaderBlock.Dock = DockStyle.Fill;
            pnlHeaderBlock.Location = new Point(3, 4);
            pnlHeaderBlock.Margin = new Padding(3, 4, 3, 4);
            pnlHeaderBlock.Name = "pnlHeaderBlock";
            pnlHeaderBlock.Size = new Size(1308, 97);
            pnlHeaderBlock.TabIndex = 0;
            // 
            // lblBreadcrumb
            // 
            lblBreadcrumb.AutoSize = true;
            lblBreadcrumb.Font = new Font("Segoe UI", 8.5F);
            lblBreadcrumb.ForeColor = Color.FromArgb(108, 117, 125);
            lblBreadcrumb.Location = new Point(37, 16);
            lblBreadcrumb.Name = "lblBreadcrumb";
            lblBreadcrumb.Size = new Size(114, 20);
            lblBreadcrumb.TabIndex = 0;
            lblBreadcrumb.Text = "Home / Leasing";
            // 
            // lblModuleTitle
            // 
            lblModuleTitle.AutoSize = true;
            lblModuleTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblModuleTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblModuleTitle.Location = new Point(37, 40);
            lblModuleTitle.Name = "lblModuleTitle";
            lblModuleTitle.Size = new Size(153, 50);
            lblModuleTitle.TabIndex = 1;
            lblModuleTitle.Text = "Leasing";
            // 
            // tlpMetricsRow
            // 
            tlpMetricsRow.ColumnCount = 4;
            tlpMetricsRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetricsRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetricsRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetricsRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetricsRow.Controls.Add(rgbActiveCard, 0, 0);
            tlpMetricsRow.Controls.Add(rgbPendingCard, 1, 0);
            tlpMetricsRow.Controls.Add(rgbExpiredCard, 2, 0);
            tlpMetricsRow.Controls.Add(rgbTerminatedCard, 3, 0);
            tlpMetricsRow.Dock = DockStyle.Fill;
            tlpMetricsRow.Location = new Point(23, 105);
            tlpMetricsRow.Margin = new Padding(23, 0, 23, 0);
            tlpMetricsRow.Name = "tlpMetricsRow";
            tlpMetricsRow.RowCount = 1;
            tlpMetricsRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMetricsRow.Size = new Size(1268, 160);
            tlpMetricsRow.TabIndex = 1;
            // 
            // rgbActiveCard
            // 
            rgbActiveCard.CaptionVisible = false;
            rgbActiveCard.Dock = DockStyle.Fill;
            rgbActiveCard.Location = new Point(14, 13);
            rgbActiveCard.Margin = new Padding(14, 13, 14, 13);
            rgbActiveCard.Size = new Size(289, 134);
            rgbActiveCard.StateCommon.Back.Color1 = Color.White;
            rgbActiveCard.StateCommon.Border.Color1 = Color.FromArgb(222, 226, 230);
            rgbActiveCard.StateCommon.Border.Rounding = 16F;
            rgbActiveCard.TabIndex = 0;
            // 
            // rgbPendingCard
            // 
            rgbPendingCard.CaptionVisible = false;
            rgbPendingCard.Dock = DockStyle.Fill;
            rgbPendingCard.Location = new Point(331, 13);
            rgbPendingCard.Margin = new Padding(14, 13, 14, 13);
            rgbPendingCard.Size = new Size(289, 134);
            rgbPendingCard.StateCommon.Back.Color1 = Color.White;
            rgbPendingCard.StateCommon.Border.Color1 = Color.FromArgb(222, 226, 230);
            rgbPendingCard.StateCommon.Border.Rounding = 16F;
            rgbPendingCard.TabIndex = 1;
            // 
            // rgbExpiredCard
            // 
            rgbExpiredCard.CaptionVisible = false;
            rgbExpiredCard.Dock = DockStyle.Fill;
            rgbExpiredCard.Location = new Point(648, 13);
            rgbExpiredCard.Margin = new Padding(14, 13, 14, 13);
            rgbExpiredCard.Size = new Size(289, 134);
            rgbExpiredCard.StateCommon.Back.Color1 = Color.White;
            rgbExpiredCard.StateCommon.Border.Color1 = Color.FromArgb(222, 226, 230);
            rgbExpiredCard.StateCommon.Border.Rounding = 16F;
            rgbExpiredCard.TabIndex = 2;
            // 
            // rgbTerminatedCard
            // 
            rgbTerminatedCard.CaptionVisible = false;
            rgbTerminatedCard.Dock = DockStyle.Fill;
            rgbTerminatedCard.Location = new Point(965, 13);
            rgbTerminatedCard.Margin = new Padding(14, 13, 14, 13);
            rgbTerminatedCard.Size = new Size(289, 134);
            rgbTerminatedCard.StateCommon.Back.Color1 = Color.White;
            rgbTerminatedCard.StateCommon.Border.Color1 = Color.FromArgb(222, 226, 230);
            rgbTerminatedCard.StateCommon.Border.Rounding = 16F;
            rgbTerminatedCard.TabIndex = 3;
            // 
            // pnlCommandActionRow
            // 
            pnlCommandActionRow.Controls.Add(txtSearchInput);
            pnlCommandActionRow.Controls.Add(cmbFilterDropdown);
            pnlCommandActionRow.Controls.Add(btnNewLease);
            pnlCommandActionRow.Dock = DockStyle.Fill;
            pnlCommandActionRow.Location = new Point(3, 269);
            pnlCommandActionRow.Margin = new Padding(3, 4, 3, 4);
            pnlCommandActionRow.Name = "pnlCommandActionRow";
            pnlCommandActionRow.Size = new Size(1308, 79);
            pnlCommandActionRow.TabIndex = 2;
            // 
            // txtSearchInput
            // 
            txtSearchInput.Location = new Point(37, 16);
            txtSearchInput.Margin = new Padding(3, 4, 3, 4);
            txtSearchInput.Name = "txtSearchInput";
            txtSearchInput.Size = new Size(663, 38);
            txtSearchInput.StateCommon.Back.Color1 = Color.White;
            txtSearchInput.StateCommon.Border.Color1 = Color.FromArgb(222, 226, 230);
            txtSearchInput.StateCommon.Border.Rounding = 12F;
            txtSearchInput.StateCommon.Content.Color1 = Color.FromArgb(33, 37, 41);
            txtSearchInput.StateCommon.Content.Font = new Font("Segoe UI", 10F);
            txtSearchInput.TabIndex = 0;
            txtSearchInput.Text = "Search tenant, unit or lease...";
            // 
            // cmbFilterDropdown
            // 
            cmbFilterDropdown.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbFilterDropdown.DropDownWidth = 140;
            cmbFilterDropdown.Location = new Point(840, 16);
            cmbFilterDropdown.Margin = new Padding(3, 4, 3, 4);
            cmbFilterDropdown.Name = "cmbFilterDropdown";
            cmbFilterDropdown.Size = new Size(171, 37);
            cmbFilterDropdown.StateCommon.ComboBox.Back.Color1 = Color.White;
            cmbFilterDropdown.StateCommon.ComboBox.Border.Color1 = Color.FromArgb(222, 226, 230);
            cmbFilterDropdown.StateCommon.ComboBox.Border.Rounding = 12F;
            cmbFilterDropdown.StateCommon.ComboBox.Content.Font = new Font("Segoe UI", 10F);
            cmbFilterDropdown.TabIndex = 1;
            cmbFilterDropdown.Text = "Filter";
            // 
            // btnNewLease
            // 
            btnNewLease.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNewLease.Location = new Point(1043, 16);
            btnNewLease.Margin = new Padding(3, 4, 3, 4);
            btnNewLease.Name = "btnNewLease";
            btnNewLease.Size = new Size(229, 51);
            btnNewLease.StateCommon.Back.Color1 = Color.FromArgb(141, 198, 63);
            btnNewLease.StateCommon.Back.Color2 = Color.FromArgb(91, 154, 42);
            btnNewLease.StateCommon.Back.ColorAngle = 90F;
            btnNewLease.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Linear;
            btnNewLease.StateCommon.Border.Rounding = 12F;
            btnNewLease.StateCommon.Content.ShortText.Color1 = Color.White;
            btnNewLease.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnNewLease.TabIndex = 2;
            btnNewLease.Values.DropDownArrowColor = Color.Empty;
            btnNewLease.Values.Text = "+   New Lease";
            // 
            // dgvLeases
            // 
            dgvLeases.BackgroundColor = Color.White;
            dgvLeases.BorderStyle = BorderStyle.None;
            dgvLeases.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLeases.ColumnHeadersHeight = 40;
            dgvLeases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvLeases.Dock = DockStyle.Fill;
            dgvLeases.EnableHeadersVisualStyles = false;
            dgvLeases.GridColor = Color.FromArgb(233, 236, 239);
            dgvLeases.Location = new Point(37, 365);
            dgvLeases.Margin = new Padding(37, 13, 37, 43);
            dgvLeases.Name = "dgvLeases";
            dgvLeases.RowHeadersVisible = false;
            dgvLeases.RowHeadersWidth = 51;
            dgvLeases.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLeases.Size = new Size(1240, 843);
            dgvLeases.TabIndex = 3;
            // 
            // LeasingModule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 245, 247);
            Controls.Add(tlpMainSkeleton);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1314, 1251);
            Name = "LeasingModule";
            Size = new Size(1314, 1251);
            tlpMainSkeleton.ResumeLayout(false);
            pnlHeaderBlock.ResumeLayout(false);
            pnlHeaderBlock.PerformLayout();
            tlpMetricsRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)rgbActiveCard.Panel).EndInit();
            ((System.ComponentModel.ISupportInitialize)rgbActiveCard).EndInit();
            ((System.ComponentModel.ISupportInitialize)rgbPendingCard.Panel).EndInit();
            ((System.ComponentModel.ISupportInitialize)rgbPendingCard).EndInit();
            ((System.ComponentModel.ISupportInitialize)rgbExpiredCard.Panel).EndInit();
            ((System.ComponentModel.ISupportInitialize)rgbExpiredCard).EndInit();
            ((System.ComponentModel.ISupportInitialize)rgbTerminatedCard.Panel).EndInit();
            ((System.ComponentModel.ISupportInitialize)rgbTerminatedCard).EndInit();
            pnlCommandActionRow.ResumeLayout(false);
            pnlCommandActionRow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cmbFilterDropdown).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLeases).EndInit();
            ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpMainSkeleton;
        private System.Windows.Forms.Panel pnlHeaderBlock;
        private System.Windows.Forms.Label lblBreadcrumb;
        private System.Windows.Forms.Label lblModuleTitle;
        private System.Windows.Forms.TableLayoutPanel tlpMetricsRow;
        private Krypton.Toolkit.KryptonGroupBox rgbActiveCard;
        private Krypton.Toolkit.KryptonGroupBox rgbPendingCard;
        private Krypton.Toolkit.KryptonGroupBox rgbExpiredCard;
        private Krypton.Toolkit.KryptonGroupBox rgbTerminatedCard;
        // Form Fields
        private System.Windows.Forms.Panel pnlCommandActionRow;
        private Krypton.Toolkit.KryptonTextBox txtSearchInput;
        private Krypton.Toolkit.KryptonComboBox cmbFilterDropdown;
        private Krypton.Toolkit.KryptonButton btnNewLease;
        private System.Windows.Forms.DataGridView dgvLeases;
    }
}