using System.Net.Http;

namespace CoinoneSDKV2.Models
{

    public class RequestUserInformation : CoinonePrivateRequestBase, ICoinonePrivateApiRequest
    {
        public string EndPoint => "/v2/account/user_info";

        public HttpMethod Method => HttpMethod.Post;
    }
}