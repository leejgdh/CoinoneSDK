using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinoneSDKV2.Models
{

    public struct ResponseKRWTransactionsHistory
    {

        [JsonProperty("krwHistory")]
        public List<CoinoneKrwHistory> KrwHistory { get; set; }


        public struct CoinoneKrwHistory
        {
            [JsonProperty("bankCode")]
            public string BankCode { get; set; }

            [JsonProperty("accountNumber")]
            public string AccountNumber { get; set; }

            [JsonProperty("depositor")]
            public string Depositor { get; set; }

            [JsonProperty("amount")]
            public long Amount { get; set; }

            [JsonProperty("processLevel")]
            public int ProcessLevel { get; set; }

            [JsonProperty("timestamp")]
            public long Timestamp { get; set; }
        }
    }


}