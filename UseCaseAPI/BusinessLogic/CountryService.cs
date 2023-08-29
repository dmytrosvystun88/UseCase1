using UseCaseAPI.DAL;
using UseCaseAPI.DAL.Entities;

namespace UseCaseAPI.BusinessLogic
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<List<Country>> GetAsync(string name, int? population, string sortDirection, int? numberOfResults, string countriesUrl)
        {
            List<Country> countries = await _countryRepository.GetAllAsync(countriesUrl);

            countries = countries
                .FilterByName(name)
                .FilterByPopulation(population)
                .Sort(sortDirection)
                .TakeOnly(numberOfResults);

            return countries;
        }
    }
}
