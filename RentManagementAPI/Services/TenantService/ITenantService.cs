namespace RentManagementAPI.Services.TenantService
{
    public interface ITenantService
    {
        Task<List<Tenant>> GetAllTenants();

        Task<Tenant> GetTenant(int id);

        Task<List<Tenant>> AddTenant(Tenant tenant);

        Task<List<Tenant>> UpdateTenant(int id, Tenant request);
        Task<List<Tenant>> DeleteTenant(int id);

    }
}
