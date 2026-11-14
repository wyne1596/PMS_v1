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
            lblTitle = new Label();
            lblBreadcrumb = new Label();
            tlpMetrics = new TableLayoutPanel();
            statCardTotalProperties = new PMS_v1.UserControls.AppearanceIconStatcard();
            statCardTotalUnits = new PMS_v1.UserControls.AppearanceIconStatcard();
            statCardUnitsOccupied = new PMS_v1.UserControls.AppearanceIconStatcard();
            statCardTotalTenants = new PMS_v1.UserControls.AppearanceIconStatcard();
            pnlActions = new Panel();
            txtSearch = new Krypton.Toolkit.KryptonTextBox();
            cmbFilter = new Krypton.Toolkit.KryptonComboBox();
            btnNewProperty = new Krypton.Toolkit.KryptonButton();
            tlpMain.SuspendLayout();
            pnlHeader.SuspendLayout();
            tlpMetrics.SuspendLayout();
            pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbFilter).BeginInit();
            SuspendLayout();
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(pnlHeader, 0, 0);
            tlpMain.Controls.Add(tlpMetrics, 0, 1);
            tlpMain.Controls.Add(pnlActions, 0, 2);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Name = "tlpMain";
            tlpMain.Padding = new Padding(42, 18, 42, 12);
            tlpMain.RowCount = 4;
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 160F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.Size = new Size(1314, 1251);
            tlpMain.TabIndex = 0;
            // 
            // pnlHeader
            // 
            pnlHeader.AutoSize = true;
            pnlHeader.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlHeader.Controls.Add(lblBreadcrumb);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Fill;
            pnlHeader.Location = new Point(45, 21);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(17, 0, 0, 0);
            pnlHeader.Size = new Size(1224, 72);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Location = new Point(17, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(164, 41);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Properties";
            // 
            // lblBreadcrumb
            // 
            lblBreadcrumb.AutoSize = true;
            lblBreadcrumb.Dock = DockStyle.Top;
            lblBreadcrumb.Font = new Font("Century Gothic", 8.5F);
            lblBreadcrumb.ForeColor = Color.FromArgb(108, 117, 125);
            lblBreadcrumb.Location = new Point(17, 41);
            lblBreadcrumb.Name = "lblBreadcrumb";
            lblBreadcrumb.Padding = new Padding(0, 0, 0, 11);
            lblBreadcrumb.Size = new Size(140, 31);
            lblBreadcrumb.TabIndex = 0;
            lblBreadcrumb.Text = "Home / Properties";
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
            tlpMetrics.Location = new Point(45, 99);
            tlpMetrics.Name = "tlpMetrics";
            tlpMetrics.RowCount = 1;
            tlpMetrics.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMetrics.Size = new Size(1224, 154);
            tlpMetrics.TabIndex = 1;
            // 
            // statCardTotalProperties
            // 
            statCardTotalProperties.BackgroundImage = Resources.Resources.Property;
            statCardTotalProperties.CardCaption = "Total Properties";
            statCardTotalProperties.CardIcon = Resources.Resources.Property;
            statCardTotalProperties.CardNumber = "00";
            statCardTotalProperties.Dock = DockStyle.Fill;
            statCardTotalProperties.Location = new Point(15, 0);
            statCardTotalProperties.Margin = new Padding(15, 0, 7, 0);
            statCardTotalProperties.Name = "statCardTotalProperties";
            statCardTotalProperties.Size = new Size(284, 154);
            statCardTotalProperties.TabIndex = 0;
            // 
            // statCardTotalUnits
            // 
            statCardTotalUnits.BackgroundImage = Resources.Resources.Lease;
            statCardTotalUnits.CardCaption = "Total Units";
            statCardTotalUnits.CardIcon = Resources.Resources.Lease;
            statCardTotalUnits.CardNumber = "00";
            statCardTotalUnits.Dock = DockStyle.Fill;
            statCardTotalUnits.Location = new Point(313, 0);
            statCardTotalUnits.Margin = new Padding(7, 0, 7, 0);
            statCardTotalUnits.Name = "statCardTotalUnits";
            statCardTotalUnits.Size = new Size(292, 154);
            statCardTotalUnits.TabIndex = 1;
            // 
            // statCardUnitsOccupied
            // 
            statCardUnitsOccupied.BackgroundImage = Resources.Resources.check;
            statCardUnitsOccupied.CardCaption = "Units Occupied";
            statCardUnitsOccupied.CardIcon = Resources.Resources.check;
            statCardUnitsOccupied.CardNumber = "00";
            statCardUnitsOccupied.Dock = DockStyle.Fill;
            statCardUnitsOccupied.Location = new Point(619, 0);
            statCardUnitsOccupied.Margin = new Padding(7, 0, 7, 0);
            statCardUnitsOccupied.Name = "statCardUnitsOccupied";
            statCardUnitsOccupied.Size = new Size(292, 154);
            statCardUnitsOccupied.TabIndex = 2;
            // 
            // statCardTotalTenants
            // 
            statCardTotalTenants.BackgroundImage = Resources.Resources.Payment;
            statCardTotalTenants.CardCaption = "Total Tenants";
            statCardTotalTenants.CardIcon = Resources.Resources.Payment;
            statCardTotalTenants.CardNumber = "00";
            statCardTotalTenants.Dock = DockStyle.Fill;
            statCardTotalTenants.Location = new Point(925, 0);
            statCardTotalTenants.Margin = new Padding(7, 0, 15, 0);
            statCardTotalTenants.Name = "statCardTotalTenants";
            statCardTotalTenants.Size = new Size(284, 154);
            statCardTotalTenants.TabIndex = 3;
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(txtSearch);
            pnlActions.Controls.Add(cmbFilter);
            pnlActions.Controls.Add(btnNewProperty);
            pnlActions.Dock = DockStyle.Fill;
            pnlActions.Location = new Point(57, 259);
            pnlActions.Margin = new Padding(15, 3, 15, 3);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(1200, 90);
            pnlActions.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.CueHint.Color1 = Color.FromArgb(125, 130, 134);
            txtSearch.CueHint.CueHintText = "⌕  Search properties...";
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
            // btnNewProperty
            // 
            btnNewProperty.Location = new Point(994, 20);
            btnNewProperty.Margin = new Padding(3, 4, 3, 4);
            btnNewProperty.Name = "btnNewProperty";
            btnNewProperty.Size = new Size(197, 53);
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
            // PropertiesModule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpMain);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PropertiesModule";
            Size = new Size(1314, 1251);
            tlpMain.ResumeLayout(false);
            tlpMain.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tlpMetrics.ResumeLayout(false);
            pnlActions.ResumeLayout(false);
            pnlActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cmbFilter).EndInit();
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
    }
}
