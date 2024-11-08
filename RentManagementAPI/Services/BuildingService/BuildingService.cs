using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentManagementAPI.Models.DTOs.Building;

namespace RentManagementAPI.Services.BuildingService
{
    public class BuildingService : IBuildingService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public BuildingService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<Building>> AddBuilding(BuildingDTO building)
        {
            var serviceResponse = new ServiceResponse<Building>();
            try
            {
                var buildingModel = _mapper.Map<Building>(building);
                await _dataContext.Building.AddAsync(buildingModel);
                await _dataContext.SaveChangesAsync();
                serviceResponse.Data = buildingModel;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Building>>> GetAllBuildings()
        {
            var serviceResponse = new ServiceResponse<List<Building>>();
            try
            { 
                var buildings = await _dataContext.Building
                       
                        .ToListAsync();

                if (buildings != null && buildings.Count == 0)  
                {
                    serviceResponse.Data = null;
                    throw new Exception($"No data found.");
                }
                else
                {
                    serviceResponse.Data = buildings;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Building>> GetBuildingById(int id)
        {
            var serviceResponse = new ServiceResponse<Building>();
            try
            {
                var existingBuilding = await _dataContext.Building.FirstOrDefaultAsync(x => x.Id == id);
                if (existingBuilding is null)
                {
                    throw new Exception($"Building with id {id} not found.");
                }
                else
                {
                    serviceResponse.Data = existingBuilding;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }


        public async Task<ServiceResponse<Building>> UpdateBuilding(int id, BuildingDTO building)
        {
            var serviceResponse = new ServiceResponse<Building>();
            try
            {
                var existingBuilding = await _dataContext.Building.FirstOrDefaultAsync(x => x.Id == id);
                if (existingBuilding is null)
                {
                    throw new Exception($"Building with id {id} not found.");
                }
                else
                {
                    var buildingModel = _mapper.Map<Building>(building);
                    existingBuilding.Name = buildingModel.Name;
                    existingBuilding.Address = buildingModel.Address;
                    existingBuilding.IsActive = buildingModel.IsActive;
                    existingBuilding.UserId = buildingModel.UserId;
                    
                    await _dataContext.SaveChangesAsync();
                    serviceResponse.Data = existingBuilding;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Building>> DeleteBuilding(int id)
        {
            var serviceResponse = new ServiceResponse<Building>();
            try
            {
                var existingBuilding = await _dataContext.Building.FirstOrDefaultAsync(x => x.Id == id);
                if (existingBuilding is null)
                {
                    throw new Exception($"Building with id {id} not found.");
                }
                else
                {
                    _dataContext.Remove(existingBuilding);
                    await _dataContext.SaveChangesAsync();
                    serviceResponse.Data = existingBuilding;
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
