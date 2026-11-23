#nullable disable
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.ComponentModel;

namespace PMS_v1   // keep as PMS_v1 so every page can see it
{
    public enum FormMode { New, Edit }

    public enum FieldType { Text, LongText, Number, Money, Date, Dropdown, Phone }

    /// <summary>
    /// A dropdown item that remembers its database id.
    /// Id = null means "no id" (for example the "Common area" choice in Maintenance).
    /// GetValue returns the Id, GetText returns the text.
    /// </summary>
    public class ComboItem
    {
        public int? Id { get; private set; }
        public string Text { get; private set; }

        public ComboItem(int? id, string text)
        {
            Id = id;
            Text = text;
        }

        public override string ToString() { return Text; }
    }

    /// <summary>Describes one row of the form. Pages create a list of these.</summary>
    public class FormField
    {
        public string Key { get; set; }                     // short id, e.g. "amount"
        public string Label { get; set; }                   // text shown beside the input
        public FieldType Type { get; set; } = FieldType.Text;
        public string[] Options { get; set; }               // fixed choices for Dropdown (enum values)
        public bool Required { get; set; } = true;          // false = optional (blank saves as null)
        public object DefaultValue { get; set; }            // optional starting value
        public bool ReadOnly { get; set; }                  // shown but not editable (for Edit)
        public int MaxLength { get; set; }                  // 0 = default (Text 100, LongText 255)
    }

    /// <summary>
    /// One reusable modal form for New / Edit on any page with a table.
    /// It only checks the input. Saving to MySQL is done by the page after DialogResult.OK.
    ///
    /// Reading values after OK:
    ///   Text / Phone / LongText -> string, or null when left blank
    ///   Number / Money          -> decimal
    ///   Date                    -> DateTime, or null when an optional date is unchecked
    ///   Dropdown                -> the ComboItem's Id (int or null), or the text for plain choices
    /// </summary>
    public class RecordForm : Form
    {
        // ---------- Look: change these to match your app ----------
        private static readonly Color HeaderBlue = Color.FromArgb(72, 149, 199);
        private static readonly Color SaveGreen = Color.FromArgb(106, 168, 35);
        private static readonly Color FooterGray = Color.FromArgb(244, 245, 246);
        private static readonly Color TextDark = Color.FromArgb(40, 40, 40);
        private const string FontName = "Century Gothic";   // the app's font

        private const int RowHeight = 46;
        private const int LongRowHeight = 84;
        private static readonly Regex PhonePattern = new Regex(@"^09\d{9}$");

        private readonly List<FormField> fields;
        private readonly Dictionary<string, Control> inputs = new Dictionary<string, Control>();
        private readonly Button btnSave = new Button();
        private readonly Button btnCancel = new Button();

        public FormMode Mode { get; private set; }

        /// <summary>
        /// Optional extra rules (end date after start date, amount not above the balance...).
        /// Return an error message to block Save, or null when everything is fine.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Func<Dictionary<string, object>, string> Validator { get; set; }

        public RecordForm(FormMode mode, string entityName, IEnumerable<FormField> fields)
        {
            Mode = mode;
            this.fields = new List<FormField>(fields);
            BuildUi(entityName);
        }

        // ---------- Reading and filling values ----------

        /// <summary>All values by key, e.g. Values["amount"]. Read this after DialogResult.OK.</summary>
        public Dictionary<string, object> Values
        {
            get
            {
                var result = new Dictionary<string, object>();
                foreach (var f in fields)
                    result[f.Key] = GetValue(f.Key);
                return result;
            }
        }

        public object GetValue(string key)
        {
            Control c;
            if (!inputs.TryGetValue(key, out c)) return null;

            var tb = c as TextBox;
            if (tb != null)
            {
                string t = tb.Text.Trim();
                return t.Length == 0 ? null : t;      // blank = null, so optional fields save as NULL
            }

            var num = c as NumericUpDown;
            if (num != null) return num.Value;

