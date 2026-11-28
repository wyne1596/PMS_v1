using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PMS_v1.Data;
using PMS_v1.Models.Entities;
using PMS_v1.Models.Requests;
using PMS_v1.Models.Responses;

namespace PMS_v1.DataAccess
{
    // DATA ACCESS for units.
    // This class is the only place that talks to the database (runs the SQL) for the Units page and the Unit window.
    // Pages and forms call these methods instead of writing SQL themselves.
    public class UnitData
    {
        // The four numbers for the stat cards; null only if the database returns no row.
        public UnitStats? GetStats()
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string query = @"
                               SELECT
                                    COUNT(*) AS TotalUnits,
                                    COUNT(CASE WHEN STATUS = 'Vacant' THEN 1 END) AS VacantUnits,
                                    COUNT(CASE WHEN STATUS = 'Occupied' THEN 1 END) AS OccupiedUnits,
                                    COUNT(CASE WHEN STATUS = 'Under Maintenance' THEN 1 END) AS MaintenanceUnits
                               FROM Units";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.Read()) return null;

                    return new UnitStats
                    {
                        Total = Convert.ToInt32(reader["TotalUnits"]),
                        Vacant = Convert.ToInt32(reader["VacantUnits"]),
                        Occupied = Convert.ToInt32(reader["OccupiedUnits"]),
                        UnderMaintenance = Convert.ToInt32(reader["MaintenanceUnits"])
                    };
                }
            }
        }

        // Every unit for the table: vacant units first, then by floor and unit number.
        public List<UnitListItem> GetAll()
        {
            var list = new List<UnitListItem>();

            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string query = @"
                               SELECT
                               UNIT_ID, UNIT_NO, FLOOR_NO, UNIT_TYPE, BASE_RENT, STATUS FROM units
                               ORDER BY CASE WHEN STATUS = 'Vacant' THEN 0 ELSE 1 END,   -- vacant units first
                                        FLOOR_NO ASC, UNIT_NO ASC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new UnitListItem
                        {
                            UnitId = Convert.ToInt32(reader["UNIT_ID"]),
                            UnitNo = reader["UNIT_NO"].ToString() ?? string.Empty,   // UNIT_NO is varchar, so "101A" must not crash
                            FloorNo = reader["FLOOR_NO"] is DBNull ? null : Convert.ToInt32(reader["FLOOR_NO"]),
                            UnitType = reader["UNIT_TYPE"].ToString() ?? string.Empty,
                            BaseRent = Convert.ToDecimal(reader["BASE_RENT"]),
                            Status = reader["STATUS"].ToString() ?? string.Empty
                        });
                    }
                }
            }

            return list;
        }

        // Everything the Unit window shows; null when the unit no longer exists.
        public UnitDetail? GetDetail(int unitId)
        {
            var detail = new UnitDetail();

            using (var conn = Db.GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand(
                    "SELECT UNIT_NO, FLOOR_NO, UNIT_TYPE, BASE_RENT, STATUS, PHOTO FROM units WHERE UNIT_ID = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", unitId);
                    using (var r = cmd.ExecuteReader())
                    {
                        if (!r.Read()) return null;

                        detail.Unit = new Unit
                        {
                            UnitId = unitId,
                            UnitNo = Str(r["UNIT_NO"]),
                            FloorNo = r["FLOOR_NO"] is DBNull ? null : Convert.ToInt32(r["FLOOR_NO"]),
                            UnitType = Str(r["UNIT_TYPE"]),
                            BaseRent = Convert.ToDecimal(r["BASE_RENT"]),
                            Status = Str(r["STATUS"]),
                            Photo = r["PHOTO"] as byte[]   // null when the unit has no photo
                        };
                    }
                }

                using (var cmd = new MySqlCommand(
                    @"SELECT CONCAT(r.FIRST_NAME, ' ', r.LAST_NAME) AS Tenant, r.CONTACT_NO,
                             l.START_DATE, l.END_DATE, l.MONTHLY_RENT, l.DEPOSIT
                      FROM lease l
                      JOIN resident r ON r.RESIDENT_ID = l.RESIDENT_ID
                      WHERE l.UNIT_ID = @id AND l.STATUS = 'Active'
                      ORDER BY l.START_DATE DESC
                      LIMIT 1", conn))
                {
                    cmd.Parameters.AddWithValue("@id", unitId);
                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            detail.Tenant = new UnitTenant
                            {
                                Name = Str(r["Tenant"]),
                                ContactNo = Str(r["CONTACT_NO"]),
                                StartDate = Convert.ToDateTime(r["START_DATE"]),
                                EndDate = Convert.ToDateTime(r["END_DATE"]),
                                MonthlyRent = Convert.ToDecimal(r["MONTHLY_RENT"]),
                                Deposit = Convert.ToDecimal(r["DEPOSIT"])
                            };
                        }
                    }
                }

                using (var cmd = new MySqlCommand(
                    "SELECT COUNT(*) FROM maintenance_request WHERE UNIT_ID = @id AND STATUS IN ('Open', 'In Progress')", conn))
                {
                    cmd.Parameters.AddWithValue("@id", unitId);
                    detail.OpenRequests = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return detail;
        }

        // A unit's details for the Edit form (the photo is not loaded); null when the unit no longer exists.
        public Unit? GetForEdit(int unitId)
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                "SELECT UNIT_NO, FLOOR_NO, UNIT_TYPE, BASE_RENT, STATUS FROM units WHERE UNIT_ID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", unitId);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return null;   // deleted by someone else

                    return new Unit
                    {
                        UnitId = unitId,
                        UnitNo = Str(r["UNIT_NO"]),
                        FloorNo = r["FLOOR_NO"] is DBNull ? null : Convert.ToInt32(r["FLOOR_NO"]),
                        UnitType = Str(r["UNIT_TYPE"]),
                        BaseRent = Convert.ToDecimal(r["BASE_RENT"]),
                        Status = Str(r["STATUS"])
                    };
                }
            }
        }

        // Saves the edited details of a unit.
        public void Update(int unitId, UpdateUnitRequest request)
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                "UPDATE units SET UNIT_NO = @unitNo, FLOOR_NO = @floor, UNIT_TYPE = @type, " +
                "BASE_RENT = @rent, STATUS = @status WHERE UNIT_ID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@unitNo", request.UnitNo);
                cmd.Parameters.AddWithValue("@floor", request.Floor);
                cmd.Parameters.AddWithValue("@type", request.UnitType);
                cmd.Parameters.AddWithValue("@rent", request.BaseRent);
                cmd.Parameters.AddWithValue("@status", request.Status);
                cmd.Parameters.AddWithValue("@id", unitId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Saves a unit's photo; null removes it.
        public void SavePhoto(int unitId, byte[]? photo)
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand("UPDATE units SET PHOTO = @photo WHERE UNIT_ID = @id", conn))
            {
                cmd.Parameters.Add("@photo", MySqlDbType.MediumBlob).Value = (object?)photo ?? DBNull.Value;
                cmd.Parameters.AddWithValue("@id", unitId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private static string Str(object value)
        {
            return value == null || value is DBNull ? string.Empty : value.ToString() ?? string.Empty;
        }
    }
}
