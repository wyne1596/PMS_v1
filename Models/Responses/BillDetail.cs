using System;

namespace PMS_v1.Models.Responses
{
    // Everything the Bill window shows.
    public class BillDetail
    {
        public int BillingId { get; set; }
        public string Tenant { get; set; } = "";
        public string UnitNo { get; set; } = "";
        public string BillType { get; set; } = "";
        public DateTime BillDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal Balance { get; set; }

        // null when nothing has been paid yet
        public DateTime? LastPaymentDate { get; set; }

        public string LastPaymentMode { get; set; } = "";
        public string LastRefNo { get; set; } = "";

        // as stored in the database (e.g. "Cancelled")
        public string Status { get; set; } = "";
    }
}
