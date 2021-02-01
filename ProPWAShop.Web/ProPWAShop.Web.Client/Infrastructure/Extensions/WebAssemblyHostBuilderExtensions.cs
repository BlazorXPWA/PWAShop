using System;
using System.Net.Http;

using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ProPWAShop.Web.Client.Infrastructure.Extensions
{

    using Services.Addresses;
    using Services.Authentication;
    using Services.Cities;
    using Services.Categories;
    using Services.Orders;
    using Services.Products;
    using Services.ShoppingCarts;
    using Services.Wishlists;
    using ProPWAShop.Web.Client.Infrastructure.Services.Users;
    using ProPWAShop.Web.Client.Infrastructure.Services.Confirm;
    //using ProPWAShop.Web.Client.Infrastructure.Services.Confirmation;

    public static class WebAssemblyHostBuilderExtensions
    {
        private const string ClientName = "ProPWAShop.ServerAPI";

        public static WebAssemblyHostBuilder AddRootComponents(this WebAssemblyHostBuilder builder)
        {
            builder.RootComponents.Add<App>("app");

            return builder;
        }

        public static WebAssemblyHostBuilder AddClientServices(this WebAssemblyHostBuilder builder)
        {
            builder
                .Services
                .AddAuthorizationCore()
                .AddBlazoredToast()
                .AddBlazoredLocalStorage()
                .AddScoped<ApiAuthenticationStateProvider>()
                .AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>()
                .AddScoped(sp => sp
                    .GetRequiredService<IHttpClientFactory>()
                    .CreateClient(ClientName))
                .AddTransient<IAuthService, AuthService>()
                .AddTransient<IUsersService, UsersService>()
                .AddTransient<IAddressesService, AddressesService>()
                .AddTransient<ICitiesService, CitiesService>()
                .AddTransient<ICategoriesService, CategoriesService>()
                .AddTransient<IOrdersService, OrdersService>()
                .AddTransient<IProductsService, ProductsService>()
                .AddTransient<IShoppingCartsService, ShoppingCartsService>()
                .AddTransient<IWishlistsService, WishlistsService>()
                .AddTransient<AuthenticationHeaderHandler>()
                .AddHttpClient(
                    ClientName,
                    client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<AuthenticationHeaderHandler>();

            return builder;
        }
    }
}
