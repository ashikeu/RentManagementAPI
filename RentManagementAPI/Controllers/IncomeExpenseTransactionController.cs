using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentManagementAPI.Models.DTOs.IncomeExpenseTransaction;
using RentManagementAPI.Services.IncomeExpenseTransactionService;

namespace RentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeExpenseTransactionController : ControllerBase
    {
        private readonly IIncomeExpenseTransactionService _incomeExpenseTransactionService;
        private readonly IMapper _mapper;

        public IncomeExpenseTransactionController(IIncomeExpenseTransactionService incomeExpenseTransactionService, IMapper mapper)
        {
            _incomeExpenseTransactionService = incomeExpenseTransactionService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("GetAllIncomeExpenseTransaction")]
        public async Task<ActionResult<ServiceResponse<List<IncomeExpenseTransaction>>>> Get()
        {
            var serviceResponse = await _incomeExpenseTransactionService.GetAllIncomeExpenseTransactions();
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpGet]
        [Route("GetSingleIncomeExpenseTransaction/{id}")]

        public async Task<ActionResult<ServiceResponse<IncomeExpenseTransaction>>> GetIncomeExpenseTransaction(int id)
        {
            var serviceResponse = await _incomeExpenseTransactionService.GetIncomeExpenseTransactionById(id);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpPost]
        [Route("CreateIncomeExpenseTransaction")]
        public async Task<ActionResult<ServiceResponse<List<IncomeExpenseTransaction>>>> AddIncomeExpenseTransaction([FromBody] AddIncomeExpenseTransactionDTO incomeExpenseTransaction)
        {
            var serviceResponse = await _incomeExpenseTransactionService.AddIncomeExpenseTransaction(incomeExpenseTransaction);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }



        [HttpPut]
        [Route("UpdateIncomeExpenseTransaction/{id}")]

        public async Task<ActionResult<ServiceResponse<List<IncomeExpenseTransaction>>>> UpdateIncomeExpenseTransaction([FromRoute] int id, AddIncomeExpenseTransactionDTO incomeExpenseTransaction)
        {
            var serviceResponse = await _incomeExpenseTransactionService.UpdateIncomeExpenseTransaction(id, incomeExpenseTransaction);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpDelete]
        [Route("DeleteIncomeExpenseTransaction/{id}")]

        public async Task<ActionResult<ServiceResponse<List<IncomeExpenseTransaction>>>> DeleteIncomeExpenseTransaction([FromRoute] int id)
        {
            var serviceResponse = await _incomeExpenseTransactionService.DeleteIncomeExpenseTransaction(id);
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
