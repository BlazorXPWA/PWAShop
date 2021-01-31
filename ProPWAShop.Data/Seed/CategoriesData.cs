namespace ProPWAShop.Data.Seed
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Models;

    public class CategoriesData : IInitialData
    {
        public Type EntityType => typeof(Category);
                public IEnumerable<object> GetData()
            => new List<Category>
            {
                new Category {/*Id=1,*/ Name = "Огурец" },
                new Category {/*Id=2,*/ Name = "Перец" },
                new Category {/*Id=3,*/ Name = "Помидоры" },
                new Category {/*Id=4,*/ Name = "Кабачки" },
                new Category {/*Id=5,*/ Name = "Цветы" },
            };
    }

}
