namespace RentManagementAPI.Models.DTOs.Building
{
    public class AddBuildingDTO
    {
        public string? Name { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public int UserId { get; set; }
        public bool? IsActive { get; set; }
    }
}
