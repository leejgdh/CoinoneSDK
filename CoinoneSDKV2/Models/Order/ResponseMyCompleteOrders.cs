using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinoneSDKV2.Models
{

    public struct ResponseMyCompleteOrders 
    {
        [JsonProperty("completeOrders")]
        public List<PrivateCompleteOrder> CompleteOrders { get; set; }


        public struct PrivateCompleteOrder
        {
            [JsonProperty("timestamp")]
            public long Timestamp { get; set; }

            [JsonProperty("price")]
            public double Price { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("qty")]
            public double Qty { get; set; }

            [JsonProperty("feeRate")]
            public double FeeRate { get; set; }

            [JsonProperty("fee")]
            public double Fee { get; set; }

            [JsonProperty("orderId")]
            public Guid OrderId { get; set; }
        }
    }


}