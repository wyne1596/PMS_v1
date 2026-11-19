using System.Drawing;
using System.Windows.Forms;

namespace PMS_v1.Pages
{
    partial class PropertiesModule
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
            lblBreadcrumb = new Label();
            lblTitle = new Label();
            tlpMetrics = new TableLayoutPanel();
            statCardTotalProperties = new PMS_v1.UserControls.AppearanceIconStatcard();
            statCardTotalUnits = new PMS_v1.UserControls.AppearanceIconStatcard();
            statCardUnitsOccupied = new PMS_v1.UserControls.AppearanceIconStatcard();
            statCardTotalTenants = new PMS_v1.UserControls.AppearanceIconStatcard();
            pnlActions = new Panel();
            txtSearch = new Krypton.Toolkit.KryptonTextBox();
            cmbFilter = new Krypton.Toolkit.KryptonComboBox();
            btnNewProperty = new Krypton.Toolkit.KryptonButton();
            roundedPanelTable = new PMS_v1.RoundedPanel();
            dgvProperties = new DataGridView();
            tlpMain.SuspendLayout();
            pnlHeader.SuspendLayout();
            tlpMetrics.SuspendLayout();
            pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbFilter).BeginInit();
            roundedPanelTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProperties).BeginInit();
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
            tlpMain.Margin = new Padding(3, 2, 3, 2);
            tlpMain.Name = "tlpMain";
            tlpMain.Padding = new Padding(37, 14, 37, 9);
            tlpMain.RowCount = 4;
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.Size = new Size(1150, 938);
            tlpMain.TabIndex = 0;
            // 
            // pnlHeader
            // 
            pnlHeader.AutoSize = true;
            pnlHeader.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlHeader.Controls.Add(lblBreadcrumb);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Fill;
            pnlHeader.Location = new Point(40, 16);
            pnlHeader.Margin = new Padding(3, 2, 3, 2);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(15, 0, 0, 0);
            pnlHeader.Size = new Size(1070, 57);
            pnlHeader.TabIndex = 0;
            // 
            // lblBreadcrumb
            // 
            lblBreadcrumb.AutoSize = true;
            lblBreadcrumb.Dock = DockStyle.Top;
            lblBreadcrumb.Font = new Font("Century Gothic", 8.5F);
            lblBreadcrumb.ForeColor = Color.FromArgb(108, 117, 125);
            lblBreadcrumb.Location = new Point(15, 32);
            lblBreadcrumb.Name = "lblBreadcrumb";
            lblBreadcrumb.Padding = new Padding(0, 0, 0, 8);
            lblBreadcrumb.Size = new Size(114, 25);
            lblBreadcrumb.TabIndex = 0;
            lblBreadcrumb.Text = "Home / Properties";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Location = new Point(15, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(133, 32);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Properties";
            // 
            // tlpMetrics
            // 
            tlpMetrics.ColumnCount = 4;
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetrics.Controls.Add(statCardTotalProperties, 0, 0);
            tlpMetrics.Controls.Add(statCardTotalUnits, 1, 0);
            tlpMetrics.Controls.Add(statCardUnitsOccupied, 2, 0);
            tlpMetrics.Controls.Add(statCardTotalTenants, 3, 0);
            tlpMetrics.Dock = DockStyle.Fill;
            tlpMetrics.Location = new Point(40, 77);
            tlpMetrics.Margin = new Padding(3, 2, 3, 2);
            tlpMetrics.Name = "tlpMetrics";
            tlpMetrics.RowCount = 1;
            tlpMetrics.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMetrics.Size = new Size(1070, 116);
            tlpMetrics.TabIndex = 1;
            // 
            // statCardTotalProperties
            // 
            statCardTotalProperties.BackgroundImage = Resources.Resources.Icon__4_;
            statCardTotalProperties.CardCaption = "Total Properties";
            statCardTotalProperties.CardIcon = Resources.Resources.Icon__4_;
            statCardTotalProperties.IconSlotPadding = new Padding(10, 20, 10, 20);
            statCardTotalProperties.CardNumber = "00";
            statCardTotalProperties.Dock = DockStyle.Fill;
            statCardTotalProperties.Location = new Point(13, 0);
            statCardTotalProperties.Margin = new Padding(13, 0, 6, 0);
            statCardTotalProperties.Name = "statCardTotalProperties";
            statCardTotalProperties.Size = new Size(248, 116);
            statCardTotalProperties.TabIndex = 0;
            // 
            // statCardTotalUnits
            // 
            statCardTotalUnits.BackgroundImage = Resources.Resources.Icon__5_;
            statCardTotalUnits.CardCaption = "Total Units";
            statCardTotalUnits.CardIcon = Resources.Resources.Icon__5_;
            statCardTotalUnits.IconSlotPadding = new Padding(10, 20, 10, 20);
            statCardTotalUnits.CardNumber = "00";
            statCardTotalUnits.Dock = DockStyle.Fill;
            statCardTotalUnits.Location = new Point(273, 0);
            statCardTotalUnits.Margin = new Padding(6, 0, 6, 0);
            statCardTotalUnits.Name = "statCardTotalUnits";
            statCardTotalUnits.Size = new Size(255, 116);
            statCardTotalUnits.TabIndex = 1;
            // 
            // statCardUnitsOccupied
            // 
            statCardUnitsOccupied.BackgroundImage = Resources.Resources.Icon__6_;
            statCardUnitsOccupied.CardCaption = "Units Occupied";
            statCardUnitsOccupied.CardIcon = Resources.Resources.Icon__6_;
            statCardUnitsOccupied.IconSlotPadding = new Padding(10, 20, 10, 20);
            statCardUnitsOccupied.CardNumber = "00";
            statCardUnitsOccupied.Dock = DockStyle.Fill;
            statCardUnitsOccupied.Location = new Point(540, 0);
            statCardUnitsOccupied.Margin = new Padding(6, 0, 6, 0);
            statCardUnitsOccupied.Name = "statCardUnitsOccupied";
            statCardUnitsOccupied.Size = new Size(255, 116);
            statCardUnitsOccupied.TabIndex = 2;
            // 
            // statCardTotalTenants
            // 
            statCardTotalTenants.BackgroundImage = Resources.Resources.Icon__7_;
            statCardTotalTenants.CardCaption = "Total Tenants";
            statCardTotalTenants.CardIcon = Resources.Resources.Icon__7_;
            statCardTotalTenants.IconSlotPadding = new Padding(10, 20, 10, 20);
            statCardTotalTenants.CardNumber = "00";
            statCardTotalTenants.Dock = DockStyle.Fill;
            statCardTotalTenants.Location = new Point(807, 0);
            statCardTotalTenants.Margin = new Padding(6, 0, 13, 0);
            statCardTotalTenants.Name = "statCardTotalTenants";
            statCardTotalTenants.Size = new Size(250, 116);
            statCardTotalTenants.TabIndex = 3;
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(txtSearch);
            pnlActions.Controls.Add(cmbFilter);
            pnlActions.Controls.Add(btnNewProperty);
            pnlActions.Dock = DockStyle.Fill;
            pnlActions.Location = new Point(50, 197);
            pnlActions.Margin = new Padding(13, 2, 13, 2);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(1050, 68);
            pnlActions.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.CueHint.Color1 = Color.FromArgb(125, 130, 134);
            txtSearch.CueHint.CueHintText = "⌕  Search properties...";
            txtSearch.CueHint.Font = new Font("Century Gothic", 8.5F);
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
            // btnNewProperty
            // 
            btnNewProperty.Location = new Point(870, 15);
            btnNewProperty.Name = "btnNewProperty";
            btnNewProperty.Size = new Size(172, 40);
            btnNewProperty.StateCommon.Back.Color1 = Color.FromArgb(141, 198, 63);
            btnNewProperty.StateCommon.Back.Color2 = Color.FromArgb(91, 154, 42);
            btnNewProperty.StateCommon.Back.ColorAngle = 90F;
            btnNewProperty.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Linear;
            btnNewProperty.StateCommon.Border.Rounding = 12F;
            btnNewProperty.StateCommon.Content.ShortText.Color1 = Color.White;
            btnNewProperty.StateCommon.Content.ShortText.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            btnNewProperty.TabIndex = 2;
            btnNewProperty.Values.DropDownArrowColor = Color.Empty;
            btnNewProperty.Values.Text = "＋  New Property";
            // 
            // roundedPanelTable
            // 
            roundedPanelTable.BackColor = Color.White;
            roundedPanelTable.BorderColor = Color.Transparent;
            roundedPanelTable.BorderRadius = 10;
            roundedPanelTable.Controls.Add(dgvProperties);
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
            // dgvProperties
            // 
            dgvProperties.BackgroundColor = Color.White;
            dgvProperties.BorderStyle = BorderStyle.None;
            dgvProperties.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProperties.ColumnHeadersHeight = 42;
            dgvProperties.Dock = DockStyle.Fill;
            dgvProperties.GridColor = Color.FromArgb(233, 236, 239);
            dgvProperties.Location = new Point(6, 7);
            dgvProperties.Margin = new Padding(0);
            dgvProperties.Name = "dgvProperties";
            dgvProperties.RowHeadersVisible = false;
            dgvProperties.RowHeadersWidth = 51;
            dgvProperties.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProperties.Size = new Size(1272, 901);
            dgvProperties.TabIndex = 0;
            // 
            // PropertiesModule
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpMain);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PropertiesModule";
            Size = new Size(1150, 938);
            tlpMain.ResumeLayout(false);
            tlpMain.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tlpMetrics.ResumeLayout(false);
            pnlActions.ResumeLayout(false);
            pnlActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cmbFilter).EndInit();
            roundedPanelTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProperties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpMain;
        private Panel pnlHeader;
        private Label lblBreadcrumb;
        private Label lblTitle;
        private TableLayoutPanel tlpMetrics;
        private UserControls.AppearanceIconStatcard statCardTotalProperties;
        private UserControls.AppearanceIconStatcard statCardTotalUnits;
        private UserControls.AppearanceIconStatcard statCardUnitsOccupied;
        private UserControls.AppearanceIconStatcard statCardTotalTenants;
        private Panel pnlActions;
        private Krypton.Toolkit.KryptonTextBox txtSearch;
        private Krypton.Toolkit.KryptonComboBox cmbFilter;
        private Krypton.Toolkit.KryptonButton btnNewProperty;
        private PMS_v1.RoundedPanel roundedPanelTable;
        private DataGridView dgvProperties;
    }
}
