using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using Helper.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinoneSDKV2.Models
{

    public class RequestLimitBuy : CoinonePrivateRequestBase, ICoinonePrivateApiRequest
    {

        public RequestLimitBuy(ECoinCurrency currency, double price, double qty)
        {
            Currency = currency;
            Price = price;
            Qty = qty;
        }

        public RequestLimitBuy(ECoinCurrency currency, double price, double qty, bool isPostOnly)
        {
            Currency = currency;
            Price = price;
            Qty = qty;
            IsPostOnly = isPostOnly;
        }

        [JsonIgnore]
        public string EndPoint => "/v2/order/limit_buy";

        [JsonIgnore]
        public HttpMethod Method => HttpMethod.Post;

        [JsonProperty("price")]
        [Required]
        public double Price { get; set; }

        [JsonProperty("qty")]
        [Required]
        public double Qty { get; set; }

        [JsonProperty("currency")]
        [Required]
        [EnumDataType(typeof(ECoinCurrency))]
        [JsonConverter(typeof(StringEnumConverter))]
        public ECoinCurrency Currency { get; set; }

        [JsonProperty("is_post_only")]
        public bool IsPostOnly { get; set; }
        
    }
}