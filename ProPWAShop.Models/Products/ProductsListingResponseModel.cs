namespace ProPWAShop.Models.Products
{
    using Common.Mapping;
    using Data.Models;
    using System.ComponentModel;

    public class ProductsListingResponseModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageSource { get; set; }

        public string Description { get; set; }

        public string SubCategory { get; set; }

        public int DaysFrom { get; set; }

        public int DaysTo  { get; set; }

        public decimal Price { get; set; }

        [Description("Кол-во в упаковке")]
        public int InPack { get; set; }

        [Description("Единицы измерения")]
        public UnitsType UnitsType { get; set; }
    }
}
