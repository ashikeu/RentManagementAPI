using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentManagementAPI.Models.DTOs.PropertyInfo;
using RentManagementAPI.Services.PropertyInfo;


namespace RentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyInfoController : ControllerBase
    {
        private readonly IPropertyInfoService _propertyInfoService;
        private readonly IMapper _mapper;

        public PropertyInfoController(IPropertyInfoService propertyInfoService, IMapper mapper)
        {
            _propertyInfoService = propertyInfoService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("GetAllPropertyInfo")]
        public async Task<ActionResult<ServiceResponse<List<PropertyInfo>>>> Get()
        {
            var serviceResponse = await _propertyInfoService.GetAllPropertyInfos();
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpGet]
        [Route("GetSinglePropertyInfo/{id}")]

        public async Task<ActionResult<ServiceResponse<PropertyInfo>>> GetPropertyInfo(int id)
        {
            var serviceResponse = await _propertyInfoService.GetPropertyInfoById(id);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpPost]
        [Route("CreatePropertyInfo")]
        public async Task<ActionResult<ServiceResponse<List<PropertyInfo>>>> AddPropertyInfo([FromBody] AddPropertyInfoDTO propertyInfo)
        {
            var serviceResponse = await _propertyInfoService.AddPropertyInfo(propertyInfo);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }



        [HttpPut]
        [Route("UpdatePropertyInfo/{id}")]

        public async Task<ActionResult<ServiceResponse<List<PropertyInfo>>>> UpdatePropertyInfo([FromRoute] int id, AddPropertyInfoDTO propertyInfo)
        {
            var serviceResponse = await _propertyInfoService.UpdatePropertyInfo(id, propertyInfo);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpDelete]
        [Route("DeletePropertyInfo/{id}")]

        public async Task<ActionResult<ServiceResponse<List<PropertyInfo>>>> DeletePropertyInfo([FromRoute] int id)
        {
            var serviceResponse = await _propertyInfoService.DeletePropertyInfo(id);
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
