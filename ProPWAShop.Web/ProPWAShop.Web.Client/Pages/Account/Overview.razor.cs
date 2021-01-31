namespace ProPWAShop.Web.Client.Pages.Account
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ProPWAShop.Models.Wishlists;
    using Infrastructure.Extensions;
    using Models.Orders;

    public partial class Overview
    {
        private IEnumerable<OrdersListingResponseModel> orders;
        private IEnumerable<WishlistsProductsResponseModel> products;

        private string email;
        private string firstName;
        private string lastName;
        //private string addres;

        protected override async Task OnInitializedAsync() => await this.LoadDataAsync();
        //private async Task LoadDataAsync() => this.products = await this.WishlistsService.Mine();

        private async Task LoadDataAsync()
        {
            var state = await this.AuthState.GetAuthenticationStateAsync();
            var user = state.User;
            this.products = await this.WishlistsService.Mine();

            this.email = user.GetEmail();
            this.firstName = user.GetFirstName();
            this.lastName = user.GetLastName();
            //this.addres = user.GetLastName();

            this.orders = await this.OrdersService.Mine();
            this.orders = this.orders.Take(4);
        }
    }
}
