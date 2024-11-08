using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentManagementAPI.Models.DTOs.Tenant;

namespace RentManagementAPI.Services.TenantService
{
    public class TenantService : ITenantService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public TenantService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<Tenant>> AddTenant(TenantDTO tenant)
        {
            var serviceResponse = new ServiceResponse<Tenant>();
            try
            {
                var tenantModel = _mapper.Map<Tenant>(tenant);
                await _dataContext.Tenant.AddAsync(tenantModel);
                await _dataContext.SaveChangesAsync();
                serviceResponse.Data = tenantModel;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Tenant>>> GetAllTenants()
        {
            var serviceResponse = new ServiceResponse<List<Tenant>>();
            try
            {
                var tenants = await _dataContext.Tenant.ToListAsync();
                /*  .Include(flat => flat.Flats) 
                  .ToListAsync();*/

                if (tenants != null && tenants.Count == 0)
                {
                    serviceResponse.Data = null;
                    throw new Exception($"No data found.");
                }
                else
                {
                    serviceResponse.Data = tenants;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Tenant>> GetTenantById(int id)
        {
            var serviceResponse = new ServiceResponse<Tenant>();
            try
            {
                var existingTenant = await _dataContext.Tenant.FirstOrDefaultAsync(x => x.Id == id);
                if (existingTenant is null)
                {
                    throw new Exception($"Tenant with id {id} not found.");
                }
                else
                {
                    serviceResponse.Data = existingTenant;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<Tenant>> UpdateTenant(int id, TenantDTO tenant)
        {
            var serviceResponse = new ServiceResponse<Tenant>();
            try
            {
                var existingTenant = await _dataContext.Tenant.FirstOrDefaultAsync(x => x.Id == id);
                if (existingTenant is null)
                {
                    throw new Exception($"Tenant with id {id} not found.");
                }
                else
                {
                    var tenantModel = _mapper.Map<Tenant>(tenant);
                    existingTenant.Name = tenantModel.Name;
                    existingTenant.NID = tenantModel.NID;
                    existingTenant.PassportNo = tenantModel.PassportNo;
                    existingTenant.BirthCertificateNo = tenantModel.BirthCertificateNo;
                    existingTenant.MobileNo = tenantModel.MobileNo;
                    existingTenant.NoofFamilyMember = tenantModel.NoofFamilyMember;
                    existingTenant.ArrivalDate = tenantModel.ArrivalDate;
                    existingTenant.AdvanceAmount= tenantModel.AdvanceAmount;
                    existingTenant.IsActive= tenantModel.IsActive;
                    existingTenant.TenantNidImage= tenantModel.TenantNidImage;
                    existingTenant.TenantImage = tenantModel.TenantImage;
                    existingTenant.RentAmountChangeDate = tenantModel.RentAmountChangeDate;
                    existingTenant.UserId= tenantModel.UserId;
                    existingTenant.EmgMobileNo= tenantModel.EmgMobileNo;
                    existingTenant.BuildingId = tenantModel.BuildingId;
                    /*existingTenant.RentAmount = tenantModel.RentAmount;
                    existingTenant.UtilityBill = tenantModel.UtilityBill;
                    existingTenant.GasBill = tenantModel.GasBill;
                    existingTenant.WaterBill = tenantModel.WaterBill;
                    existingTenant.TotalAmount = tenantModel.TotalAmount;
                    
                    existingTenant.FlatId = tenantModel.FlatId;*/
                    await _dataContext.SaveChangesAsync();
                    serviceResponse.Data = existingTenant;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Tenant>> DeleteTenant(int id)
        {
            var serviceResponse = new ServiceResponse<Tenant>();
            try
            {
                var existingTenant = await _dataContext.Tenant.FirstOrDefaultAsync(x => x.Id == id);
                if (existingTenant is null)
                {
                    throw new Exception($"Tenant with id {id} not found.");
                }
                else
                {
                    _dataContext.Remove(existingTenant);
                    await _dataContext.SaveChangesAsync();
                    serviceResponse.Data = existingTenant;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
