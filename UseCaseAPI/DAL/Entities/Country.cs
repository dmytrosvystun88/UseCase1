namespace UseCaseAPI.DAL.Entities
{
    public class Country
    {
        public CountryName Name { get; set; }

        public long Population { get; set; }

        public string Cca2 { get; set; }

        public bool Independent { get; set; }

        public bool UnMember { get; set; }

        public string Region { get; set; }
    }
}
