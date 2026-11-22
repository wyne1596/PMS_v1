using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PMS_v1.Helper
{
    public static class Session
    {
        public static string Role { get; set; }

        // true for an admin login (system_user.ROLE = 'Admin'); used to show edit buttons
        public static bool IsAdmin =>
            string.Equals(Role, "Admin", StringComparison.OrdinalIgnoreCase);
    }
}