            var dtp = c as DateTimePicker;
            if (dtp != null)
                return (dtp.ShowCheckBox && !dtp.Checked) ? null : (object)dtp.Value.Date;

            var cbo = c as ComboBox;
            if (cbo != null)
            {
                var item = cbo.SelectedItem as ComboItem;
                if (item != null) return item.Id;     // the database id
                return cbo.SelectedItem;              // plain text choice
            }
            return null;
        }

        /// <summary>The text the user sees in a dropdown (for messages, receipts and so on).</summary>
        public string GetText(string key)
        {
            Control c;
            var cbo = inputs.TryGetValue(key, out c) ? c as ComboBox : null;
            if (cbo == null || cbo.SelectedItem == null) return null;
            return cbo.SelectedItem.ToString();
        }

        /// <summary>Prefill one field (used for Edit). DBNull and null are ignored.</summary>
        public void SetValue(string key, object value)
        {
            Control c;
            if (value == null || value is DBNull || !inputs.TryGetValue(key, out c)) return;

            var tb = c as TextBox;
            if (tb != null) { tb.Text = value.ToString(); return; }

            var num = c as NumericUpDown;
            if (num != null) { SetNumeric(num, Convert.ToDecimal(value)); return; }

            var dtp = c as DateTimePicker;
            if (dtp != null)
            {
                if (dtp.ShowCheckBox) dtp.Checked = true;
                dtp.Value = Convert.ToDateTime(value);
                return;
            }

            var cbo = c as ComboBox;
            if (cbo != null) SelectItem(cbo, value);
        }

        /// <summary>Prefill several fields at once (used for Edit).</summary>
        public void SetValues(IDictionary<string, object> values)
        {
            foreach (var pair in values)
                SetValue(pair.Key, pair.Value);
        }

        /// <summary>Fill a dropdown with database rows: new ComboItem(id, "text").</summary>
        public void SetOptions(string key, IEnumerable<ComboItem> options)
        {
            Control c;
            var cbo = inputs.TryGetValue(key, out c) ? c as ComboBox : null;
            if (cbo == null) return;

            cbo.Items.Clear();
            foreach (var option in options)
                cbo.Items.Add(option);
        }

        /// <summary>Replace a dropdown's choices with plain text.</summary>
        public void SetOptions(string key, IEnumerable<string> options)
        {
            Control c;
            var cbo = inputs.TryGetValue(key, out c) ? c as ComboBox : null;
            if (cbo == null) return;

            cbo.Items.Clear();
            foreach (var option in options)
                cbo.Items.Add(option);
        }

        /// <summary>
        /// Lock or unlock one field. A locked field is shown but can't be changed, and Save does not check it.
        /// Its value can still be set from code with SetValue.
        /// </summary>
        public void SetLocked(string key, bool locked)
        {
            Control c;
            if (inputs.TryGetValue(key, out c)) c.Enabled = !locked;
        }

        /// <summary>
        /// Run <paramref name="handler"/> whenever a different choice is picked in a dropdown
        /// (for example, to fill another field from the chosen row). Call it after SetOptions / SetValues.
        /// </summary>
        public void OnChoiceChanged(string key, Action handler)
        {
            Control c;
            var cbo = inputs.TryGetValue(key, out c) ? c as ComboBox : null;
            if (cbo != null) cbo.SelectedIndexChanged += (s, e) => handler();
        }

        // ---------- UI construction ----------
        private static int RowFor(FormField f)
        {
            return f.Type == FieldType.LongText ? LongRowHeight : RowHeight;
        }

