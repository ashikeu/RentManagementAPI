using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentManagementAPI.Models.DTOs.User;
using RentManagementAPI.Services.UserService;

namespace RentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("GetAllUser")]
        public async Task<ActionResult<ServiceResponse<List<User>>>> Get()
        {
            var serviceResponse = await _userService.GetAllUsers();
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpGet]
        [Route("GetSingleUser/{id}")]

        public async Task<ActionResult<ServiceResponse<User>>> GetUser(int id)
        {
            var serviceResponse = await _userService.GetUserById(id);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult<ServiceResponse<List<User>>>> AddUser([FromBody] UserDTO user)
        {
            var serviceResponse = await _userService.AddUser(user);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<ServiceResponse<User>>> Login([FromBody] LogInDTO user)
        {
            var serviceResponse = await _userService.Login(user);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }



        [HttpPut]
        [Route("UpdateUser/{id}")]

        public async Task<ActionResult<ServiceResponse<List<User>>>> UpdateUser([FromRoute] int id, UserDTO user)
        {
            var serviceResponse = await _userService.UpdateUser(id, user);
            if (serviceResponse.Data is null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpDelete]
        [Route("DeleteUser/{id}")]

        public async Task<ActionResult<ServiceResponse<List<User>>>> DeleteUser([FromRoute] int id)
        {
            var serviceResponse = await _userService.DeleteUser(id);
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
