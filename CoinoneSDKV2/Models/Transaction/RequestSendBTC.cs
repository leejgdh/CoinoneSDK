using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using Helper.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinoneSDKV2.Models
{

    public class RequestSendBTC : CoinonePrivateRequestBase, ICoinonePrivateApiRequest
    {
        public RequestSendBTC(long authNumber, ECoinoneTradeType type, string fromAddress, string address, double qty)
        {
            AuthNumber = authNumber;
            Type = type;
            FromAddress = fromAddress;
            Address = address;
            Qty = qty;

        }

        public string EndPoint => "/v2/transaction/btc";


        public HttpMethod Method => HttpMethod.Post;

        [JsonProperty("auth_number")]
        [Required]
        public long AuthNumber { get; set; }

        [JsonProperty("type")]
        [Required]
        [EnumDataType(typeof(ECoinoneTradeType))]
        [JsonConverter(typeof(StringEnumConverter))]
        public ECoinoneTradeType Type { get; set; }

        [JsonProperty("from_address")]
        [Required]
        public string FromAddress { get; set; }

        [JsonProperty("address")]
        [Required]
        public string Address { get; set; }

        [JsonProperty("qty")]
        [Required]
        public double Qty { get; set; }


    }
}