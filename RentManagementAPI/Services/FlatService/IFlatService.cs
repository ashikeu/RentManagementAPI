namespace RentManagementAPI.Services.FlatService
{
    public interface IFlatService
    {
        Task<List<Flat>> GetAllFlats();

        Task<Flat> GetFlat(int id);

        Task<List<Flat>> AddFlat(Flat flat);

        Task<List<Flat>> UpdateFlat(int id, Flat request);
        Task<List<Flat>> DeleteFlat(int id);
    }
}
