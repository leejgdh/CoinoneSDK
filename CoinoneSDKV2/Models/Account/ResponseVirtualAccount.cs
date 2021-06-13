using Newtonsoft.Json;

namespace CoinoneSDKV2.Models
{

    public struct ResponseVirtualAccount
    {


        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }


        [JsonProperty("depositer")]
        public string Depositer { get; set; }

        [JsonProperty("bankName")]
        public string BankName { get; set; }

    }
}