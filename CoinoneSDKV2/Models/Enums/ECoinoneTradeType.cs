using System.Runtime.Serialization;

namespace CoinoneSDKV2.Models
{


    public enum ECoinoneTradeType
    {
        [EnumMember(Value ="normal")]
        NORMAL,
        
        [EnumMember(Value ="trade")]
        TRADE,
        

    }
}