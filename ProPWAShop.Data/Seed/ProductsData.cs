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
                    InPack= 10,
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
                    InPack= 10,
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
                    InPack= 10,
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
                    InPack= 10,
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
                    InPack= 10,
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
            };
    }
}
