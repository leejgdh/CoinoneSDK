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


    public class RecentCompleteOrdersUnitTest
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

            _coinoneClient = new CoinoneClient(_secretKey);

        }

        [Test]
        public async Task RecentCompleteOrders()
        {
            try
            {
                RequestRecentCompleteOrders requestOrderBook = new RequestRecentCompleteOrders(ECoinCurrency.BTC);

                var res = await _coinoneClient.SendRequestAsync<ResponseRecentCompleteOrders>(requestOrderBook);

                Assert.AreEqual(res.IsSuccess, true, res.Message);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }


}