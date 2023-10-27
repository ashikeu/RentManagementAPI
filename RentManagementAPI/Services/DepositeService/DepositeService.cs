using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentManagementAPI.Models.DTOs.Deposite;

namespace RentManagementAPI.Services.DepositeService
{
    public class DepositeService : IDepositeService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public DepositeService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<Deposite>> AddDeposite(AddDepositeDTO deposite)
        {
            var serviceResponse = new ServiceResponse<Deposite>();
            try
            {
                var depositeModel = _mapper.Map<Deposite>(deposite);
                await _dataContext.Deposite.AddAsync(depositeModel);
                await _dataContext.SaveChangesAsync();
                serviceResponse.Data = depositeModel;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Deposite>>> GetAllDeposites()
        {
            var serviceResponse = new ServiceResponse<List<Deposite>>();
            try
            {
                var deposites = await _dataContext.Deposite.ToListAsync();

                if (deposites != null && deposites.Count == 0)
                {
                    serviceResponse.Data = null;
                    throw new Exception($"No data found.");
                }
                else
                {
                    serviceResponse.Data = deposites;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Deposite>> GetDepositeById(int id)
        {
            var serviceResponse = new ServiceResponse<Deposite>();
            try
            {
                var existingDeposite = await _dataContext.Deposite.FirstOrDefaultAsync(x => x.Id == id);
                if (existingDeposite is null)
                {
                    throw new Exception($"Deposite with id {id} not found.");
                }
                else
                {
                    serviceResponse.Data = existingDeposite;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }


        public async Task<ServiceResponse<Deposite>> UpdateDeposite(int id, AddDepositeDTO deposite)
        {
            var serviceResponse = new ServiceResponse<Deposite>();
            try
            {
                var existingDeposite = await _dataContext.Deposite.FirstOrDefaultAsync(x => x.Id == id);
                if (existingDeposite is null)
                {
                    throw new Exception($"Deposite with id {id} not found.");
                }
                else
                {
                    var depositeModel = _mapper.Map<Deposite>(deposite);
                    existingDeposite.TotalAmount = depositeModel.TotalAmount;
                    existingDeposite.UserId= depositeModel.UserId;
                    existingDeposite.DepositeAmount = depositeModel.DepositeAmount;
                    existingDeposite.DueAmount = depositeModel.DueAmount;
                    existingDeposite.TranDate = depositeModel.TranDate; 
                    existingDeposite.RentId = depositeModel.RentId;
                    existingDeposite.BuildingId= depositeModel.BuildingId;
                    existingDeposite.FlatId = depositeModel.FlatId;
                    existingDeposite.TenantId = depositeModel.TenantId;
                    await _dataContext.SaveChangesAsync();
                    serviceResponse.Data = existingDeposite;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Deposite>> DeleteDeposite(int id)
        {
            var serviceResponse = new ServiceResponse<Deposite>();
            try
            {
                var existingDeposite = await _dataContext.Deposite.FirstOrDefaultAsync(x => x.Id == id);
                if (existingDeposite is null)
                {
                    throw new Exception($"Deposite with id {id} not found.");
                }
                else
                {
                    _dataContext.Remove(existingDeposite);
                    await _dataContext.SaveChangesAsync();
                    serviceResponse.Data = existingDeposite;
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
