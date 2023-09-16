using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentManagementAPI.Models.DTOs.Deposite;
using RentManagementAPI.Services.DepositeService;
using RentManagementAPI.Services.DepositeService;

namespace RentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositeController : ControllerBase
    {
        private readonly IDepositeService _depositeService;
        private readonly IMapper _mapper;

        public DepositeController(IDepositeService depositeService, IMapper mapper)
        {
            _depositeService = depositeService;
            _mapper = mapper;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<Deposite>>>> Get()
        {
            var serviceResponse = await _depositeService.GetAllDeposites();
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Deposite>>> GetDeposite(int id)
        {
            var serviceResponse = await _depositeService.GetDepositeById(id);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Deposite>>>> AddDeposite([FromBody] AddDepositeDTO deposite)
        {
            var serviceResponse = await _depositeService.AddDeposite(deposite);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }



        [HttpPut("{id:int}")]
        public async Task<ActionResult<ServiceResponse<List<Deposite>>>> UpdateDeposite([FromRoute] int id, AddDepositeDTO deposite)
        {
            var serviceResponse = await _depositeService.UpdateDeposite(id, deposite);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ServiceResponse<List<Deposite>>>> DeleteDeposite([FromRoute] int id)
        {
            var serviceResponse = await _depositeService.DeleteDeposite(id);
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
