using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinoneSDKV2.Models
{

    public class ResponseMyLimitOrders 
    {

        [JsonProperty("limitOrders")]
        public List<LimitOrder> LimitOrders { get; set; }

        public struct LimitOrder
        {
            [JsonProperty("index")]
            public long Index { get; set; }

            [JsonProperty("orderId")]
            public Guid OrderId { get; set; }

            [JsonProperty("timestamp")]
            public long Timestamp { get; set; }

            [JsonProperty("price")]
            public double Price { get; set; }

            [JsonProperty("qty")]
            public double Qty { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("feeRate")]
            public double FeeRate { get; set; }
        }
    }


}