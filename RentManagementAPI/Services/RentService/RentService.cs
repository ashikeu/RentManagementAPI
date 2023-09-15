using Microsoft.EntityFrameworkCore;

namespace RentManagementAPI.Services.RentService
{
    public class RentService : IRentService
    {
        private readonly DataContext _context;
        public RentService(DataContext context) 
        {
            _context = context;
        }
        public async Task<List<Rent>> AddRent(Rent rent)
        {
            _context.Rent.Add(rent);
            await _context.SaveChangesAsync();
            return await _context.Rent.ToListAsync();
        }

        public async Task<List<Rent>?> DeleteRent(int id)


        {
            var rent = await _context.Rent.FindAsync(id);
            if (rent == null)
                return null;

            _context.Rent.Remove(rent);

            _context.SaveChanges();
            return await _context.Rent.ToListAsync();




        }

        public async Task<List<Rent>> GetAllRents()

        {

            return await _context.Rent.ToListAsync();
        }

        public async Task<Rent?> GetRent(int id)
        {
            var rent = await _context.Rent.FindAsync(id);
            if (rent == null)
                return null;
            return rent;
        }

        public async Task<List<Rent>?> UpdateRent(int id, Rent request)
        {
            var rent = await _context.Rent.FindAsync(id);
            if (rent == null)
                return null;

            rent.RentMonth = request.RentMonth;
            rent.TotalAmount = request.TotalAmount; 
            rent.IsPaid = request.IsPaid;

            await _context.SaveChangesAsync();
            return await _context.Rent.ToListAsync();
        }
    }
} 
