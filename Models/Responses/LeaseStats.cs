namespace PMS_v1.Models.Responses
{
    // The four numbers on the Leasing page stat cards, one per status.
    public class LeaseStats
    {
        public int Active { get; set; }
        public int Pending { get; set; }
        public int Expired { get; set; }
        public int Terminated { get; set; }
    }
}
