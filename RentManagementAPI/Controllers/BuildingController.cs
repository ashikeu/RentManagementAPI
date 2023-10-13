using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentManagementAPI.Models.DTOs.Building;
using RentManagementAPI.Services.BuildingService;

namespace RentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _buildingService;
        private readonly IMapper _mapper;

        public BuildingController(IBuildingService buildingService, IMapper mapper)
        {
            _buildingService = buildingService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("GetAllBuilding")]
        public async Task<ActionResult<ServiceResponse<List<Building>>>> Get()
        {
            var serviceResponse = await _buildingService.GetAllBuildings();
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpGet]
        [Route("GetSingleBuilding/{id}")]

        public async Task<ActionResult<ServiceResponse<Building>>> GetBuilding(int id)
        {
            var serviceResponse = await _buildingService.GetBuildingById(id);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpPost]
        [Route("CreateBuilding")]
        public async Task<ActionResult<ServiceResponse<List<Building>>>> AddBuilding([FromBody] AddBuildingDTO building)
        {
            var serviceResponse = await _buildingService.AddBuilding(building);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }



        [HttpPut]
        [Route("UpdateBuilding/{id}")]

        public async Task<ActionResult<ServiceResponse<List<Building>>>> UpdateBuilding([FromRoute] int id, AddBuildingDTO building)
        {
            var serviceResponse = await _buildingService.UpdateBuilding(id, building);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpDelete]
        [Route("DeleteBuilding/{id}")]

        public async Task<ActionResult<ServiceResponse<List<Building>>>> DeleteBuilding([FromRoute] int id)
        {
            var serviceResponse = await _buildingService.DeleteBuilding(id);
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
