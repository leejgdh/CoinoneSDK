using System;
using System.ComponentModel.DataAnnotations;
using Helper.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinoneSDKV2.Models
{

    public class ResponseMyOrderInformation
    {
        
//         {
//   "result": "success",
//   "errorCode": "0",
//   "orderId": "0e3019f2-1e4d-11e9-9ec7-00e04c3600d7",
//   "baseCurrency": "KRW",
//   "targetCurrency": "BTC",
//   "price": "10011000.0",
//   "originalQty": "3.0",
//   "executedQty": "0.62",
//   "canceledQty": "1.125",
//   "remainQty": "1.255",
//   "status": "partially_filled",
//   "side": "bid",
//   "orderedAt": "1499340941",
//   "updatedAt": "1499341142",
//   "feeRate": "0.002",
//   "fee": "0.00124",
//   "averageExecutedPrice": "10011000.0"
// }

        [JsonProperty("orderId")]
        public Guid OrderId { get; set; }

        [JsonProperty("baseCurrency")]
        [EnumDataType(typeof(ECoinCurrency))]
        [JsonConverter(typeof(StringEnumConverter))]
        public ECoinCurrency BaseCurrency { get; set; }

        [JsonProperty("targetCurrency")]
        [EnumDataType(typeof(ECoinCurrency))]
        [JsonConverter(typeof(StringEnumConverter))]
        public ECoinCurrency TargetCurrency { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("originalQty")]
        public double OriginalQty { get; set; }

        [JsonProperty("executedQty")]
        public double ExecutedQty { get; set; }

        [JsonProperty("canceledQty")]
        public double CanceledQty { get; set; }

        [JsonProperty("remainQty")]
        public double RemainQty { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("orderedAt")]
        public long OrderedAt { get; set; }

        [JsonProperty("updatedAt")]
        public long UpdatedAt { get; set; }

        [JsonProperty("feeRate")]
        public string FeeRate { get; set; }

        [JsonProperty("fee")]
        public double Fee { get; set; }

        [JsonProperty("averageExecutedPrice")]
        public double AverageExecutedPrice { get; set; }
    }
}
