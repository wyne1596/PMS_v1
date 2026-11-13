using System;
using System.Windows.Forms;

namespace PMS_v1.Pages
{
    public partial class DashboardModule : UserControl
    {
        public DashboardModule()
        {
            InitializeComponent();
            PMS_v1.UserControls.ModulePageLayout.FitGridToRoundedPanel(roundedPanelTable, dgvRecent);

            // Sample rows so the design can be previewed. Remove when real data is connected.
            dgvRecent.Rows.Add("Sophia Leigh R. Manoguid", "A-101", "April 15, 2026", "Active");
            dgvRecent.Rows.Add("Alexis N. Prado", "B-009", "September 11, 2026", "Pending");
            dgvRecent.Rows.Add("Shello Mith C. Belarmino", "C-220", "January 6, 2026", "Expired");
            dgvRecent.Rows.Add("Wyne Beinjamin Constantino", "D-069", "May 9, 2026", "Terminated");
        }
    }
}
