using RentManagementAPI.Models.DTOs.IncomeExpenseTransaction;

namespace RentManagementAPI.Services.IncomeExpenseTransactionService
{
    public interface IIncomeExpenseTransactionService
    {
        Task<ServiceResponse<List<IncomeExpenseTransaction>>> GetAllIncomeExpenseTransactions();
        Task<ServiceResponse<IncomeExpenseTransaction>> GetIncomeExpenseTransactionById(int id);
        Task<ServiceResponse<IncomeExpenseTransaction>> AddIncomeExpenseTransaction(AddIncomeExpenseTransactionDTO incomeExpenseTransaction);
        Task<ServiceResponse<IncomeExpenseTransaction>> UpdateIncomeExpenseTransaction(int id, AddIncomeExpenseTransactionDTO incomeExpenseTransaction);
        Task<ServiceResponse<IncomeExpenseTransaction>> DeleteIncomeExpenseTransaction(int id);
    }
}
