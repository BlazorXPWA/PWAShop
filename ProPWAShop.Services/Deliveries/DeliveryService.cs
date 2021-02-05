using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProPWAShop.Data;
using ProPWAShop.Data.Models;
using ProPWAShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProPWAShop.Services.Deliveries
{
    class DeliveryService : BaseService<Delivery>, IDeliveryService
    {
        public DeliveryService(ProPWAShopDbContext data, IMapper mapper)
            : base(data, mapper)
        {
        }

        public async Task<Delivery> FindByIdAsync(
            int id)
            => await this
                .All()
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

        public async Task<Result> UpdateAsync(
            int id, Delivery model)
        {
            var delivery = await this.FindByIdAsync(id);

            if (delivery == null)
            {
                return false;
            }

            delivery.Name = model.Name;
            delivery.Phone = model.Phone;
            delivery.Price = model.Price;
            delivery.Target = model.Target;
            delivery.TargetDescription = model.TargetDescription;

            await this.Data.SaveChangesAsync();

            return true;
        }

        public async Task<int> CreateAsync(
            Delivery model)
        {
            await this.Data.AddAsync(model);
            await this.Data.SaveChangesAsync();

            return model.Id;
        }

        public async Task<Result> DeleteAsync(
            int id)
        {
            var deliveries = await this
                .All()
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            if (deliveries == null)
            {
                return "Вида доставки с таким Id нет в базе данных";
            }

            this.Data.Remove(deliveries);
            await this.Data.SaveChangesAsync();

            return Result.Success;
        }

        public async Task<IEnumerable<Delivery>> AllAsync()
            => await this
                .All()
                .ToListAsync();
    }
}
