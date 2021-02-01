namespace ProPWAShop.Services.Identity
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;

    using Data.Models;
    using Models;
    using Models.Identity;
    using System.Collections.Generic;
    using Telegram.Bot;
    using System;
    using ProPWAShop.Data;
    using AutoMapper;

    public class IdentityService : IIdentityService
    {
        private const string InvalidErrorMessage = "Неверный телефон или пароль";

        private readonly UserManager<ProPWAShopUser> userManager;
        private readonly IJwtGeneratorService jwtGenerator;

        public IdentityService(
            UserManager<ProPWAShopUser> userManager,
            IJwtGeneratorService jwtGenerator)
        {
            this.userManager = userManager;
            this.jwtGenerator = jwtGenerator;
        }

        public async Task<Result> RegisterAsync(RegisterRequestModel model)
        {
            var user = new ProPWAShopUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.Phone,
                Email = model.Phone + "@semky.ru",
                UserName = model.FirstName + " " + model.LastName + " " + model.Phone
            };

            var identityResult = await this.userManager.CreateAsync(user, model.Password);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Result.Success
                : Result.Failure(errors);
        }

        public async Task<Result<ChangeSettingsRequestModel>> GetUserDataAsync(string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return InvalidErrorMessage;
            }
            ChangeSettingsRequestModel model = new ChangeSettingsRequestModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.PhoneNumber,
                PhoneConfirmed = user.EmailConfirmed,
                PersonalDiscountPercent = user.PersonalDiscountPercent
            };
            return model;
        }

        public async Task<Result> GetConfirmCodeAsync(string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return InvalidErrorMessage;
            }
            return Result.Success;
        }

        public async Task<Result> ConfirmationAsync(ConfirmationRequestModel model, string userId)
        {

            var user = await this.userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return InvalidErrorMessage;
            }

            var errors = new List<string>() { "Неправильный код" };

            return model.PhoneConfirmation == 1
                ? Result.Success
                : Result.Failure(errors);
        }

        public async Task<Result<LoginResponseModel>> LoginAsync(LoginRequestModel model)
        {
            var user = await this.userManager.FindByEmailAsync(model.Phone + "@donsem.ru");
            if (user == null)
            {
                return InvalidErrorMessage;
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid)
            {
                return InvalidErrorMessage;
            }

            var token = await this.jwtGenerator.GenerateJwtAsync(user);

            return new LoginResponseModel { Token = token };
        }

        public async Task<Result> ChangeSettingsAsync(
            ChangeSettingsRequestModel model, string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return InvalidErrorMessage;
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            

            var identityResult = await this.userManager.UpdateAsync(user);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Result.Success
                : Result.Failure(errors);
        }

        public async Task<Result> ChangePasswordAsync(
            ChangePasswordRequestModel model, string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return InvalidErrorMessage;
            }

            var identityResult = await this.userManager.ChangePasswordAsync(
                user,
                model.Password,
                model.NewPassword);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Result.Success
                : Result.Failure(errors);
        }
    }

}
