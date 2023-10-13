namespace RentManagementAPI.Models.DTOs.Building
{
    public class GetBuildingDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public Floor Floor { get; set; }
    }
}
