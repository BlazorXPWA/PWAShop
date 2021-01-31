namespace ProPWAShop.Models.ShoppingCarts
{
    using ProPWAShop.Data.Models;
    using System.ComponentModel.DataAnnotations;

    using static Data.ModelConstants.Product;

    public class ShoppingCartRequestModel
    {
        [Required]
        public int ProductId { get; set; }

        [Range(MinQuantity, MaxQuantity)]
        public int Quantity { get; set; } = MinQuantity;

        public string UserId { get; set; }
        public ProPWAShopUser ProPWAShopUser;
    }
}