using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PMS_v1.Data;
using PMS_v1.Models.Entities;
using PMS_v1.Models.Requests;
using PMS_v1.Models.Responses;

namespace PMS_v1.DataAccess
{
    // DATA ACCESS for leases.
    // This class is the only place that talks to the database (runs the SQL) for the Leasing page and the Lease window.
    // The page and the window call these methods instead of writing SQL themselves.
    //
    // SaveNew and SaveEdit save a lease AND keep the unit's status in step, all or nothing (one database transaction).
    // The lease rules (no overlapping leases, no Active lease on a unit under maintenance, ...) are checked inside
    // that same transaction, so they live here next to the SQL. They return a message when nothing could be saved.
    public class LeaseData
    {
        // An Active lease whose end date has passed becomes Expired, and its unit goes back to Vacant
        // (unless the unit still has another Active lease that has not ended).
        public void ExpireEndedLeases()
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    // units first, while the leases still show as Active
                    using (var cmd = new MySqlCommand(
                        "UPDATE units u SET u.STATUS = 'Vacant' WHERE u.STATUS = 'Occupied' " +
                        "AND EXISTS (SELECT 1 FROM lease l WHERE l.UNIT_ID = u.UNIT_ID AND l.STATUS = 'Active' AND l.END_DATE < @today) " +
                        "AND NOT EXISTS (SELECT 1 FROM lease l2 WHERE l2.UNIT_ID = u.UNIT_ID AND l2.STATUS = 'Active' AND l2.END_DATE >= @today)",
                        conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@today", DateTime.Today);
                        cmd.ExecuteNonQuery();
                    }

                    using (var cmd = new MySqlCommand(
                        "UPDATE lease SET STATUS = 'Expired' WHERE STATUS = 'Active' AND END_DATE < @today", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@today", DateTime.Today);
                        cmd.ExecuteNonQuery();
                    }

                    tx.Commit();
                }
            }
        }

        // One count per status; null only if the database returns no row.
        public LeaseStats? GetStats()
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
                    if (!reader.Read()) return null;

