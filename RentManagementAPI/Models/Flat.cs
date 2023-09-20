namespace RentManagementAPI.Models
{
    public class Flat
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int MasterbedRoom { get; set; }

        public int Bedroom { get; set; }

        public int Washroom { get; set; }
        public int FlatSize { get; set; }
        public string FlatSide { get; set; } = string.Empty;
        public int FloorId { get; set; }
        public List<Tenant> Tenants { get; set; } = new List<Tenant>();

    }
}
