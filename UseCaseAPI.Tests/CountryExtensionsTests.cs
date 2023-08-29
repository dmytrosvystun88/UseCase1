using AutoFixture;
using UseCaseAPI.BusinessLogic;
using UseCaseAPI.DAL.Entities;

namespace UseCaseAPI.Tests
{
    [TestClass]
    public class CountryExtensionsTests
    {
        private Fixture _fixture;

        [TestInitialize]
        public void TestInitialize()
        {
            _fixture = new Fixture();
        }

        [TestMethod]
        public void FilterByName_WhenNameIsNull_ReturnsAll()
        {
            // arrange

            List<Country> countries = _fixture.CreateMany<Country>(5).ToList();

            // act

            List<Country> resuls = countries.FilterByName(null);

            // assert

            Assert.AreEqual(countries, resuls);
        }

        [TestMethod]
        public void FilterByName_WhenNameIsEmpty_ReturnsAll()
        {
            // arrange

            List<Country> countries = _fixture.CreateMany<Country>(5).ToList();

            // act

            List<Country> resuls = countries.FilterByName(string.Empty);

            // assert

            Assert.AreEqual(countries, resuls);
        }

        [TestMethod]
        public void FilterByName_WhenNameIsProvidedUppercase_ReturnsCorrectItem()
        {
            // arrange

            List<Country> countries = _fixture.CreateMany<Country>(5).ToList();
            string name = countries.First().Name.Common.Substring(1, countries.First().Name.Common.Length - 1).ToUpper();

            // act

            List<Country> resuls = countries.FilterByName(name);

            // assert

            Assert.AreEqual(countries.First().Name.Common, resuls.First().Name.Common);
        }

        [TestMethod]
        public void FilterByPopulation_WhenPopulationIsNull_ReturnsAll()
        {
            // arrange

            List<Country> countries = _fixture.CreateMany<Country>(5).ToList();

            // act

            List<Country> resuls = countries.FilterByPopulation(null);

            // assert

            Assert.AreEqual(countries, resuls);
        }

        [TestMethod]
        public void FilterByPopulation_WhenPopulationIsProvided_ReturnsCorrectItems()
        {
            // arrange

            List<Country> countries = _fixture.CreateMany<Country>(5).ToList();

            int population = (int) countries.OrderByDescending(x => x.Population).First().Population;

            foreach (Country country in countries)
            {
                country.Population *= 1000000;
            }

            List<Country> expectedResults = countries.Where(x => x.Population < population * 1000000).ToList();

            // act

            List<Country> resuls = countries.FilterByPopulation(population);

            // assert

            CollectionAssert.AreEqual(expectedResults, resuls);
        }

        [TestMethod]
        public void Sort_WhenDirectionIsNull_ReturnsNotSorted()
        {
            // arrange

            List<Country> countries = _fixture.CreateMany<Country>(5).ToList();

            // act

            List<Country> resuls = countries.Sort(sortDirection: null);

            // assert

            CollectionAssert.AreEqual(countries, resuls);
        }

        [TestMethod]
        public void Sort_WhenDirectionIsNotValid_ReturnsNotSorted()
        {
            // arrange

            List<Country> countries = _fixture.CreateMany<Country>(5).ToList();

            // act

            List<Country> resuls = countries.Sort(sortDirection: "Ascending");

            // assert

            CollectionAssert.AreEqual(countries, resuls);
        }

        [TestMethod]
        public void Sort_WhenDirectionIsAscend_ReturnsSortedAscending()
        {
            // arrange

            List<Country> countries = _fixture.CreateMany<Country>(5).ToList();

            // act

            List<Country> resuls = countries.Sort(sortDirection: "Ascend");

            // assert

            CollectionAssert.AreEqual(countries.OrderBy(x=>x.Name.Common).ToList(), resuls);
        }

        [TestMethod]
        public void Sort_WhenDirectionIsAscend_ReturnsSortedDescending()
        {
            // arrange

            List<Country> countries = _fixture.CreateMany<Country>(5).ToList();

            // act

            List<Country> resuls = countries.Sort(sortDirection: "Descend");

            // assert

            CollectionAssert.AreEqual(countries.OrderByDescending(x => x.Name.Common).ToList(), resuls);
        }

        [TestMethod]
        public void TakeOnly_WhenNumberOfResultsIsNull_ReturnsAll()
        {
            // arrange

            List<Country> countries = _fixture.CreateMany<Country>(5).ToList();

            // act

            List<Country> resuls = countries.TakeOnly(null);

            // assert

            CollectionAssert.AreEqual(countries, resuls);
        }

        [DataRow(3)]
        [DataRow(-3)]
        [DataTestMethod]
        public void TakeOnly_WhenNumberOfResultsIsProvided_ReturnsCorrectItems(int numberOfResults)
        {
            // arrange

            List<Country> countries = _fixture.CreateMany<Country>(5).ToList();

            // act

            List<Country> resuls = countries.TakeOnly(numberOfResults);

            // assert

            CollectionAssert.AreEqual(countries.Take(numberOfResults).ToList(), resuls);
        }
    }
}