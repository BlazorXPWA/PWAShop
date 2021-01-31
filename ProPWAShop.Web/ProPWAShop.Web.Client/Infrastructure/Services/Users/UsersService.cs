using ProPWAShop.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ProPWAShop.Web.Client.Infrastructure.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly HttpClient http;

        private const string UsersPath = "api/users";
        private const string UsersPathWithSlash = UsersPath + "/";

        public UsersService(HttpClient http) => this.http = http;              

        public async Task<UsersListingResponseModel> GetCurrentUserData()
            => await this.http.GetFromJsonAsync<UsersListingResponseModel>(UsersPath);

    }
}