                    return new LeaseStats
                    {
                        Active = Convert.ToInt32(reader["Active"]),
                        Pending = Convert.ToInt32(reader["Pending"]),
                        Expired = Convert.ToInt32(reader["Expired"]),
                        Terminated = Convert.ToInt32(reader["Terminate"])
                    };
                }
            }
        }

        // Every lease for the table, latest end date first.
        public List<LeaseListItem> GetAll()
        {
            var list = new List<LeaseListItem>();

            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string query = @"
                               SELECT
                                    CONCAT(r.FIRST_NAME, ' ', r.LAST_NAME) AS Tenant,
                                    l.LEASE_ID,
                                    u.UNIT_NO, u.FLOOR_NO,
                                    l.START_DATE AS StartDate,
                                    l.END_DATE AS LeaseEnds, l.STATUS
                               FROM lease l
                               LEFT JOIN resident r ON l.RESIDENT_ID = r.RESIDENT_ID
                               LEFT JOIN units u ON l.UNIT_ID = u.UNIT_ID
                               ORDER BY l.END_DATE DESC";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new LeaseListItem
                        {
                            LeaseId = Convert.ToInt32(reader["LEASE_ID"]),
                            Tenant = reader["Tenant"].ToString() ?? string.Empty,
                            UnitNo = reader["UNIT_NO"].ToString() ?? string.Empty,
                            FloorNo = reader["FLOOR_NO"] is DBNull ? null : Convert.ToInt32(reader["FLOOR_NO"]),
                            StartDate = Convert.ToDateTime(reader["StartDate"]),
                            EndDate = Convert.ToDateTime(reader["LeaseEnds"]),
                            Status = reader["STATUS"].ToString() ?? string.Empty
                        });
                    }
                }
            }

            return list;
        }

        // Everything the Lease window shows; null when the lease no longer exists.
        public LeaseDetail? GetDetail(int leaseId)
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                "SELECT l.LEASE_ID, l.START_DATE, l.END_DATE, l.MONTHLY_RENT, l.DEPOSIT, l.STATUS, l.UPDATED_AT, " +
                "       r.FIRST_NAME AS R_FIRST, r.LAST_NAME AS R_LAST, r.CONTACT_NO AS R_CONTACT, " +
                "       u.UNIT_NO, u.FLOOR_NO, u.UNIT_TYPE, u.PHOTO, " +
                "       p.FIRST_NAME AS P_FIRST, p.LAST_NAME AS P_LAST, p.POSITION AS P_POSITION " +
                "FROM lease l " +
                "LEFT JOIN resident r ON r.RESIDENT_ID = l.RESIDENT_ID " +
                "LEFT JOIN units u ON u.UNIT_ID = l.UNIT_ID " +
                "LEFT JOIN personnel p ON p.EMPLOYEE_NO = l.EMPLOYEE_NO " +
                "WHERE l.LEASE_ID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", leaseId);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return null;   // deleted by someone else

                    return new LeaseDetail
                    {
                        LeaseId = leaseId,
                        StartDate = Convert.ToDateTime(r["START_DATE"]),
                        EndDate = Convert.ToDateTime(r["END_DATE"]),
                        MonthlyRent = Convert.ToDecimal(r["MONTHLY_RENT"]),
                        Deposit = Convert.ToDecimal(r["DEPOSIT"]),
                        Status = NullableText(r["STATUS"]) ?? string.Empty,
                        UpdatedAt = Convert.ToDateTime(r["UPDATED_AT"]),
                        ResidentFirstName = NullableText(r["R_FIRST"]),
                        ResidentLastName = NullableText(r["R_LAST"]),
                        ResidentContactNo = NullableText(r["R_CONTACT"]),
                        UnitNo = NullableText(r["UNIT_NO"]),
                        FloorNo = r["FLOOR_NO"] is DBNull ? null : Convert.ToInt32(r["FLOOR_NO"]),
                        UnitType = NullableText(r["UNIT_TYPE"]),
                        Photo = r["PHOTO"] as byte[],   // null when the unit has no photo
                        RecorderFirstName = NullableText(r["P_FIRST"]),
                        RecorderLastName = NullableText(r["P_LAST"]),
                        RecorderPosition = NullableText(r["P_POSITION"])
                    };
                }
            }
        }

        // One lease for the Edit form; null when the lease no longer exists.
        public Lease? GetById(int leaseId)
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                "SELECT RESIDENT_ID, UNIT_ID, START_DATE, END_DATE, MONTHLY_RENT, DEPOSIT, STATUS, UPDATED_AT " +
                "FROM lease WHERE LEASE_ID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", leaseId);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return null;   // deleted by someone else

                    return new Lease
                    {
                        LeaseId = leaseId,
                        ResidentId = Convert.ToInt32(r["RESIDENT_ID"]),
                        UnitId = Convert.ToInt32(r["UNIT_ID"]),
                        StartDate = Convert.ToDateTime(r["START_DATE"]),
                        EndDate = Convert.ToDateTime(r["END_DATE"]),
                        MonthlyRent = Convert.ToDecimal(r["MONTHLY_RENT"]),
                        Deposit = Convert.ToDecimal(r["DEPOSIT"]),
                        Status = r["STATUS"].ToString() ?? string.Empty,
                        UpdatedAt = Convert.ToDateTime(r["UPDATED_AT"])
                    };
                }
            }
        }

        // The checks that need the database, run when Save is pressed so a problem keeps the form open.
        // leaseId is 0 for a new lease; oldStatus is empty for a new lease.
        // Returns a message, or null when the lease can be saved.
        public string? CheckLease(int leaseId, int unitId, DateTime start, DateTime end, string oldStatus, string newStatus)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                return CheckLease(conn, null, leaseId, unitId, start, end, oldStatus, newStatus);
            }
        }

        // Saves the edited lease and keeps the unit's status in step, all or nothing.
        // RESIDENT_ID, UNIT_ID and EMPLOYEE_NO are not touched, so whoever recorded the lease stays on it.
        // Returns a message when nothing could be saved, or null when it was saved.
        public string? SaveEdit(int id, int unitId, DateTime loadedUpdatedAt, string oldStatus, UpdateLeaseRequest request)
        {
            string newStatus = request.Status;
            string? problem = null;   // set when nothing could be saved

            using (var conn = Db.GetConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    // lock the lease, then make sure nobody changed it while the form was open
                    object? stamp;
                    using (var cmd = new MySqlCommand(
                        "SELECT UPDATED_AT FROM lease WHERE LEASE_ID = @id FOR UPDATE", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        stamp = cmd.ExecuteScalar();
                    }

                    if (stamp == null)
                        problem = "This lease no longer exists.";
                    else if (Convert.ToDateTime(stamp) != loadedUpdatedAt)
                        problem = "This lease was changed by someone else while you were editing it. Your changes were not saved.";
                    else
                    {
                        // lock the unit too, so its status can't change between the checks and the save
                        using (var cmd = new MySqlCommand(
                            "SELECT STATUS FROM units WHERE UNIT_ID = @unit FOR UPDATE", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@unit", unitId);
                            cmd.ExecuteScalar();
                        }

                        problem = CheckLease(conn, tx, id, unitId, request.StartDate, request.EndDate, oldStatus, newStatus);
                    }

                    if (problem == null)
                    {
                        using (var cmd = new MySqlCommand(
                            "UPDATE lease SET START_DATE = @start, END_DATE = @end, MONTHLY_RENT = @rent, " +
                            "DEPOSIT = @deposit, STATUS = @status WHERE LEASE_ID = @id", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@start", request.StartDate);
                            cmd.Parameters.AddWithValue("@end", request.EndDate);
                            cmd.Parameters.AddWithValue("@rent", request.MonthlyRent);
                            cmd.Parameters.AddWithValue("@deposit", request.Deposit);
                            cmd.Parameters.AddWithValue("@status", newStatus);
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }

                        // an Active lease makes the unit Occupied; when one ends, the unit goes back to
                        // Vacant unless it is still Occupied by another Active lease
                        string? unitSql = null;
                        if (newStatus == "Active")
                            unitSql = "UPDATE units SET STATUS = 'Occupied' WHERE UNIT_ID = @unit";
                        else if (oldStatus == "Active")
                            unitSql = "UPDATE units SET STATUS = 'Vacant' WHERE UNIT_ID = @unit AND STATUS = 'Occupied' " +
                                      "AND NOT EXISTS (SELECT 1 FROM lease WHERE UNIT_ID = @unit AND STATUS = 'Active' AND LEASE_ID <> @id)";

                        if (unitSql != null)
                        {
                            using (var cmd = new MySqlCommand(unitSql, conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@unit", unitId);
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        tx.Commit();
                    }
                    else
                    {
                        tx.Rollback();
                    }
                }
            }

            return problem;
        }

        // Saves a new lease, all or nothing. The rent is the unit's base rent at this moment (copied, so
        // later changes to the base rent never touch it) and the signed-in employee is recorded on the lease.
        // Returns a message when nothing could be saved, or null when it was saved.
        public string? SaveNew(CreateLeaseRequest request)
        {
            int unitId = request.UnitId;
            string status = request.Status;
            string? problem = null;   // set when nothing could be saved

            using (var conn = Db.GetConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    // lock the unit, then make sure it is still vacant
                    string? unitStatus = null;
                    decimal baseRent = 0m;
                    using (var cmd = new MySqlCommand(
                        "SELECT STATUS, BASE_RENT FROM units WHERE UNIT_ID = @unit FOR UPDATE", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@unit", unitId);
                        using (var r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                unitStatus = r["STATUS"].ToString();
                                baseRent = Convert.ToDecimal(r["BASE_RENT"]);
                            }
                        }
                    }

                    if (unitStatus != "Vacant")
                        problem = "This unit is no longer vacant.";
                    else
                        problem = CheckLease(conn, tx, 0, unitId, request.StartDate, request.EndDate, string.Empty, status);

                    if (problem == null)
                    {
                        using (var cmd = new MySqlCommand(
                            "INSERT INTO lease (START_DATE, END_DATE, UNIT_ID, RESIDENT_ID, MONTHLY_RENT, DEPOSIT, STATUS, EMPLOYEE_NO) " +
                            "VALUES (@start, @end, @unit, @resident, @rent, @deposit, @status, " +
                            "(SELECT EMPLOYEE_NO FROM personnel WHERE PERSONNEL_ID = @personnel))", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@start", request.StartDate);
                            cmd.Parameters.AddWithValue("@end", request.EndDate);
                            cmd.Parameters.AddWithValue("@unit", unitId);
                            cmd.Parameters.AddWithValue("@resident", request.ResidentId);
                            cmd.Parameters.AddWithValue("@rent", baseRent);
                            cmd.Parameters.AddWithValue("@deposit", request.Deposit);
                            cmd.Parameters.AddWithValue("@status", status);
                            cmd.Parameters.AddWithValue("@personnel", request.PersonnelId);
                            cmd.ExecuteNonQuery();
                        }

                        // an Active lease makes the unit Occupied
                        if (status == "Active")
                        {
                            using (var cmd = new MySqlCommand(
                                "UPDATE units SET STATUS = 'Occupied' WHERE UNIT_ID = @unit", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@unit", unitId);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        tx.Commit();
                    }
                    else
                    {
                        tx.Rollback();
                    }
                }
            }

            return problem;
        }

        // the checks that need the database; returns a message, or null when the lease can be saved
        private static string? CheckLease(MySqlConnection conn, MySqlTransaction? tx, int leaseId, int unitId,
            DateTime start, DateTime end, string oldStatus, string newStatus)
        {
            // Expired and Terminated leases no longer hold the unit
            if (newStatus != "Pending" && newStatus != "Active") return null;

            using (var cmd = new MySqlCommand(
                "SELECT COUNT(*) FROM lease WHERE UNIT_ID = @unit AND LEASE_ID <> @id " +
                "AND STATUS IN ('Pending', 'Active') AND START_DATE <= @end AND END_DATE >= @start", conn, tx))
            {
                cmd.Parameters.AddWithValue("@unit", unitId);
                cmd.Parameters.AddWithValue("@id", leaseId);
                cmd.Parameters.AddWithValue("@start", start);
                cmd.Parameters.AddWithValue("@end", end);
                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    return "This unit already has another Pending or Active lease that overlaps these dates.";
            }

            if (newStatus == "Active" && oldStatus != "Active")
            {
                using (var cmd = new MySqlCommand("SELECT STATUS FROM units WHERE UNIT_ID = @unit", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@unit", unitId);
                    if (string.Equals(cmd.ExecuteScalar()?.ToString(), "Under Maintenance", StringComparison.Ordinal))
                        return "This unit is under maintenance, so the lease can't be set to Active. Finish the maintenance first.";
                }
            }
            return null;
        }

        private static string? NullableText(object value)
        {
            return value == null || value is DBNull ? null : value.ToString();
        }
    }
}
