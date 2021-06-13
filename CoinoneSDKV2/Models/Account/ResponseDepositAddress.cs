using System.Collections.Generic;
using Helper.Models;
using Newtonsoft.Json;

namespace CoinoneSDKV2.Models
{

    public struct ResponseDepositAddress
    {

        [JsonProperty("walletAddress")]
        
        public Dictionary<ECoinCurrency, string> WalletAddress { get; set; }
    }
}