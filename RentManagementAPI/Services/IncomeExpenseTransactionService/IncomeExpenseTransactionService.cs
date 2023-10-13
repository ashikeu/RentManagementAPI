using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentManagementAPI.Models.DTOs.IncomeExpenseTransaction;

namespace RentManagementAPI.Services.IncomeExpenseTransactionService
{
    public class IncomeExpenseTransactionService : IIncomeExpenseTransactionService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public IncomeExpenseTransactionService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<IncomeExpenseTransaction>> AddIncomeExpenseTransaction(AddIncomeExpenseTransactionDTO incomeExpenseTransaction)
        {
            var serviceResponse = new ServiceResponse<IncomeExpenseTransaction>();
            try
            {
                var incomeExpenseTransactionModel = _mapper.Map<IncomeExpenseTransaction>(incomeExpenseTransaction);
                await _dataContext.IncomeExpenseTransaction.AddAsync(incomeExpenseTransactionModel);
                await _dataContext.SaveChangesAsync();
                serviceResponse.Data = incomeExpenseTransactionModel;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<IncomeExpenseTransaction>>> GetAllIncomeExpenseTransactions()
        {
            var serviceResponse = new ServiceResponse<List<IncomeExpenseTransaction>>();
            try
            {
                var incomeExpenseTransactions = await _dataContext.IncomeExpenseTransaction.ToListAsync();
                        /*.Include(fl => fl.Flats)
                        .ToListAsync();*/

                if (incomeExpenseTransactions != null && incomeExpenseTransactions.Count == 0)
                {
                    serviceResponse.Data = null;
                    throw new Exception($"No data found.");
                }
                else
                {
                    serviceResponse.Data = incomeExpenseTransactions;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<IncomeExpenseTransaction>> GetIncomeExpenseTransactionById(int id)
        {
            var serviceResponse = new ServiceResponse<IncomeExpenseTransaction>();
            try
            {
                var existingIncomeExpenseTransaction = await _dataContext.IncomeExpenseTransaction.FirstOrDefaultAsync(x => x.Id == id);
                if (existingIncomeExpenseTransaction is null)
                {
                    throw new Exception($"IncomeExpenseTransaction with id {id} not found.");
                }
                else
                {
                    serviceResponse.Data = existingIncomeExpenseTransaction;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }


        public async Task<ServiceResponse<IncomeExpenseTransaction>> UpdateIncomeExpenseTransaction(int id, AddIncomeExpenseTransactionDTO incomeExpenseTransaction)
        {
            var serviceResponse = new ServiceResponse<IncomeExpenseTransaction>();
            try
            {
                var existingIncomeExpenseTransaction = await _dataContext.IncomeExpenseTransaction.FirstOrDefaultAsync(x => x.Id == id);
                if (existingIncomeExpenseTransaction is null)
                {
                    throw new Exception($"IncomeExpenseTransaction with id {id} not found.");
                }
                else
                {
                    var incomeExpenseTransactionModel = _mapper.Map<IncomeExpenseTransaction>(incomeExpenseTransaction);
                    existingIncomeExpenseTransaction.Name = incomeExpenseTransactionModel.Name;
                    existingIncomeExpenseTransaction.IncomeExpenseId= incomeExpenseTransactionModel.IncomeExpenseId;
                    existingIncomeExpenseTransaction.TranDate= incomeExpenseTransactionModel.TranDate;
                    existingIncomeExpenseTransaction.Amount= incomeExpenseTransactionModel.Amount;
                    existingIncomeExpenseTransaction.RentId= incomeExpenseTransactionModel.RentId;
                    existingIncomeExpenseTransaction.UserId= incomeExpenseTransactionModel.UserId;
                    
                    await _dataContext.SaveChangesAsync();
                    serviceResponse.Data = existingIncomeExpenseTransaction;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<IncomeExpenseTransaction>> DeleteIncomeExpenseTransaction(int id)
        {
            var serviceResponse = new ServiceResponse<IncomeExpenseTransaction>();
            try
            {
                var existingIncomeExpenseTransaction = await _dataContext.IncomeExpenseTransaction.FirstOrDefaultAsync(x => x.Id == id);
                if (existingIncomeExpenseTransaction is null)
                {
                    throw new Exception($"IncomeExpenseTransaction with id {id} not found.");
                }
                else
                {
                    _dataContext.Remove(existingIncomeExpenseTransaction);
                    await _dataContext.SaveChangesAsync();
                    serviceResponse.Data = existingIncomeExpenseTransaction;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
