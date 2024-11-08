namespace RentManagementAPI.Models.DTOs.Flat
{
    public class FlatDTO
    {
        public string? Name { get; set; } = string.Empty;
        public int? MasterbedRoom { get; set; }

        public int? Bedroom { get; set; }

        public int? Washroom { get; set; }
        public int? FlatSize { get; set; }
        public string? FlatSide { get; set; } = string.Empty;
        public int FloorId { get; set; }
        public int UserId { get; set; }
        public int TenantId { get; set; }
        public int BuildingId { get; set; }
        public bool? IsActive { get; set; }
        public double? RentAmount { get; set; }
        public double? GasBill { get; set; }
        public double? WaterBill { get; set; }
        public double? ServiceCharge { get; set; }
    }
}
