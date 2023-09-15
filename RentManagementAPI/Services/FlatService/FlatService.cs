using Microsoft.EntityFrameworkCore;

namespace RentManagementAPI.Services.FlatService
{
    public class FlatService : IFlatService
    {
        private readonly DataContext _context;
        public FlatService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Flat>> AddFlat(Flat flat)
        {
            _context.Flat.Add(flat);
            await _context.SaveChangesAsync();
            return await _context.Flat.ToListAsync();
        }

        public async Task<List<Flat>?> DeleteFlat(int id)


        {
            var flat = await _context.Flat.FindAsync(id);
            if (flat == null)
                return null;

            _context.Flat.Remove(flat);

            _context.SaveChanges();
            return await _context.Flat.ToListAsync();




        }

        public async Task<List<Flat>> GetAllFlats()

        {
           
            return await _context.Flat.ToListAsync();
        }

        public async Task<Flat?> GetFlat(int id)
        {
            var flat = await _context.Flat.FindAsync(id);
            if (flat == null)
                return null;
            return flat;
        }

        public async Task<List<Flat>?> UpdateFlat(int id, Flat request)
        {
            var flat = await _context.Flat.FindAsync(id);
            if (flat == null)
                return null; 

            flat.Name = request.Name;
            flat.MasterbedRoom = request.MasterbedRoom;
            flat.FlatSize = request.FlatSize;
            flat.FlatSide = request.FlatSide;

            await _context.SaveChangesAsync();
            return await _context.Flat.ToListAsync();
        }
    }
}
