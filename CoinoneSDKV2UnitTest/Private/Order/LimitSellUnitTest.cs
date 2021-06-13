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


    public class LimitSellUnitTest
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

        [TestCase(ECoinCurrency.ETH, 10000000, 1)]
        public async Task LimitSellTest(ECoinCurrency currency, double price, double qty)
        {
            try
            {
                RequestLimitSell request_sell = new RequestLimitSell(currency, price, qty, true);

                var sell_res = await _coinoneClient.SendRequestAsync<ResponseLimitSell>(request_sell);

                Assert.AreEqual(sell_res.IsSuccess, true, sell_res.Message);
            }
            catch (CoinoneSDKException e)
            {
                Assert.Fail(e.Message);
            }
        }
    }


}