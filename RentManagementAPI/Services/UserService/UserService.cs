using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentManagementAPI.Models.DTOs.User;
using RentManagementAPI.Services.PasswordHasher;

namespace RentManagementAPI.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(DataContext dataContext, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }
        public async Task<ServiceResponse<User>> AddUser(UserDTO user)
        {
            var serviceResponse = new ServiceResponse<User>();
            try
            {
                var userModel = _mapper.Map<User>(user);
                userModel.Password = _passwordHasher.Hash(userModel.Password);
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


        public async Task<ServiceResponse<User>> UpdateUser(int id, UserDTO user)
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
                    /*existingUser = userModel;*/
                    existingUser.Name = userModel.Name;
                   /* existingUser.PropertyInfoId = userModel.PropertyInfoId;*/
                    existingUser.Password = userModel.Password;
                   /* existingUser.IsActive = userModel.IsActive;*/
                    existingUser.Email = userModel.Email;
                    existingUser.MobileNo = userModel.MobileNo;
                /*    existingUser.IsRegularUser = userModel.IsRegularUser;
                    existingUser.IsLoggedIn = userModel.IsLoggedIn;
                    existingUser.IsAdmin = userModel.IsAdmin;*/

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
        public async Task<ServiceResponse<User>> Login(LogInDTO user)
        {
            var serviceResponse = new ServiceResponse<User>();
            try
            {
                var existingUser = await _dataContext.User.FirstOrDefaultAsync(x => x.Email == user.Email);
                if (existingUser is null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"User  {user.Email} not found.";
                }
                else
                {
                    if (_passwordHasher.Verify(existingUser.Password, user.Password))
                    {
                        serviceResponse.Data = existingUser;
                        serviceResponse.Success = true;
                    }
                    else
                    {
                        serviceResponse.Data = null;
                        serviceResponse.Success = false;
                        serviceResponse.Message = "Userid/Password didn't match.";
                    }
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
