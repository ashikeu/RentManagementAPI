namespace RentManagementAPI.Models.DTOs.Floor
{
    public class AddFloorDTO
    {
        public int UserId { get; set; }
        public int BuildingId { get; set; }
        public string? Name { get; set; } = string.Empty;
        public bool? IsActive { get; set; }

    }
}
