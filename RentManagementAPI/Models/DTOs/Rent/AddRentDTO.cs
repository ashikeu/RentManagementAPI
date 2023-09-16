namespace RentManagementAPI.Models.DTOs.Rent
{
    public class AddRentDTO
    {
        public DateTime RentMonth { get; set; }
        public double TotalAmount { get; set; }
        public bool IsPaid { get; set; }
        public int FlatId { get; set; } 
        public int TenantId { get; set; }
    }
}
