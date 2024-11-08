using RentManagementAPI.Models.DTOs.PropertyInfo;

namespace RentManagementAPI.Services.PropertyInfoService
{
    public interface IPropertyInfoService
    {
        Task<ServiceResponse<List<PropertyInfo>>> GetAllPropertyInfos();
        Task<ServiceResponse<PropertyInfo>> GetPropertyInfoById(int id);
        Task<ServiceResponse<PropertyInfo>> AddPropertyInfo(PropertyInfoDTO propertyInfo);
        Task<ServiceResponse<PropertyInfo>> UpdatePropertyInfo(int id, PropertyInfoDTO propertyInfo);
        Task<ServiceResponse<PropertyInfo>> DeletePropertyInfo(int id);
    }
}
