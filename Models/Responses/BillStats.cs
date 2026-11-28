namespace PMS_v1.Models.Responses
{
    // The five numbers on the Billing page stat cards, one per bill status.
    public class BillStats
    {
        public int Paid { get; set; }
        public int PartiallyPaid { get; set; }
        public int Unpaid { get; set; }
        public int Overdue { get; set; }
        public int Canceled { get; set; }
    }
}
