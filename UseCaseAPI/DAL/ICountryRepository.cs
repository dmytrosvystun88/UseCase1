using UseCaseAPI.DAL.Entities;

namespace UseCaseAPI.DAL
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllAsync(string countriesUrl);
    }
}
