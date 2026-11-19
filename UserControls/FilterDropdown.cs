using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace PMS_v1.UserControls
{
    /// <summary>
    /// Self-drawn filter dropdown: chevron on the left, text in the middle, filter icon on the right.
    /// Items / SelectedIndex / SelectedIndexChanged / Text work like a ComboBox, so page code stays the same.
    /// </summary>
    public class FilterDropdown : Control
    {
        private readonly ItemCollection items;
        private int selectedIndex = -1;
        private bool hover;
        private Bitmap? chevron;
        private Bitmap? filterIcon;
        private int iconDpi;
        private ContextMenuStrip? menu;

        public FilterDropdown()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                     ControlStyles.Selectable | ControlStyles.StandardClick, true);
            TabStop = true;
            items = new ItemCollection(this);
            BackColor = Color.White;
            ForeColor = Color.FromArgb(125, 130, 134);
            Font = new Font("Century Gothic", 8.5F);
            Cursor = Cursors.Hand;
        }

        public event EventHandler? SelectedIndexChanged;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ItemCollection Items => items;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                if (value < -1 || value >= items.Count) value = -1;
                if (value == selectedIndex) return;
                selectedIndex = value;
                Invalidate();
                SelectedIndexChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        [Category("Appearance")]
        [DefaultValue("Filter")]
        public string PlaceholderText { get; set; } = "Filter";

        /// <summary>When true, the first item means "no filter" and the placeholder is shown for it.</summary>
        [Category("Appearance")]
        [DefaultValue(true)]
        public bool FirstItemIsDefault { get; set; } = true;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [AllowNull]
        public override string Text
        {
            get => selectedIndex >= 0 ? items[selectedIndex].ToString() ?? string.Empty : string.Empty;
            set => SelectedIndex = items.IndexOf(value);
        }

        private string DisplayText =>
            selectedIndex < 0 || (FirstItemIsDefault && selectedIndex == 0) ? PlaceholderText : Text;

        private int Scale(int value) => (int)Math.Round(value * DeviceDpi / 96f);

        private void EnsureIcons()
        {
            if (chevron != null && filterIcon != null && iconDpi == DeviceDpi) return;
            chevron?.Dispose();
            filterIcon?.Dispose();
            chevron = ActionIcons.Chevron(ForeColor, Scale(16));
            filterIcon = ActionIcons.Filter(ForeColor, Scale(16));
            iconDpi = DeviceDpi;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            EnsureIcons();
            var g = e.Graphics;
            g.Clear(hover ? Color.FromArgb(247, 249, 250) : BackColor);

            int pad = Scale(10);
            g.DrawImage(chevron!, pad, (Height - chevron!.Height) / 2);
            g.DrawImage(filterIcon!, Width - pad - filterIcon!.Width, (Height - filterIcon.Height) / 2);

            int textLeft = pad * 2 + chevron.Width;
            int textWidth = Math.Max(0, Width - textLeft - pad * 2 - filterIcon.Width);
            TextRenderer.DrawText(g, DisplayText, Font, new Rectangle(textLeft, 0, textWidth, Height), ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);
        }

        protected override void OnMouseEnter(EventArgs e) { hover = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { hover = false; Invalidate(); base.OnMouseLeave(e); }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left) ShowMenu();
        }

        protected override bool IsInputKey(Keys keyData) => keyData == Keys.Down || base.IsInputKey(keyData);

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space || e.KeyCode == Keys.Down)
            {
                ShowMenu();
                e.Handled = true;
            }
        }

        private void ShowMenu()
        {
            if (items.Count == 0) return;

            menu?.Dispose();
            menu = new ContextMenuStrip
            {
                Font = Font,
                ShowImageMargin = false,
                ShowCheckMargin = true,
                MinimumSize = new Size(Width, 0)
            };

            for (int i = 0; i < items.Count; i++)
            {
                int index = i;
                var item = new ToolStripMenuItem(items[i].ToString() ?? string.Empty) { Checked = i == selectedIndex };
                item.Click += (_, _) => SelectedIndex = index;
                menu.Items.Add(item);
            }

            menu.Show(this, new Point(0, Height + 2));
        }

        protected override void OnDpiChangedAfterParent(EventArgs e)
        {
            base.OnDpiChangedAfterParent(e);
            Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                chevron?.Dispose();
                filterIcon?.Dispose();
                menu?.Dispose();
            }
            base.Dispose(disposing);
        }

        public sealed class ItemCollection : IEnumerable
        {
            private readonly List<object> list = new();
            private readonly FilterDropdown owner;

            internal ItemCollection(FilterDropdown owner) => this.owner = owner;

            public int Count => list.Count;
            public object this[int index] => list[index];

            public int Add(object item)
            {
                list.Add(item);
                owner.Invalidate();
                return list.Count - 1;
            }

            public void AddRange(object[] range)
            {
                list.AddRange(range);
                owner.Invalidate();
            }

            public void Clear()
            {
                list.Clear();
                owner.selectedIndex = -1;
                owner.Invalidate();
            }

            public int IndexOf(object? value)
            {
                string? text = value?.ToString();
                for (int i = 0; i < list.Count; i++)
                    if (string.Equals(list[i].ToString(), text, StringComparison.OrdinalIgnoreCase)) return i;
                return -1;
            }

            public IEnumerator GetEnumerator() => list.GetEnumerator();
        }
    }
}
