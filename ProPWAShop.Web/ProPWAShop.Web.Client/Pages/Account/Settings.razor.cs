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
    using ProPWAShop.Models;

    public partial class Settings
    {
        private ChangeSettingsRequestModel model;
        private string phone;
        public bool phoneConfirmedVisibiliy = false;
        Result s;
        public bool ShowErrors { get; set; }

        public IEnumerable<string> Errors { get; set; }

        protected override async Task OnInitializedAsync() => await this.LoadDataAsync();

        private async Task LoadDataAsync()
        {
            this.model = await AuthService.GetUserData();
            //this.phone = $"+38(071){model.Phone.Substring(1, 2)}/*-{ model.Phone.Substring(3, 4)}-{ model.Phone.Substring(5, 6)}*/";

            this.phone = $"+38(071){model.Phone.Substring(0, 3)}-{ model.Phone.Substring(3, 2)}-{ model.Phone.Substring(5, 2)}";
             
            if (!model.PhoneConfirmed) s = await AuthService.SendConfirmationCode();
            s = Result.Success;
        }

        private async Task SubmitAsync()
        {
            var response = await this.Http.PutAsJsonAsync("api/identity/changesettings", this.model);
            if (!model.PhoneConfirmed)
            s = await AuthService.Confirmation(new ConfirmationRequestModel() { PhoneConfirmation = model.PhoneConfirmation });

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

        }

    }
}





