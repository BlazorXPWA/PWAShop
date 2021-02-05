using ProPWAShop.Data.Models;
using ProPWAShop.Models;
using ProPWAShop.Web.Client.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ProPWAShop.Web.Client.Infrastructure.Services.Deliveries
{
    public class DeliveriesClientService : IDeliveriesClientService
    {
        private readonly HttpClient http;

        private const string Path = "api/deliveries";

        public DeliveriesClientService(HttpClient http) => this.http = http;

        public async Task<IEnumerable<Delivery>> AllAsynk()
            => await this.http.GetFromJsonAsync<IEnumerable<Delivery>>(Path);

        public async Task<int> CreateAsync(Delivery model)
        {
            var DeliveryResponse = await this.http.PostAsJsonAsync(Path, model);

            return DeliveryResponse.Content.ReadFromJsonAsync<int>().Result;
        }

        public async Task<Result> DeleteAsync(int id)
            => await this.http
                .DeleteAsync($"{Path}/{id}")
                .ToResult();
    }
}
