using System.Collections.Generic;
using Helper.Models;
using Newtonsoft.Json;

namespace CoinoneSDKV2.Models
{

    public struct ResponseUserInformation
    {

        [JsonProperty("userInfo")]
        public CoinoneUserInfo UserInfo { get; set; }


        public struct CoinoneUserInfo
        {
            [JsonProperty("virtualAccountInfo")]
            public CoinoneVirtualAccountInfo VirtualAccountInfo { get; set; }

            [JsonProperty("mobileInfo")]
            public CoinoneMobileInfo MobileInfo { get; set; }

            [JsonProperty("bankInfo")]
            public CoinoneBankInfo BankInfo { get; set; }

            [JsonProperty("emailInfo")]
            public CoinoneEmailInfo EmailInfo { get; set; }

            [JsonProperty("securityLevel")]
            public int SecurityLevel { get; set; }

            [JsonProperty("feeRate")]
            public Dictionary<ECoinCurrency, FeeRate> FeeRate { get; set; }
        }


        public struct CoinoneBankInfo
        {
            [JsonProperty("depositor")]
            public string Depositor { get; set; }

            [JsonProperty("bankCode")]
            public string BankCode { get; set; }

            [JsonProperty("accountNumber")]
            public string AccountNumber { get; set; }

            [JsonProperty("isAuthenticated")]
            public bool IsAuthenticated { get; set; }
        }

        public struct CoinoneEmailInfo
        {
            [JsonProperty("isAuthenticated")]
            public bool IsAuthenticated { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }
        }

        public struct CoinoneMobileInfo
        {
            [JsonProperty("userName")]
            public string UserName { get; set; }

            [JsonProperty("phoneNumber")]
            public string PhoneNumber { get; set; }

            [JsonProperty("phoneCorp")]
            public string PhoneCorp { get; set; }

            [JsonProperty("isAuthenticated")]
            public bool IsAuthenticated { get; set; }
        }

        public struct CoinoneVirtualAccountInfo
        {
            [JsonProperty("depositor")]
            public string Depositor { get; set; }

            [JsonProperty("accountNumber")]
            public string AccountNumber { get; set; }

            [JsonProperty("bankName")]
            public string BankName { get; set; }
        }



        public struct FeeRate
        {
            public double Maker { get; set; }

            public double Taker { get; set; }
        }
    }
}