using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentManagementAPI.Services.TenantService;

namespace RentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ITenantService _TenantService;

        public TenantController(ITenantService tenantService)
        {
            _TenantService = tenantService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Tenant>>> GetAllTenants()
        {

            return await _TenantService.GetAllTenants();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Tenant>> GetTenant(int id)

        {
            var result = await _TenantService.GetTenant(id);
            return Ok(result);
        }

        [HttpPost]

        public async Task<ActionResult<List<Tenant>>> AddTenant(Tenant tenant)

        {
            var result = await _TenantService.AddTenant(tenant);
            return Ok(result);
        }



        [HttpPut("{id}")]

        public async Task<ActionResult<List<Tenant>>> UpdateTenant(int id, Tenant request)

        {
            var result = await _TenantService.UpdateTenant(id, request);
            if (result == null)
                return NotFound("tenant not found");
            return Ok(result);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Tenant>?>> DeleteTenant(int id)

        {
            var result = await _TenantService.DeleteTenant(id);

            if (result == null)
                return NotFound("tenant not found");
            return Ok(result);



        }
    }
} 