        private void BuildUi(string entityName)
        {
            SuspendLayout();

            // same scaling on every PC, so the layout does not clip at 125% display scaling
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;

            Text = (Mode == FormMode.New ? "New " : "Edit ") + entityName;
            Font = new Font(FontName, 10F);
            BackColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;

            int bodyHeight = 0;
            foreach (var f in fields) bodyHeight += RowFor(f);
            ClientSize = new Size(440, 56 + 12 + bodyHeight + 16 + 64);   // grows with the fields

            var root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                Margin = Padding.Empty
            };
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 56));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 64));

            var header = new Label
            {
                Text = Text,
                Dock = DockStyle.Fill,
                BackColor = HeaderBlue,
                ForeColor = Color.White,
                Font = new Font(FontName, 14F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(24, 0, 0, 0),
                Margin = Padding.Empty
            };

            var body = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                Padding = new Padding(24, 12, 24, 0),
                Margin = Padding.Empty
            };
            body.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130));
            body.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            foreach (var field in fields)
            {
                var input = CreateInput(field);
                input.Enabled = !field.ReadOnly;
                inputs[field.Key] = input;
                AddRow(body, field, input);
            }

            var footer = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                BackColor = FooterGray,
                Padding = new Padding(24, 13, 24, 0),
                Margin = Padding.Empty
            };
            StyleButton(btnSave, "Save", SaveGreen, Color.White);
            StyleButton(btnCancel, "Cancel", Color.White, TextDark);
            btnCancel.FlatAppearance.BorderSize = 1;
            btnCancel.FlatAppearance.BorderColor = Color.Silver;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnSave.Click += btnSave_Click;
            footer.Controls.Add(btnSave);     // first added = rightmost
            footer.Controls.Add(btnCancel);

            root.Controls.Add(header, 0, 0);
            root.Controls.Add(body, 0, 1);
            root.Controls.Add(footer, 0, 2);
            Controls.Add(root);

            AcceptButton = btnSave;    // Enter = Save
            CancelButton = btnCancel;  // Esc = Cancel

            ResumeLayout(false);
        }

        private static Control CreateInput(FormField field)
        {
            switch (field.Type)
            {
                case FieldType.Dropdown:
                    var cbo = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
                    if (field.Options != null) cbo.Items.AddRange(field.Options);
                    if (field.DefaultValue != null) SelectItem(cbo, field.DefaultValue);
                    return cbo;

                case FieldType.Date:
                    var dtp = new DateTimePicker
                    {
                        Format = DateTimePickerFormat.Custom,
                        CustomFormat = "MMM dd, yyyy",
                        // optional date: untick = no date (saves as NULL)
                        ShowCheckBox = !field.Required
                    };
                    if (field.DefaultValue is DateTime) dtp.Value = (DateTime)field.DefaultValue;
                    if (!field.Required) dtp.Checked = field.DefaultValue is DateTime;
                    return dtp;

                case FieldType.Money:
                    var money = new NumericUpDown
                    {
                        DecimalPlaces = 2,
                        Minimum = 0,
                        Maximum = 10000000,
                        Increment = 500,
                        ThousandsSeparator = true
                    };
                    if (field.DefaultValue != null) SetNumeric(money, Convert.ToDecimal(field.DefaultValue));
                    return money;

                case FieldType.Number:
                    var number = new NumericUpDown { DecimalPlaces = 0, Minimum = 0, Maximum = 100000 };
                    if (field.DefaultValue != null) SetNumeric(number, Convert.ToDecimal(field.DefaultValue));
                    return number;

                case FieldType.Phone:
                    var phone = new TextBox { MaxLength = 11 };
                    phone.KeyPress += PhoneKeyPress;          // digits only
                    if (field.DefaultValue != null) phone.Text = field.DefaultValue.ToString();
                    return phone;

                case FieldType.LongText:
                    var longText = new TextBox
                    {
                        Multiline = true,
                        ScrollBars = ScrollBars.Vertical,
                        MaxLength = field.MaxLength > 0 ? field.MaxLength : 255
                    };
                    if (field.DefaultValue != null) longText.Text = field.DefaultValue.ToString();
                    return longText;

                default:
                    var text = new TextBox { MaxLength = field.MaxLength > 0 ? field.MaxLength : 100 };
                    if (field.DefaultValue != null) text.Text = field.DefaultValue.ToString();
                    return text;
            }
        }

        private static void PhoneKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private static void AddRow(TableLayoutPanel table, FormField field, Control input)
        {
            bool tall = field.Type == FieldType.LongText;
            int row = table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, RowFor(field)));

            var label = new Label
            {
                Text = field.Label + (field.Required ? "" : " (optional)"),
                AutoSize = false,
                Height = tall ? 40 : 30,
                Dock = tall ? DockStyle.Top : DockStyle.Fill,
                TextAlign = tall ? ContentAlignment.TopLeft : ContentAlignment.MiddleLeft,
                ForeColor = TextDark,
                Margin = tall ? new Padding(3, 12, 3, 0) : new Padding(3, 0, 3, 0)
            };

            if (tall)
            {
                input.Dock = DockStyle.Fill;
                input.Margin = new Padding(3, 6, 3, 6);
            }
            else
            {
                input.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            }

            table.Controls.Add(label, 0, row);
            table.Controls.Add(input, 1, row);
        }

        private static void StyleButton(Button b, string text, Color back, Color fore)
        {
            b.Text = text;
            b.Size = new Size(110, 38);
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = back;
            b.ForeColor = fore;
            b.Cursor = Cursors.Hand;
            b.Margin = new Padding(8, 0, 0, 0);
        }

        // ---------- Behavior ----------
        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (var field in fields)
            {
                var input = inputs[field.Key];
                if (!input.Enabled) continue;                       // read-only fields are not checked

                bool isText = field.Type == FieldType.Text || field.Type == FieldType.LongText
                              || field.Type == FieldType.Phone;
                string text = isText ? input.Text.Trim() : null;

                if (field.Required)
                {
                    if (isText && text.Length == 0)
                    { Warn(field.Label + " is required.", input); return; }

                    if (field.Type == FieldType.Dropdown && ((ComboBox)input).SelectedIndex < 0)
                    { Warn("Please choose a value for " + field.Label.ToLower() + ".", input); return; }

                    if (field.Type == FieldType.Money && ((NumericUpDown)input).Value <= 0)
                    { Warn(field.Label + " must be greater than zero.", input); return; }
                }

                if (field.Type == FieldType.Phone && !string.IsNullOrEmpty(text) && !PhonePattern.IsMatch(text))
                { Warn("Enter an 11-digit mobile number starting with 09, for example 09171234567.", input); return; }
            }

            if (Validator != null)
            {
                string error = Validator(Values);
                if (!string.IsNullOrEmpty(error)) { Warn(error, null); return; }
            }

            DialogResult = DialogResult.OK;   // closes the form
        }

        private void Warn(string message, Control focusTarget)
        {
            MessageBox.Show(this, message, "Please check your input",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (focusTarget != null) focusTarget.Focus();
        }

        private static void SetNumeric(NumericUpDown n, decimal value)
        {
            n.Value = Math.Max(n.Minimum, Math.Min(n.Maximum, value));
        }

        /// <summary>Select by database id (ComboItem), or by text.</summary>
        private static void SelectItem(ComboBox cbo, object value)
        {
            if (value == null) { cbo.SelectedIndex = -1; return; }

            bool isNumber = value is int || value is long || value is short;

            for (int i = 0; i < cbo.Items.Count; i++)
            {
                var item = cbo.Items[i] as ComboItem;
                if (item != null && isNumber && item.Id.HasValue && item.Id.Value == Convert.ToInt32(value))
                { cbo.SelectedIndex = i; return; }

                if (string.Equals(cbo.Items[i].ToString(), value.ToString(), StringComparison.Ordinal))
                { cbo.SelectedIndex = i; return; }
            }

            // a plain-text value that is not in the list yet
            if (!isNumber && !string.IsNullOrWhiteSpace(value.ToString()))
                cbo.SelectedIndex = cbo.Items.Add(value.ToString());
        }
    }
}