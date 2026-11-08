using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PMS_v1.Pages
{
    public partial class PaymentModule : UserControl
    {
        public PaymentModule()
        {
            InitializeComponent();
            statCardRefunded.CardIcon = CreateRefundIcon();
            ConfigurePaymentGrid();
            PopulateSampleRows();
            LayoutActionRow();
            pnlActions.Resize += (_, _) => LayoutActionRow();
            dgvPayments.CellPainting += DgvPayments_CellPainting;
        }

        private void ConfigurePaymentGrid()
        {
            txtSearch.Text = "⌕  Search transaction...";
            cmbFilter.Text = "Filter";
            btnNewTransaction.Values.Text = "＋  New Transaction";

            statCardCompleted.CardCaption = "Completed";
            statCardCompleted.CardNumber = "12";
            statCardPending.CardCaption = "Pending";
            statCardPending.CardNumber = "22";
            statCardFailed.CardCaption = "Failed";
            statCardFailed.CardNumber = "5";
            statCardRefunded.CardCaption = "Refunded";
            statCardRefunded.CardNumber = "0";

            dgvPayments.AutoGenerateColumns = false;
            dgvPayments.AllowUserToAddRows = false;
            dgvPayments.AllowUserToDeleteRows = false;
            dgvPayments.AllowUserToResizeRows = false;
            dgvPayments.MultiSelect = false;
            dgvPayments.ReadOnly = true;
            dgvPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPayments.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPayments.EnableHeadersVisualStyles = false;
            dgvPayments.RowTemplate.Height = 42;
            dgvPayments.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(74, 151, 196),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(74, 151, 196),
                SelectionForeColor = Color.White
            };
            dgvPayments.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(44, 49, 53),
                Font = new Font("Segoe UI", 9F),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(12, 0, 8, 0),
                SelectionBackColor = Color.White,
                SelectionForeColor = Color.FromArgb(44, 49, 53)
            };
            dgvPayments.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                SelectionBackColor = Color.White,
                SelectionForeColor = Color.FromArgb(44, 49, 53)
            };

            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Reference",
                HeaderText = "REFERENCE",
                FillWeight = 19,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Tenant",
                HeaderText = "TENANT",
                FillWeight = 43,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Amount",
                HeaderText = "AMOUNT",
                FillWeight = 18,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Padding = new Padding(8, 0, 14, 0)
                }
            });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "STATUS",
                FillWeight = 20,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Padding = new Padding(4, 0, 4, 0)
                }
            });
        }

        private void PopulateSampleRows()
        {
            dgvPayments.Rows.Add("PAY-001", "Sophia Leigh R. Manoguid", "5,000", "Completed");
            dgvPayments.Rows.Add("PAY-002", "Alexis N. Prado", "10,000", "Pending");
            dgvPayments.Rows.Add("PAY-003", "Shella Mith C. Belarmino", "6,356", "Failed");
            dgvPayments.Rows.Add("PAY-004", "Wyne Benjamin Constantino", "6,767", "Refunded");
        }

        private void LayoutActionRow()
        {
            const int gap = 14;
            int width = pnlActions.ClientSize.Width;
            int buttonWidth = Math.Min(210, Math.Max(140, (int)(width * 0.21)));
            int filterWidth = Math.Min(150, Math.Max(96, (int)(width * 0.16)));
            int searchWidth = Math.Max(120, width - buttonWidth - filterWidth - gap * 2);
            int top = Math.Max(0, (pnlActions.ClientSize.Height - 40) / 2);

            txtSearch.SetBounds(0, top + 3, searchWidth, 34);
            cmbFilter.SetBounds(searchWidth + gap, top + 3, filterWidth, 34);
            btnNewTransaction.SetBounds(searchWidth + gap * 2 + filterWidth, top, buttonWidth, 40);
        }

        private void DgvPayments_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvPayments.Columns["Status"].Index)
                return;

            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

            string status = Convert.ToString(e.FormattedValue) ?? string.Empty;
            Font font = e.CellStyle.Font ?? dgvPayments.Font;
            Size textSize = TextRenderer.MeasureText(status, font);
            int badgeWidth = Math.Min(e.CellBounds.Width - 8, textSize.Width + 14);
            int badgeHeight = Math.Min(24, e.CellBounds.Height - 8);
            var badgeBounds = new Rectangle(
                e.CellBounds.Left + (e.CellBounds.Width - badgeWidth) / 2,
                e.CellBounds.Top + (e.CellBounds.Height - badgeHeight) / 2,
                badgeWidth,
                badgeHeight);

            using (var badge = new SolidBrush(Color.FromArgb(218, 237, 248)))
                e.Graphics.FillRectangle(badge, badgeBounds);

            TextRenderer.DrawText(e.Graphics, status, font, badgeBounds,
                Color.FromArgb(45, 93, 120),
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
            e.Handled = true;
        }

        private static Bitmap CreateRefundIcon()
        {
            var icon = new Bitmap(48, 48);
            using Graphics graphics = Graphics.FromImage(icon);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var pen = new Pen(Color.FromArgb(74, 151, 196), 3.2F)
            {
                StartCap = LineCap.Flat,
                EndCap = LineCap.Triangle
            };

            graphics.DrawLine(pen, 8, 16, 39, 16);
            graphics.DrawLine(pen, 40, 32, 9, 32);
            return icon;
        }
    }
}
