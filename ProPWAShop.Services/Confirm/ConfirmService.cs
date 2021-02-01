using AutoMapper;
using ProPWAShop.Data;
using ProPWAShop.Data.Models;
using ProPWAShop.Models;
using ProPWAShop.Models.Identity;
using ProPWAShop.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ProPWAShop.Services.Confirm
{
    public class ConfirmService : BaseService<ConfirmCode>, IConfirmService
    {
        ProPWAShopDbContext DBContext;
        public ConfirmService(ProPWAShopDbContext data, IMapper mapper)
            : base(data, mapper)
        {
            DBContext = data;
        }


        //public async Task SendSMS(
        //     string userId)
        //{
        //    var baseAddress = new Uri("https://my.phoenix-dnr.ru"); 
        //    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

        //    var cookieContainer = new CookieContainer();
        //    using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
        //    using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
        //    {
        //        var content = new FormUrlEncodedContent(new[]
        //        {
        //            new KeyValuePair<string, string>("dstlogin", "380718802832"),
        //            new KeyValuePair<string, string>("message", "world"),
        //        });
        //        cookieContainer.Add(baseAddress, new Cookie("_ga", "GA1.2.834748369.1611517096"));
        //        cookieContainer.Add(baseAddress, new Cookie("_ym_uid", "1611517097475116639"));
        //        cookieContainer.Add(baseAddress, new Cookie("_ym_d", "1611517097"));
        //        cookieContainer.Add(baseAddress, new Cookie("XSRF-TOKEN", "3ede0d85-e331-4098-95ae-a265b70e9e59"));
        //        cookieContainer.Add(baseAddress, new Cookie("JSESSIONID", "7EEB6DE35F648FB9FF1889CF9C6C1238"));
        //        try
        //        {

        //        var result = await client.PostAsync("/sendSMS", content);
        //        result.EnsureSuccessStatusCode();
        //        }
        //        catch 
        //        {

        //        }
        //    }
        //}


            //HttpClient client = new HttpClient();
            //var values = new Dictionary<string, string>
            //    {
            //        { "dstlogin", "380718802832" },
            //        { "message", "world" }
            //    };

            //var content = new FormUrlEncodedContent(values);

            //var response = await client.PostAsync("", content);

            //var responseString = await response.Content.ReadAsStringAsync();
        

        //public Task<string> SendCode(
        //     string userId)
        //{
        //    return Task<string>.Run(() => "123");
        //}
        public async Task<Result> SendCodeAsync(
             string userId)
        {           
            var User = DBContext.Users.FirstOrDefault(e => e.Id == userId);
            if (User.EmailConfirmed == true) return "Confirm";
            if (User == null) return "Ошибка акторизации";
            Random rnd = new Random();
            int code = rnd.Next(10000, 99999);
            var bot = new TelegramBotClient("1614843593:AAFVzDmH70pPgDcMMvUwOBPmDaUR1146T98");
            var res = await bot.SendTextMessageAsync("-1001273688019", $" +38071{User.PhoneNumber} {code}");
            ConfirmCode ConfirmCode = new ConfirmCode()
            {
                UserId = userId,
                MessageId = res.MessageId,
                Code = code,
            };

            await this.Data.AddAsync(ConfirmCode);
            await this.Data.SaveChangesAsync();

            if (res.MessageId == 0)
            {
                return "Ошибка отправки пароля";
            }
            return ConfirmCode.Id;
        }

        public async Task<Result> ConfirmationAsync(ConfirmationRequestModel model, string userId)
        {
            var User = await Task.Run(() => DBContext.Users.FirstOrDefault(e => e.Id == userId));
            if (User == null) return "Ошибка акторизации";

            var codes = DBContext.ConfirmCode.Where(e => e.UserId == userId).Select(e=>e.Code).ToList();

            var errors = new List<string>() { "Неправильный код" };
            if (!codes.Contains(model.PhoneConfirmation)) return Result.Failure(errors);
            User.PhoneNumberConfirmed = true;
            User.EmailConfirmed = true;
            User.PersonalDiscountPercent += 5;
            await this.DBContext.SaveChangesAsync();

            return Result.Success;
        }
               
    }
}
