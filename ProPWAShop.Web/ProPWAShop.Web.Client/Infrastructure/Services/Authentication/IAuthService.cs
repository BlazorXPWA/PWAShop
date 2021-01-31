namespace ProPWAShop.Web.Client.Infrastructure.Services.Authentication
{
    using System.Threading.Tasks;

    using Models;
    using Models.Identity;

    public interface IAuthService
    {
        Task<Result> Register(RegisterRequestModel model);

        Task<Result> Confirmation(ConfirmationRequestModel model);

        Task<Result> Login(LoginRequestModel model);

        Task<ChangeSettingsRequestModel> GetUserData();

        Task Logout();
    }
}
