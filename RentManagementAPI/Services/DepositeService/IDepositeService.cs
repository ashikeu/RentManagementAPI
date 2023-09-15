namespace RentManagementAPI.Services.DepositeService
{
    public interface IDepositeService
    {
        Task<List<Deposite>> GetAllDeposites();

        Task<Deposite> GetDeposite(int id);

        Task<List<Deposite>> AddDeposite(Deposite deposite);

        Task<List<Deposite>> UpdateDeposite(int id, Deposite request);
        Task<List<Deposite>> DeleteDeposite(int id);

    }
}
