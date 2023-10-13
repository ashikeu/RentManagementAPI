namespace RentManagementAPI.Models.DTOs.IncomeExpense
{
    public class AddIncomeExpenseDTO
    {
        public EnumIncomeExpenseType IncomeExpenseType { get; set; }
        public string Name { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}
