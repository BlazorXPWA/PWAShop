namespace ProPWAShop.Services.Cities
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ProPWAShop.Models.Cities;
    using Common;
    using Models;

    public interface ICitiesService : IService
    {
        Task<int> CreateAsync(CitiesRequestModel model, string userId);

        Task<Result> DeleteAsync(int id);

        Task<IEnumerable<CitiesListingResponseModel>> AllCitiesAsync();
    }
}