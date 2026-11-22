using System.ComponentModel;
using System.Drawing;

namespace PMS_v1.UserControls
{
    /// <summary>
    /// Progress line for a maintenance request: Open > In Progress > Resolved > Closed.
    /// The layout (circles, lines, captions) is in StatusTracker.Designer.cs;
    /// this file only sets the colors for the current status.
    /// Set Status to the database status and the steps up to it are filled in.
    /// </summary>
    public partial class StatusTracker : UserControl
    {
        private static readonly string[] Steps = { "Open", "In Progress", "Resolved", "Closed" };
        private static readonly Color Done = Color.FromArgb(72, 149, 199);
        private static readonly Color Pending = Color.FromArgb(206, 212, 218);
        private static readonly Color TextDark = Color.FromArgb(44, 49, 53);
        private static readonly Color LabelGray = Color.FromArgb(108, 117, 125);

        private readonly RoundedPanel[] circles;
        private readonly Label[] marks;
        private readonly Label[] captions;
        private readonly Panel[] lines;
        private readonly Font regularFont;
        private readonly Font boldFont;

        private string status = "Open";

        public StatusTracker()
        {
            InitializeComponent();

            circles = new[] { circle1, circle2, circle3, circle4 };
            marks = new[] { lblMark1, lblMark2, lblMark3, lblMark4 };
            captions = new[] { lblStep1, lblStep2, lblStep3, lblStep4 };
            lines = new[] { line1, line2, line3 };

            regularFont = lblStep1.Font;
            boldFont = new Font(regularFont, FontStyle.Bold);
            Disposed += (_, _) => boldFont.Dispose();

            ApplyStatus();
        }

        [Category("Custom Properties")]
        [Description("The request status: Open, In Progress, Resolved or Closed.")]
        [DefaultValue("Open")]
        public string Status
        {
            get => status;
            set { status = value ?? "Open"; ApplyStatus(); }
        }

        // finished steps get a check mark, the current step a dot, the rest stay empty
        private void ApplyStatus()
        {
            int current = Math.Max(0, Array.IndexOf(Steps, status));

            for (int i = 0; i < Steps.Length; i++)
            {
                bool reached = i <= current;

                circles[i].BackColor = reached ? Done : Color.White;
                circles[i].BorderColor = reached ? Done : Pending;
                marks[i].Text = i < current ? "\u2713" : i == current ? "\u25CF" : string.Empty;
                captions[i].ForeColor = reached ? TextDark : LabelGray;
                captions[i].Font = i == current ? boldFont : regularFont;

                if (i < lines.Length)
                    lines[i].BackColor = i < current ? Done : Pending;
            }
        }
    }
}
