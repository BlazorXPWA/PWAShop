using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using ProPWAShop.Data.Contracts;
using ProPWAShop.Data.Models;

namespace ProPWAShop.Data
{

    using static Common.Constants;

    public class ProPWAShopDbInitializer : IInitializer
    {
        private readonly ProPWAShopDbContext db;
        private readonly UserManager<ProPWAShopUser> userManager;
        private readonly RoleManager<ProPWAShopRole> roleManager;
        private readonly IEnumerable<IInitialData> initialDataProviders;

        public ProPWAShopDbInitializer(
            ProPWAShopDbContext db,
            UserManager<ProPWAShopUser> userManager,
            RoleManager<ProPWAShopRole> roleManager,
            IEnumerable<IInitialData> initialDataProviders)
        {
            this.db = db;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.initialDataProviders = initialDataProviders;
        }

        public void Initialize()
        {
            this.db.Database.Migrate();

            this.AddAdministrator();

            this.db.SaveChanges();
            foreach (var initialDataProvider in this.initialDataProviders)
            {
                if (this.DataSetIsEmpty(initialDataProvider.EntityType))
                {
                    var data = initialDataProvider.GetData();

                    foreach (var entity in data)
                    {
                        this.db.Add(entity);
                    }
                }
            }

            this.db.SaveChanges();
        }

        private void AddAdministrator()
            => Task
                .Run(async () =>
                {
                    var existingRole = await this.roleManager.FindByNameAsync(AdministratorRole);

                    if (existingRole != null)
                    {
                        return;
                    }

                    var adminUser = new ProPWAShopUser
                    {
                        FirstName = "Admin",
                        LastName = "Admin",
                        PhoneNumber = "7777777",
                        UserName = "Admin_Admin",
                        SecurityStamp = "9d876trdcvbnmliuytrds",
                        Email = "7777777@semky.ru",
                    };
                    var adminRole = new ProPWAShopRole(AdministratorRole);
                    await this.roleManager.CreateAsync(adminRole);
                    await this.userManager.CreateAsync(adminUser, "admWn@w12sd");
                    await this.userManager.AddToRoleAsync(adminUser, AdministratorRole);
                })
                .GetAwaiter()
                .GetResult();

        private bool DataSetIsEmpty(Type type)
        {
            var setMethod = this.GetType()
                .GetMethod(nameof(this.GetSet), BindingFlags.Instance | BindingFlags.NonPublic)
                ?.MakeGenericMethod(type);

            var set = setMethod?.Invoke(this, Array.Empty<object>());

            var countMethod = typeof(Queryable)
                .GetMethods()
                .First(m => m.Name == nameof(Queryable.Count) && m.GetParameters().Length == 1)
                .MakeGenericMethod(type);

            var result = (int)countMethod.Invoke(null, new[] { set })!;

            return result == 0;
        }

        private DbSet<TEntity> GetSet<TEntity>()
            where TEntity : class
            => this.db.Set<TEntity>();
    }
}
