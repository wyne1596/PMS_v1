using System;

namespace PMS_v1.Models.Responses
{
    // One row of the Reports page: a payment received on a bill, with the bill's current amount, balance and status.
    public class PaymentReportItem
    {
        public int BillingId { get; set; }

        // blank when the payment has no reference number
        public string RefNo { get; set; } = "";

        public string Tenant { get; set; } = "";
        public string UnitNo { get; set; } = "";
        public DateTime PaymentDate { get; set; }

        // blank when no payment mode was recorded
        public string PaymentMode { get; set; } = "";

        public decimal BillAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal Balance { get; set; }
        public string Status { get; set; } = "";
    }
}
