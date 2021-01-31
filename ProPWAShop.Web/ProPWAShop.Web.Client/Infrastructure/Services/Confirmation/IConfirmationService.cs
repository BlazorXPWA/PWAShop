using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProPWAShop.Web.Client.Infrastructure.Services.Confirmation
{
    public interface IConfirmationService
    {
        Task<string> SendCode();
    }
}
