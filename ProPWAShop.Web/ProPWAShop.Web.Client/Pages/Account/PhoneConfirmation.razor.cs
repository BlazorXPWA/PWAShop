using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProPWAShop.Web.Client.Pages.Account
{
    using ProPWAShop.Web.Client.Infrastructure.Services.Confirm;
    using Models.Identity;
    public partial class PhoneConfirmation
    {
        private readonly ConfirmationRequestModel model = new ConfirmationRequestModel();
        public bool ok = false;
        public bool confirm = false;
        public bool ShowErrors { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var res = await this.ConfirmationService.SendCode();
              if (res == "Confirm") confirm = true;
                ok = true;
        }
        //protected async override void OnAfterRender(bool firstRender)
        //{
        //    if (ok1) await Task.Run(()=> this.NavigationManager.NavigateTo("/"));
        //}    
        //protected override void OnAfterRender(bool firstRender)
        //{
        //    if (ok1) this.NavigationManager.NavigateTo("/");
        //}

        public IEnumerable<string> Errors { get; set; }
      
        private async Task SubmitAsync()
        {
            if (confirm)
            {
                this.NavigationManager.NavigateTo("/");
                return;
            }

            var result = await this.AuthService.Confirmation(this.model);

            if (result.Succeeded)
            {
                this.ShowErrors = false;
                if(!confirm)
                this.ToastService.ShowSuccess(
                    "Телефон подтвержден.\n Вым добавлена скидка 5%.",
                    "Поздравляем!");

                this.NavigationManager.NavigateTo("/");
            }
            else
            {
                this.Errors = result.Errors;
                this.ShowErrors = true;
            }
        }
    }
}
