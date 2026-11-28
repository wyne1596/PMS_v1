using System;

namespace PMS_v1.Models.Responses
{
    // One row of the Billing page table.
    public class BillListItem
    {
        public int BillingId { get; set; }
        public string Tenant { get; set; } = "";
        public string UnitNo { get; set; } = "";
        public string BillType { get; set; } = "";
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal Balance { get; set; }

        // blank when nothing has been paid yet
        public string LastPaymentMode { get; set; } = "";

        // as stored in the database (e.g. "Cancelled")
        public string Status { get; set; } = "";
    }
}
