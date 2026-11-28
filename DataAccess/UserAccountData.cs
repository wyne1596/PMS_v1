using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PMS_v1.Data;
using PMS_v1.Models.Responses;

namespace PMS_v1.DataAccess
{
    // DATA ACCESS for system accounts (the system_user table) on the Settings page.
    // This class is the only place that runs the SQL for the admin list and for changing or deleting an account.
    // (Creating an account is done on the Sign Up screen: see AuthData.)
    public class UserAccountData
    {
        // Every account with the Admin role, ordered by last name then first name.
        public List<AdminListItem> GetAdmins()
        {
            const string sql = @"
                SELECT p.PERSONNEL_ID, p.EMPLOYEE_NO, p.FIRST_NAME, p.LAST_NAME,
                       u.USERNAME, u.ACCOUNT_STATUS, u.LAST_LOGIN
                FROM `system_user` u
                JOIN personnel p ON p.PERSONNEL_ID = u.PERSONNEL_ID
                WHERE u.ROLE = 'Admin'
                ORDER BY p.LAST_NAME, p.FIRST_NAME";

            var list = new List<AdminListItem>();

            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new AdminListItem
                        {
                            PersonnelId = Convert.ToInt32(r["PERSONNEL_ID"]),
                            EmployeeNo = Convert.ToString(r["EMPLOYEE_NO"]) ?? string.Empty,
                            FirstName = Convert.ToString(r["FIRST_NAME"]) ?? string.Empty,
                            LastName = Convert.ToString(r["LAST_NAME"]) ?? string.Empty,
                            Username = Convert.ToString(r["USERNAME"]) ?? string.Empty,
                            AccountStatus = Convert.ToString(r["ACCOUNT_STATUS"]) ?? string.Empty,
                            LastLogin = r["LAST_LOGIN"] is DateTime d ? d : (DateTime?)null
                        });
                    }
                }
            }

            return list;
        }

        // Saves the edited account. passwordHash is the new (already hashed) password; null keeps the current one.
        public void UpdateAccount(int userId, string username, string role, string status, string? passwordHash)
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                "UPDATE `system_user` SET USERNAME=@user, ROLE=@role, ACCOUNT_STATUS=@status" +
                (passwordHash != null ? ", PASSWORD=@pass" : "") + " WHERE USER_ID=@id", conn))
            {
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@role", role);
                cmd.Parameters.AddWithValue("@status", status);
                if (passwordHash != null)
                    cmd.Parameters.AddWithValue("@pass", passwordHash);
                cmd.Parameters.AddWithValue("@id", userId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Deletes an account (the employee record stays).
        public void DeleteAccount(int userId)
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand("DELETE FROM `system_user` WHERE USER_ID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", userId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // True when this account is an active admin and no other active admin exists.
        public bool IsLastActiveAdmin(int userId)
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
    }
}
