namespace ProPWAShop.Web.Server.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Infrastructure.Services;
    using ProPWAShop.Services.Users;
    using ProPWAShop.Models.Users;

    public class UsersController : ApiController
    {
        private readonly IUsersService users;
        private readonly ICurrentUserService currentUser;

        public UsersController(
            IUsersService users,
            ICurrentUserService currentUser)
        {
            this.users = users;
            this.currentUser = currentUser;
        }
        [HttpGet]
        public async Task<UsersListingResponseModel> GetById()
        => await this.users.FindListingResponseModelByIdAsync(currentUser.UserId);
    }
}
