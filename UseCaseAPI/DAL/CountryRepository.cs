using UseCaseAPI.DAL.Entities;

namespace UseCaseAPI.DAL
{
    public class CountryRepository : ICountryRepository
    {
        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            using HttpClient client = new HttpClient();
            using HttpResponseMessage response = await client.GetAsync("https://restcountries.com/v3.1/all");

            return await response.Content.ReadFromJsonAsync<IEnumerable<Country>>() ?? new List<Country>();
        }
    }
}
