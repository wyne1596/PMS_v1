using System;

namespace PMS_v1.Models.Entities
{
    // One bill (a row of `billing`, read through the v_billing view).
    public class Bill
    {
        public int BillingId { get; set; }
        public int LeaseId { get; set; }
        public string BillType { get; set; } = "";
        public DateTime BillDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }

        // worked out from the payment rows by the v_billing view
        public decimal AmountPaid { get; set; }

        public bool Cancelled { get; set; }
    }
}
