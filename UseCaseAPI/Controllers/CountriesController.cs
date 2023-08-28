using Microsoft.AspNetCore.Mvc;
using UseCaseAPI.DAL;
using UseCaseAPI.DAL.Entities;

namespace UseCaseAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CountriesController : ControllerBase
{
    private readonly ICountryRepository _countryRepository;
    private readonly IConfiguration _configuration;

    public CountriesController(ICountryRepository countryRepository, IConfiguration configuration)
    {
        _countryRepository = countryRepository;
        _configuration = configuration;
    }

    [HttpGet]
    public async Task<IEnumerable<Country>> GetAsync([FromQuery] string name = null, [FromQuery] long? population = null, [FromQuery] string sortDirection = null, 
        [FromQuery] int? numberOfResults = null)
    {
        string countriesUrl = _configuration.GetValue<string>(Constants.CountriesUrlConfigName);

        if (countriesUrl == null) { 
            return new List<Country>(); 
        }

        return await _countryRepository.GetAllAsync(countriesUrl);
    }
}
