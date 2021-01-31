namespace ProPWAShop.Web.Client.Infrastructure.Services.Cities
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Models;
    using Models.Cities;


    public interface ICitiesService
    {
        Task<int> CreateAsync(CitiesListingResponseModel model);

        Task<Result> DeleteAsync(int id);

        Task<IEnumerable<CitiesListingResponseModel>> Cities();

        //Task<Result> UpdateProduct(CitiesListingResponseModel model);
    }
}