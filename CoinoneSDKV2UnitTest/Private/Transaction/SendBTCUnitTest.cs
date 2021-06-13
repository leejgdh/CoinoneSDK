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


    public class SendBTCUnitTest
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

        [TestCase(0,ECoinoneTradeType.NORMAL,0,0,1)]
        public async Task SendBTCTest(long authNumber, ECoinoneTradeType type, string fromAddress, string address, double qty)
        {
            try
            {
                RequestSendBTC req_send_btc = new RequestSendBTC(authNumber,type,fromAddress,address,qty);

                var res_send_btc = await _coinoneClient.SendRequestAsync<ResponseSendBTC>(req_send_btc);

                if (res_send_btc.IsSuccess)
                {

                    Assert.AreEqual(res_send_btc.IsSuccess, true, res_send_btc.Message);
                }

            }
            catch (CoinoneSDKException e)
            {
                Assert.Fail(e.Message);
            }
        }
    }


}