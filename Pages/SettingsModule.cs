using MySql.Data.MySqlClient;
using PMS_v1.Database;
using PMS_v1.Helper;
using PMS_v1.UserControls;
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PMS_v1.Pages
{
    /// <summary>
    /// Settings (admins full access; managers can view and add employees only). Left half: personnel table + system admins list.
    /// Right half: add / edit an employee and manage that employee's system account.
    /// </summary>
    public partial class SettingsModule : UserControl
    {
        private const int MinPassLen = 6;     // same rule as the Sign Up form

        private static readonly string[] EmploymentStatuses = { "Active", "On Leave", "Resigned", "Terminated" };
        private static readonly string[] Roles = { "Admin", "Manager", "Staff" };
        private static readonly string[] AccountStatuses = { "Active", "Inactive", "Suspended", "Locked" };

        private int? _personnelId;      // null = the editor is adding a new employee
        private int? _userId;           // null = the selected employee has no account
        private string _loadedUsername = "";
        private bool _loading;          // true while code (not the user) changes the grid selection

        public SettingsModule()
        {
            InitializeComponent();

            // Admins and managers only. The menu hides the button and Main refuses the page too; this is the last guard.
            if (!Session.CanOpenSettings) { tlpMain.Enabled = false; return; }

            ModulePageLayout.ApplyStandardGridStyle(dgvPersonnel);
            ModulePageLayout.ApplyStandardGridStyle(dgvAdmins);
            ConfigureGrids();

            cmbFilter.Items.AddRange(new object[] { "All Personnel", "With Account", "No Account", "System Admins" });
            cmbFilter.SelectedIndex = 0;
            cmbEmploymentStatus.Items.AddRange(EmploymentStatuses);
            cmbRole.Items.AddRange(Roles);
            cmbAccountStatus.Items.AddRange(AccountStatuses);

            txtSearch.TextChanged += (_, _) => ApplyFilters();
            cmbFilter.SelectedIndexChanged += (_, _) => ApplyFilters();
            dgvPersonnel.SelectionChanged += DgvPersonnel_SelectionChanged;
            dgvPersonnel.CellPainting += (_, e) =>
            {
                StatusBadge.Paint(dgvPersonnel, e, "Employment");
                StatusBadge.Paint(dgvPersonnel, e, "Account", s => s == "None" ? "No account" : s);
            };
            StatusBadge.Attach(dgvAdmins, "Status");
            dgvAdmins.CellClick += (_, e) =>
            {
                // clicking an admin opens that person in the editor
                if (e.RowIndex >= 0 && dgvAdmins.Rows[e.RowIndex].Tag is int id)
                {
                    _personnelId = id;
                    RefreshGrids();
                    LoadEditor(id);
                }
            };

            ClearEditor();
        }

        // refresh every time the page is opened (Main keeps the page alive between visits)
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible && Session.CanOpenSettings && dgvPersonnel.Columns.Count > 0)
                RefreshGrids();
        }

        // ---------- grids ----------
        private void ConfigureGrids()
        {
            AddColumn(dgvPersonnel, "EmpNo", "EMPLOYEE NO.", 17);
            AddColumn(dgvPersonnel, "Name", "NAME", 27);
            AddColumn(dgvPersonnel, "Position", "POSITION", 18);
            AddColumn(dgvPersonnel, "Employment", "EMPLOYMENT", 19, DataGridViewContentAlignment.MiddleCenter);
            AddColumn(dgvPersonnel, "Account", "ACCOUNT", 19, DataGridViewContentAlignment.MiddleCenter);
            AddColumn(dgvPersonnel, "Role", "ROLE", 10);
            dgvPersonnel.Columns["Role"].Visible = false;       // only used by the "System Admins" filter

            AddColumn(dgvAdmins, "EmpNo", "EMPLOYEE NO.", 18);
            AddColumn(dgvAdmins, "Name", "NAME", 26);
            AddColumn(dgvAdmins, "Username", "USERNAME", 20);
            AddColumn(dgvAdmins, "Status", "STATUS", 16, DataGridViewContentAlignment.MiddleCenter);
            AddColumn(dgvAdmins, "LastLogin", "LAST LOGIN", 20);
        }

        private static void AddColumn(DataGridView grid, string name, string header, float weight,
            DataGridViewContentAlignment align = DataGridViewContentAlignment.MiddleLeft)
        {
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                FillWeight = weight,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = align }
            });
        }

        private void RefreshGrids()
        {
            LoadPersonnel();
            LoadAdmins();
        }

        private void LoadPersonnel()
        {
            const string sql = @"
                SELECT p.PERSONNEL_ID, p.EMPLOYEE_NO, p.FIRST_NAME, p.LAST_NAME, p.POSITION,
                       p.EMPLOYMENT_STATUS, u.USER_ID, u.ROLE, u.ACCOUNT_STATUS
                FROM personnel p
                LEFT JOIN `system_user` u ON u.PERSONNEL_ID = p.PERSONNEL_ID
                ORDER BY p.LAST_NAME, p.FIRST_NAME";

            _loading = true;
            try
            {
                using (var conn = Db.GetConnection())
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    conn.Open();
                    using (var r = cmd.ExecuteReader())
                    {
                        dgvPersonnel.Rows.Clear();
                        while (r.Read())
                        {
                            bool hasAccount = !(r["USER_ID"] is DBNull);
                            int i = dgvPersonnel.Rows.Add(
                                r["EMPLOYEE_NO"],
                                r["FIRST_NAME"] + " " + r["LAST_NAME"],
                                Show(r["POSITION"]),
                                Convert.ToString(r["EMPLOYMENT_STATUS"]),
                                hasAccount ? Convert.ToString(r["ACCOUNT_STATUS"]) : "None",
                                hasAccount ? Convert.ToString(r["ROLE"]) : "");
                            dgvPersonnel.Rows[i].Tag = Convert.ToInt32(r["PERSONNEL_ID"]);
                        }
                    }
                }
            }
            finally { _loading = false; }

            ApplyFilters();
        }

        private void LoadAdmins()
        {
            const string sql = @"
                SELECT p.PERSONNEL_ID, p.EMPLOYEE_NO, p.FIRST_NAME, p.LAST_NAME,
                       u.USERNAME, u.ACCOUNT_STATUS, u.LAST_LOGIN
                FROM `system_user` u
                JOIN personnel p ON p.PERSONNEL_ID = u.PERSONNEL_ID
                WHERE u.ROLE = 'Admin'
                ORDER BY p.LAST_NAME, p.FIRST_NAME";

            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    dgvAdmins.Rows.Clear();
                    while (r.Read())
                    {
                        int i = dgvAdmins.Rows.Add(
                            r["EMPLOYEE_NO"],
                            r["FIRST_NAME"] + " " + r["LAST_NAME"],
                            r["USERNAME"],
                            Convert.ToString(r["ACCOUNT_STATUS"]),
                            r["LAST_LOGIN"] is DateTime d ? d.ToString("MMM dd, yyyy h:mm tt") : "Never");
                        dgvAdmins.Rows[i].Tag = Convert.ToInt32(r["PERSONNEL_ID"]);
                    }
                }
            }
            dgvAdmins.ClearSelection();
        }

        private void ApplyFilters()
        {
            string search = txtSearch.Text.Trim();
            int filter = cmbFilter.SelectedIndex;      // 0 all, 1 with account, 2 no account, 3 admins

            _loading = true;
            try
            {
                GridHelper.Filter(dgvPersonnel, row =>
                {
                    bool matchesSearch = string.IsNullOrEmpty(search) ||
                        GridHelper.Has(row, "EmpNo", search) ||
                        GridHelper.Has(row, "Name", search) ||
                        GridHelper.Has(row, "Position", search);

                    string account = row.Cells["Account"].Value?.ToString() ?? "None";
                    string role = row.Cells["Role"].Value?.ToString() ?? "";
                    bool matchesFilter = filter <= 0 ||
                        (filter == 1 && account != "None") ||
                        (filter == 2 && account == "None") ||
                        (filter == 3 && role == "Admin");

                    return matchesSearch && matchesFilter;
                });

                // keep the employee being edited highlighted
                if (_personnelId is int id)
                    foreach (DataGridViewRow row in dgvPersonnel.Rows)
                        if (row.Visible && row.Tag is int rid && rid == id)
                        {
                            dgvPersonnel.CurrentCell = row.Cells[0];
                            break;
                        }
            }
            finally { _loading = false; }
        }

        private void DgvPersonnel_SelectionChanged(object? sender, EventArgs e)
        {
            if (_loading) return;
            if (dgvPersonnel.CurrentRow?.Tag is int id && id != _personnelId)
                LoadEditor(id);
        }

        // ---------- editor ----------
        private void ClearEditor()
        {
            _personnelId = null;
            _userId = null;
            _loadedUsername = "";

            _loading = true;
            dgvPersonnel.CurrentCell = null;
            dgvPersonnel.ClearSelection();
            _loading = false;

            lblEmployeeTitle.Text = "New Employee";
            txtEmployeeNo.Text = GenerateEmployeeNo();
            btnGenerate.Enabled = true;
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPosition.Clear();
            txtContact.Clear();
            txtEmail.Clear();
            cmbEmploymentStatus.SelectedItem = "Active";
            btnSaveEmployee.Values.Text = "Add Employee";
            tlpEmployee.Enabled = true;                    // admins and managers can both add
            btnSaveEmployee.Enabled = true;
            flpEmployeeButtons.Enabled = true;

            ShowAccount(null);
            txtFirstName.Focus();
        }

        private void LoadEditor(int personnelId)
        {
            const string sql = @"
                SELECT p.EMPLOYEE_NO, p.FIRST_NAME, p.LAST_NAME, p.POSITION, p.CONTACT_NO, p.EMAIL,
                       p.EMPLOYMENT_STATUS, u.USER_ID, u.USERNAME, u.ROLE, u.ACCOUNT_STATUS, u.LAST_LOGIN
                FROM personnel p
                LEFT JOIN `system_user` u ON u.PERSONNEL_ID = p.PERSONNEL_ID
                WHERE p.PERSONNEL_ID = @id";

            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", personnelId);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read())      // deleted elsewhere
                    {
                        r.Close();
                        ClearEditor();
                        RefreshGrids();
                        return;
                    }

                    _personnelId = personnelId;
                    lblEmployeeTitle.Text = "Edit Employee";
                    txtEmployeeNo.Text = Convert.ToString(r["EMPLOYEE_NO"]);
                    btnGenerate.Enabled = false;                   // an existing employee keeps their number
                    txtFirstName.Text = Str(r["FIRST_NAME"]);
                    txtLastName.Text = Str(r["LAST_NAME"]);
                    txtPosition.Text = Str(r["POSITION"]);
                    txtContact.Text = Str(r["CONTACT_NO"]);
                    txtEmail.Text = Str(r["EMAIL"]);
                    cmbEmploymentStatus.SelectedItem = Convert.ToString(r["EMPLOYMENT_STATUS"]);
                    btnSaveEmployee.Values.Text = "Save Changes";
                    btnGenerate.Enabled = false;
                    tlpEmployee.Enabled = Session.IsAdmin;         // managers can view existing employees, not edit them
                    flpEmployeeButtons.Enabled = true;             // keeps "New" usable; Save is blocked below for managers
                    btnSaveEmployee.Enabled = Session.IsAdmin;

                    ShowAccount(r["USER_ID"] is DBNull ? null : new AccountInfo
                    {
                        UserId = Convert.ToInt32(r["USER_ID"]),
                        Username = Convert.ToString(r["USERNAME"]) ?? "",
                        Role = Convert.ToString(r["ROLE"]) ?? "Staff",
                        Status = Convert.ToString(r["ACCOUNT_STATUS"]) ?? "Active",
                        LastLogin = r["LAST_LOGIN"] as DateTime?
                    });
                }
            }
        }

        private sealed class AccountInfo
        {
            public int UserId;
            public string Username = "";
            public string Role = "Staff";
            public string Status = "Active";
            public DateTime? LastLogin;
        }

        private void ShowAccount(AccountInfo? a)
        {
            _userId = a?.UserId;
            _loadedUsername = a?.Username ?? "";

            txtUsername.Text = a?.Username ?? "";
            cmbRole.SelectedItem = a?.Role;
            cmbAccountStatus.SelectedItem = a?.Status;
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
            lblLastLogin.Text = a == null ? "—" : a.LastLogin is DateTime d ? d.ToString("MMM dd, yyyy h:mm tt") : "Never";

            bool has = a != null;
            tlpAccount.Enabled = has && Session.IsAdmin;       // managers can't edit accounts
            flpAccountButtons.Enabled = has && Session.IsAdmin;
            lblAccountHint.Text = has
                ? (Session.IsAdmin ? "Leave the password blank to keep the current one." : "Only administrators can change accounts.")
                : _personnelId == null
                    ? "Save the employee first. They can then create their own account on the Sign Up screen using their Employee No. and last name."
                    : "This employee has no account yet. They can create one on the Sign Up screen using their Employee No. and last name.";
        }

        // ---------- random employee number ----------
        // Format YYYY-NNNNN (same as the existing records and the Sign Up check), unique in the personnel table.
        private static string GenerateEmployeeNo()
        {
            string Make() => $"{DateTime.Now.Year}-{RandomNumberGenerator.GetInt32(0, 100000):D5}";

            try
            {
                using (var conn = Db.GetConnection())
                using (var cmd = new MySqlCommand("SELECT 1 FROM personnel WHERE EMPLOYEE_NO = @no LIMIT 1", conn))
                {
                    var p = cmd.Parameters.Add("@no", MySqlDbType.VarChar, 20);
                    conn.Open();
                    for (int i = 0; i < 25; i++)
                    {
                        string no = Make();
                        p.Value = no;
                        if (cmd.ExecuteScalar() == null) return no;
                    }
                }
            }
            catch (MySqlException) { /* the unique key still protects the insert; Save retries */ }

            return Make();
        }

        private void btnGenerate_Click(object? sender, EventArgs e)
        {
            if (_personnelId == null) txtEmployeeNo.Text = GenerateEmployeeNo();
        }

        private void btnNewEmployee_Click(object? sender, EventArgs e) => ClearEditor();

        // ---------- save employee ----------
        private void btnSaveEmployee_Click(object? sender, EventArgs e)
        {
            string first = txtFirstName.Text.Trim();
            string last = txtLastName.Text.Trim();
            string position = txtPosition.Text.Trim();
            string contact = txtContact.Text.Trim();
            string email = txtEmail.Text.Trim();
            string status = cmbEmploymentStatus.Text;

            if (_personnelId != null && !Session.IsAdmin) return;   // managers can add, not edit

            string? error =
                first.Length == 0 || last.Length == 0 ? "First name and last name are required." :
                first.Length > 45 || last.Length > 45 || position.Length > 45 ? "Names and position can be at most 45 characters." :
                contact.Length > 0 && !Regex.IsMatch(contact, @"^[0-9+\-\s()]{7,20}$") ? "Contact No. looks like 09123456789." :
                email.Length > 0 && (email.Length > 100 || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) ? "Enter a valid email address." :
                string.IsNullOrEmpty(status) ? "Choose an employment status." : null;

            if (error != null) { MessageBox.Show(this, error, "Check the form"); return; }

            bool isNew = _personnelId == null;

            for (int attempt = 0; attempt < 3; attempt++)
            {
                try
                {
                    int id;
                    using (var conn = Db.GetConnection())
                    using (var cmd = new MySqlCommand(isNew
                        ? "INSERT INTO personnel (EMPLOYEE_NO, FIRST_NAME, LAST_NAME, POSITION, CONTACT_NO, EMAIL, EMPLOYMENT_STATUS) " +
                          "VALUES (@no, @first, @last, @pos, @contact, @email, @status)"
                        : "UPDATE personnel SET FIRST_NAME=@first, LAST_NAME=@last, POSITION=@pos, CONTACT_NO=@contact, " +
                          "EMAIL=@email, EMPLOYMENT_STATUS=@status WHERE PERSONNEL_ID=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@first", first);
                        cmd.Parameters.AddWithValue("@last", last);
                        cmd.Parameters.AddWithValue("@pos", NullIfEmpty(position));
                        cmd.Parameters.AddWithValue("@contact", NullIfEmpty(contact));
                        cmd.Parameters.AddWithValue("@email", NullIfEmpty(email));
                        cmd.Parameters.AddWithValue("@status", status);
                        if (isNew) cmd.Parameters.AddWithValue("@no", txtEmployeeNo.Text);
                        else cmd.Parameters.AddWithValue("@id", _personnelId!.Value);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        id = isNew ? (int)cmd.LastInsertedId : _personnelId!.Value;
                    }

                    _personnelId = id;
                    RefreshGrids();
                    LoadEditor(id);

                    if (isNew)
                        MessageBox.Show(this, $"Employee added.\nEmployee No.: {txtEmployeeNo.Text}", "Employee added");
                    return;
                }
                catch (MySqlException ex) when (ex.Number == 1062 && ex.Message.Contains("uq_personnel_email"))
                {
                    MessageBox.Show(this, "That email is already used by another employee.");
                    return;
                }
                catch (MySqlException ex) when (ex.Number == 1062 && isNew)
                {
                    txtEmployeeNo.Text = GenerateEmployeeNo();      // number was taken a moment ago: draw another
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message);
                    return;
                }
            }

            MessageBox.Show(this, "Couldn't generate a free employee number. Please try again.");
        }

        // ---------- save account ----------
        private void btnSaveAccount_Click(object? sender, EventArgs e)
        {
            if (!Session.IsAdmin || _userId is not int userId) return;

            string username = txtUsername.Text.Trim();
            string role = cmbRole.Text;
            string status = cmbAccountStatus.Text;
            string password = txtNewPassword.Text;

            string? error =
                !Regex.IsMatch(username, @"^[A-Za-z0-9_]{4,20}$") ? "Username must be 4-20 letters, numbers, or underscores." :
                string.IsNullOrEmpty(role) || string.IsNullOrEmpty(status) ? "Choose a role and an account status." :
                password.Length > 0 && password.Length < MinPassLen ? $"Password must be at least {MinPassLen} characters." :
                password != txtConfirmPassword.Text ? "Passwords do not match." : null;

            if (error != null) { MessageBox.Show(this, error, "Check the form"); return; }

            bool losesAdminAccess = role != "Admin" || status != "Active";
            if (userId == Session.UserId && losesAdminAccess)
            {
                MessageBox.Show(this, "You can't remove your own admin access or deactivate your own account.");
                return;
            }
            if (losesAdminAccess && IsLastActiveAdmin(userId))
            {
                MessageBox.Show(this, "This is the last active admin. Make another account an active admin first.");
                return;
            }

            try
            {
                using (var conn = Db.GetConnection())
                using (var cmd = new MySqlCommand(
                    "UPDATE `system_user` SET USERNAME=@user, ROLE=@role, ACCOUNT_STATUS=@status" +
                    (password.Length > 0 ? ", PASSWORD=@pass" : "") + " WHERE USER_ID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.Parameters.AddWithValue("@status", status);
                    if (password.Length > 0)
                        cmd.Parameters.AddWithValue("@pass", BCrypt.Net.BCrypt.HashPassword(password));
                    cmd.Parameters.AddWithValue("@id", userId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                int pid = _personnelId!.Value;
                RefreshGrids();
                LoadEditor(pid);
                MessageBox.Show(this, "Account updated.");
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                MessageBox.Show(this, "That username is already taken.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        // ---------- delete account ----------
        private void btnDeleteAccount_Click(object? sender, EventArgs e)
        {
            if (!Session.IsAdmin || _userId is not int userId) return;

            if (userId == Session.UserId)
            {
                MessageBox.Show(this, "You can't delete the account you are signed in with.");
                return;
            }
            if (IsLastActiveAdmin(userId))
            {
                MessageBox.Show(this, "This is the last active admin and can't be deleted.");
                return;
            }

            if (MessageBox.Show(this,
                    $"Delete the account \"{_loadedUsername}\"?\n\nThe employee record stays, and they can sign up for a new account later.",
                    "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                using (var conn = Db.GetConnection())
                using (var cmd = new MySqlCommand("DELETE FROM `system_user` WHERE USER_ID = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", userId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                int pid = _personnelId!.Value;
                RefreshGrids();
                LoadEditor(pid);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        // True when this account is an active admin and no other active admin exists.
        private static bool IsLastActiveAdmin(int userId)
        {
            const string sql = @"
                SELECT
                  (SELECT COUNT(*) FROM `system_user` WHERE USER_ID = @id AND ROLE = 'Admin' AND ACCOUNT_STATUS = 'Active'),
                  (SELECT COUNT(*) FROM `system_user` WHERE USER_ID <> @id AND ROLE = 'Admin' AND ACCOUNT_STATUS = 'Active')";

            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", userId);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    return r.Read() && Convert.ToInt32(r[0]) > 0 && Convert.ToInt32(r[1]) == 0;
            }
        }

        // ---------- small helpers ----------
        private static string Show(object value) =>
            value == null || value is DBNull || string.IsNullOrWhiteSpace(value.ToString()) ? "—" : value.ToString()!;

        private static string Str(object value) => value is DBNull ? "" : Convert.ToString(value) ?? "";

        private static object NullIfEmpty(string s) => s.Length == 0 ? DBNull.Value : s;
    }
}