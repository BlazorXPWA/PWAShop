namespace ProPWAShop.Web.Server.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Infrastructure.Services;
    using ProPWAShop.Data.Models;
    using ProPWAShop.Services.Deliveries;
    using Microsoft.AspNetCore.Authorization;
    using static Common.Constants;
    using ProPWAShop.Web.Server.Infrastructure.Extensions;

    [Authorize(Roles = AdministratorRole)]
    public class DeliveriesController : ApiController
    {
        private readonly IDeliveryService deliveries;
        private readonly ICurrentUserService currentUser;

        public DeliveriesController(
            IDeliveryService deliveries,
            ICurrentUserService currentUser)
        {
            this.deliveries = deliveries;
            this.currentUser = currentUser;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Delivery>> AllAsync()
        => await this.deliveries.AllAsync();

        [HttpGet(Id)]
        [AllowAnonymous]
        public async Task<Delivery> FindByIdAsync(int id)
        => await this.deliveries.FindByIdAsync(id);

        [HttpPost]
        public async Task<ActionResult> CreateAsync(
            Delivery model)
        {
            var id = await this.deliveries.CreateAsync(model);

            return Created(nameof(this.CreateAsync), id);
        }

        [HttpPut(Id)]
        public async Task<ActionResult> UpdateAsync(
            int id, Delivery model)
            => await this.deliveries
                .UpdateAsync(id, model)
                .ToActionResult();

        [HttpDelete(Id)]
        public async Task<ActionResult> DeleteAsync(
            int id)
            => await this.deliveries
                .DeleteAsync(id)
                .ToActionResult();
    }
}
