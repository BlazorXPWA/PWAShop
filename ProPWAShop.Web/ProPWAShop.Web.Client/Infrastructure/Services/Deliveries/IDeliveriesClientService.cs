using ProPWAShop.Data.Models;
using ProPWAShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProPWAShop.Web.Client.Infrastructure.Services.Deliveries
{
    public interface IDeliveriesClientService
    {
        Task<IEnumerable<Delivery>> AllAsynk();

        Task<int> CreateAsync(Delivery model);

        Task<Result> DeleteAsync(int id);
    }
}
