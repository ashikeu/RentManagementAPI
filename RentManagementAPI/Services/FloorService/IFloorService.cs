namespace RentManagementAPI.Services.FloorService
{
    public interface IFloorService
    {
        Task<List<Floor>> GetAllFloors();

        Task<Floor> GetFloor(int id);

        Task<List<Floor>> AddFloor(Floor floor);

        Task<List<Floor>> UpdateFloor(int id, Floor request);
        Task<List<Floor>> DeleteFloor(int id);



    }
}
