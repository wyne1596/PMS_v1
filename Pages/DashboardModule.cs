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
            
        }
    }
}
