using System;

namespace PMS_v1.Models.Requests
{
    // The values the Edit Bill form sends down to be saved.
    public class UpdateBillRequest
    {
        public string BillType { get; set; } = "";
        public DateTime BillDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public bool Cancelled { get; set; }
    }
}
