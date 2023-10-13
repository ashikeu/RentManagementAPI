using RentManagementAPI.Models.DTOs.Building;

namespace RentManagementAPI.Services.BuildingService
{
    public interface IBuildingService
    {
        Task<ServiceResponse<List<Building>>> GetAllBuildings();
        Task<ServiceResponse<Building>> GetBuildingById(int id);
        Task<ServiceResponse<Building>> AddBuilding(AddBuildingDTO building);
        Task<ServiceResponse<Building>> UpdateBuilding(int id, AddBuildingDTO building);
        Task<ServiceResponse<Building>> DeleteBuilding(int id);
    }
}
