using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using Helper.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinoneSDKV2.Models
{

    public class RequestMyLimitOrders : CoinonePrivateRequestBase, ICoinonePrivateApiRequest
    {
        public RequestMyLimitOrders(ECoinCurrency currency)
        {
            Currency = currency;
        }

        [JsonIgnore]
        public string EndPoint => "/v2/order/limit_orders";

        [JsonIgnore]
        public HttpMethod Method => HttpMethod.Post;

        [JsonProperty("currency")]
        [Required]
        [EnumDataType(typeof(ECoinCurrency))]
        [JsonConverter(typeof(StringEnumConverter))]
        public ECoinCurrency Currency { get; set; }

    }
}