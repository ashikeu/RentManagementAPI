namespace RentManagementAPI.Models.DTOs.Flat
    
{
    using RentManagementAPI.Models;
    public class GetFlatDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int MasterbedRoom { get; set; }
        public int Bedroom { get; set; }

        public int Washroom { get; set; }
        public int FlatSize { get; set; }
        public string FlatSide { get; set; } = string.Empty;
        public int FloorId { get; set; }

        public Floor Floor { get; set; }
      
    }
}
