using MySql.Data.MySqlClient;
using PMS_v1.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace PMS_v1.Pages
{
    public partial class LeasingModule : UserControl
    {
        public LeasingModule()
        {
            InitializeComponent();
            PMS_v1.UserControls.ModulePageLayout.ApplyStandardLayout(
                tlpMainSkeleton, pnlHeaderBlock, tlpMetricsRow, pnlCommandActionRow, roundedPanelTable);
            ConfigureLeaseGrid();
            LayoutCommandActionRow();
            pnlCommandActionRow.Resize += (_, _) => LayoutCommandActionRow();
            dgvLeases.CellPainting += DgvLeases_CellPainting;
            LoadStats();
        }

        private void LeasingModule_Load(object sender, EventArgs e)
        {
            
        }
        private void btnNewLease_Click(object sender, EventArgs e)
        {

        }

        private void ConfigureLeaseGrid()
        {
            cmbFilterDropdown.Text = "Filter";
            btnNewLease.Values.Text = "＋  New Lease";

            dgvLeases.AutoGenerateColumns = false;
            dgvLeases.AllowUserToAddRows = false;
            dgvLeases.AllowUserToDeleteRows = false;
            dgvLeases.AllowUserToResizeRows = false;
            dgvLeases.MultiSelect = false;
            dgvLeases.ReadOnly = true;
            dgvLeases.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLeases.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvLeases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvLeases.EnableHeadersVisualStyles = false;
            dgvLeases.RowTemplate.Height = 42;
            dgvLeases.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(74, 151, 196),
                ForeColor = Color.White,
                Font = new Font("Century Gothic", 9F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(74, 151, 196),
                SelectionForeColor = Color.White
            };
            dgvLeases.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(44, 49, 53),
                Font = new Font("Century Gothic", 9F),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(12, 0, 8, 0),
                SelectionBackColor = Color.White,
                SelectionForeColor = Color.FromArgb(44, 49, 53)
            };
            dgvLeases.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                SelectionBackColor = Color.White,
                SelectionForeColor = Color.FromArgb(44, 49, 53)
            };

            dgvLeases.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Tenant",
                HeaderText = "TENANT",
                FillWeight = 38,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvLeases.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Unit",
                HeaderText = "UNIT",
                FillWeight = 18,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvLeases.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "LeaseEnds",
                HeaderText = "LEASE ENDS",
                FillWeight = 27,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvLeases.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "STATUS",
                FillWeight = 17,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Padding = new Padding(4, 0, 4, 0)
                }
            });
        }

        private void LayoutCommandActionRow()
        {
            PMS_v1.UserControls.ModulePageLayout.LayoutActions(
                pnlCommandActionRow, txtSearchInput, cmbFilterDropdown, btnNewLease);
        }

        private void DgvLeases_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvLeases.Columns["Status"].Index)
                return;

            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

            string status = Convert.ToString(e.FormattedValue) ?? string.Empty;
            Font font = e.CellStyle.Font ?? dgvLeases.Font;
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

        //Load statcards
        private void LoadStats()
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string query = @"
                               SELECT
                                    COUNT(CASE WHEN STATUS = 'Active' THEN 1 END) AS Active,
                                    COUNT(CASE WHEN STATUS = 'Pending' THEN 1 END) AS Pending,
                                    COUNT(CASE WHEN STATUS = 'Expired' THEN 1 END) AS Expired,
                                    COUNT(CASE WHEN STATUS = 'Terminated' THEN 1 END) AS Terminate
                               FROM lease";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        statCardActive.CardNumber = reader["Active"].ToString();
                        statCardPending.CardNumber = reader["Pending"].ToString();
                        statCardExpired.CardNumber = reader["Expired"].ToString();
                        statCardTerminated.CardNumber = reader["Terminate"].ToString();
                    }
                }
            }
        }
    }
}
