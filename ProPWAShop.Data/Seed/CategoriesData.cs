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
                new Category {/*Id=3,*/ Name = "Electronics" },
                new Category {/*Id=4,*/ Name = "Books, Movies & Music" },
                new Category {/*Id=5,*/ Name = "Books, Mwww & Music" },
            };
    }

}
