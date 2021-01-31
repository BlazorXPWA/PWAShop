namespace ProPWAShop.Web.Client.Pages.Account
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using ProPWAShop.Models.Users;
    using Infrastructure.Extensions;
    using Models.Identity;
    using System.Threading;

    public partial class Settings
    {
        private ChangeSettingsRequestModel model;

        private string phone;
        private int PhoneConfirmationCode = 0;
        public bool phoneConfirmedVisibiliy = false;

        public bool ShowErrors { get; set; }

        public IEnumerable<string> Errors { get; set; }

        protected override async Task OnInitializedAsync() => await this.LoadDataAsync();

        private async Task LoadDataAsync()
        {
            this.model = await AuthService.GetUserData();
            //this.phone = $"+38(071){model.Phone.Substring(1, 2)}/*-{ model.Phone.Substring(3, 4)}-{ model.Phone.Substring(5, 6)}*/";

            this.phone = $"+38(071){model.Phone}";
        }

        private async Task SubmitAsync()
        {
            var response = await this.Http.PutAsJsonAsync("api/identity/changesettings", this.model);

            if (response.IsSuccessStatusCode)
            {
                this.ShowErrors = false;

                await this.AuthService.Logout();

                this.ToastService.ShowSuccess("Ваш аккаунт был успешно изменен.\n Пожалуйста выполните вход.","Все ОК!");
                this.NavigationManager.NavigateTo("/account/login");
            }
            else
            {
                this.Errors = await response.Content.ReadFromJsonAsync<string[]>();
                this.ShowErrors = true;
            }
            this.model.PhoneConfirmation = PhoneConfirmationCode;
        }

    }
}
//this.userData = await this.UsersService.GetCurrentUserData();
//if (userData.PersonalDiscountPercent == 0) phoneConfirmedVisibiliy = true;
// var state = await this.AuthState.GetAuthenticationStateAsync();
//var user = state.User;
//this.phone = "+38(071) " + user.GetEmail().Substring(0, 7);
//this.model.FirstName = user.GetFirstName();
//this.model.LastName = user.GetLastName();