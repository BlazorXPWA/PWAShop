namespace ProPWAShop.Web.Client.Infrastructure.Services.Authentication
{
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Threading.Tasks;

    using Blazored.LocalStorage;
    using Microsoft.AspNetCore.Components.Authorization;

    using Extensions;
    using Infrastructure;
    using Models;
    using Models.Identity;

    public class AuthService : IAuthService
    {
        private readonly HttpClient httpClient;
        private readonly ILocalStorageService localStorage;
        private readonly AuthenticationStateProvider authenticationStateProvider;

        private const string LoginPath = "api/identity/login";
        private const string RegisterPath = "api/identity/register";
        private const string GetUserDataPath = "api/identity/GetUserData";
        private const string ConfirmdPath = "api/ConfirmsMessage/confirmation";
        //private const string ConfirmdPath = "api/identity/confirmation";

        public AuthService(
            HttpClient httpClient,
            ILocalStorageService localStorage,
            AuthenticationStateProvider authenticationStateProvider)
        {
            this.httpClient = httpClient;
            this.localStorage = localStorage;
            this.authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<Result> Register(RegisterRequestModel model)
            => await this.httpClient
                .PostAsJsonAsync(RegisterPath, model)
                .ToResult();

        public async Task<Result> Confirmation(ConfirmationRequestModel model)
            => await this.httpClient
                .PostAsJsonAsync(ConfirmdPath, model)
                .ToResult();

        public async Task<Result> Login(LoginRequestModel model)
        {
            var response = await this.httpClient.PostAsJsonAsync(LoginPath, model);

            if (!response.IsSuccessStatusCode)
            {
                var errors = await response.Content.ReadFromJsonAsync<string[]>();

                return Result.Failure(errors);
            }

            var responseAsString = await response.Content.ReadAsStringAsync();

            var responseObject = JsonSerializer.Deserialize<LoginResponseModel>(responseAsString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var token = responseObject.Token;

            await this.localStorage.SetItemAsync("authToken", token);

            ((ApiAuthenticationStateProvider)this.authenticationStateProvider).MarkUserAsAuthenticated(model.Phone);

            this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return Result.Success;
        }
        
        public async Task<ChangeSettingsRequestModel> GetUserData()
            => await this.httpClient.GetFromJsonAsync<ChangeSettingsRequestModel>(GetUserDataPath);

        public async Task Logout()
        {
            await this.localStorage.RemoveItemAsync("authToken");

            ((ApiAuthenticationStateProvider)this.authenticationStateProvider).MarkUserAsLoggedOut();

            this.httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
