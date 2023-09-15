namespace RentManagementAPI.Services.RentService
{
    public interface IRentService
    {
        Task<List<Rent>> GetAllRents();

        Task<Rent> GetRent(int id);

        Task<List<Rent>> AddRent(Rent rent);

        Task<List<Rent>> UpdateRent(int id, Rent request);
        Task<List<Rent>> DeleteRent(int id);
    }
}
