using System.Drawing;
using System.Windows.Forms;

namespace PMS_v1.Pages
{
    partial class UnitsModule
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
            statCardTotalUnits = new PMS_v1.UserControls.AppearanceIconStatcard();
            statCardVacantUnits = new PMS_v1.UserControls.AppearanceIconStatcard();
            statCardOccupiedUnits = new PMS_v1.UserControls.AppearanceIconStatcard();
            statCardMaintenanceUnits = new PMS_v1.UserControls.AppearanceIconStatcard();
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
            lblTitle.Size = new Size(83, 37);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Units";
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
            lblBreadcrumb.Size = new Size(101, 31);
            lblBreadcrumb.TabIndex = 0;
            lblBreadcrumb.Text = "Home / Units";
            // 
            // tlpMetrics
            // 
            tlpMetrics.ColumnCount = 4;
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpMetrics.Controls.Add(statCardTotalUnits, 0, 0);
            tlpMetrics.Controls.Add(statCardVacantUnits, 1, 0);
            tlpMetrics.Controls.Add(statCardOccupiedUnits, 2, 0);
            tlpMetrics.Controls.Add(statCardMaintenanceUnits, 3, 0);
            tlpMetrics.Dock = DockStyle.Fill;
            tlpMetrics.Location = new Point(3, 77);
            tlpMetrics.Name = "tlpMetrics";
            tlpMetrics.RowCount = 1;
            tlpMetrics.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMetrics.Size = new Size(1308, 154);
            tlpMetrics.TabIndex = 1;
            // 
            // statCardTotalUnits
            // 
            statCardTotalUnits.BackgroundImage = Resources.Resources.circle;
            statCardTotalUnits.CardCaption = "Total Units";
            statCardTotalUnits.CardIcon = Resources.Resources.circle;
            statCardTotalUnits.CardNumber = "00";
            statCardTotalUnits.Dock = DockStyle.Fill;
            statCardTotalUnits.Location = new Point(15, 0);
            statCardTotalUnits.Margin = new Padding(15, 0, 7, 0);
            statCardTotalUnits.Name = "statCardTotalUnits";
            statCardTotalUnits.Size = new Size(305, 154);
            statCardTotalUnits.TabIndex = 0;
            // 
            // statCardVacantUnits
            // 
            statCardVacantUnits.BackgroundImage = Resources.Resources.circle__1_;
            statCardVacantUnits.CardCaption = "Vacant Units";
            statCardVacantUnits.CardIcon = Resources.Resources.circle__1_;
            statCardVacantUnits.CardNumber = "00";
            statCardVacantUnits.Dock = DockStyle.Fill;
            statCardVacantUnits.Location = new Point(334, 0);
            statCardVacantUnits.Margin = new Padding(7, 0, 7, 0);
            statCardVacantUnits.Name = "statCardVacantUnits";
            statCardVacantUnits.Size = new Size(313, 154);
            statCardVacantUnits.TabIndex = 1;
            // 
            // statCardOccupiedUnits
            // 
            statCardOccupiedUnits.BackgroundImage = Resources.Resources.familiar_group_of_four_persons_composed_by_two_women_with_male_and_female_kids_in_a_house;
            statCardOccupiedUnits.CardCaption = "Occupied Units";
            statCardOccupiedUnits.CardIcon = Resources.Resources.familiar_group_of_four_persons_composed_by_two_women_with_male_and_female_kids_in_a_house;
            statCardOccupiedUnits.CardNumber = "00";
            statCardOccupiedUnits.Dock = DockStyle.Fill;
            statCardOccupiedUnits.Location = new Point(661, 0);
            statCardOccupiedUnits.Margin = new Padding(7, 0, 7, 0);
            statCardOccupiedUnits.Name = "statCardOccupiedUnits";
            statCardOccupiedUnits.Size = new Size(313, 154);
            statCardOccupiedUnits.TabIndex = 2;
            // 
            // statCardMaintenanceUnits
            // 
            statCardMaintenanceUnits.BackgroundImage = Resources.Resources.hourglass;
            statCardMaintenanceUnits.CardCaption = "Under Maintenance";
            statCardMaintenanceUnits.CardIcon = Resources.Resources.hourglass;
            statCardMaintenanceUnits.CardNumber = "00";
            statCardMaintenanceUnits.Dock = DockStyle.Fill;
            statCardMaintenanceUnits.Location = new Point(988, 0);
            statCardMaintenanceUnits.Margin = new Padding(7, 0, 15, 0);
            statCardMaintenanceUnits.Name = "statCardMaintenanceUnits";
            statCardMaintenanceUnits.Size = new Size(305, 154);
            statCardMaintenanceUnits.TabIndex = 3;
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(txtSearch);
            pnlActions.Controls.Add(cmbFilter);
            pnlActions.Controls.Add(btnNewProperty);
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
            txtSearch.CueHint.CueHintText = "⌕  Search properties...";
            txtSearch.CueHint.Font = new Font("Century Gothic", 8.5F);
            txtSearch.Location = new Point(0, 31);
            txtSearch.Margin = new Padding(3, 5, 3, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(758, 35);
            txtSearch.StateCommon.Back.Color1 = Color.White;
            txtSearch.StateCommon.Border.Color1 = Color.FromArgb(222, 226, 230);
            txtSearch.StateCommon.Border.Rounding = 12F;
            txtSearch.TabIndex = 0;
            // 
            // cmbFilter
            // 
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.Location = new Point(914, 31);
            cmbFilter.Margin = new Padding(3, 5, 3, 5);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(195, 34);
            cmbFilter.StateCommon.ComboBox.Back.Color1 = Color.White;
            cmbFilter.StateCommon.ComboBox.Border.Color1 = Color.FromArgb(222, 226, 230);
            cmbFilter.StateCommon.ComboBox.Border.Rounding = 12F;
            cmbFilter.TabIndex = 1;
            // 
            // btnNewProperty
            // 
            btnNewProperty.Location = new Point(1136, 27);
            btnNewProperty.Margin = new Padding(3, 5, 3, 5);
            btnNewProperty.Name = "btnNewProperty";
            btnNewProperty.Size = new Size(225, 71);
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
            // UnitsModule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpMain);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UnitsModule";
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
        private UserControls.AppearanceIconStatcard statCardTotalUnits;
        private UserControls.AppearanceIconStatcard statCardVacantUnits;
        private UserControls.AppearanceIconStatcard statCardOccupiedUnits;
        private UserControls.AppearanceIconStatcard statCardMaintenanceUnits;
        private Panel pnlActions;
        private Krypton.Toolkit.KryptonTextBox txtSearch;
        private Krypton.Toolkit.KryptonComboBox cmbFilter;
        private Krypton.Toolkit.KryptonButton btnNewProperty;
    }
}
