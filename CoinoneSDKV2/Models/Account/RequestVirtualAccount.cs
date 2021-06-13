using System.Net.Http;

namespace CoinoneSDKV2.Models
{

    public class RequestVirtualAccount: CoinonePrivateRequestBase, ICoinonePrivateApiRequest
    {
        public string EndPoint =>  "/v2/account/virtual_account";

        public HttpMethod Method => HttpMethod.Post;
    }
}