namespace ProPWAShop.Services.Identity
{
    using System.Threading.Tasks;
    using Common;
    using Data.Models;

    public interface IJwtGeneratorService : IService
    {
        Task<string> GenerateJwtAsync(ProPWAShopUser user);
    }
}
