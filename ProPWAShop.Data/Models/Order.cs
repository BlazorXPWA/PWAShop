namespace ProPWAShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using Contracts;

    public class Order : BaseModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public OrderStatus OrderStatus { get; set; }

        public int OrderPrice { get; set; }

        public int DeliveryId { get; set; }
        [ForeignKey("DeliveryId")]
        public Delivery Delivery { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ProPWAShopUser User { get; set; }

        public int DeliveryAddressId { get; set; }
        [ForeignKey("DeliveryAddressId")]
        public Address DeliveryAddress { get; set; }

        public ICollection<OrderProduct> Products { get; } = new HashSet<OrderProduct>();

    }
}
