using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinoneSDKV2.Models
{

    public struct ResponseCoinTransactionsHistory
    {

        [JsonProperty("transactions")]
        public List<Transaction> Transactions { get; set; }

        public struct Transaction
        {
            [JsonProperty("txid")]
            public string Txid { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("from")]
            public string From { get; set; }

            [JsonProperty("to")]
            public string To { get; set; }

            [JsonProperty("confirmations")]
            public int Confirmations { get; set; }

            [JsonProperty("quantity")]
            public double Quantity { get; set; }

            [JsonProperty("timestamp")]
            public long Timestamp { get; set; }
        }
    }



}