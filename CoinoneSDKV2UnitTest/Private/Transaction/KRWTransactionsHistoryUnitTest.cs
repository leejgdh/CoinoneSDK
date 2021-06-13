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


    public class KRWTransactionsHistoryUnitTest
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
        public async Task KRWTransactionsHistoryTest()
        {
            try
            {
                RequestKRWTransactionsHistory req_krw_tran = new RequestKRWTransactionsHistory();

                var res_krw_tran = await _coinoneClient.SendRequestAsync<ResponseKRWTransactionsHistory>(req_krw_tran);

                if (res_krw_tran.IsSuccess)
                {

                    Assert.AreEqual(res_krw_tran.IsSuccess, true, res_krw_tran.Message);
                }

            }
            catch (CoinoneSDKException e)
            {
                Assert.Fail(e.Message);
            }
        }
    }


}