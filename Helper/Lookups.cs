using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PMS_v1.Database;

namespace PMS_v1
{
    public static class Lookups
    {
        private static List<ComboItem> Load(string sql)
        {
            var list = new List<ComboItem>();
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(new ComboItem(r.GetInt32(0), r.GetString(1)));
            }
            return list;
        }

        public static List<ComboItem> VacantUnits() => Load(
            "SELECT UNIT_ID, CONCAT('Unit ', UNIT_NO) FROM units " +
            "WHERE STATUS = 'Vacant' ORDER BY FLOOR_NO, UNIT_NO");

        public static List<ComboItem> Residents() => Load(
            "SELECT RESIDENT_ID, CONCAT(FIRST_NAME, ' ', LAST_NAME) FROM resident " +
            "ORDER BY LAST_NAME, FIRST_NAME");

        // every unit, for the maintenance form (the form adds its own "Common area" choice)
        public static List<ComboItem> AllUnits() => Load(
            "SELECT UNIT_ID, CONCAT('Unit ', UNIT_NO) FROM units " +
            "ORDER BY FLOOR_NO, UNIT_NO");

        // active personnel for "Assigned to"; includeId keeps the person already assigned in the list even if no longer active
        public static List<ComboItem> Technicians(int? includeId = null) => Load(
            "SELECT PERSONNEL_ID, CONCAT(FIRST_NAME, ' ', LAST_NAME) FROM personnel " +
            "WHERE EMPLOYMENT_STATUS = 'Active'" +
            (includeId.HasValue ? " OR PERSONNEL_ID = " + includeId.Value : "") +
            " ORDER BY LAST_NAME, FIRST_NAME");

        // a unit's base rent: copied onto a new lease, and shown (locked) on a new rent bill
        public static decimal BaseRent(int? unitId)
        {
            if (!unitId.HasValue) return 0m;
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand("SELECT BASE_RENT FROM units WHERE UNIT_ID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", unitId.Value);
                conn.Open();
                object? o = cmd.ExecuteScalar();
                return o == null || o is DBNull ? 0m : Convert.ToDecimal(o);
            }
        }

        // the base rent of the unit a lease is for
        public static decimal BaseRentOfLease(int? leaseId)
        {
            if (!leaseId.HasValue) return 0m;
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                "SELECT u.BASE_RENT FROM lease l JOIN units u ON u.UNIT_ID = l.UNIT_ID WHERE l.LEASE_ID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", leaseId.Value);
                conn.Open();
                object? o = cmd.ExecuteScalar();
                return o == null || o is DBNull ? 0m : Convert.ToDecimal(o);
            }
        }
    }
}