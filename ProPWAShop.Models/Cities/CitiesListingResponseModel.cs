namespace ProPWAShop.Models.Cities
{
    using Common.Mapping;
    using Data.Models;

    public class CitiesListingResponseModel : IMapFrom<City>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}