namespace RentManagementAPI.Models.DTOs.Deposite
{
    public class AddDepositeDTO
    {
        public int UserId { get; set; }
        public double? TotalAmount { get; set; }
        public double? DepositeAmount { get; set; }
        public double? DueAmount { get; set; }
        public DateTime? TranDate { get; set; }
        public int RentId { get; set; }

        public int TenantId { get; set; }
        public int FlatId { get; set; }
        public int BuildingId { get; set; }
    }
}
