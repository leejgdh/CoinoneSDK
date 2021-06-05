using System;
using System.ComponentModel.DataAnnotations;
using Helper.Models;
using Newtonsoft.Json;

namespace CoinoneSDKV2.Models
{
    public class ResponseTicker 
    {
        public ResponseTicker()
        {
        }

        [JsonProperty("currency")]
        [StringLength(50)]
        public ECoinCurrency Currency { get; set; }

        [JsonProperty("high")]
        [StringLength(200)]
        public double High { get; set; }

        [JsonProperty("low")]
        [StringLength(200)]
        public double Low { get; set; }

        [JsonProperty("first")]
        [StringLength(200)]
        public double First { get; set; }

        [JsonProperty("last")]
        [StringLength(200)]
        public double Last { get; set; }

        [JsonProperty("volume")]
        [StringLength(200)]
        public double Volume { get; set; }

        [JsonProperty("yesterday_high")]
        [StringLength(200)]
        public double YesterdayHigh { get; set; }

        [JsonProperty("yesterday_low")]
        [StringLength(200)]
        public double YesterdayLow { get; set; }

        [JsonProperty("yesterday_first")]
        [StringLength(200)]
        public double YesterdayFirst { get; set; }

        [JsonProperty("yesterday_last")]
        [StringLength(200)]
        public double YesterdayLast { get; set; }

        [JsonProperty("yesterday_volume")]
        [StringLength(200)]
        public double YesterdayVolume { get; set; }
    }
}
