using System;
using Newtonsoft.Json;

namespace CoinoneSDKV2.Models
{

    public struct ResponseLimitSell 
    {

        [JsonProperty("orderId")]
        public Guid OrderId{get; set;}
    }
}