using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentManagementAPI.Models.DTOs.PropertyInfo;

namespace RentManagementAPI.Services.PropertyInfoService
{
    public class PropertyInfoService : IPropertyInfoService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public PropertyInfoService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<PropertyInfo>> AddPropertyInfo(AddPropertyInfoDTO propertyInfo)
        {
            var serviceResponse = new ServiceResponse<PropertyInfo>();
            try
            {
                var propertyInfoModel = _mapper.Map<PropertyInfo>(propertyInfo);
                await _dataContext.PropertyInfo.AddAsync(propertyInfoModel);
                await _dataContext.SaveChangesAsync();
                serviceResponse.Data = propertyInfoModel;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PropertyInfo>>> GetAllPropertyInfos()
        {
            var serviceResponse = new ServiceResponse<List<PropertyInfo>>();
            try
            {
                var propertyInfos = await _dataContext.PropertyInfo.ToListAsync();
                       /* .Include(fl => fl.Flats)
                        .ToListAsync();*/

                if (propertyInfos != null && propertyInfos.Count == 0)
                {
                    serviceResponse.Data = null;
                    throw new Exception($"No data found.");
                }
                else
                {
                    serviceResponse.Data = propertyInfos;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<PropertyInfo>> GetPropertyInfoById(int id)
        {
            var serviceResponse = new ServiceResponse<PropertyInfo>();
            try
            {
                var existingPropertyInfo = await _dataContext.PropertyInfo.FirstOrDefaultAsync(x => x.Id == id);
                if (existingPropertyInfo is null)
                {
                    throw new Exception($"PropertyInfo with id {id} not found.");
                }
                else
                {
                    serviceResponse.Data = existingPropertyInfo;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }


        public async Task<ServiceResponse<PropertyInfo>> UpdatePropertyInfo(int id, AddPropertyInfoDTO propertyInfo)
        {
            var serviceResponse = new ServiceResponse<PropertyInfo>();
            try
            {
                var existingPropertyInfo = await _dataContext.PropertyInfo.FirstOrDefaultAsync(x => x.Id == id);
                if (existingPropertyInfo is null)
                {
                    throw new Exception($"PropertyInfo with id {id} not found.");
                }
                else
                {
                    var propertyInfoModel = _mapper.Map<PropertyInfo>(propertyInfo);
                    existingPropertyInfo.Name = propertyInfoModel.Name;
                    existingPropertyInfo.WebAddress= propertyInfoModel.WebAddress;
                    existingPropertyInfo.Address = propertyInfoModel.Address;
                    existingPropertyInfo.OwnerName= propertyInfoModel.OwnerName;
                    existingPropertyInfo.Email= propertyInfoModel.Email;
                    existingPropertyInfo.MobileNo= propertyInfoModel.MobileNo;
                   
                    await _dataContext.SaveChangesAsync();
                    serviceResponse.Data = existingPropertyInfo;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<PropertyInfo>> DeletePropertyInfo(int id)
        {
            var serviceResponse = new ServiceResponse<PropertyInfo>();
            try
            {
                var existingPropertyInfo = await _dataContext.PropertyInfo.FirstOrDefaultAsync(x => x.Id == id);
                if (existingPropertyInfo is null)
                {
                    throw new Exception($"PropertyInfo with id {id} not found.");
                }
                else
                {
                    _dataContext.Remove(existingPropertyInfo);
                    await _dataContext.SaveChangesAsync();
                    serviceResponse.Data = existingPropertyInfo;
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
