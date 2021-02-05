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
                new Delivery {Name = "Континент",
                    Price=0, Target="Выдача у ТЦ Континен. Ср. Пт. в 18-00",
                    Phone="+38(071)123-00-00"},
                new Delivery {Name = "Калининский",
                    Price=0,
                    Target="Калининский рынок. Донецк. Вт. Чт. в 8-00",
                    Phone="+38(071)123-11-11"},
                new Delivery {Name = "ЖД Донецк", 
                    Price=0,
                    Target="Выдача у ЖД Вокзала. Донецк. Ср. Пт. СБ. в 12-00",
                    Phone="+38(071)123-22-22"},               
            };
    }
}