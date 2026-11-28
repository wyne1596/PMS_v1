using System;

namespace PMS_v1.Models.Responses
{
    // A bill that still has a balance left to pay (the choices on the Record Payment form).
    public class PayableBill
    {
        public int BillingId { get; set; }
        public string Tenant { get; set; } = "";
        public decimal Balance { get; set; }

        // date only
        public DateTime BillDate { get; set; }
    }
}
