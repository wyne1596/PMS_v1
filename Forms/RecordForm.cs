#nullable disable
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PMS_v1   // keep as PMS_v1 so every page can see it
{
    public enum FormMode { New, Edit }

    public enum FieldType { Text, Number, Money, Date, Dropdown }

    /// <summary>Describes one row of the form. Pages create a list of these.</summary>
    public class FormField
    {
        public string Key { get; set; }                     // short id, e.g. "amount"
        public string Label { get; set; }                   // text shown beside the input
        public FieldType Type { get; set; } = FieldType.Text;
        public string[] Options { get; set; }               // choices for Dropdown
        public bool Required { get; set; } = true;
        public object DefaultValue { get; set; }            // optional starting value
    }

    /// <summary>
    /// One reusable modal form for New / Edit on any page with a table.
    /// Design only: Save checks the required fields and closes with DialogResult.OK.
    /// Whoever builds the backend reads Values (or GetValue) after OK.
    /// </summary>
    public class RecordForm : Form
    {
        // ---------- Look: change these to match your app ----------
        private static readonly Color HeaderBlue = Color.FromArgb(72, 149, 199);
        private static readonly Color SaveGreen = Color.FromArgb(106, 168, 35);
        private static readonly Color FooterGray = Color.FromArgb(244, 245, 246);
        private static readonly Color TextDark = Color.FromArgb(40, 40, 40);
        private const string FontName = "Segoe UI";   // put your app's font here

        private readonly List<FormField> fields;
        private readonly Dictionary<string, Control> inputs = new Dictionary<string, Control>();
        private readonly Button btnSave = new Button();
        private readonly Button btnCancel = new Button();

        public FormMode Mode { get; }

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

        /// <summary>Text fields give string, Number and Money give decimal, Date gives DateTime, Dropdown gives string (null if none chosen).</summary>
        public object GetValue(string key)
        {
            Control c;
            if (!inputs.TryGetValue(key, out c)) return null;

            if (c is TextBox) return c.Text.Trim();
            if (c is NumericUpDown) return ((NumericUpDown)c).Value;
            if (c is DateTimePicker) return ((DateTimePicker)c).Value.Date;

            var cbo = c as ComboBox;
            return cbo != null ? cbo.SelectedItem : null;
        }

        /// <summary>Prefill one field (used for Edit).</summary>
        public void SetValue(string key, object value)
        {
            Control c;
            if (value == null || !inputs.TryGetValue(key, out c)) return;

            if (c is TextBox) c.Text = value.ToString();
            else if (c is NumericUpDown) SetNumeric((NumericUpDown)c, Convert.ToDecimal(value));
            else if (c is DateTimePicker) ((DateTimePicker)c).Value = Convert.ToDateTime(value);
            else if (c is ComboBox) SelectItem((ComboBox)c, value.ToString());
        }

        /// <summary>Prefill several fields at once (used for Edit).</summary>
        public void SetValues(IDictionary<string, object> values)
        {
            foreach (var pair in values)
                SetValue(pair.Key, pair.Value);
        }

        /// <summary>Replace a dropdown's choices later, for example with real tenants from the database.</summary>
        public void SetOptions(string key, IEnumerable<string> options)
        {
            Control c;
            var cbo = inputs.TryGetValue(key, out c) ? c as ComboBox : null;
            if (cbo == null) return;

            cbo.Items.Clear();
            foreach (var option in options)
                cbo.Items.Add(option);
        }

        // ---------- UI construction ----------
        private void BuildUi(string entityName)
        {
            Text = (Mode == FormMode.New ? "New " : "Edit ") + entityName;
            Font = new Font(FontName, 10F);
            BackColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            ClientSize = new Size(440, 56 + 12 + fields.Count * 46 + 16 + 64);   // grows with the number of fields

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
            body.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
            body.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            foreach (var field in fields)
            {
                var input = CreateInput(field);
                inputs[field.Key] = input;
                AddRow(body, field.Label, input);
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
        }

        private static Control CreateInput(FormField field)
        {
            switch (field.Type)
            {
                case FieldType.Dropdown:
                    var cbo = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
                    if (field.Options != null) cbo.Items.AddRange(field.Options);
                    if (field.DefaultValue != null) SelectItem(cbo, field.DefaultValue.ToString());
                    return cbo;

                case FieldType.Date:
                    var dtp = new DateTimePicker
                    {
                        Format = DateTimePickerFormat.Custom,
                        CustomFormat = "MMM dd, yyyy"
                    };
                    if (field.DefaultValue is DateTime) dtp.Value = (DateTime)field.DefaultValue;
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

                default:
                    var text = new TextBox { MaxLength = 100 };
                    if (field.DefaultValue != null) text.Text = field.DefaultValue.ToString();
                    return text;
            }
        }

        private static void AddRow(TableLayoutPanel table, string labelText, Control input)
        {
            int row = table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 46));

            var label = new Label
            {
                Text = labelText,
                AutoSize = true,
                Anchor = AnchorStyles.Left,
                ForeColor = TextDark
            };
            input.Anchor = AnchorStyles.Left | AnchorStyles.Right;

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
            // only checks required fields; business rules belong to the backend
            foreach (var field in fields)
            {
                if (!field.Required) continue;
                var input = inputs[field.Key];

                if (field.Type == FieldType.Text && string.IsNullOrWhiteSpace(input.Text))
                { Warn(field.Label + " is required.", input); return; }

                if (field.Type == FieldType.Dropdown && ((ComboBox)input).SelectedIndex < 0)
                { Warn("Please choose a value for " + field.Label.ToLower() + ".", input); return; }

                if (field.Type == FieldType.Money && ((NumericUpDown)input).Value <= 0)
                { Warn(field.Label + " must be greater than zero.", input); return; }
            }

            DialogResult = DialogResult.OK;   // closes the form
        }

        private void Warn(string message, Control focusTarget)
        {
            MessageBox.Show(this, message, "Please check your input",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            focusTarget.Focus();
        }

        private static void SetNumeric(NumericUpDown n, decimal value)
        {
            n.Value = Math.Max(n.Minimum, Math.Min(n.Maximum, value));
        }

        private static void SelectItem(ComboBox cbo, string value)
        {
            int index = cbo.FindStringExact(value ?? "");
            if (index < 0 && !string.IsNullOrWhiteSpace(value))
                index = cbo.Items.Add(value);   // value isn't in the list yet
            cbo.SelectedIndex = index;
        }
    }
}