using System;
using System.Collections.Generic;
using System.Net.Http;
using Helper.Models;
using Newtonsoft.Json;

namespace CoinoneSDKV2.Models
{
    public class RequestRecentCompleteOrders : IApiRequest
    {
        public RequestRecentCompleteOrders()
        {
        }

        public RequestRecentCompleteOrders(ECoinCurrency currency)
        {
            Currency = currency;
        }


        [JsonIgnore]
        public string EndPoint => "/trades";

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
