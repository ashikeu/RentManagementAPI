namespace RentManagementAPI.Models
{
    public class IncomeExpenseTransaction
    {
        public int Id { get; set; }
        public int IncomeExpenseId { get; set;}
        public DateTime TranDate { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Amount { get; set; }
        public int RentId { get; set; } 
        public int UserId { get; set; } 
    }
}
