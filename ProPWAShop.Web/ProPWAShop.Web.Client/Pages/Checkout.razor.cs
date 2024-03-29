﻿namespace ProPWAShop.Web.Client.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using ProPWAShop.Data.Models;
    using Infrastructure.Extensions;
    using Models.Addresses;
    using Models.Orders;
    using Models.ShoppingCarts;
    using Models.Cities;

    public partial class Checkout
    {
        private readonly AddressesRequestModel address = new AddressesRequestModel();
        private readonly OrdersRequestModel order = new OrdersRequestModel();

        private string email;
        private decimal totalPrice;
        private IEnumerable<ShoppingCartProductsResponseModel> cartProducts;
        private IEnumerable<CitiesListingResponseModel> cities;

        protected override async Task OnInitializedAsync()
        {
            var state = await this.AuthState.GetAuthenticationStateAsync();
            var user = state.User;
            address.CityId = 1;
            this.email = user.GetEmail();
            this.cities = await this.CitiesService.Cities();
            this.cartProducts = await this.ShoppingCartsService.Mine();
            this.totalPrice = this.cartProducts.Sum(p => p.Price * p.Quantity);
        }

        private async Task SubmitAsync()
        {
            var addressId = await this.AddressesService.CreateAsync(this.address);

            this.order.AddressId = addressId;

            var orderId = await this.OrdersService.Purchase(this.order);

            this.NavigationManager.NavigateTo($"/order/confirmed/{orderId}", forceLoad: true);
        }
    }
    public static class Extensions
    {
        /// <summary>
        ///     A generic extension method that aids in reflecting 
        ///     and retrieving any attribute that is applied to an `Enum`.
        /// </summary>
        public static TAttribute GetAttribute<TAttribute>(this City enumValue)
                where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
        }
    }
}
