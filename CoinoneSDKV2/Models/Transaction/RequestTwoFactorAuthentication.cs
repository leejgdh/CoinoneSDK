using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using Helper.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinoneSDKV2.Models
{

    public class RequestTwoFactorAuthentication : CoinonePrivateRequestBase, ICoinonePrivateApiRequest
    {

        public RequestTwoFactorAuthentication(ECoinCurrency type)
        {
            Type = type;
        }

        public string EndPoint => "/v2/transaction/auth_number";

        public HttpMethod Method => HttpMethod.Post;

        [JsonProperty("type")]
        [Required]
        [EnumDataType(typeof(ECoinCurrency))]
        [JsonConverter(typeof(StringEnumConverter))]
        public ECoinCurrency Type { get; set; }

    }
}