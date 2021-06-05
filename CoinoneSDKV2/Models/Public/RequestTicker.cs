using System;
using System.Net.Http;
using Helper.Models;
using Newtonsoft.Json;

namespace CoinoneSDKV2.Models
{
    public class RequestTicker : IApiRequest
    {
        public RequestTicker()
        {
        }

        public RequestTicker(ECoinCurrency currency)
        {
            Currency = currency;
        }


        [JsonIgnore]
        public string EndPoint => "/ticker";

        [JsonIgnore]
        public HttpMethod Method => HttpMethod.Get;


        [JsonProperty("currency")]
        public ECoinCurrency Currency { get; set; }


        public string ToPayload()
        {
            throw new NotImplementedException();
        }
    }
}
