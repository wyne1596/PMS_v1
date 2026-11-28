namespace PMS_v1.Models.Responses
{
    // The four numbers on the Maintenance page stat cards, one per status.
    public class MaintenanceStats
    {
        public int Resolved { get; set; }
        public int Open { get; set; }
        public int InProgress { get; set; }
        public int Closed { get; set; }
    }
}
