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


    public class MyOrderInformationUnitTest
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

        [TestCase(ECoinCurrency.ETH, 1000, 2)]
        public async Task MyOrderInformationTest(ECoinCurrency currency, double price, double qty)
        {

            //터무니 없는 주문으로 하나 날리고

            try
            {
                RequestLimitBuy req_buy = new RequestLimitBuy(currency, price, qty, true);

                var buy_res = await _coinoneClient.SendRequestAsync<ResponseLimitBuy>(req_buy);

                if (buy_res.IsSuccess)
                {

                    RequestMyOrderInformation req_order_info = new RequestMyOrderInformation(currency, buy_res.Result.OrderId);

                    var order_info_res = await _coinoneClient.SendRequestAsync<ResponseMyOrderInformation>(req_order_info);

                    //다시 취소 해야지

                    RequestCancelOrder req_cancel = new RequestCancelOrder(req_buy.Currency, buy_res.Result.OrderId, req_buy.Price, req_buy.Qty, false);

                    var cancel_res = await _coinoneClient.SendRequestAsync<ResponseCancelOrder>(req_cancel);



                    Assert.AreEqual(order_info_res.IsSuccess && order_info_res.IsSuccess && cancel_res.IsSuccess, true, order_info_res.Message);
                }

            }
            catch (CoinoneSDKException e)
            {
                Assert.Fail(e.Message);
            }
        }
    }


}