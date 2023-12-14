using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentManagementAPI.Models.DTOs.Rent;

namespace RentManagementAPI.Services.RentService
{
    public class RentService : IRentService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public RentService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<Rent>> AddRent(AddRentDTO rent)
        {
            var serviceResponse = new ServiceResponse<Rent>();
            try
            { 

                var rentModel = _mapper.Map<Rent>(rent);
                rentModel.ReciptNo=Guid.NewGuid().ToString();   
                await _dataContext.Rent.AddAsync(rentModel); 
                await _dataContext.SaveChangesAsync();
                serviceResponse.Data = rentModel;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Rent>>> GetAllRents()
        {
            var serviceResponse = new ServiceResponse<List<Rent>>();
            try
            {
                var rents = await _dataContext.Rent.ToListAsync();
                /* .Include(dpst => dpst.Deposits)*/


                if (rents != null && rents.Count == 0)
                {
                    serviceResponse.Data = null;
                    throw new Exception($"No data found.");
                }
                else
                {
                    serviceResponse.Data = rents;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Rent>> GetRentById(int id)
        {
            var serviceResponse = new ServiceResponse<Rent>();
            try
            {
                var existingRent = await _dataContext.Rent.FirstOrDefaultAsync(x => x.Id == id);
                if (existingRent is null)
                {
                    throw new Exception($"Rent with id {id} not found.");
                }
                else
                {
                    serviceResponse.Data = existingRent;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }


        public async Task<ServiceResponse<Rent>> UpdateRent(int id, AddRentDTO rent)
        {
            var serviceResponse = new ServiceResponse<Rent>();
            try
            {
                var existingRent = await _dataContext.Rent.FirstOrDefaultAsync(x => x.Id == id);
                if (existingRent is null)
                {
                    throw new Exception($"Rent with id {id} not found.");
                }
                else
                {
                    var rentModel = _mapper.Map<Rent>(rent);
                    existingRent.RentMonth = rentModel.RentMonth;
                    existingRent.ServiceCharge = rentModel.ServiceCharge;
                    existingRent.WaterBill= rentModel.WaterBill;
                    existingRent.GasBill= rentModel.GasBill;
                    existingRent.RentAmount= rentModel.RentAmount;
                    existingRent.TotalAmount = rentModel.TotalAmount;
                    existingRent.DueAmount= rentModel.DueAmount;
                    existingRent.UserId= rentModel.UserId;
                    existingRent.IsPrinted= rentModel.IsPrinted;
                    
                    existingRent.IsPaid = rentModel.IsPaid;
                    existingRent.FlatId = rentModel.FlatId;
                    existingRent.TenantId = rentModel.TenantId;
                    existingRent.BuildingId= rentModel.BuildingId;

                    await _dataContext.SaveChangesAsync();
                    serviceResponse.Data = existingRent;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Rent>> DeleteRent(int id)
        {
            var serviceResponse = new ServiceResponse<Rent>();
            try
            {
                var existingRent = await _dataContext.Rent.FirstOrDefaultAsync(x => x.Id == id);
                if (existingRent is null)
                {
                    throw new Exception($"Rent with id {id} not found.");
                }
                else
                {
                    _dataContext.Remove(existingRent);
                    await _dataContext.SaveChangesAsync();
                    serviceResponse.Data = existingRent;
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
