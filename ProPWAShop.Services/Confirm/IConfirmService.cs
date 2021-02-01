using ProPWAShop.Models;
using ProPWAShop.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProPWAShop.Services.Confirm
{
   public interface IConfirmService
    {
        Task<Result> SendCodeAsync(string userId);
        Task<Result> ConfirmationAsync(ConfirmationRequestModel model, string userId);
    }
}
