using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PMS_v1.Data;
using PMS_v1.Models.Entities;
using PMS_v1.Models.Requests;
using PMS_v1.Models.Responses;

namespace PMS_v1.DataAccess
{
    // DATA ACCESS for maintenance requests.
    // This class is the only place that talks to the database (runs the SQL) for the Maintenance page and the Request window.
    // The page and the window call these methods instead of writing SQL themselves.
    public class MaintenanceData
    {
        // One count per database status; null only if the database returns no row.
        public MaintenanceStats? GetStats()
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string query = @"
                               SELECT
                                   COUNT(CASE WHEN STATUS = 'Resolved' THEN 1 END) AS Resolved,
                                   COUNT(CASE WHEN STATUS = 'Open' THEN 1 END) AS OpenRequests,
                                   COUNT(CASE WHEN STATUS = 'In Progress' THEN 1 END) AS InProgress,
                                   COUNT(CASE WHEN STATUS = 'Closed' THEN 1 END) AS Closed
                               FROM maintenance_request";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.Read()) return null;

                    return new MaintenanceStats
                    {
                        Resolved = Convert.ToInt32(reader["Resolved"]),
                        Open = Convert.ToInt32(reader["OpenRequests"]),
                        InProgress = Convert.ToInt32(reader["InProgress"]),
                        Closed = Convert.ToInt32(reader["Closed"])
                    };
                }
            }
        }

        // Every request for the table.
        // Order: Resolved/Closed sink to the bottom; the rest go Urgent > High > Medium > Low, oldest reported first.
        public List<MaintenanceListItem> GetAll()
        {
            var list = new List<MaintenanceListItem>();

            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string query = @"
                               SELECT m.REPORT_ID, u.UNIT_NO, m.PROBLEM, m.MAINTENANCE_TYPE, m.DATE_REPORTED, m.PRIORITY, m.STATUS
                               FROM maintenance_request m
                               LEFT JOIN units u ON u.UNIT_ID = m.UNIT_ID
                               ORDER BY CASE WHEN m.STATUS IN ('Resolved', 'Closed') THEN 1 ELSE 0 END,
                                        FIELD(m.PRIORITY, 'Urgent', 'High', 'Medium', 'Low'),
                                        m.DATE_REPORTED ASC, m.REPORT_ID ASC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new MaintenanceListItem
                        {
                            ReportId = Convert.ToInt32(reader["REPORT_ID"]),
                            UnitNo = reader["UNIT_NO"] is DBNull ? null : reader["UNIT_NO"].ToString(),
                            Problem = reader["PROBLEM"].ToString() ?? string.Empty,
                            MaintenanceType = reader["MAINTENANCE_TYPE"].ToString() ?? string.Empty,
                            DateReported = Convert.ToDateTime(reader["DATE_REPORTED"]),
                            Status = reader["STATUS"].ToString() ?? string.Empty,
                            Priority = reader["PRIORITY"].ToString() ?? string.Empty
                        });
                    }
                }
            }

            return list;
        }

        // Everything the Request window shows; null when the request no longer exists.
        public MaintenanceDetail? GetDetail(int reportId)
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                "SELECT m.REPORT_ID, u.UNIT_NO, " +
                "       r.FIRST_NAME AS R_FIRST, r.LAST_NAME AS R_LAST, r.CONTACT_NO AS R_CONTACT, " +
                "       p.FIRST_NAME AS P_FIRST, p.LAST_NAME AS P_LAST, p.POSITION AS P_POSITION, " +
                "       m.PROBLEM, m.MAINTENANCE_TYPE, m.PRIORITY, m.STATUS, m.DATE_REPORTED, " +
                "       m.DATE_COMPLETED, m.COST, m.REPAIR_DETAILS, m.UPDATED_AT " +
                "FROM maintenance_request m " +
                "LEFT JOIN units u ON u.UNIT_ID = m.UNIT_ID " +
                "LEFT JOIN resident r ON r.RESIDENT_ID = m.RESIDENT_ID " +
                "LEFT JOIN personnel p ON p.PERSONNEL_ID = m.PERSONNEL_ID " +
                "WHERE m.REPORT_ID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", reportId);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return null;   // deleted by someone else

                    return new MaintenanceDetail
                    {
                        ReportId = reportId,
                        UnitNo = NullableText(r["UNIT_NO"]),
                        ReporterFirstName = NullableText(r["R_FIRST"]),
                        ReporterLastName = NullableText(r["R_LAST"]),
                        ReporterContactNo = NullableText(r["R_CONTACT"]),
                        TechnicianFirstName = NullableText(r["P_FIRST"]),
                        TechnicianLastName = NullableText(r["P_LAST"]),
                        TechnicianPosition = NullableText(r["P_POSITION"]),
                        Problem = NullableText(r["PROBLEM"]) ?? string.Empty,
                        MaintenanceType = NullableText(r["MAINTENANCE_TYPE"]) ?? string.Empty,
                        Priority = NullableText(r["PRIORITY"]) ?? string.Empty,
                        Status = NullableText(r["STATUS"]) ?? string.Empty,
                        DateReported = Convert.ToDateTime(r["DATE_REPORTED"]),
                        DateCompleted = r["DATE_COMPLETED"] is DBNull ? null : Convert.ToDateTime(r["DATE_COMPLETED"]),
                        Cost = Convert.ToDecimal(r["COST"]),
                        RepairDetails = NullableText(r["REPAIR_DETAILS"]),
                        UpdatedAt = Convert.ToDateTime(r["UPDATED_AT"])
                    };
                }
            }
        }

        // One request for the Edit form; null when the request no longer exists.
        public MaintenanceRequest? GetById(int reportId)
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                "SELECT UNIT_ID, RESIDENT_ID, PROBLEM, MAINTENANCE_TYPE, PRIORITY, DATE_REPORTED, STATUS, " +
                "PERSONNEL_ID, DATE_COMPLETED, COST, REPAIR_DETAILS " +
                "FROM maintenance_request WHERE REPORT_ID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", reportId);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return null;   // deleted by someone else

                    return new MaintenanceRequest
                    {
                        ReportId = reportId,
                        UnitId = r["UNIT_ID"] is DBNull ? null : Convert.ToInt32(r["UNIT_ID"]),
                        ResidentId = r["RESIDENT_ID"] is DBNull ? null : Convert.ToInt32(r["RESIDENT_ID"]),
                        Problem = NullableText(r["PROBLEM"]) ?? string.Empty,
                        MaintenanceType = NullableText(r["MAINTENANCE_TYPE"]) ?? string.Empty,
                        Priority = NullableText(r["PRIORITY"]) ?? string.Empty,
                        DateReported = Convert.ToDateTime(r["DATE_REPORTED"]),
                        Status = NullableText(r["STATUS"]) ?? string.Empty,
                        PersonnelId = r["PERSONNEL_ID"] is DBNull ? null : Convert.ToInt32(r["PERSONNEL_ID"]),
                        DateCompleted = r["DATE_COMPLETED"] is DBNull ? null : Convert.ToDateTime(r["DATE_COMPLETED"]),
                        Cost = Convert.ToDecimal(r["COST"]),
                        RepairDetails = NullableText(r["REPAIR_DETAILS"])
                    };
                }
            }
        }

        // Adds a new request.
        public void Create(CreateMaintenanceRequest request)
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                "INSERT INTO maintenance_request " +
                "(UNIT_ID, RESIDENT_ID, PROBLEM, MAINTENANCE_TYPE, PRIORITY, DATE_REPORTED) " +
                "VALUES (@unit, @resident, @problem, @type, @priority, @reported)", conn))
            {
                AddRequestParams(cmd, request);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Saves the edited request.
        public void Update(int reportId, UpdateMaintenanceRequest request)
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                "UPDATE maintenance_request SET UNIT_ID=@unit, RESIDENT_ID=@resident, PROBLEM=@problem, " +
                "MAINTENANCE_TYPE=@type, PRIORITY=@priority, DATE_REPORTED=@reported, STATUS=@status, " +
                "PERSONNEL_ID=@technician, DATE_COMPLETED=@completed, COST=@cost, REPAIR_DETAILS=@repair " +
                "WHERE REPORT_ID=@id", conn))
            {
                AddRequestParams(cmd, request);
                cmd.Parameters.AddWithValue("@status", (object?)request.Status ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@technician", (object?)request.PersonnelId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@completed", (object?)request.DateCompleted ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@cost", request.Cost);
                cmd.Parameters.AddWithValue("@repair", (object?)request.RepairDetails ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@id", reportId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // the values the New and Edit forms share
        private static void AddRequestParams(MySqlCommand cmd, CreateMaintenanceRequest v)
        {
            cmd.Parameters.AddWithValue("@unit", (object?)v.UnitId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@resident", (object?)v.ResidentId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@problem", (object?)v.Problem ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@type", (object?)v.MaintenanceType ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@priority", (object?)v.Priority ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@reported", (object?)v.DateReported ?? DBNull.Value);
        }

        private static string? NullableText(object value)
        {
            return value == null || value is DBNull ? null : value.ToString();
        }
    }
}
