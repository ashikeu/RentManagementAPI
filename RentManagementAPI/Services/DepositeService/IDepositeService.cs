using RentManagementAPI.Models.DTOs.Deposite;

namespace RentManagementAPI.Services.DepositeService
{
    public interface IDepositeService
    {
        Task<ServiceResponse<List<Deposite>>> GetAllDeposites();
        Task<ServiceResponse<Deposite>> GetDepositeById(int id);
        Task<ServiceResponse<Deposite>> AddDeposite(AddDepositeDTO deposite);
        Task<ServiceResponse<Deposite>> UpdateDeposite(int id, AddDepositeDTO deposite);
        Task<ServiceResponse<Deposite>> DeleteDeposite(int id);

    }
}
