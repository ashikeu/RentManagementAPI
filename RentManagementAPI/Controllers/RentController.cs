using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentManagementAPI.Services.RentService;

namespace RentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly IRentService _RentService;

        public RentController(IRentService rentService)
        {
            _RentService = rentService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Rent>>> GetAllRents()
        {

            return await _RentService.GetAllRents();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Rent>> GetRent(int id)

        {
            var result = await _RentService.GetRent(id);
            return Ok(result);
        }

        [HttpPost]

        public async Task<ActionResult<List<Rent>>> AddRent(Rent rent)

        {
            var result = await _RentService.AddRent(rent);
            return Ok(result);
        }



        [HttpPut("{id}")]

        public async Task<ActionResult<List<Rent>>> UpdateRent(int id, Rent request)

        {
            var result = await _RentService.UpdateRent(id, request);
            if (result == null)
                return NotFound("rent not found");
            return Ok(result);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Rent>?>> DeleteRent(int id)

        {
            var result = await _RentService.DeleteRent(id);

            if (result == null)
                return NotFound("rent not found");
            return Ok(result);



        }
    }
}
