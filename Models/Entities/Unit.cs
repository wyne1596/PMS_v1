namespace PMS_v1.Models.Entities
{
    // One row of the `units` table.
    public class Unit
    {
        public int UnitId { get; set; }
        public string UnitNo { get; set; } = "";
        public int? FloorNo { get; set; }
        public string UnitType { get; set; } = "";
        public decimal BaseRent { get; set; }
        public string Status { get; set; } = "";

        // null when the unit has no photo (or when the photo was not loaded)
        public byte[]? Photo { get; set; }
    }
}
