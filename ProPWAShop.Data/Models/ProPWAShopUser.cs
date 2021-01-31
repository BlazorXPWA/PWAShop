namespace ProPWAShop.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;

    using Contracts;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class ProPWAShopUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ProPWAShopUser() => this.Id = Guid.NewGuid().ToString();

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Description("Персональная скидка")]
        [Range(0,25)]
        public int PersonalDiscountPercent { get; set; }

        public ICollection<Address> Addresses { get; } = new HashSet<Address>();

        public ICollection<Order> Orders { get; } = new HashSet<Order>();

        public ICollection<Wishlist> Wishlists { get; } = new HashSet<Wishlist>();

        public ICollection<ShoppingCart> ShoppingCarts { get; } = new HashSet<ShoppingCart>();

        public ICollection<ConfirmCode> ConfirmCodes { get; } = new HashSet<ConfirmCode>();
    }
}