namespace PMS_v1.Models.Responses
{
    // One row of the Units page table.
    public class UnitListItem
    {
        public int UnitId { get; set; }
        public string UnitNo { get; set; } = "";
        public int? FloorNo { get; set; }
        public string UnitType { get; set; } = "";
        public decimal BaseRent { get; set; }
        public string Status { get; set; } = "";
    }
}
