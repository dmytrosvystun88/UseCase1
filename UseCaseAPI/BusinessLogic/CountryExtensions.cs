using UseCaseAPI.DAL.Entities;
using UseCaseAPI.Enums;

namespace UseCaseAPI.BusinessLogic
{
    public static class CountryExtensions
    {
        public static List<Country> FilterByName(this List<Country> countries, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return countries;
            }

            return countries.Where(x => x.Name.Common.Contains(name, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }

        public static List<Country> FilterByPopulation(this List<Country> countries, int? population)
        {
            return population.HasValue ?
                countries.Where(x => x.Population < population.Value * 1000000).ToList() :
                countries;
        }

        public static List<Country> Sort(this List<Country> countries, string sortDirection)
        {
            if (!Enum.TryParse(sortDirection, true, out SortDirection direction))
            {
                return countries;
            }

            switch (direction)
            {
                case SortDirection.Ascend:
                    return countries.OrderBy(x => x.Name.Common).ToList();
                case SortDirection.Descend:
                    return countries.OrderByDescending(x => x.Name.Common).ToList();
                default:
                    return countries;
            }
        }

        public static List<Country> TakeOnly(this List<Country> countries, int? numberOfResults)
        {
            return numberOfResults.HasValue ?
                countries.Take(numberOfResults.Value).ToList() :
                countries;
        }
    }
}
