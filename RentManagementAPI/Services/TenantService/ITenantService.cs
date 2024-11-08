using RentManagementAPI.Models.DTOs.Tenant;

namespace RentManagementAPI.Services.TenantService
{
    public interface ITenantService
    {
        Task<ServiceResponse<List<Tenant>>> GetAllTenants();
        Task<ServiceResponse<Tenant>> GetTenantById(int id);
        Task<ServiceResponse<Tenant>> AddTenant(TenantDTO tenant);
        Task<ServiceResponse<Tenant>> UpdateTenant(int id, TenantDTO tenant);
        Task<ServiceResponse<Tenant>> DeleteTenant(int id);

    } 
}
