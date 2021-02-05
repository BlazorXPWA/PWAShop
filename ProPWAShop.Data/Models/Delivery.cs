namespace ProPWAShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Contracts;

    public class Delivery: BaseModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Target { get; set; }
        public string TargetDescription { get; set; }
        public decimal Price { get; set; }

        public ICollection<Order> Orders { get; } = new HashSet<Order>();
    }
}
