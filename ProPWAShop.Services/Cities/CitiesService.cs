namespace ProPWAShop.Services.Cities
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Models;
    using Models;
    using ProPWAShop.Models.Cities;
    using ProPWAShop.Services.Cities;

    public class CitiesService : BaseService<City>, ICitiesService
    {
        public CitiesService(ProPWAShopDbContext data, IMapper mapper)
            : base(data, mapper)
        {
        }

        public async Task<int> CreateAsync(
            CitiesRequestModel model, string userId)
        {
            var city = new City
            {
                Name = model.Name
            };

            await this.Data.AddAsync(city);
            await this.Data.SaveChangesAsync();

            return city.Id;
        }

        public async Task<Result> DeleteAsync(
            int id)
        {
            var cities = await this
                .All()
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            if (cities == null)
            {
                return "Пользователь не может удалить данный город";
            }

            this.Data.Remove(cities);

            await this.Data.SaveChangesAsync();

            return Result.Success;
        }

        public async Task<IEnumerable<CitiesListingResponseModel>> AllCitiesAsync()
            => await this.Mapper
                .ProjectTo<CitiesListingResponseModel>(this
                    .AllAsNoTracking())
                .ToListAsync();
    }
}
