namespace ProPWAShop.Web.Client.Shared
{
    using System.Threading.Tasks;

    public partial class AccountSidebar
    {
        private async Task Submit()
        {
            this.ToastService.ShowSuccess("Вы вышли из аккаунта.", "Все OК!");
            await this.AuthService.Logout();
        }
    }
}
