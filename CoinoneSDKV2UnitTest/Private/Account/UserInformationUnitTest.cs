using System;
using System.IO;
using System.Threading.Tasks;
using CoinoneSDKV2.Clients;
using CoinoneSDKV2.Models;
using Helper.Models;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace CoinoneSDKV2UnitTest
{


    public class UserInformationUnitTest
    {

        private string _secretKey;
        private string _accessToken;

        private CoinoneClient _coinoneClient;

        [SetUp]
        public void Setup()
        {

            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString())
            .AddJsonFile(@"appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            _secretKey = config.GetSection("Coinone")["SecretKey"];
            _accessToken = config.GetSection("Coinone")["AccessToken"];

            _coinoneClient = new CoinoneClient(_secretKey, _accessToken);

        }

        [TestCase]
        public async Task UserInformationTest()
        {
            try
            {
                RequestUserInformation req_user_info = new RequestUserInformation();

                var user_info_res = await _coinoneClient.SendRequestAsync<ResponseUserInformation>(req_user_info);

                if (user_info_res.IsSuccess)
                {

                    Assert.AreEqual(user_info_res.IsSuccess, true, user_info_res.Message);
                }

            }
            catch (CoinoneSDKException e)
            {
                Assert.Fail(e.Message);
            }
        }
    }


}