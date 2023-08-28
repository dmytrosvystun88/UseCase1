using Microsoft.AspNetCore.Mvc;
using UseCaseAPI.DAL;
using UseCaseAPI.DAL.Entities;

namespace UseCaseAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CountriesController : ControllerBase
{
    private readonly ICountryRepository _countryRepository;

    public CountriesController(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<Country>> GetAsync([FromQuery] string name = null, [FromQuery] long? population = null, [FromQuery] string sortDirection = null, 
        [FromQuery] int? numberOfResults = null)
    {
        return await _countryRepository.GetAllAsync();
    }
}
