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


    public class CancelOrderUnitTest
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

        [TestCase(ECoinCurrency.ETH, 10000, 1)]
        public async Task CancelOrderTest(ECoinCurrency currency, double price, double qty)
        {
            try
            {
                RequestLimitBuy req_buy = new RequestLimitBuy(ECoinCurrency.ETH, price, qty, true);

                var buy_res = await _coinoneClient.SendRequestAsync<ResponseLimitBuy>(req_buy);

                if (buy_res.IsSuccess)
                {

                    RequestCancelOrder cancel_order_req = new RequestCancelOrder(req_buy.Currency, buy_res.Result.OrderId, req_buy.Price, req_buy.Qty, true);

                    var cancel_res = await _coinoneClient.SendRequestAsync<ResponseCancelOrder>(cancel_order_req);

                    Assert.AreEqual(cancel_res.IsSuccess, true, cancel_res.Message);
                }

            }
            catch (CoinoneSDKException e)
            {
                Assert.Fail(e.Message);
            }
        }
    }


}