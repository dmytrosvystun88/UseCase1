using UseCaseAPI.DAL.Entities;

namespace UseCaseAPI.DAL
{
    public class CountryRepository : ICountryRepository
    {
        public async Task<IEnumerable<Country>> GetAllAsync(string countriesUrl)
        {
            using HttpClient client = new HttpClient();
            using HttpResponseMessage response = await client.GetAsync(countriesUrl);

            return await response.Content.ReadFromJsonAsync<IEnumerable<Country>>() ?? new List<Country>();
        }
    }
}
