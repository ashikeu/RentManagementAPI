namespace RentManagementAPI.Models.DTOs.Flat
{
    public class AddFlatDTO
    {
        public string Name { get; set; } = string.Empty; 
        public int MasterbedRoom { get; set; }
        public int FlatSize { get; set; }
        public string FlatSide { get; set; } = string.Empty;
        public int FloorId { get; set; } 
    }
}
