namespace RentManagementAPI.Models.DTOs.IncomeExpense
{
    public class GetIncomeExpenseDTO
    {
        public int Id { get; set; }
        public EnumIncomeExpenseType IncomeExpenseType { get; set; }
        public string? Name { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int BuildingId { get; set; }

    }
}
