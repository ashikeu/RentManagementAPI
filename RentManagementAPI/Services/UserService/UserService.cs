using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentManagementAPI.Models.DTOs.User;

namespace RentManagementAPI.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public UserService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<User>> AddUser(AddUserDTO user)
        {
            var serviceResponse = new ServiceResponse<User>();
            try
            {
                var userModel = _mapper.Map<User>(user);
                await _dataContext.User.AddAsync(userModel);
                await _dataContext.SaveChangesAsync();
                serviceResponse.Data = userModel;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<User>>> GetAllUsers()
        {
            var serviceResponse = new ServiceResponse<List<User>>();
            try
            {
                var users = await _dataContext.User.ToListAsync();
                        /*.Include(fl => fl.Flats)
                        .ToListAsync();*/

                if (users != null && users.Count == 0)
                {
                    serviceResponse.Data = null;
                    throw new Exception($"No data found.");
                }
                else
                {
                    serviceResponse.Data = users;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<User>> GetUserById(int id)
        {
            var serviceResponse = new ServiceResponse<User>();
            try
            {
                var existingUser = await _dataContext.User.FirstOrDefaultAsync(x => x.Id == id);
                if (existingUser is null)
                {
                    throw new Exception($"User with id {id} not found.");
                }
                else
                {
                    serviceResponse.Data = existingUser;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }


        public async Task<ServiceResponse<User>> UpdateUser(int id, AddUserDTO user)
        {
            var serviceResponse = new ServiceResponse<User>();
            try
            {
                var existingUser = await _dataContext.User.FirstOrDefaultAsync(x => x.Id == id);
                if (existingUser is null)
                {
                    throw new Exception($"User with id {id} not found.");
                }
                else
                {
                    var userModel = _mapper.Map<User>(user);
                    existingUser.Name = userModel.Name;
                    existingUser.PropertyInfoId= userModel.PropertyInfoId;
                    existingUser.Password= userModel.Password;
                    existingUser.IsActive = userModel.IsActive;
                    existingUser.Email = userModel.Email;
                    existingUser.MobileNo= userModel.MobileNo;
                    existingUser.IsRegularUser= userModel.IsRegularUser;
                    existingUser.IsLoggedIn= userModel.IsLoggedIn;
                    existingUser.IsAdmin= userModel.IsAdmin;
                   
                    await _dataContext.SaveChangesAsync();
                    serviceResponse.Data = existingUser;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<User>> DeleteUser(int id)
        {
            var serviceResponse = new ServiceResponse<User>();
            try
            {
                var existingUser = await _dataContext.User.FirstOrDefaultAsync(x => x.Id == id);
                if (existingUser is null)
                {
                    throw new Exception($"User with id {id} not found.");
                }
                else
                {
                    _dataContext.Remove(existingUser);
                    await _dataContext.SaveChangesAsync();
                    serviceResponse.Data = existingUser;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
