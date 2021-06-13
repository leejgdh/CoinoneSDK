using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using Helper.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinoneSDKV2.Models
{

    public class RequestCoinTransationsHistory : CoinonePrivateRequestBase, ICoinonePrivateApiRequest
    {
        public RequestCoinTransationsHistory(ECoinCurrency currency)
        {
            Currency = currency;
        }

        public string EndPoint => "/v2/transaction/history";

        public HttpMethod Method => HttpMethod.Post;


        [JsonProperty("currency")]
        [Required]
        [EnumDataType(typeof(ECoinCurrency))]
        [JsonConverter(typeof(StringEnumConverter))]
        public ECoinCurrency Currency { get; set; }
    }
}