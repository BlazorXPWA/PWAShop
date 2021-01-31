namespace ProPWAShop.Web.Client.Pages.Account
{
    using System.Threading.Tasks;

    public partial class Logout
    {
        private async Task Submit()
        {
            this.ToastService.ShowSuccess("Вы вышли из аккаунта", "Все ОК!");
            await this.AuthService.Logout();
        }
    }
}
