using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentManagementAPI.Models.DTOs.Floor;

namespace RentManagementAPI.Services.FloorService
{
    public class FloorService : IFloorService
    {
       
        private readonly DataContext _dataContext; 
        private readonly IMapper _mapper;
        public FloorService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<Floor>> AddFloor(AddFloorDTO floor)
        {
            var serviceResponse = new ServiceResponse<Floor>();
            try
            {
                var floorModel = _mapper.Map<Floor>(floor);
                await _dataContext.Floor.AddAsync(floorModel);
                await _dataContext.SaveChangesAsync(); 
                serviceResponse.Data = floorModel;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

         public async Task<ServiceResponse<List<Floor>>> GetAllFloors()
        {
            var serviceResponse = new ServiceResponse<List<Floor>>();
            try
            {
                var floors = await _dataContext.Floor
                        
                        .ToListAsync();
               
                if (floors != null && floors.Count == 0)
                {
                    serviceResponse.Data = null;
                    throw new Exception($"No data found.");
                }
                else
                {
                    serviceResponse.Data = floors;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Floor>> GetFloorById(int id)
        {
            var serviceResponse = new ServiceResponse<Floor>();
            try
            {
                var existingFloor = await _dataContext.Floor.FirstOrDefaultAsync(x => x.Id == id);
                if (existingFloor is null)
                {
                    throw new Exception($"Floor with id {id} not found.");
                }
                else
                {
                    serviceResponse.Data = existingFloor;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }


        public async Task<ServiceResponse<Floor>> UpdateFloor(int id, AddFloorDTO floor)
        {
            var serviceResponse = new ServiceResponse<Floor>();
            try
            {
                var existingFloor = await _dataContext.Floor.FirstOrDefaultAsync(x => x.Id == id);
                if (existingFloor is null)
                {
                    throw new Exception($"Floor with id {id} not found.");
                }
                else
                {
                    var floorModel = _mapper.Map<Floor>(floor);
                    existingFloor.Name = floorModel.Name; 
                    existingFloor.IsActive= floorModel.IsActive;
                    existingFloor.UserId= floorModel.UserId;
                    existingFloor.BuildingId= floorModel.BuildingId; 
                    
                    await _dataContext.SaveChangesAsync();
                    serviceResponse.Data = existingFloor;
                } 
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Floor>> DeleteFloor(int id)
        {
            var serviceResponse = new ServiceResponse<Floor>();
            try
            {
                var existingFloor = await _dataContext.Floor.FirstOrDefaultAsync(x => x.Id == id);
                if (existingFloor is null)
                {
                    throw new Exception($"Floor with id {id} not found.");
                }
                else
                {
                    _dataContext.Remove(existingFloor);
                    await _dataContext.SaveChangesAsync();
                    serviceResponse.Data = existingFloor;
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
