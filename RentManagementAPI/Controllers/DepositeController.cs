using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentManagementAPI.Services.DepositeService;

namespace RentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositeController : ControllerBase
    {
        private readonly IDepositeService _DepositeService;

        public DepositeController(IDepositeService depositeService)
        {
            _DepositeService = depositeService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Deposite>>> GetAllDeposites()
        {

            return await _DepositeService.GetAllDeposites();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Deposite>> GetDeposite(int id)

        {
            var result = await _DepositeService.GetDeposite(id);
            return Ok(result);
        }

        [HttpPost]

        public async Task<ActionResult<List<Deposite>>> AddDeposite(Deposite deposite)

        {
            var result = await _DepositeService.AddDeposite(deposite);
            return Ok(result);
        }



        [HttpPut("{id}")]

        public async Task<ActionResult<List<Deposite>>> UpdateDeposite(int id, Deposite request)

        {
            var result = await _DepositeService.UpdateDeposite(id, request);
            if (result == null)
                return NotFound(" deposite not found");
            return Ok(result);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Deposite>?>> DeleteDeposite(int id)

        {
            var result = await _DepositeService.DeleteDeposite(id);

            if (result == null)
                return NotFound(" deposite not found");
            return Ok(result);



        }
    }
}
