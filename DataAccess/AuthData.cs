using MySql.Data.MySqlClient;
using PMS_v1.Data;
using PMS_v1.Models.Responses;

namespace PMS_v1.DataAccess
{
    // DATA ACCESS for login and sign-up.
    // This class is the only place that talks to the database (runs the SQL) for these two screens.
    // The forms and AuthService call these methods instead of writing SQL themselves.
    public class AuthData
    {
        // Finds the account for a username (with its personnel details); null when the username does not exist.
        public LoginAccount? FindLoginAccount(string username)
        {
            const string sql = @"SELECT u.USER_ID, u.PERSONNEL_ID, u.PASSWORD, u.ROLE, u.ACCOUNT_STATUS,
                                 p.FIRST_NAME, p.LAST_NAME, p.POSITION, p.EMPLOYEE_NO, p.EMPLOYMENT_STATUS
                                 FROM `SYSTEM_USER` u
                                 JOIN PERSONNEL p ON p.PERSONNEL_ID = u.PERSONNEL_ID
                                 WHERE u.USERNAME = @user";

            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@user", username);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read()) return null;

                    return new LoginAccount
                    {
                        UserId = reader.GetInt32("USER_ID"),
                        PersonnelId = reader.GetInt32("PERSONNEL_ID"),
                        PasswordHash = reader.GetString("PASSWORD"),
                        Role = reader.GetString("ROLE"),
                        AccountStatus = reader.GetString("ACCOUNT_STATUS"),
                        FirstName = reader.GetString("FIRST_NAME"),
                        LastName = reader.GetString("LAST_NAME"),
                        Position = reader.IsDBNull(reader.GetOrdinal("POSITION")) ? "" : reader.GetString("POSITION"),
                        EmployeeNo = reader.GetString("EMPLOYEE_NO"),
                        EmploymentStatus = reader.GetString("EMPLOYMENT_STATUS")
                    };
                }
            }
        }

        // Records the time of a successful login.
        public void UpdateLastLogin(int userId)
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand("UPDATE `SYSTEM_USER` SET LAST_LOGIN = NOW() WHERE USER_ID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", userId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Finds the employee that matches Employee No. + last name, and whether they already have an account; null when nobody matches.
        public SignUpCandidate? FindEmployeeForSignUp(string employeeNo, string lastName)
        {
            const string sql = @"SELECT p.PERSONNEL_ID, p.EMPLOYMENT_STATUS, u.USER_ID
                FROM personnel p
                LEFT JOIN `system_user` u ON u.PERSONNEL_ID = p.PERSONNEL_ID
                WHERE p.EMPLOYEE_NO = @no AND p.LAST_NAME = @ln";

            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@no", employeeNo);
                cmd.Parameters.AddWithValue("@ln", lastName);
                conn.Open();

                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return null;

                    return new SignUpCandidate
                    {
                        PersonnelId = r.GetInt32("PERSONNEL_ID"),
                        EmploymentStatus = r.GetString("EMPLOYMENT_STATUS"),
                        ExistingUserId = r.IsDBNull(r.GetOrdinal("USER_ID")) ? null : r.GetInt32("USER_ID")
                    };
                }
            }
        }

        // Creates the login account (always with the 'Staff' role) for an employee.
        public void CreateAccount(int personnelId, string username, string passwordHash)
        {
            const string sql = @"INSERT INTO `system_user`
                (PERSONNEL_ID, USERNAME, PASSWORD, ROLE)
                VALUES (@pid, @user, @pass, 'Staff')";

            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@pid", personnelId);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", passwordHash);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
