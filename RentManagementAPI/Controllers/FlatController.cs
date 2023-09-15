using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentManagementAPI.Services.FlatService;


namespace RentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatController : ControllerBase
    {
        private readonly IFlatService _FlatService;

        public FlatController(IFlatService flatService)
        {
            _FlatService = flatService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Flat>>> GetAllFlats()
        {

            return await _FlatService.GetAllFlats();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Flat>> GetFlat(int id)

        {
            var result = await _FlatService.GetFlat(id);
            return Ok(result);
        }

        [HttpPost]

        public async Task<ActionResult<List<Flat>>> AddFlat(Flat flat)

        {
            var result = await _FlatService.AddFlat(flat);
            return Ok(result);
        }



        [HttpPut("{id}")]

        public async Task<ActionResult<List<Flat>>> UpdateFlat(int id, Flat request)

        {
            var result = await _FlatService.UpdateFlat(id, request);
            if (result == null)
                return NotFound("flat not found");
            return Ok(result);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Flat>?>> DeleteFlat(int id)

        {
            var result = await _FlatService.DeleteFlat(id);

            if (result == null)
                return NotFound("flat not found");
            return Ok(result);



        }
    }
} 
