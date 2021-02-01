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

        [HttpGet(nameof(SendConfirmationCode))]
        public async Task<ActionResult> SendConfirmationCode()
        => await this.confirmService.SendCodeAsync(this.currentUser.UserId)
            .ToActionResult();
              
        [HttpPost(nameof(Confirmation))]
        public async Task<ActionResult> Confirmation(
            ConfirmationRequestModel model)
            => await this.confirmService
                .ConfirmationAsync(model, this.currentUser.UserId)
                .ToActionResult();
    }
}
