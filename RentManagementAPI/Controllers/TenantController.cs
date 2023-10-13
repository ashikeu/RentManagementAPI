using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentManagementAPI.Models.DTOs.Tenant;
using RentManagementAPI.Services.TenantService;


namespace RentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public TenantController(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("GetAllTenant")]
        public async Task<ActionResult<ServiceResponse<List<Tenant>>>> Get()
        {
            var serviceResponse = await _tenantService.GetAllTenants();
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpGet]
        [Route("GetSingleTenant/{id}")]
        public async Task<ActionResult<ServiceResponse<Tenant>>> GetTenant(int id)
        {
            var serviceResponse = await _tenantService.GetTenantById(id);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpPost]
        [Route("CreateTenant")]
        public async Task<ActionResult<ServiceResponse<List<Tenant>>>> AddTenant([FromBody] AddTenantDTO tenant)
        {
            var serviceResponse = await _tenantService.AddTenant(tenant);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }



        [HttpPut]
        [Route("UpdateTenant/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Tenant>>>> UpdateTenant([FromRoute] int id, AddTenantDTO tenant)
        {
            var serviceResponse = await _tenantService.UpdateTenant(id, tenant);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpDelete]
        [Route("DeleteTenant/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Tenant>>>> DeleteTenant([FromRoute] int id)
        {
            var serviceResponse = await _tenantService.DeleteTenant(id);
            if (serviceResponse is null)
            {
                return NotFound(serviceResponse);
            }
            else
            {
                return Ok(serviceResponse);
            }

        }
    }
} 
