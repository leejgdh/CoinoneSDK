using System.Net.Http;
using Helper.Models;

namespace CoinoneSDKV2.Models
{


    public interface ICoinonePrivateApiRequest
    {

        string EndPoint { get; }
        HttpMethod Method { get; }

        string AccessToken { get; set; }

        long Nonce { get; }

        string ToPayload();
    }
}