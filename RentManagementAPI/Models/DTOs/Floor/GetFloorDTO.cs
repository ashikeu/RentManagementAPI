

namespace RentManagementAPI.Models.DTOs.Floor
{
    using RentManagementAPI.Models;
    public class GetFloorDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BuildingId { get; set; }
        public string? Name { get; set; } = string.Empty;
        public bool? IsActive { get; set; }
       public Flat Flat { get; set; }
        public List<Flat> Flats { get; set; } = new List<Flat>();
    }
}
