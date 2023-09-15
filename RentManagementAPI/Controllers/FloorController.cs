using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentManagementAPI.Services.FloorService;
using System.Xml.Linq;

namespace RentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloorController : ControllerBase
    {
        private readonly IFloorService _FloorService;

        public FloorController(IFloorService floorService) 
        {
            _FloorService = floorService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Floor>>> GetAllFloors()
        {

            return await _FloorService.GetAllFloors();
        }

        [HttpGet("{id}")]
        
        public async Task<ActionResult<Floor>> GetFloor(int id)

        {
           var result = await _FloorService.GetFloor(id);
            return Ok(result);
        }
       
        [HttpPost]

        public async Task<ActionResult<List<Floor>>> AddFloor(Floor floor)

        {
           var result = await _FloorService.AddFloor(floor);
            return Ok(result);
        }

        
        
        [HttpPut("{id}")]

        public async Task<ActionResult<List<Floor>>> UpdateFloor(int id, Floor request)

        {
            var result = await _FloorService.UpdateFloor(id, request);
            if (result == null) 
                return NotFound("floor not found");
            return Ok(result);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Floor>?>> DeleteFloor(int id)

        {
            var result = await _FloorService.DeleteFloor(id);

            if (result == null)
                return NotFound("floor not found");
            return Ok(result);  


           
        }
    }
}
