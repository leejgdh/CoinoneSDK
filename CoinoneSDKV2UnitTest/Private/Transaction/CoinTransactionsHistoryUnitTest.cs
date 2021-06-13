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


    public class CoinTransactionsHistoryUnitTest
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
        public async Task CoinTransactionsHistoryTest(ECoinCurrency currency)
        {
            try
            {
                RequestCoinTransationsHistory req_coin_tran = new RequestCoinTransationsHistory(currency);

                var res_coin_tran = await _coinoneClient.SendRequestAsync<ResponseCoinTransactionsHistory>(req_coin_tran);

                if (res_coin_tran.IsSuccess)
                {

                    Assert.AreEqual(res_coin_tran.IsSuccess, true, res_coin_tran.Message);
                }

            }
            catch (CoinoneSDKException e)
            {
                Assert.Fail(e.Message);
            }
        }
    }


}