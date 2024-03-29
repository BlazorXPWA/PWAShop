﻿namespace ProPWAShop.Web.Server.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Infrastructure.Services;
    using ProPWAShop.Services.Cities;
    using ProPWAShop.Models.Cities;

    public class CitiesController : ApiController
    {
        private readonly ICitiesService cities;
        private readonly ICurrentUserService currentUser;

        public CitiesController(
            ICitiesService cities,
            ICurrentUserService currentUser)
        {
            this.cities = cities;
            this.currentUser = currentUser;
        }
        [HttpGet]
        public async Task<IEnumerable<CitiesListingResponseModel>> All()
        => await this.cities.AllCitiesAsync();
      
    }

}
