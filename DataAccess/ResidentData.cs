using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PMS_v1.Data;
using PMS_v1.Models.Entities;
using PMS_v1.Models.Requests;
using PMS_v1.Models.Responses;

namespace PMS_v1.DataAccess
{
    // DATA ACCESS for residents.
    // This class is the only place that talks to the database (runs the SQL) for the Residents page.
    // The page calls these methods instead of writing SQL itself.
    public class ResidentData
    {
        // The numbers for the stat cards; null only if the database returns no row.
        public ResidentStats? GetStats()
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                const string query = @"
                    SELECT
                        COUNT(*) AS Total,
                        (SELECT COUNT(DISTINCT RESIDENT_ID) FROM lease WHERE STATUS = 'Active') AS WithLease,
                        COALESCE(SUM(CREATED_AT >= DATE_FORMAT(CURDATE(), '%Y-%m-01')), 0) AS NewThisMonth
                    FROM resident";

                using (var cmd = new MySqlCommand(query, conn))
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return null;

                    return new ResidentStats
                    {
                        Total = Convert.ToInt32(r["Total"]),
                        WithLease = Convert.ToInt32(r["WithLease"]),
                        NewThisMonth = Convert.ToInt32(r["NewThisMonth"])
                    };
                }
            }
        }

        // Every resident for the table, ordered by last name then first name.
        public List<ResidentListItem> GetAll()
        {
            var list = new List<ResidentListItem>();

            using (var conn = Db.GetConnection())
            {
                conn.Open();
                const string query = @"
                    SELECT r.RESIDENT_ID, r.FIRST_NAME, r.LAST_NAME, r.CONTACT_NO, r.EMAIL,
                           r.BIRTHDATE, r.EMERGENCY_CONTACT_NO,
                           EXISTS (SELECT 1 FROM lease l
                                   WHERE l.RESIDENT_ID = r.RESIDENT_ID AND l.STATUS = 'Active') AS HasLease
                    FROM resident r
                    ORDER BY r.LAST_NAME, r.FIRST_NAME";

                using (var cmd = new MySqlCommand(query, conn))
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new ResidentListItem
                        {
                            ResidentId = Convert.ToInt32(r["RESIDENT_ID"]),
                            FirstName = Convert.ToString(r["FIRST_NAME"]) ?? string.Empty,
                            LastName = Convert.ToString(r["LAST_NAME"]) ?? string.Empty,
                            ContactNo = r["CONTACT_NO"] is DBNull ? null : Convert.ToString(r["CONTACT_NO"]),
                            Email = r["EMAIL"] is DBNull ? null : Convert.ToString(r["EMAIL"]),
                            Birthdate = r["BIRTHDATE"] is DateTime d ? d : null,
                            EmergencyContactNo = r["EMERGENCY_CONTACT_NO"] is DBNull ? null : Convert.ToString(r["EMERGENCY_CONTACT_NO"]),
                            HasLease = Convert.ToInt32(r["HasLease"]) == 1
                        });
                    }
                }
            }

            return list;
        }

        // One resident for the Edit form; null when the resident no longer exists.
        public Resident? GetById(int residentId)
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                "SELECT FIRST_NAME, LAST_NAME, CONTACT_NO, EMAIL, BIRTHDATE, EMERGENCY_CONTACT_NO " +
                "FROM resident WHERE RESIDENT_ID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", residentId);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return null;   // deleted by someone else

                    return new Resident
                    {
                        ResidentId = residentId,
                        FirstName = Convert.ToString(r["FIRST_NAME"]) ?? string.Empty,
                        LastName = Convert.ToString(r["LAST_NAME"]) ?? string.Empty,
                        ContactNo = r["CONTACT_NO"] is DBNull ? null : Convert.ToString(r["CONTACT_NO"]),
                        Email = r["EMAIL"] is DBNull ? null : Convert.ToString(r["EMAIL"]),
                        Birthdate = r["BIRTHDATE"] is DateTime d ? d : null,
                        EmergencyContactNo = r["EMERGENCY_CONTACT_NO"] is DBNull ? null : Convert.ToString(r["EMERGENCY_CONTACT_NO"])
                    };
                }
            }
        }

        // Adds a new resident.
        public void Create(SaveResidentRequest request)
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                "INSERT INTO resident (FIRST_NAME, LAST_NAME, CONTACT_NO, EMAIL, BIRTHDATE, EMERGENCY_CONTACT_NO) " +
                "VALUES (@first, @last, @contact, @email, @birth, @emergency)", conn))
            {
                AddParams(cmd, request);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Saves the edited details of a resident.
        public void Update(int residentId, SaveResidentRequest request)
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                "UPDATE resident SET FIRST_NAME=@first, LAST_NAME=@last, CONTACT_NO=@contact, " +
                "EMAIL=@email, BIRTHDATE=@birth, EMERGENCY_CONTACT_NO=@emergency " +
                "WHERE RESIDENT_ID=@id", conn))
            {
                AddParams(cmd, request);
                cmd.Parameters.AddWithValue("@id", residentId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Deletes a resident.
        public void Delete(int residentId)
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand("DELETE FROM resident WHERE RESIDENT_ID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", residentId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private static void AddParams(MySqlCommand cmd, SaveResidentRequest v)
        {
            // blank optional fields are null; MySQL needs DBNull
            cmd.Parameters.AddWithValue("@first", v.FirstName);
            cmd.Parameters.AddWithValue("@last", v.LastName);
            cmd.Parameters.AddWithValue("@contact", (object?)v.ContactNo ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@email", (object?)v.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@birth", (object?)v.Birthdate ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@emergency", (object?)v.EmergencyContactNo ?? DBNull.Value);
        }
    }
}
