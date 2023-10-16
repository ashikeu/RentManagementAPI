using RentManagementAPI.Models.DTOs.User;

namespace RentManagementAPI.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<List<User>>> GetAllUsers();
        Task<ServiceResponse<User>> GetUserById(int id);
        Task<ServiceResponse<User>> AddUser(AddUserDTO user);
        Task<ServiceResponse<User>> UpdateUser(int id, AddUserDTO user);
        Task<ServiceResponse<User>> DeleteUser(int id);
        Task<ServiceResponse<User>> Login(LogInDTO user);
    }
}
