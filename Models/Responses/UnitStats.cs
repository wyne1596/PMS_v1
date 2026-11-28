namespace PMS_v1.Models.Responses
{
    // The four numbers on the Units page stat cards.
    public class UnitStats
    {
        public int Total { get; set; }
        public int Vacant { get; set; }
        public int Occupied { get; set; }
        public int UnderMaintenance { get; set; }
    }
}
