using AutoMapper;
using ProPWAShop.Data;
using ProPWAShop.Data.Models;
using ProPWAShop.Models;
using ProPWAShop.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProPWAShop.Services.Users
{
     public class UsersService : BaseService<ProPWAShopUser>, IUsersService
    {
        public UsersService(ProPWAShopDbContext data, IMapper mapper)
            : base(data, mapper)
        {
        }

        public async Task<ProPWAShopUser> GetAsync(
            string userId)
        {
            var user = await FindByIdAsync(userId);

            return user;
        }

        private async Task<ProPWAShopUser> FindByIdAsync(
            string id)
            => await this
                .All()
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();


        public async Task<UsersListingResponseModel> FindListingResponseModelByIdAsync(
    string userId)
    => await this.Mapper
        .ProjectTo<UsersListingResponseModel>(this
            .AllAsNoTracking()
            .Where(a => a.Id == userId))
        .FirstOrDefaultAsync();
    }
}
