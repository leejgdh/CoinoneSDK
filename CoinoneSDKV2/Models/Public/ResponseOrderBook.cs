using System.Collections.Generic;
using Helper.Models;
using Newtonsoft.Json;

namespace CoinoneSDKV2.Models
{

    public class ResponseOrderBook
    {
        [JsonProperty("currency")]
        public ECoinCurrency Currency { get; set; }

        [JsonProperty("bid")]
        public List<OrderBookItem> Bid { get; set; }

        [JsonProperty("ask")]
        public List<OrderBookItem> Ask { get; set; }

        public class OrderBookItem
        {
            [JsonProperty("price")]
            public string Price { get; set; }

            [JsonProperty("qty")]
            public string Qty { get; set; }
        }
    }


}