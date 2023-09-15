namespace RentManagementAPI.Services.FloorService
{
    public interface IFloorService
    {
        List<Floor> GetAllFloors();

        Floor GetFloor(int id);

        List<Floor> AddFloor(Floor floor);

        List<Floor> UpdateFloor(int id, Floor request);
        List<Floor> DeleteFloor(int id);



    }
}
