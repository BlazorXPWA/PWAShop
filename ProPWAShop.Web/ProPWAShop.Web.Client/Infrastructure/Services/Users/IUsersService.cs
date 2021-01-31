using ProPWAShop.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProPWAShop.Web.Client.Infrastructure.Services.Users
{
    public interface IUsersService
    {
        Task<UsersListingResponseModel> GetCurrentUserData(); 
    }
}
