using RentManagementAPI.Models.DTOs.PropertyInfo;

namespace RentManagementAPI.Services.PropertyInfoService
{
    public interface IPropertyInfoService
    {
        Task<ServiceResponse<List<PropertyInfo>>> GetAllPropertyInfos();
        Task<ServiceResponse<PropertyInfo>> GetPropertyInfoById(int id);
        Task<ServiceResponse<PropertyInfo>> AddPropertyInfo(AddPropertyInfoDTO propertyInfo);
        Task<ServiceResponse<PropertyInfo>> UpdatePropertyInfo(int id, AddPropertyInfoDTO propertyInfo);
        Task<ServiceResponse<PropertyInfo>> DeletePropertyInfo(int id);
    }
}
