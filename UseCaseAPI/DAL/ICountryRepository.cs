using UseCaseAPI.DAL.Entities;

namespace UseCaseAPI.DAL
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllAsync(string countriesUrl);
    }
}
