using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Helper.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinoneSDKV2.Models
{
    public class ResponseRecentCompleteOrders
    {
        public ResponseRecentCompleteOrders()
        {
        }

        [JsonProperty("currency")]
        [EnumDataType(typeof(ECoinCurrency))]
        [JsonConverter(typeof(StringEnumConverter))]
        public ECoinCurrency Currency { get; set; }

        [JsonProperty("completeOrders")]
        public List<PublicCompleteOrder> CompleteOrders { get; set; }


        public class PublicCompleteOrder
        {
            [JsonProperty("timestamp")]
            public long Timestamp { get; set; }

            [JsonProperty("price")]
            public double Price { get; set; }

            [JsonProperty("qty")]
            public double Qty { get; set; }

            public bool IsAsk { get; set; }

            [JsonProperty("is_ask")]
            private string _isAsk { get { return IsAsk ? "1" : "0"; } set { IsAsk = value == "1" ? true : false; } }
        }
    }


}
