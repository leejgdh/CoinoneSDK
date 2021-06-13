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


    public class TickerUTCUnitTest
    {

        private string _secretKey;
        private string _accessToken;

        private CoinoneClient _coinoneClient;

        [SetUp]
        public void Setup()
        {
            _coinoneClient = new CoinoneClient();

        }

        [Test]
        public async Task TickerUTCTest()
        {
            try
            {
                RequestTickerUTC requestOrderBook = new RequestTickerUTC(ECoinCurrency.BTC);

                var res = await _coinoneClient.SendRequestAsync<ResponseTicker>(requestOrderBook);

                Assert.AreEqual(res.IsSuccess, true, res.Message);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }


}