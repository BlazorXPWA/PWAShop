using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ProPWAShop.Web.Client.Infrastructure.Services.Confirmation
{
    public class ConfirmationService : IConfirmationService
    {
        private readonly HttpClient http;

        private const string Path = "api/ConfirmsMessage";
        public ConfirmationService(HttpClient http) => this.http = http;

        public async Task<string> SendCode()
        {
            try
            {
                object res = http.GetAsync("api / ConfirmsMessage/Test");

                return await this.http.GetFromJsonAsync<string>(Path);
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }        
    }
}
