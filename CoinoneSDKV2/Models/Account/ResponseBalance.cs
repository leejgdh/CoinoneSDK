using System.Collections.Generic;
using Helper.Models;
using Newtonsoft.Json;

namespace CoinoneSDKV2.Models
{

    public struct ResponseBalance
    {


        [JsonProperty("normalWallets")]
        public List<Dictionary<ECoinCurrency, NormalWallet>> NormalWallets { get; set; }


        public Dictionary<ECoinCurrency, BalanceDic> Balances { get; set; }


        public struct NormalWallet
        {

            [JsonProperty("balance")]
            public double Balance { get; set; }

            [JsonProperty("label")]
            public string Label { get; set; }
        }

        public struct BalanceDic
        {

            [JsonProperty("avail")]
            public double Avail { get; set; }

            [JsonProperty("balance")]
            public string Balance { get; set; }
        }
    }
}