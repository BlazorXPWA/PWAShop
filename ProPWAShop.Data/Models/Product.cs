namespace ProPWAShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Contracts;

    public class Product : BaseDeletableModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SubCategory { get; set; }

        public string Description { get; set; }

        public string ImageSource { get; set; }

        [Description("Кол-во в упаковке")]
        public int InPack { get; set; }

        [Description("Единицы измерения")]
        public UnitsType UnitsType { get; set; }

        [Description("Остаток")]
        public int Quantity { get; set; }

        public int DaysFrom { get; set; }

        public int DaysTo { get; set; }

        public decimal Price { get; set; }

        //public List<Designation> Designations { get;set;}

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<WishlistProduct> Wishlists { get; } = new HashSet<WishlistProduct>();

        public ICollection<ShoppingCartProduct> ShoppingCarts { get; } = new HashSet<ShoppingCartProduct>();

        public ICollection<OrderProduct> Orders { get; } = new HashSet<OrderProduct>();
    }

    public enum UnitsType
    {

        [Display(Name = "шт.")]
        Pcs,
        [Display(Name = "г")]
        g,
        [Display(Name = "кг")]
        kg
    }

    //public enum Designation
    //{
    //    [Description("Засолка")]
    //    Salting,
    //    [Description("Маринование")]
    //    Pickling,
    //    [Description("Свежее потребление")]
    //    FreshConsumption,
    //    [Description("Переработка")]
    //    Processing,
    //    [Description("Свежий рынок")]
    //    FreshMarket,
    //    [Description("Хранение")]
    //    Storage
    //}
}