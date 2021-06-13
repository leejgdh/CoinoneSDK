using System;
using Newtonsoft.Json;

namespace CoinoneSDKV2.Models
{

    public struct ResponseLimitBuy 
    {
        [JsonProperty("orderId")]
        public Guid OrderId{get; set;}
    }
}