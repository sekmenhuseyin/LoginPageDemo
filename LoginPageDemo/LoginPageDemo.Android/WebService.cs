using LoginPageDemo.WebService;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System;
using LoginPageDemo.Droid.AndroidService;
using LoginPageDemo.WebService.Models;

[assembly: Dependency(typeof(LoginPageDemo.Droid.WebService))]
namespace LoginPageDemo.Droid
{
    public sealed class WebService : IService
    {
        AndroidService.Android service;

        public WebService()
        {
            service = new AndroidService.Android()
            {
                Url = "http://testserver:9080/service/android.asmx"
            };
        }

        public async Task<AndroidService.Login> LoginKontrol(string userID, string sifre, string AndroidID)
        {
            return await Task.Run(() =>
            {
                var result = service.LoginKontrol(userID, sifre, AndroidID);

                return result;
            });
        }

        Task<LoginPageDemo.WebService.Models.Login> IService.LoginKontrol(string userID, string sifre, string AndroidID)
        {
            throw new NotImplementedException();
        }
    }
}