namespace PMS_v1.Models.Responses
{
    // The numbers on the ten Dashboard stat cards.
    public class DashboardStats
    {
        public decimal UnpaidBalance { get; set; }
        public int ExpiredLeases { get; set; }
        public int RentOverdue { get; set; }
        public int RepairsNeeded { get; set; }
        public int OccupiedUnits { get; set; }
        public int TotalUnits { get; set; }
        public int VacantUnits { get; set; }
        public decimal CollectedThisMonth { get; set; }
        public int BillsDueSoon { get; set; }
        public int LeasesExpiring { get; set; }
        public int UrgentRepairs { get; set; }
    }
}
