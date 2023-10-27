namespace RentManagementAPI.Models
{

    public enum EnumIncomeExpenseType
    {
        Income = 1,
        Expense = 2
    }

    public class IncomeExpense
    {
        public int Id { get; set; }
        public EnumIncomeExpenseType IncomeExpenseType { get; set; }
        public string Name { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int BuildingId { get; set; }

    }
}
