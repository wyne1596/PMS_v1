using System.Drawing;
using System.Windows.Forms;

namespace PMS_v1.Pages
{
    partial class Units
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
            statCardTotalUnits = new PMS_v1.UserControls.AppearanceIconStatcard();
            statCardVacantUnits = new PMS_v1.UserControls.AppearanceIconStatcard();
            statCardOccupiedUnits = new PMS_v1.UserControls.AppearanceIconStatcard();
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
            lblBreadcrumb.Size = new Size(78, 15);
            lblBreadcrumb.TabIndex = 0;
            lblBreadcrumb.Text = "Home / Units";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Location = new Point(0, 43);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(73, 32);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Units";
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
            tlpMetrics.Controls.Add(statCardTotalTenants, 3, 0);
            tlpMetrics.Dock = DockStyle.Fill;
            tlpMetrics.Location = new Point(42, 114);
            tlpMetrics.Margin = new Padding(0);
            tlpMetrics.Name = "tlpMetrics";
            tlpMetrics.RowCount = 1;
            tlpMetrics.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMetrics.Size = new Size(1066, 120);
            tlpMetrics.TabIndex = 1;
            // 
            // statCardTotalUnits
            // 
            statCardTotalUnits.BackgroundImage = Resources.Resources.circle;
            statCardTotalUnits.CardCaption = "Total Units";
            statCardTotalUnits.CardIcon = Resources.Resources.circle;
            statCardTotalUnits.CardNumber = "00";
            statCardTotalUnits.Dock = DockStyle.Fill;
            statCardTotalUnits.Location = new Point(8, 0);
            statCardTotalUnits.Margin = new Padding(8, 0, 8, 0);
            statCardTotalUnits.Name = "statCardTotalUnits";
            statCardTotalUnits.Size = new Size(250, 120);
            statCardTotalUnits.TabIndex = 0;
            // 
            // statCardVacantUnits
            // 
            statCardVacantUnits.BackgroundImage = Resources.Resources.circle__1_;
            statCardVacantUnits.CardCaption = "Vacant Units";
            statCardVacantUnits.CardIcon = Resources.Resources.circle__1_;
            statCardVacantUnits.CardNumber = "00";
            statCardVacantUnits.Dock = DockStyle.Fill;
            statCardVacantUnits.Location = new Point(274, 0);
            statCardVacantUnits.Margin = new Padding(8, 0, 8, 0);
            statCardVacantUnits.Name = "statCardVacantUnits";
            statCardVacantUnits.Size = new Size(250, 120);
            statCardVacantUnits.TabIndex = 1;
            // 
            // statCardOccupiedUnits
            // 
            statCardOccupiedUnits.BackgroundImage = Resources.Resources.familiar_group_of_four_persons_composed_by_two_women_with_male_and_female_kids_in_a_house;
            statCardOccupiedUnits.CardCaption = "Occupied Units";
            statCardOccupiedUnits.CardIcon = Resources.Resources.familiar_group_of_four_persons_composed_by_two_women_with_male_and_female_kids_in_a_house;
            statCardOccupiedUnits.CardNumber = "00";
            statCardOccupiedUnits.Dock = DockStyle.Fill;
            statCardOccupiedUnits.Location = new Point(540, 0);
            statCardOccupiedUnits.Margin = new Padding(8, 0, 8, 0);
            statCardOccupiedUnits.Name = "statCardOccupiedUnits";
            statCardOccupiedUnits.Size = new Size(250, 120);
            statCardOccupiedUnits.TabIndex = 2;
            // 
            // statCardTotalTenants
            // 
            statCardTotalTenants.BackgroundImage = Resources.Resources.audience;
            statCardTotalTenants.CardCaption = "Total Tenants";
            statCardTotalTenants.CardIcon = Resources.Resources.audience;
            statCardTotalTenants.CardNumber = "00";
            statCardTotalTenants.Dock = DockStyle.Fill;
            statCardTotalTenants.Location = new Point(806, 0);
            statCardTotalTenants.Margin = new Padding(8, 0, 8, 0);
            statCardTotalTenants.Name = "statCardTotalTenants";
            statCardTotalTenants.Size = new Size(252, 120);
            statCardTotalTenants.TabIndex = 3;
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(txtSearch);
            pnlActions.Controls.Add(cmbFilter);
            pnlActions.Controls.Add(btnNewProperty);
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
            btnNewProperty.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNewProperty.TabIndex = 2;
            btnNewProperty.Values.DropDownArrowColor = Color.Empty;
            btnNewProperty.Values.Text = "＋  New Property";
            // 
            // Units
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpMain);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Units";
            Size = new Size(1150, 938);
            tlpMain.ResumeLayout(false);
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
        private UserControls.AppearanceIconStatcard statCardTotalTenants;
        private Panel pnlActions;
        private Krypton.Toolkit.KryptonTextBox txtSearch;
        private Krypton.Toolkit.KryptonComboBox cmbFilter;
        private Krypton.Toolkit.KryptonButton btnNewProperty;
    }
}
