namespace RentManagementAPI.Models
{
    public class Flat
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int MasterbedRoom { get; set; }
        public int FlatSize { get; set; }
        public string FlatSide { get; set; } = string.Empty;
        public int FloorId { get; set; }
        public Floor? Floor { get; set; }
        public Tenant? Tenant { get; set; }
    }
}
