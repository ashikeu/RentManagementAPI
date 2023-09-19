using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentManagementAPI.Models.DTOs.Floor;
using RentManagementAPI.Services.FloorService;
using System.Xml.Linq;

namespace RentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloorController : ControllerBase
    {
        private readonly IFloorService _floorService;
        private readonly IMapper _mapper;

        public FloorController(IFloorService floorService, IMapper mapper)
        {
            _floorService = floorService;
            _mapper = mapper;
        }


        [HttpGet] 
        [Route("GetAllFloor")]
        public async Task<ActionResult<ServiceResponse<List<Floor>>>> Get()
        {
            var serviceResponse = await _floorService.GetAllFloors();
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpGet]
        [Route("GetSingleFloor/{id}")]

        public async Task<ActionResult<ServiceResponse<Floor>>> GetFloor(int id)
        {
            var serviceResponse = await _floorService.GetFloorById(id);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpPost]
        [Route("CreateFloor")]
        public async Task<ActionResult<ServiceResponse<List<Floor>>>> AddFloor([FromBody] AddFloorDTO floor)
        {
            var serviceResponse = await _floorService.AddFloor(floor);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }



        [HttpPut]
        [Route("UpdateFloor/{id}")]

        public async Task<ActionResult<ServiceResponse<List<Floor>>>> UpdateFloor([FromRoute] int id, AddFloorDTO floor)
        {
            var serviceResponse = await _floorService.UpdateFloor(id, floor);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpDelete]
        [Route("DeleteFloor/{id}")]

        public async Task<ActionResult<ServiceResponse<List<Floor>>>> DeleteFloor([FromRoute] int id)
        {
            var serviceResponse = await _floorService.DeleteFloor(id);
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
