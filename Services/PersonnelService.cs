using System;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using PMS_v1.DataAccess;

namespace PMS_v1.Services
{
    // SERVICE for employees: the rules for creating an employee number.
    // The Settings page calls this; this calls PersonnelData for anything that needs the database.
    public static class PersonnelService
    {
        // Random employee number, format YYYY-NNNNN (same as the existing records and the Sign Up check),
        // unique in the personnel table.
        public static string GenerateEmployeeNo()
        {
            string Make() => $"{DateTime.Now.Year}-{RandomNumberGenerator.GetInt32(0, 100000):D5}";

            try
            {
                string? free = new PersonnelData().FindUnusedEmployeeNo(Make, 25);
                if (free != null) return free;
            }
            catch (MySqlException) { /* the unique key still protects the insert; Save retries */ }

            return Make();
        }
    }
}
