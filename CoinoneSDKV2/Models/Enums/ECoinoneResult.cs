using System.Runtime.Serialization;

namespace CoinoneSDKV2.Models
{

    public enum ECoinoneResult
    {
        [EnumMember(Value ="none")]
        NONE,

        [EnumMember(Value ="success")]
        SUCCESS,

        [EnumMember(Value ="error")]
        ERROR
    }
}