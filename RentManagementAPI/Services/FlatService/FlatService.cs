using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentManagementAPI.Models;
using RentManagementAPI.Models.DTOs.Flat;

namespace RentManagementAPI.Services.FlatService
{
    public class FlatService : IFlatService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public FlatService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<Flat>> AddFlat(AddFlatDTO flat)
        {
            var serviceResponse = new ServiceResponse<Flat>(); 
            try
            {
                var flatModel = _mapper.Map<Flat>(flat);
                await _dataContext.Flat.AddAsync(flatModel);
                await _dataContext.SaveChangesAsync();
                serviceResponse.Data = flatModel;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Flat>>> GetAllFlats()
        {
            var serviceResponse = new ServiceResponse<List<Flat>>();
            try
            {
                var flats = await _dataContext.Flat.Include(tnt => tnt.Tenant).Include(flr => flr.Floor).ToListAsync();

                if (flats != null && flats.Count == 0)
                {
                    serviceResponse.Data = null;
                    throw new Exception($"No data found.");
                }
                else
                {
                    serviceResponse.Data = flats;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Flat>> GetFlatById(int id)
        {
            var serviceResponse = new ServiceResponse<Flat>();
            try
            {
                var existingFlat = await _dataContext.Flat.FirstOrDefaultAsync(x => x.Id == id);
                if (existingFlat is null)
                {
                    throw new Exception($"Flat with id {id} not found.");
                }
                else
                {
                    serviceResponse.Data = existingFlat;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }


        public async Task<ServiceResponse<Flat>> UpdateFlat(int id, AddFlatDTO flat)
        {
            var serviceResponse = new ServiceResponse<Flat>();
            try
            {
                var existingFlat = await _dataContext.Flat.FirstOrDefaultAsync(x => x.Id == id);
                if (existingFlat is null)
                {
                    throw new Exception($"Flat with id {id} not found.");
                } 
                else
                {
                    var FlatModel = _mapper.Map<Flat>(flat);
                    existingFlat.Name = FlatModel.Name;
                    existingFlat.MasterbedRoom = FlatModel.MasterbedRoom;
                    existingFlat.Bedroom= FlatModel.Bedroom;
                    existingFlat.Washroom= FlatModel.Washroom;
                    existingFlat.FlatSize = FlatModel.FlatSize;
                    existingFlat.FlatSide = FlatModel.FlatSide;
                    existingFlat.FloorId = FlatModel.FloorId;
                    existingFlat.UserId= FlatModel.UserId;
                    existingFlat.TenantId= FlatModel.TenantId;
                    existingFlat.IsActive= FlatModel.IsActive;
                    existingFlat.GasBill= FlatModel.GasBill;
                    existingFlat.WaterBill= FlatModel.WaterBill;
                    existingFlat.ServiceCharge= FlatModel.ServiceCharge;
                    existingFlat.RentAmount= FlatModel.RentAmount;
                    await _dataContext.SaveChangesAsync();
                    serviceResponse.Data = existingFlat;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Flat>> DeleteFlat(int id)
        {
            var serviceResponse = new ServiceResponse<Flat>();
            try
            {
                var existingFlat = await _dataContext.Flat.FirstOrDefaultAsync(x => x.Id == id);
                if (existingFlat is null)
                {
                    throw new Exception($"Flat with id {id} not found.");
                }
                else
                {
                    _dataContext.Remove(existingFlat);
                    await _dataContext.SaveChangesAsync();
                    serviceResponse.Data = existingFlat;
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
