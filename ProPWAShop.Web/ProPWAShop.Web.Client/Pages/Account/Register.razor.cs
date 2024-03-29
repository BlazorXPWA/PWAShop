﻿namespace ProPWAShop.Web.Client.Pages.Account
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Models.Identity;

    public partial class Register
    {
        private readonly RegisterRequestModel model = new RegisterRequestModel();

        public bool ShowErrors { get; set; }

        public IEnumerable<string> Errors { get; set; }

        private async Task SubmitAsync()
        {
            var result = await this.AuthService.Register(this.model);

            if (result.Succeeded)
            {
                this.ShowErrors = false;

                this.ToastService.ShowSuccess(
                    "Вы успешно зарегистрировались.\n Выполните вход на сайт.",
                    "Поздравляем!");

                this.NavigationManager.NavigateTo("/account/login");
            }
            else
            {
                this.Errors = result.Errors;
                this.ShowErrors = true;
            }
        }
    }
}
