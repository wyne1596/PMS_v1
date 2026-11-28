using System;
using PMS_v1.DataAccess;

namespace PMS_v1.Services
{
    // SERVICE for bills: the rules a bill must follow before it is saved.
    // The Billing page calls this; this calls BillData for anything that needs the database.
    public class BillService
    {
        private readonly BillData _data = new BillData();

        // The checks for a bill that need the database; they run when Save is pressed, so a problem keeps the form open.
        // billingId is 0 for a new bill. Returns the message to show, or null when the bill is fine.
        public string? CheckBillAgainstLease(int leaseId, string billType, DateTime billDate, int billingId)
        {
            DateTime? start = _data.GetLeaseStartDate(leaseId);
            if (start.HasValue && billDate < start.Value.Date)
                return "Bill date can't be before the lease start date.";

            if (billType == "Rent")
            {
                var monthStart = new DateTime(billDate.Year, billDate.Month, 1);
                if (_data.CountRentBillsInMonth(leaseId, billingId, monthStart) > 0)
                    return "This lease already has a Rent bill for that month.";
            }

            return null;
        }
    }
}
