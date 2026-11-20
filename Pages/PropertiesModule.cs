namespace PMS_v1.Pages
{
    public partial class PropertiesModule : UserControl
    {
        public event Action<string>? PropertySearchChanged;
        public event Action<string>? PropertyStatusChanged;
        public event EventHandler? NewPropertyRequested;

        public PropertiesModule()
        {
            InitializeComponent();
            statCardUnitsOccupied.CardIcon = null!;
            PMS_v1.UserControls.ModulePageLayout.ApplyStandardLayout(
                tlpMain, pnlHeader, tlpMetrics, pnlActions, roundedPanelTable);
            PMS_v1.UserControls.ModulePageLayout.FitGridToRoundedPanel(roundedPanelTable, dgvProperties);
            ConfigurePropertyActions();
            ConfigurePropertiesGrid();
            LayoutActionRow();
            pnlActions.Resize += (_, _) => LayoutActionRow();
        }

        private void ConfigurePropertyActions()
        {
            // The search hint comes from txtSearch.CueHint in the designer, like the other pages.
            cmbFilter.Items.AddRange(new object[]
            {
                "All Properties", "Occupied", "Vacant"
            });
            cmbFilter.SelectedIndex = 0;
            btnNewProperty.Values.Text = "＋  New Property";

            txtSearch.TextChanged += (_, _) =>
                PropertySearchChanged?.Invoke(txtSearch.Text.Trim());
            cmbFilter.SelectedIndexChanged += (_, _) =>
                PropertyStatusChanged?.Invoke(Convert.ToString(cmbFilter.SelectedItem) ?? "All Properties");
            btnNewProperty.Click += (_, _) => NewPropertyRequested?.Invoke(this, EventArgs.Empty);
        }

        // Table: same look as the other pages
        private void ConfigurePropertiesGrid()
        {
            PMS_v1.UserControls.ModulePageLayout.ApplyStandardGridStyle(dgvProperties);

            dgvProperties.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Property",
                HeaderText = "PROPERTY",
                FillWeight = 40,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvProperties.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Units",
                HeaderText = "UNITS",
                FillWeight = 18,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvProperties.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Occupied",
                HeaderText = "OCCUPIED",
                FillWeight = 20,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvProperties.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "STATUS",
                FillWeight = 22,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Padding = new Padding(4, 0, 4, 0)
                }
            });

            PMS_v1.UserControls.ModulePageLayout.AttachStatusBadge(dgvProperties, "Status");
        }

        private void LayoutActionRow()
        {
            PMS_v1.UserControls.ModulePageLayout.LayoutActions(
                pnlActions, txtSearch, cmbFilter, btnNewProperty);
        }
    }
}
