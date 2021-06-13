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


    public class TwoFactorAuthenticationUnitTest
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

        [TestCase(ECoinCurrency.ETH)]
        public async Task TwoFactorAuthenticationTest(ECoinCurrency currency)
        {
            try
            {
                RequestTwoFactorAuthentication req_two_factor = new RequestTwoFactorAuthentication(currency);

                var res_two_factor = await _coinoneClient.SendRequestAsync<ResponseTwoFactorAuthentication>(req_two_factor);
                
                if (res_two_factor.IsSuccess)
                {

                    Assert.AreEqual(res_two_factor.IsSuccess, true, res_two_factor.Message);
                }

            }
            catch (CoinoneSDKException e)
            {
                Assert.Fail(e.Message);
            }
        }
    }


}