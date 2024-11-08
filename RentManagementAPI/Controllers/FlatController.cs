﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentManagementAPI.Models.DTOs.Flat;
using RentManagementAPI.Services.FlatService;


namespace RentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatController : ControllerBase
    {
        private readonly IFlatService _flatService;
        private readonly IMapper _mapper;

        public FlatController(IFlatService flatService, IMapper mapper)
        {
            _flatService = flatService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("GetAllFlat")]
        public async Task<ActionResult<ServiceResponse<List<Flat>>>> Get()
        {
            var serviceResponse = await _flatService.GetAllFlats();
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }
        [HttpGet]
        [Route("GetSingleFlat/{id}")]
        public async Task<ActionResult<ServiceResponse<Flat>>> GetFlat(int id)
        {
            var serviceResponse = await _flatService.GetFlatById(id);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpPost]
        [Route("CreateFlat")]
        public async Task<ActionResult<ServiceResponse<List<Flat>>>> AddFlat([FromBody] FlatDTO flat)
        {
            var serviceResponse = await _flatService.AddFlat(flat);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }


        [HttpPut]
        [Route("UpdateFlat/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Flat>>>> UpdateFlat([FromRoute] int id, FlatDTO flat)
        {
            var serviceResponse = await _flatService.UpdateFlat(id, flat);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }


        [HttpDelete]
        [Route("DeleteFlat/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Flat>>>> DeleteFlat([FromRoute] int id)
        {
            var serviceResponse = await _flatService.DeleteFlat(id);
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
