using Microsoft.EntityFrameworkCore;

namespace RentManagementAPI.Services.TenantService
{
    public class TenantService : ITenantService
    {
        private readonly DataContext _context;
        public TenantService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Tenant>> AddTenant(Tenant tenant)
        {
            _context.Tenant.Add(tenant);
            await _context.SaveChangesAsync();
            return await _context.Tenant.ToListAsync();
        }

        public async Task<List<Tenant>?> DeleteTenant(int id)


        {
            var tenant = await _context.Tenant.FindAsync(id);
            if (tenant == null)
                return null;

            _context.Tenant.Remove(tenant);

            _context.SaveChanges();
            return await _context.Tenant.ToListAsync();




        }

        public async Task<List<Tenant>> GetAllTenants()

        {

            return await _context.Tenant.ToListAsync();
        }

        public async Task<Tenant?> GetTenant(int id)
        {
            var tenant = await _context.Tenant.FindAsync(id);
            if (tenant == null)
                return null;
            return tenant;
        }

        public async Task<List<Tenant>?> UpdateTenant(int id, Tenant request)
        {
            var tenant = await _context.Tenant.FindAsync(id);
            if (tenant == null)
                return null;

            tenant.Name = request.Name;
            tenant.NID = request.NID;
            tenant.PassportNo = request.PassportNo;
            tenant.BirthCertificateNo = request.BirthCertificateNo;
            tenant.MobileNo = request.MobileNo;
            tenant.NoofFamilyMember = request.NoofFamilyMember;
            tenant.ArrivalDate = request.ArrivalDate;
            tenant.RentAmount = request.RentAmount;
            tenant.ElectricityBill = request.ElectricityBill;
            tenant.GasBill = request.GasBill;
            tenant.WaterBill = request.WaterBill;
            tenant.TotalAmount = request.TotalAmount;

            await _context.SaveChangesAsync();
            return await _context.Tenant.ToListAsync();
        }
    }
}
