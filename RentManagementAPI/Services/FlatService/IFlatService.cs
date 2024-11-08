using RentManagementAPI.Models.DTOs.Flat;

namespace RentManagementAPI.Services.FlatService
{
    public interface IFlatService
    {
        Task<ServiceResponse<List<Flat>>> GetAllFlats();
        Task<ServiceResponse<Flat>> GetFlatById(int id);
        Task<ServiceResponse<Flat>> AddFlat(FlatDTO flat);
        Task<ServiceResponse<Flat>> UpdateFlat(int id, FlatDTO flat);
        Task<ServiceResponse<Flat>> DeleteFlat(int id);
    }
}
