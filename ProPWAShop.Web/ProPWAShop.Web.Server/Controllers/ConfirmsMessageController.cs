using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProPWAShop.Services.Confirm;
using ProPWAShop.Web.Server.Infrastructure.Services;
using ProPWAShop.Models.Users;
using ProPWAShop.Models.Identity;
using ProPWAShop.Web.Server.Infrastructure.Extensions;

namespace ProPWAShop.Web.Server.Controllers
{
    [Authorize]
    public class ConfirmsMessageController : ApiController
    {
        private readonly IConfirmService confirmService;
        private readonly ICurrentUserService currentUser;

        public ConfirmsMessageController(
            IConfirmService confirmService,
            ICurrentUserService currentUser)
        {
            this.confirmService = confirmService;
            this.currentUser = currentUser;
        }

        [HttpGet]
        //[AllowAnonymous]
        public async Task<string> Index()
        //=> await this.confirmService.SendCode("2f1cfe91-195b-47bc-887d-699d4110c39b");
        => await this.confirmService.SendCodeAsync(this.currentUser.UserId);

        [HttpGet(nameof(Test))]
        //[AllowAnonymous]
        public Task<string> Test()
        //=> await this.confirmService.SendCode("2f1cfe91-195b-47bc-887d-699d4110c39b");
        =>  this.confirmService.SendCode(this.currentUser.UserId);

        [HttpPost(nameof(Confirmation))]
        public async Task<ActionResult> Confirmation(
            ConfirmationRequestModel model)
            => await this.confirmService
                .ConfirmationAsync(model, this.currentUser.UserId)
                .ToActionResult();
    }
}
