using Microsoft.EntityFrameworkCore;

namespace RentManagementAPI.Services.DepositeService
{
    public class DepositeService : IDepositeService
    {
        private readonly DataContext _context;
        public DepositeService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Deposite>> AddDeposite(Deposite deposite)
        {
            _context.Deposite.Add(deposite);
            await _context.SaveChangesAsync();
            return await _context.Deposite.ToListAsync();
        }

        public async Task<List<Deposite>?> DeleteDeposite(int id)


        {
            var deposite = await _context.Deposite.FindAsync(id);
            if (deposite == null)
                return null;

            _context.Deposite.Remove(deposite);

            _context.SaveChanges();
            return await _context.Deposite.ToListAsync();




        }

        public async Task<List<Deposite>> GetAllDeposites()

        {

            return await _context.Deposite.ToListAsync();
        }

        public async Task<Deposite?> GetDeposite(int id)
        {
            var deposite = await _context.Deposite.FindAsync(id);
            if (deposite == null)
                return null;
            return deposite;
        }

        public async Task<List<Deposite>?> UpdateDeposite(int id, Deposite request)
        {
            var deposite = await _context.Deposite.FindAsync(id);
            if (deposite == null)
                return null;

            deposite.TotalAmount = request.TotalAmount;
            deposite.DepositeAmount = request.DepositeAmount; 
            deposite.DueAmount = request.DueAmount;
            deposite.DepositeDate = request.DepositeDate;
            await _context.SaveChangesAsync();
            return await _context.Deposite.ToListAsync();
        }
    } 
}
