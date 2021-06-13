using System.Net.Http;

namespace CoinoneSDKV2.Models
{

    public class RequestDepositAddress : CoinonePrivateRequestBase, ICoinonePrivateApiRequest
    {
        public string EndPoint => "/v2/account/deposit_address/";

        public HttpMethod Method => HttpMethod.Post;
    }
}