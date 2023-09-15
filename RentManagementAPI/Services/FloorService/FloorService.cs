namespace RentManagementAPI.Services.FloorService
{
    public class FloorService : IFloorService
    {
        public static List<Floor> floors = new List<Floor> {
        new Floor
        {
        Id = 0,
        Name = "First"
        },
            new Floor
            {
                Id = 1,
        Name = "Second"
        } };
        public List<Floor> AddFloor(Floor floor)
        {
            floors.Add(floor);
            return floors;
        }

        public List<Floor> DeleteFloor(int id)


        {
            var floor = floors.Find(x => x.Id == id);
            if (floor == null)
                return null;

            floors.Remove(floor);
            return floors;



           
        }

        public List<Floor> GetAllFloors()
        {
            return floors;
        }

        public Floor GetFloor(int id)
        {
            var floor = floors.Find(x => x.Id == id);
            if (floor == null)
                return null;
            return floor;
        }

        public List<Floor> UpdateFloor(int id, Floor request)
        {
            var floor = floors.Find(x => x.Id == id);
            if (floor == null)
                return null;

            floor.Name = request.Name;
            return floors;
        }
    }
}
