using System;

namespace PMS_v1.Models.Requests
{
    // The values the New Bill form sends down to be saved.
    public class CreateBillRequest
    {
        public int LeaseId { get; set; }
        public string BillType { get; set; } = "";
        public DateTime BillDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
    }
}
