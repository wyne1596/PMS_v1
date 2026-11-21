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
            PMS_v1.UserControls.ModulePageLayout.FitGridToRoundedPanel(roundedPanelTable, dgvLeases);
            ConfigureLeaseGrid();
            PMS_v1.UserControls.GridHelper.ShowSelection(dgvLeases);
            LayoutCommandActionRow();
            pnlCommandActionRow.Resize += (_, _) => LayoutCommandActionRow();
            dgvLeases.CellPainting += DgvLeases_CellPainting;
            txtSearchInput.TextChanged += (_, _) => ApplyLeaseFilters();
            cmbFilterDropdown.SelectedIndexChanged += (_, _) => ApplyLeaseFilters();
            LoadStats();
            LoadLease();
        }

        private void LeasingModule_Load(object sender, EventArgs e)
        {

        }
        private void btnNewLease_Click(object sender, EventArgs e)
        {

        }

        private void ConfigureLeaseGrid()
        {
            cmbFilterDropdown.Items.AddRange(new object[] { "All Statuses", "Active", "Pending", "Expired", "Terminated" });
            cmbFilterDropdown.SelectedIndex = 0;
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

        private void ApplyLeaseFilters()
        {
            string search = txtSearchInput.Text.Trim();
            string status = cmbFilterDropdown.SelectedIndex <= 0 ? string.Empty : cmbFilterDropdown.Text;

            PMS_v1.UserControls.GridHelper.Filter(dgvLeases, row =>
            {
                bool matchesSearch = string.IsNullOrEmpty(search) ||
                    PMS_v1.UserControls.GridHelper.Has(row, "Tenant", search) || PMS_v1.UserControls.GridHelper.Has(row, "Unit", search) ||
                    PMS_v1.UserControls.GridHelper.Has(row, "LeaseEnds", search) || PMS_v1.UserControls.GridHelper.Has(row, "Status", search);
                bool matchesStatus = string.IsNullOrEmpty(status) ||
                    string.Equals(row.Cells["Status"].Value?.ToString(), status, StringComparison.OrdinalIgnoreCase);
                return matchesSearch && matchesStatus;
            });
        }

        private void LayoutCommandActionRow()
        {
            PMS_v1.UserControls.ActionRowLayout.PackRight(
                pnlCommandActionRow, txtSearchInput, cmbFilterDropdown, btnNewLease);
        }

        private void DgvLeases_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            PMS_v1.UserControls.StatusBadge.Paint(dgvLeases, e, "Status");
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

        private void LoadLease()
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string query = @"
                               SELECT
                                    CONCAT(r.FIRST_NAME, ' ', r.LAST_NAME) AS Tenant,
                                    l.LEASE_ID,
                                    u.UNIT_NO,
                                    l.END_DATE AS LeaseEnds, l.STATUS
                               FROM lease l
                               LEFT JOIN resident r ON l.RESIDENT_ID = r.RESIDENT_ID
                               LEFT JOIN units u ON l.UNIT_ID = u.UNIT_ID
                               ORDER BY l.END_DATE DESC";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    dgvLeases.Rows.Clear();

                    while (reader.Read())
                    {
                        string status = reader["STATUS"].ToString() ?? string.Empty;

                        int rowIndex = dgvLeases.Rows.Add(
                            reader["Tenant"].ToString(),
                            reader["UNIT_NO"].ToString(),
                            Convert.ToDateTime(reader["LeaseEnds"]).ToString("MMM dd, yyyy"),
                            status);

                        dgvLeases.Rows[rowIndex].Tag = Convert.ToInt32(reader["LEASE_ID"]);
                    }
                }
            }

            ApplyLeaseFilters();
        }

        private void btnNewLease_Click_1(object sender, EventArgs e)
        {
            using (var f = new RecordForm(FormMode.New, "Lease", FormDefinitions.Lease()))
            {
                f.Validator = FormDefinitions.ValidateLease;
                f.SetOptions("unit", Lookups.VacantUnits());       // a list of new ComboItem(unitId, "Unit 101")
                f.SetOptions("resident", Lookups.Residents());
                if (f.ShowDialog(FindForm()) == DialogResult.OK)
                {
                    int unitId = (int)f.Values["unit"];
                    // INSERT with @parameters here
                }
            }
        }
    }
}