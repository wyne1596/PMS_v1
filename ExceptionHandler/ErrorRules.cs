using System.Windows.Forms;

namespace PMS_v1.ExceptionHandler
{
    /// <summary>
    /// Every known database error of the app, grouped by the screen that can cause it.
    /// A page passes the group to ErrorHandler.Show, for example:
    ///   catch (Exception ex) { ErrorHandler.Show(this, ex, ErrorRules.Resident); }
    /// To change a message, change it here.
    /// </summary>
    public static class ErrorRules
    {
        // MySQL error numbers
        public const int DuplicateKey = 1062;        // a unique value is already used
        public const int ParentRowReferenced = 1451; // the row is used by another table
        public const int TriggerRefused = 1644;      // a database trigger refused the change (its message says why)
        public const int CheckFailed = 3819;         // a CHECK constraint failed

        // names of unique keys in the database
        public const string PersonnelEmailKey = "uq_personnel_email";
        public const string SystemUserUsernameKey = "uq_system_user_username";

        // Sign Up
        public static readonly ErrorRule[] SignUp =
        {
            new ErrorRule(DuplicateKey, "That username is already taken.", SystemUserUsernameKey),
            new ErrorRule(DuplicateKey, "This employee already has an account.")
        };

        // Billing: new bill and edit bill
        public static readonly ErrorRule[] Bill =
        {
            new ErrorRule(CheckFailed, "Check the amount and the dates, then try again."),
            new ErrorRule(TriggerRefused, null)
        };

        // Billing: record a payment (REF_NO is unique)
        public static ErrorRule[] Payment(bool typedReference) => new[]
        {
            new ErrorRule(DuplicateKey, typedReference
                ? "That reference number has already been used."
                : "Couldn't create a reference number for this payment. Please try again."),
            new ErrorRule(TriggerRefused, null)   // from the payment trigger in pms_triggers_v1.sql: more than the balance, or a canceled bill
        };

        // Residents: new and edit (EMAIL is unique)
        public static readonly ErrorRule[] Resident =
        {
            new ErrorRule(DuplicateKey, "That email is already used by another resident.")
        };

        // Residents: delete
        public static readonly ErrorRule[] ResidentDelete =
        {
            new ErrorRule(ParentRowReferenced, "This resident has leases or other records and can't be deleted.")
        };

        // Leasing: new and edit lease
        public static readonly ErrorRule[] Lease =
        {
            new ErrorRule(CheckFailed, "Check the dates and the rent, then try again.")
        };

        // Units: edit unit (UNIT_NO is unique)
        public static readonly ErrorRule[] Unit =
        {
            new ErrorRule(DuplicateKey, "That unit number is already used by another unit.",
                null, "Can't save", MessageBoxIcon.Warning)
        };

        // Settings: add / edit employee
        public static readonly ErrorRule[] Personnel =
        {
            new ErrorRule(DuplicateKey, "That email is already used by another employee.", PersonnelEmailKey)
        };

        // Settings: edit account (USERNAME is unique)
        public static readonly ErrorRule[] Account =
        {
            new ErrorRule(DuplicateKey, "That username is already taken.")
        };
    }
}