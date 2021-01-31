namespace ProPWAShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Contracts;

    public class Address : BaseDeletableModel
    {
        public int Id { get; set; }

        //public string Country { get; set; }

        //public string State { get; set; }

        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }

        public string Description { get; set; }

        //public string PostalCode { get; set; }

        public string PhoneNumber { get; set; }

        public string Comments { get; set; }

        public string UserId { get; set; }

        public ProPWAShopUser User { get; set; }

        public ICollection<Order> Orders { get; } = new HashSet<Order>();
    }
}