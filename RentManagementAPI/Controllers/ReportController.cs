/*using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using RentManagementAPI.Services.ReportService;

namespace RentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly IMapper _mapper;

        public ReportController(IReportService reportService, IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("GetAllReport")]
        public async Task<ActionResult<ServiceResponse<List<Report>>>> Get()
        {
            var serviceResponse = await _reportService.GetAllReports();
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpGet]
        [Route("GetSingleReport/{id}")]

        public async Task<ActionResult<ServiceResponse<Report>>> GetReport(int id)
        {
            var serviceResponse = await _reportService.GetReportById(id);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpPost]
        [Route("CreateReport")]
        public async Task<ActionResult<ServiceResponse<List<Report>>>> AddReport([FromBody] AddReportDTO report)
        {
            var serviceResponse = await _reportService.AddReport(report);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }



        [HttpPut]
        [Route("UpdateReport/{id}")]

        public async Task<ActionResult<ServiceResponse<List<Report>>>> UpdateReport([FromRoute] int id, AddReportDTO report)
        {
            var serviceResponse = await _reportService.UpdateReport(id, report);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpDelete]
        [Route("DeleteReport/{id}")]

        public async Task<ActionResult<ServiceResponse<List<Report>>>> DeleteReport([FromRoute] int id)
        {
            var serviceResponse = await _reportService.DeleteReport(id);
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
*/