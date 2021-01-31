namespace ProPWAShop.Data.Seed
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Models;

    public class CityData : IInitialData
    {
        public Type EntityType => typeof(City);
                public IEnumerable<object> GetData()
            => new List<City>
            {
                new City {Name = "Донецк"},
                new City {Name = "Макеевка"},
                new City {Name = "Харцызск"},          
            };
    }

}