using System.Net.Http;

namespace CoinoneSDKV2.Models
{

    public class RequestBalance : CoinonePrivateRequestBase, ICoinonePrivateApiRequest
    {
        public string EndPoint => "/v2/account/balance";

        public HttpMethod Method => HttpMethod.Post;
    }
}