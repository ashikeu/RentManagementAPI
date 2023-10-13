using RentManagementAPI.Models.DTOs.IncomeExpense;

namespace RentManagementAPI.Services.IncomeExpenseService
{
    public interface IIncomeExpenseService
    {
        Task<ServiceResponse<List<IncomeExpense>>> GetAllIncomeExpenses();
        Task<ServiceResponse<IncomeExpense>> GetIncomeExpenseById(int id);
        Task<ServiceResponse<IncomeExpense>> AddIncomeExpense(AddIncomeExpenseDTO incomeExpense);
        Task<ServiceResponse<IncomeExpense>> UpdateIncomeExpense(int id, AddIncomeExpenseDTO incomeExpense);
        Task<ServiceResponse<IncomeExpense>> DeleteIncomeExpense(int id);
    }
}
