using Microsoft.AspNetCore.Mvc;
using UseCaseAPI.BusinessLogic;
using UseCaseAPI.DAL.Entities;

namespace UseCaseAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CountriesController : ControllerBase
{
    private readonly ICountryService _countryService;
    private readonly IConfiguration _configuration;

    public CountriesController(ICountryService countryService, IConfiguration configuration)
    {
        _countryService = countryService;
        _configuration = configuration;
    }

    [HttpGet]
    public async Task<IEnumerable<Country>> GetAsync([FromQuery] string name = null, [FromQuery] int? population = null, [FromQuery] string sortDirection = null, 
        [FromQuery] int? numberOfResults = null)
    {
        string countriesUrl = _configuration.GetValue<string>(Constants.CountriesUrlConfigName);

        if (countriesUrl == null) { 
            return new List<Country>(); 
        }

        return await _countryService.GetAsync(name, population, sortDirection, numberOfResults, countriesUrl);
    }
}
