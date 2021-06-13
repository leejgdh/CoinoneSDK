using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinoneSDKV2.Models
{

    public class CoinoneErrorResponse
    {

        // "{\"result\":\"error\",\"errorCode\":\"405\",\"errorMsg\":\"Server error\"}"

        [EnumDataType(typeof(ECoinoneResult))]
        [JsonConverter(typeof(StringEnumConverter))]
        public ECoinoneResult Result { get; set; }
        
        public string ErrorCode { get; set; }

        public string ErrorMsg { get; set; }
    }
}