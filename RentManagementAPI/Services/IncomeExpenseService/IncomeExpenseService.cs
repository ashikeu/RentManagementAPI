using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentManagementAPI.Models.DTOs.IncomeExpense;

namespace RentManagementAPI.Services.IncomeExpenseService
{
    public class IncomeExpenseService : IIncomeExpenseService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public IncomeExpenseService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<IncomeExpense>> AddIncomeExpense(AddIncomeExpenseDTO incomeExpense)
        {
            var serviceResponse = new ServiceResponse<IncomeExpense>();
            try
            {
                var incomeExpenseModel = _mapper.Map<IncomeExpense>(incomeExpense);
                await _dataContext.IncomeExpense.AddAsync(incomeExpenseModel);
                await _dataContext.SaveChangesAsync();
                serviceResponse.Data = incomeExpenseModel;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<IncomeExpense>>> GetAllIncomeExpenses()
        {
            var serviceResponse = new ServiceResponse<List<IncomeExpense>>();
            try
            {
                var incomeExpenses = await _dataContext.IncomeExpense.ToListAsync();
                        /*.Include(fl => fl.Flats)
                        .ToListAsync();*/

                if (incomeExpenses != null && incomeExpenses.Count == 0)
                {
                    serviceResponse.Data = null;
                    throw new Exception($"No data found.");
                }
                else
                {
                    serviceResponse.Data = incomeExpenses;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<IncomeExpense>> GetIncomeExpenseById(int id)
        {
            var serviceResponse = new ServiceResponse<IncomeExpense>();
            try
            {
                var existingIncomeExpense = await _dataContext.IncomeExpense.FirstOrDefaultAsync(x => x.Id == id);
                if (existingIncomeExpense is null)
                {
                    throw new Exception($"IncomeExpense with id {id} not found.");
                }
                else
                {
                    serviceResponse.Data = existingIncomeExpense;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }


        public async Task<ServiceResponse<IncomeExpense>> UpdateIncomeExpense(int id, AddIncomeExpenseDTO incomeExpense)
        {
            var serviceResponse = new ServiceResponse<IncomeExpense>();
            try
            {
                var existingIncomeExpense = await _dataContext.IncomeExpense.FirstOrDefaultAsync(x => x.Id == id);
                if (existingIncomeExpense is null)
                {
                    throw new Exception($"IncomeExpense with id {id} not found.");
                }
                else
                {
                    var incomeExpenseModel = _mapper.Map<IncomeExpense>(incomeExpense);
                    existingIncomeExpense.Name = incomeExpenseModel.Name;
                    existingIncomeExpense.IncomeExpenseType = incomeExpenseModel.IncomeExpenseType;

                    existingIncomeExpense.UserId = incomeExpenseModel.UserId;
                    existingIncomeExpense.BuildingId= incomeExpenseModel.BuildingId;
                    
                    await _dataContext.SaveChangesAsync();
                    serviceResponse.Data = existingIncomeExpense;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<IncomeExpense>> DeleteIncomeExpense(int id)
        {
            var serviceResponse = new ServiceResponse<IncomeExpense>();
            try
            {
                var existingIncomeExpense = await _dataContext.IncomeExpense.FirstOrDefaultAsync(x => x.Id == id);
                if (existingIncomeExpense is null)
                {
                    throw new Exception($"IncomeExpense with id {id} not found.");
                }
                else
                {
                    _dataContext.Remove(existingIncomeExpense);
                    await _dataContext.SaveChangesAsync();
                    serviceResponse.Data = existingIncomeExpense;
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
