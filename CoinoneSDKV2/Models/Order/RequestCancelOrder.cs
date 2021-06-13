using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using Helper.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinoneSDKV2.Models
{

    public class RequestCancelOrder : CoinonePrivateRequestBase, ICoinonePrivateApiRequest
    {
        public RequestCancelOrder(ECoinCurrency currency, Guid orderId, double price, double qty, bool isAsk)
        {

            OrderId = orderId;
            Price = price;
            Qty = qty;
            Currency = currency;
        }


        [JsonIgnore]
        public string EndPoint => "/v2/order/cancel";

        [JsonIgnore]
        public HttpMethod Method => HttpMethod.Post;

        [JsonProperty("order_id")]
        [Required]
        public Guid OrderId { get; set; }

        [JsonProperty("price")]
        [Required]
        public double Price { get; set; }

        [JsonProperty("qty")]
        [Required]
        public double Qty { get; set; }

        [JsonProperty("is_ask")]
        [Required]
        public bool IsAsk { get; set; }

        [JsonProperty("currency")]
        [Required]
        [EnumDataType(typeof(ECoinCurrency))]
        [JsonConverter(typeof(StringEnumConverter))]
        public ECoinCurrency Currency { get; set; }

    }
}