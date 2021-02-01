namespace ProPWAShop.Data.Seed
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Models;

    public class DeliveryData : IInitialData
    {
        public Type EntityType => typeof(Delivery);
                public IEnumerable<object> GetData()
            => new List<Delivery>
            {
                new Delivery {Name = "Бесплатная", Price=0, Target="Адресная"},
                new Delivery {Name = "Самовывоз", Price=0, Target="Главный офис" },
                new Delivery {Name = "Срочная", Price=100, Target="Адресная"},          
            };
    }
}