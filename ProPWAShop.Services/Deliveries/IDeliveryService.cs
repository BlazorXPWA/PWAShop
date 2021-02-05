using ProPWAShop.Data.Models;
using ProPWAShop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProPWAShop.Services.Deliveries
{
    public interface IDeliveryService
    {
        Task<Delivery> FindByIdAsync(int id);

        Task<Result> UpdateAsync(int id, Delivery model);

        Task<int> CreateAsync(Delivery model);

        Task<Result> DeleteAsync(int id);

        Task<IEnumerable<Delivery>> AllAsync();
    }
}
