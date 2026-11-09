using System.ComponentModel;
using System.Drawing;

namespace PMS_v1.UserControls
{
    public class AppearanceIconStatcard : Statcard
    {
        [Category("Appearance")]
        [Description("Displays the stat card icon in its designated icon slot.")]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new Image? BackgroundImage
        {
            get => CardIcon;
            set => CardIcon = value;
        }
    }
}
