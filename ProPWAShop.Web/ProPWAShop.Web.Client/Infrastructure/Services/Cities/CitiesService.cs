namespace ProPWAShop.Web.Client.Infrastructure.Services.Cities
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using ProPWAShop.Data.Models;
    using Models.Cities;
    using Extensions;
    using Models;

    public class CitiesService : ICitiesService
    {
        private readonly HttpClient http;

        private const string Path = "api/cities";
        private const string PathWithSlash = Path + "/";

        public CitiesService(HttpClient http) => this.http = http;

        public async Task<int> CreateAsync(CitiesListingResponseModel model)
        {
            var addressResponse = await this.http.PostAsJsonAsync(Path, model);
            var addressId = await addressResponse.Content.ReadFromJsonAsync<int>();

            return addressId;
        }

        public async Task<Result> DeleteAsync(int id)
            => await this.http
                .DeleteAsync(PathWithSlash + id)
                .ToResult();

        public async Task<IEnumerable<CitiesListingResponseModel>> Cities()
        => await this.http.GetFromJsonAsync<IEnumerable<CitiesListingResponseModel>>(Path);
    }
}
