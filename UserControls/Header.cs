using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PMS_v1.UserControls
{
    public partial class Header : UserControl
    {
        public event EventHandler? MenuToggleClicked;
        public Header()
        {
            InitializeComponent();

        }

        private void btnHamburger_Click(object sender, EventArgs e)
            => MenuToggleClicked?.Invoke(this, EventArgs.Empty);
    }
}
