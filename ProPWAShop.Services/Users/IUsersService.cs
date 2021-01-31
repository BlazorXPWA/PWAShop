using ProPWAShop.Data.Models;
using ProPWAShop.Models.Users;
using ProPWAShop.Services.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProPWAShop.Services.Users
{
    public interface IUsersService : IService
    {
        Task<ProPWAShopUser> GetAsync(string userId);
        Task<UsersListingResponseModel> FindListingResponseModelByIdAsync(string userId);
    }
}
