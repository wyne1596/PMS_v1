using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PMS_v1.Helper
{
    public static class Session
    {
        public static string Role { get; set; }

        // who is signed in (system_user.USER_ID / personnel.PERSONNEL_ID); Settings uses them so an admin can't lock or delete themselves
        public static int UserId { get; set; }
        public static int PersonnelId { get; set; }

        // true for an admin login (system_user.ROLE = 'Admin'); used to show edit buttons
        public static bool IsAdmin =>
            string.Equals(Role, "Admin", StringComparison.OrdinalIgnoreCase);

        public static bool IsManager =>
            string.Equals(Role, "Manager", StringComparison.OrdinalIgnoreCase);

        // Delete buttons on the module pages: admins and managers only (staff can add and edit, not delete)
        public static bool CanDelete => IsAdmin || IsManager;

        // Settings page: admins (full) and managers (view personnel + add employees only)
        public static bool CanOpenSettings => IsAdmin || IsManager;
    }
}