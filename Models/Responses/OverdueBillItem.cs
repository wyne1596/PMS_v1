using System;

namespace PMS_v1.Models.Responses
{
    // One row of the Dashboard's "Needs Attention" table: an overdue bill.
    public class OverdueBillItem
    {
        public string Tenant { get; set; } = "";
        public string UnitNo { get; set; } = "";
        public string BillType { get; set; } = "";
        public DateTime DueDate { get; set; }
        public int DaysLate { get; set; }
        public decimal Balance { get; set; }
    }
}
