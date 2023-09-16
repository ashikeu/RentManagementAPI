namespace RentManagementAPI.Models.DTOs.Deposite
{
    public class AddDepositeDTO
    {
        public double TotalAmount { get; set; }
        public double DepositeAmount { get; set; } 
        public double DueAmount { get; set; }
        public DateTime DepositeDate { get; set; }
        public int RentId { get; set; }
    }
}
