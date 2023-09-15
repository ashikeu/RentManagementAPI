using Microsoft.EntityFrameworkCore;

namespace RentManagementAPI.Services.FloorService
{
    public class FloorService : IFloorService
    {
       
        private readonly DataContext _context;
        public FloorService(DataContext context)
        {
            _context = context;
        }
        public  async Task<List<Floor>> AddFloor(Floor floor)
        {
             _context.Floor.Add(floor);
            await _context.SaveChangesAsync(); 
            return await _context.Floor.ToListAsync();
        } 

        public async Task<List<Floor>?> DeleteFloor(int id)


        {
            var floor = await _context.Floor.FindAsync(id);
            if (floor == null)
                return null; 

            _context.Floor.Remove(floor);

            _context.SaveChanges(); 
            return await _context.Floor.ToListAsync();




        }

        public async Task<List<Floor>> GetAllFloors()
            
        {
            var floors = await _context.Floor.ToListAsync();
            return await _context.Floor.ToListAsync();
        }

        public async Task<Floor?> GetFloor(int id)
        {
            var floor = await _context.Floor.FindAsync(id);
            if (floor == null)
                return null;
            return floor;
        }

        public async Task<List<Floor>?> UpdateFloor(int id, Floor request)
        {
            var floor = await _context.Floor.FindAsync(id);
            if (floor == null)
                return null;

            floor.Name = request.Name;
            await _context.SaveChangesAsync();
            return await _context.Floor.ToListAsync();
        }
    }
}
