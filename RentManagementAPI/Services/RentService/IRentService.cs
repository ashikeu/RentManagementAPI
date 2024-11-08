using RentManagementAPI.Models.DTOs.Rent;

namespace RentManagementAPI.Services.RentService
{
    public interface IRentService
    {
        Task<ServiceResponse<List<Rent>>> GetAllRents();
        Task<ServiceResponse<Rent>> GetRentById(int id);
        Task<ServiceResponse<Rent>> AddRent(RentDTO rent);
        Task<ServiceResponse<Rent>> UpdateRent(int id, RentDTO rent);
        Task<ServiceResponse<Rent>> DeleteRent(int id);
    }
}
