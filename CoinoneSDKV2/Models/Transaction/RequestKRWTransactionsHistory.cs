using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using Helper.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinoneSDKV2.Models
{

    public class RequestKRWTransactionsHistory : CoinonePrivateRequestBase, ICoinonePrivateApiRequest
    {

        public string EndPoint => "/v2/transaction/krw/history";

        public HttpMethod Method => HttpMethod.Post;


    }
}