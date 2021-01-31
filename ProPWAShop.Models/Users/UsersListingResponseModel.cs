namespace ProPWAShop.Models.Users
{
    using Common.Mapping;
    using Data.Models;

    public class UsersListingResponseModel : IMapFrom<ProPWAShopUser>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int PersonalDiscountPercent { get; set; }               
    }
}

