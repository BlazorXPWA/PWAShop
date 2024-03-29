﻿namespace ProPWAShop.Data.Models
{
    using System.Collections.Generic;

    using Contracts;

    public class ShoppingCart : BaseModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public ProPWAShopUser User { get; set; }

        public ICollection<ShoppingCartProduct> Products { get; } = new HashSet<ShoppingCartProduct>();
    }
}
