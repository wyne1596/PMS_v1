using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PMS_v1.Data;
using PMS_v1.Models.Requests;
using PMS_v1.Models.Responses;

namespace PMS_v1.DataAccess
{
    // DATA ACCESS for employees (the personnel table).
    // This class is the only place that talks to the database (runs the SQL) for the employee side of the Settings page.
    // The page calls these methods instead of writing SQL itself.
    public class PersonnelData
    {
        // Every employee with the status of their system account, ordered by last name then first name.
        public List<PersonnelListItem> GetAll()
        {
            const string sql = @"
                SELECT p.PERSONNEL_ID, p.EMPLOYEE_NO, p.FIRST_NAME, p.LAST_NAME, p.POSITION,
                       p.EMPLOYMENT_STATUS, u.USER_ID, u.ROLE, u.ACCOUNT_STATUS
                FROM personnel p
                LEFT JOIN `system_user` u ON u.PERSONNEL_ID = p.PERSONNEL_ID
                ORDER BY p.LAST_NAME, p.FIRST_NAME";

            var list = new List<PersonnelListItem>();

            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        bool hasAccount = !(r["USER_ID"] is DBNull);
                        list.Add(new PersonnelListItem
                        {
                            PersonnelId = Convert.ToInt32(r["PERSONNEL_ID"]),
                            EmployeeNo = Convert.ToString(r["EMPLOYEE_NO"]) ?? string.Empty,
                            FirstName = Convert.ToString(r["FIRST_NAME"]) ?? string.Empty,
                            LastName = Convert.ToString(r["LAST_NAME"]) ?? string.Empty,
                            Position = r["POSITION"] is DBNull ? null : Convert.ToString(r["POSITION"]),
                            EmploymentStatus = Convert.ToString(r["EMPLOYMENT_STATUS"]) ?? string.Empty,
                            HasAccount = hasAccount,
                            AccountStatus = hasAccount ? Convert.ToString(r["ACCOUNT_STATUS"]) : null,
                            Role = hasAccount ? Convert.ToString(r["ROLE"]) : null
                        });
                    }
                }
            }

            return list;
        }

        // One employee with their account for the editor; null when the employee no longer exists.
        public EmployeeDetail? GetDetail(int personnelId)
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
                    if (!r.Read()) return null;   // deleted elsewhere

                    var detail = new EmployeeDetail
                    {
                        EmployeeNo = Convert.ToString(r["EMPLOYEE_NO"]) ?? string.Empty,
                        FirstName = Str(r["FIRST_NAME"]),
                        LastName = Str(r["LAST_NAME"]),
                        Position = Str(r["POSITION"]),
                        ContactNo = Str(r["CONTACT_NO"]),
                        Email = Str(r["EMAIL"]),
                        EmploymentStatus = Convert.ToString(r["EMPLOYMENT_STATUS"]) ?? string.Empty
                    };

                    if (!(r["USER_ID"] is DBNull))
                    {
                        detail.Account = new AccountSummary
                        {
                            UserId = Convert.ToInt32(r["USER_ID"]),
                            Username = Convert.ToString(r["USERNAME"]) ?? "",
                            Role = Convert.ToString(r["ROLE"]) ?? "Staff",
                            Status = Convert.ToString(r["ACCOUNT_STATUS"]) ?? "Active",
                            LastLogin = r["LAST_LOGIN"] as DateTime?
                        };
                    }

                    return detail;
                }
            }
        }

        // Tries up to `attempts` numbers from `make` and returns the first one no employee has; null when all were taken.
        public string? FindUnusedEmployeeNo(Func<string> make, int attempts)
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand("SELECT 1 FROM personnel WHERE EMPLOYEE_NO = @no LIMIT 1", conn))
            {
                var p = cmd.Parameters.Add("@no", MySqlDbType.VarChar, 20);
                conn.Open();
                for (int i = 0; i < attempts; i++)
                {
                    string no = make();
                    p.Value = no;
                    if (cmd.ExecuteScalar() == null) return no;
                }
            }

            return null;
        }

        // Adds a new employee and returns their new id.
        public int Create(SavePersonnelRequest request)
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                "INSERT INTO personnel (EMPLOYEE_NO, FIRST_NAME, LAST_NAME, POSITION, CONTACT_NO, EMAIL, EMPLOYMENT_STATUS) " +
                "VALUES (@no, @first, @last, @pos, @contact, @email, @status)", conn))
            {
                AddParams(cmd, request);
                cmd.Parameters.AddWithValue("@no", request.EmployeeNo);

                conn.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.LastInsertedId;
            }
        }

        // Saves the edited details of an employee (the employee number never changes).
        public void Update(int personnelId, SavePersonnelRequest request)
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                "UPDATE personnel SET FIRST_NAME=@first, LAST_NAME=@last, POSITION=@pos, CONTACT_NO=@contact, " +
                "EMAIL=@email, EMPLOYMENT_STATUS=@status WHERE PERSONNEL_ID=@id", conn))
            {
                AddParams(cmd, request);
                cmd.Parameters.AddWithValue("@id", personnelId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Saves only the employment status of an employee.
        public void UpdateStatus(int personnelId, string status)
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                "UPDATE personnel SET EMPLOYMENT_STATUS=@status WHERE PERSONNEL_ID=@id", conn))
            {
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", personnelId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private static void AddParams(MySqlCommand cmd, SavePersonnelRequest request)
        {
            cmd.Parameters.AddWithValue("@first", request.FirstName);
            cmd.Parameters.AddWithValue("@last", request.LastName);
            cmd.Parameters.AddWithValue("@pos", NullIfEmpty(request.Position));
            cmd.Parameters.AddWithValue("@contact", NullIfEmpty(request.ContactNo));
            cmd.Parameters.AddWithValue("@email", NullIfEmpty(request.Email));
            cmd.Parameters.AddWithValue("@status", request.EmploymentStatus);
        }

        private static object NullIfEmpty(string s) => s.Length == 0 ? DBNull.Value : s;

        private static string Str(object value) => value is DBNull ? "" : Convert.ToString(value) ?? "";
    }
}
