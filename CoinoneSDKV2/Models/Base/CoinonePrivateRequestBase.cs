using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using Newtonsoft.Json;

namespace CoinoneSDKV2.Models
{

    public class CoinonePrivateRequestBase
    {

        [JsonProperty("access_token")]
        [Required]
        public string AccessToken { get; set; }

        [JsonProperty("nonce")]
        [Required]
        public long Nonce => Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds);

        public virtual string ToPayload()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}