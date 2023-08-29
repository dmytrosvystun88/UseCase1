using UseCaseAPI.DAL.Entities;

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
    }
}
