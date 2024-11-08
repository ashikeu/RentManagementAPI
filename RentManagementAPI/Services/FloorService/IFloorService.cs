using RentManagementAPI.Models.DTOs.Floor;

namespace RentManagementAPI.Services.FloorService
{
    public interface IFloorService
    {
        Task<ServiceResponse<List<Floor>>> GetAllFloors();
        Task<ServiceResponse<Floor>> GetFloorById(int id);
        Task<ServiceResponse<Floor>> AddFloor(FloorDTO floor);
        Task<ServiceResponse<Floor>> UpdateFloor(int id, FloorDTO floor);
        Task<ServiceResponse<Floor>> DeleteFloor(int id);



    }
}
