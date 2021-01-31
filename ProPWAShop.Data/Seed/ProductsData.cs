namespace ProPWAShop.Data.Seed
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Models;

    public class ProductsData : IInitialData
    {
        public Type EntityType => typeof(Product);

        public IEnumerable<object> GetData()
            => new List<Product>
            {
                 new Product
                {
                    SubCategory = "Партенокарпический крупнобугорчатый",
                    Name = "Амарок F1",
                    Description = "Ранний высокоурожайный партенокарпический гибрид. Универсальный, подходит для открытого грунта и теплиц. Зеленец красивого зелёного цвета, крупнобугорчатый, хрустящий. Отличное качество и плотность позволяют мариновать плоды без потери качества.",
                    DaysFrom = 40,
                    DaysTo = 45,
                    //Designations = new List<Designation>
                    //{
                    //    Designation.FreshConsumption,
                    //    Designation.Salting,
                    //    Designation.Pickling
                    //},
                    ImageSource = "images/products/seeds/cucumbers/Amarok.jpg",
                    Price = 19.99m,
                    Quantity = 30,
                    CategoryId = 1
                },
                 
                 new Product
                {
                    SubCategory = "Партенокарпический крупнобугорчатый",
                    Name = "Артист F1",
                    Description = "Высокоурожайный гибрид огурца для остекленных и пленочных теплиц. Растение теневыносливое, сбалансированное, генеративное, открытое. Прост в уходе: формировка простая, нагрузка на растения равномерная, отдача дружная. Плоды однородные, очень плотные, с маленькой семенной камерой, от зеленого до темно-зеленого цвета.",
                    DaysFrom = 38,
                    DaysTo = 45,
                    //Designations = new List<Designation>
                    //{
                    //    Designation.FreshConsumption,
                    //    Designation.Salting,
                    //    Designation.Pickling
                    //},
                    ImageSource = "images/products/seeds/cucumbers/Artist.jpg",
                    Price = 19.99m,
                    Quantity = 30,
                    CategoryId = 1
                },
                 
                 new Product
                {
                    SubCategory = "Партенокарпический крупнобугорчатый",
                    Name = "Абсолют F1",
                    Description = "Новый партенокарпический гибрид огурца универсального назначения. Зеленец среднего размера (8-10 см), цилиндрический, темно-зеленый, крупнобугорчатый, сильно опушенный. Формирует по 2-3 плода в пазухе листа.Гибрид отличается жаростойкостью и неприхотливостью к условиям выращивания, выровненной формой плодов и, благодаря мощной корневой системе, высокой устойчивостью к стрессовым условиям. Высокоурожайный. Рекомендуется для выращивания на раннюю продукцию весной и в осеннем обороте.",
                    DaysFrom = 70,
                    DaysTo = 72,
                    //Designations = new List<Designation>
                    //{
                    //    Designation.FreshConsumption,
                    //    Designation.Salting,
                    //    Designation.Pickling
                    //},
                    ImageSource = "images/products/seeds/cucumbers/Absolut.jpg",
                    Price = 19.99m,
                    Quantity = 30,
                    CategoryId = 1
                },

                 new Product
                {
                    SubCategory = "Партенокарпический крупнобугорчатый",
                    Name = "Анзор F1",
                    Description = "Скороспелый гибрид для выращивания в весенне-летнем летне-осеннем оборотах в остекленных и пленочных теплицах. В узлах образует образует по 2-5 завязейпремиум-класса насыщенного темно-зеленого цвета и отменного вкуса. Хороший выход стандартной продукции всего оборота. Сильная корневая система, с хорошей устойчивостью к корневым гнилям.",
                    DaysFrom = 38,
                    DaysTo = 45,
                    //Designations = new List<Designation>
                    //{
                    //    Designation.FreshConsumption,
                    //    Designation.Salting,
                    //    Designation.Pickling
                    //},
                    ImageSource = "images/products/seeds/cucumbers/Ansor.jpg",
                    Price = 19.99m,
                    Quantity = 30,
                    CategoryId = 1
                },
                 




                 new Product
                {
                    SubCategory = "Сладкий",
                    Name = "Турбин F1",
                    Description = "В технической cпелости имеет светло-зелёный цвет, в биологической спелости приобретает ярко-жёлтый цвет. Обладает отличным вкусом. Очень пластичный гибрид к условиям выращивания.",
                    DaysFrom = 55,
                    DaysTo = 60,
                    //Designations = new List<Designation>
                    //{
                    //    Designation.FreshConsumption,
                    //    Designation.Salting,
                    //    Designation.Pickling
                    //},
                    ImageSource = "images/products/seeds/peppers/Turbin.jpg",
                    Price = 19.99m,
                    Quantity = 10,
                    CategoryId = 2
                },




    //public enum Product
    //    {
    //        [Description("Партенокарпический крупнобугорчатый")]
    //        ParthenocarpicLargeTuberous,
    //        [Description("Партенокарпический мелкобугорчатый")]
    //        ParthenocarpicSmallTuberous,
    //        [Description("Пчелоопыляемый преимущественно женского типа цветения")]
    //        Bee_pollinated,
    //    }




        //new Product
        //        {
        //            Name = "Cool T-Shirt",
        //            Description = "The Cool T-Shirt is made from soft cotton and features a clean print.",
        //            ImageSource = "https://gorilla.bg/userfiles/productlargeimages/product_256.jpg",
        //            Price = 19.99m,
        //            Quantity = 10,
        //            CategoryId = 3
        //        },
        //        new Product
        //        {
        //            Name = "Super Hero Marvel Sweatshirt",
        //            Description = "The Super Hero Marvel Sweatshirt is made from soft cotton.",
        //            ImageSource = "https://cdn11.bigcommerce.com/s-pkla4xn3/images/stencil/1280x1280/products/7404/67088/New-Super-Hero-Marvel-Sweatshirts-Fashion-Cotton-Men-Hoodies-Marvel-Cool-Printed-Sweatshirts-Men-Clothing-Free__23706.1527569968.jpg?c=2&imbypass=on",
        //            Price = 50,
        //            Quantity = 30,
        //            CategoryId = 3
        //        },
        //        new Product
        //        {
        //            Name = "Beats by Dr. Dre Solo3 Wireless On-Ear Headphones",
        //            Description = "Beats Solo 3 is easy to set up, simply power on and hold near your iPhone, Apple Watch, iPad and Mac. Bluetooth technology makes it easy to instantly enjoy music from your Apple devices.",
        //            ImageSource = "https://i.ebayimg.com/images/g/OkQAAOSwFdRe18Yq/s-l1600.jpg",
        //            Price = 109.60m,
        //            Quantity = 10,
        //            CategoryId = 4
        //        },
        //        new Product
        //        {
        //            Name = "Apple Watch Series 5",
        //            Description = "Keep your workouts fresh and enjoyable by streaming your favorite audio with the Apple Watch Series 5. The Series 5 has access to the Apple Music library, letting you stream your favorite albums, podcasts, and audiobooks.",
        //            ImageSource = "https://static.plasico.bg/thumbs/12/mwvf2bsa.jpg",
        //            Price = 366.98m,
        //            Quantity = 10,
        //            CategoryId = 4
        //        },
        //        new Product
        //        {
        //            Name = "Code Complete - Second Edition",
        //            Description = "CODE COMPLETE has been helping developers write better software for more than a decade.",
        //            ImageSource = "https://i.ebayimg.com/images/g/55gAAOSwIqtfW63B/s-l500.png",
        //            Price = 35.99m,
        //            Quantity = 10,
        //            CategoryId = 5
        //        },
        //        new Product
        //        {
        //            Name = "Rick and Morty: Season 3 - Blu-Ray",
        //            Description = "An animated series that follows the exploits of a super scientist and his not-so-bright grandson.",
        //            ImageSource = "https://www.augoods.com.au/assets/full/DVD-LN-9322225226746.jpg?20200703062244",
        //            Price = 28.95m,
        //            Quantity = 10,
        //            CategoryId = 5
        //        }
            };
    }
}
