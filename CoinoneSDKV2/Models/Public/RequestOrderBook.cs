using System.Net.Http;
using CoinoneSDKV2.Models;
using Helper.Models;
using Newtonsoft.Json;

namespace CoinoneSDKV2.Models
{

    public class RequestOrderBook : IApiRequest
    {
        public RequestOrderBook()
        {
        }

        public RequestOrderBook(ECoinCurrency currency)
        {
            Currency = currency;
        }
        
        [JsonIgnore]
        public string EndPoint => "/orderbook";

        [JsonIgnore]
        public HttpMethod Method => HttpMethod.Get;


        [JsonProperty("currency")]
        public ECoinCurrency Currency { get; set; }

        public string ToPayload()
        {
            throw new System.NotImplementedException();
        }
    }

}