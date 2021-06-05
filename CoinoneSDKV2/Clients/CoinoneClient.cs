using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CoinoneSDKV2.Models;
using Helper.Helpers;
using Helper.Models;
using Newtonsoft.Json;

namespace CoinoneSDKV2.Clients
{

    public class CoinoneClient
    {
        private const string PRODUCTIONURL = "https://api.coinone.co.kr";

        private readonly string _secretKey;

        private HttpClient _client;

        public CoinoneClient(string secretKey)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(PRODUCTIONURL);
            
            _secretKey = secretKey;
        }


        public async Task<CoinoneResponseBase<T>> SendRequestAsync<T>(IApiRequest request){
            
            var result = new CoinoneResponseBase<T>();

            var response = await SendRequest(request);

            result.IsSuccess = response.IsSuccessStatusCode;

            string content = await response.Content.ReadAsStringAsync();

            if(response.IsSuccessStatusCode){

                var response_object = JsonConvert.DeserializeObject<T>(content);
                result.Result = response_object;

            }else{
                result.Message = content;
            }

            return result;
        }

        private Task<HttpResponseMessage> SendRequest(IApiRequest request){

            

            HttpRequestMessage request_message = new HttpRequestMessage(request.Method, request.EndPoint);

            if(request.Method == HttpMethod.Get){

                string query_string = ConvertHelper.ConvertToQueryString(request);

                request_message = new HttpRequestMessage(request.Method, $"{request.EndPoint}?{query_string}");

            }else{
                
                string payload = request.ToPayload();
                request_message.Content = new StringContent(payload,Encoding.UTF8,"application/json");

            }

            return _client.SendAsync(request_message);
        }
                

        // private Task<HttpResponseMessage> SendRequest(IApiRequest request){

        //     //header

        //     //X-COINONE-PAYLOAD
        //     //X-COINONE-SIGNATURE

        //     string payload = request.ToPayload();
        //     string signature = CryptoHelper.SHA512Hash(payload, _secretKey);

        //     //httpclient 는 계속 재활용 하니까 default에 자꾸 넣으면 한없이 추가되버림
        //     //_client.DefaultRequestHeaders.Add("X-COINONE-PAYLOAD", payload);
        //     //_client.DefaultRequestHeaders.Add("X-COINONE-SIGNATURE", signature);

        //     HttpRequestMessage request_message = new HttpRequestMessage(request.HttpMethod, request.EndPoint);

        //     request_message.Headers.Add("X-COINONE-PAYLOAD", payload);
        //     request_message.Headers.Add("X-COINONE-SIGNATURE", signature);

        //     string json = JsonConvert.SerializeObject(request);

        //     request_message.Content = new StringContent(json,Encoding.UTF8,"application/json");

        //     return _client.SendAsync(request_message);
        // }





    }

}