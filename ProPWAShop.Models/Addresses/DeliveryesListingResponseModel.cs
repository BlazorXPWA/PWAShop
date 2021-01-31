namespace ProPWAShop.Models.Addresses
{
    using Common.Mapping;
    using Data.Models;

    public class DeliveryesListingResponseModel : IMapFrom<Delivery>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}