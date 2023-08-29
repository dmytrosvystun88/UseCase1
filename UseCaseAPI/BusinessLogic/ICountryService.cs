using Microsoft.AspNetCore.Mvc;
using UseCaseAPI.DAL.Entities;

namespace UseCaseAPI.BusinessLogic
{
    public interface ICountryService
    {
        Task<List<Country>> GetAsync(string name, int? population, string sortDirection, int? numberOfResults, string countriesUrl);
    }
}
