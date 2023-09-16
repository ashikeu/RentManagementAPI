namespace RentManagementAPI.Models.DTOs.Deposite
{
    using RentManagementAPI.Models;
    public class GetDepositeDTO
    {
        public int Id { get; set; }
        public double TotalAmount { get; set; }
        public double DepositeAmount { get; set; }
        public double DueAmount { get; set; }
        public DateTime DepositeDate { get; set; }
        public int RentId { get; set; }
        public Rent? Rent { get; set; }
    }
}
