using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using Helper.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinoneSDKV2.Models
{

    public class RequestMyOrderInformation : CoinonePrivateRequestBase, ICoinonePrivateApiRequest
    {
        public RequestMyOrderInformation(ECoinCurrency currency, Guid orderId)
        {
            Currency = currency;
            OrderId = orderId;
        }

        [JsonIgnore]
        public string EndPoint => "/v2/order/query_order";

        [JsonIgnore]
        public HttpMethod Method => HttpMethod.Post;

        [JsonProperty("order_id")]
        [Required]
        public Guid OrderId { get; set; }

        [JsonProperty("currency")]
        [Required]
        [EnumDataType(typeof(ECoinCurrency))]
        [JsonConverter(typeof(StringEnumConverter))]
        public ECoinCurrency Currency { get; set; }

    }
}