using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentManagementAPI.Models.DTOs.Rent;
using RentManagementAPI.Services.RentService;


namespace RentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly IRentService _rentService;
        private readonly IMapper _mapper;

        public RentController(IRentService rentService, IMapper mapper)
        {
            _rentService = rentService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("GetAllRent")]
        public async Task<ActionResult<ServiceResponse<List<Rent>>>> Get()
        {
            var serviceResponse = await _rentService.GetAllRents();
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpGet]
        [Route("GetSingleRent/{id}")]
        public async Task<ActionResult<ServiceResponse<Rent>>> GetRent(int id)
        {
            var serviceResponse = await _rentService.GetRentById(id);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpPost]
        [Route("CreateRent")]
        public async Task<ActionResult<ServiceResponse<List<Rent>>>> AddRent([FromBody] AddRentDTO rent)
        {
            var serviceResponse = await _rentService.AddRent(rent);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }



        [HttpPut]
        [Route("UpdateRent/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Rent>>>> UpdateRent([FromRoute] int id, AddRentDTO rent)
        {
            var serviceResponse = await _rentService.UpdateRent(id, rent);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpDelete]
        [Route("DeleteRent/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Rent>>>> DeleteRent([FromRoute] int id)
        {
            var serviceResponse = await _rentService.DeleteRent(id);
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
