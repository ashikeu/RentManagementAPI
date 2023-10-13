using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentManagementAPI.Models.DTOs.IncomeExpense;
using RentManagementAPI.Services.IncomeExpenseService;

namespace RentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeExpenseController : ControllerBase
    {
        private readonly IIncomeExpenseService _incomeExpenseService;
        private readonly IMapper _mapper;

        public IncomeExpenseController(IIncomeExpenseService incomeExpenseService, IMapper mapper)
        {
            _incomeExpenseService = incomeExpenseService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("GetAllIncomeExpense")]
        public async Task<ActionResult<ServiceResponse<List<IncomeExpense>>>> Get()
        {
            var serviceResponse = await _incomeExpenseService.GetAllIncomeExpenses();
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpGet]
        [Route("GetSingleIncomeExpense/{id}")]

        public async Task<ActionResult<ServiceResponse<IncomeExpense>>> GetIncomeExpense(int id)
        {
            var serviceResponse = await _incomeExpenseService.GetIncomeExpenseById(id);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpPost]
        [Route("CreateIncomeExpense")]
        public async Task<ActionResult<ServiceResponse<List<IncomeExpense>>>> AddIncomeExpense([FromBody] AddIncomeExpenseDTO incomeExpense)
        {
            var serviceResponse = await _incomeExpenseService.AddIncomeExpense(incomeExpense);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }



        [HttpPut]
        [Route("UpdateIncomeExpense/{id}")]

        public async Task<ActionResult<ServiceResponse<List<IncomeExpense>>>> UpdateIncomeExpense([FromRoute] int id, AddIncomeExpenseDTO incomeExpense)
        {
            var serviceResponse = await _incomeExpenseService.UpdateIncomeExpense(id, incomeExpense);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpDelete]
        [Route("DeleteIncomeExpense/{id}")]

        public async Task<ActionResult<ServiceResponse<List<IncomeExpense>>>> DeleteIncomeExpense([FromRoute] int id)
        {
            var serviceResponse = await _incomeExpenseService.DeleteIncomeExpense(id);
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
