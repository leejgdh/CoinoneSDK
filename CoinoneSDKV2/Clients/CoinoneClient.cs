using System;
using System.Collections.Generic;
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
        private string _accessToken;

        private HttpClient _client;

        public CoinoneClient(string secretKey, string accessToken)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(PRODUCTIONURL);
            
            _secretKey = secretKey;
            _accessToken = accessToken;
        }


        public CoinoneClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(PRODUCTIONURL);
        }

        /// <summary>
        /// Public API Call Method
        /// </summary>
        /// <param name="request"></param>
        /// <typeparam name="ResponseType"></typeparam>
        /// <returns></returns>
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

        public Task<HttpResponseMessage> SendRequest(IApiRequest request){

            

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
        







        /// <summary>
        /// Private Request Async
        /// Require SecretKey and AccessToken
        /// </summary>
        /// <param name="request"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<CoinoneResponseBase<T>> SendRequestAsync<T>(ICoinonePrivateApiRequest request){
            
            if(string.IsNullOrWhiteSpace(_secretKey) || string.IsNullOrWhiteSpace(_accessToken)){
                
                throw new CoinoneSDKException("Secretkey or accesstoken is empty");
            }


            //balance는 구조가 이상함
            if(request.EndPoint == "/v2/account/balance"){
                throw new CoinoneSDKException("Balance method is not available this version sdk");
            }

            //Set accesstoken
            request.AccessToken = _accessToken;

            var result = new CoinoneResponseBase<T>();

            var response = await SendRequest(request);

            result.IsSuccess = response.IsSuccessStatusCode;

            string content = await response.Content.ReadAsStringAsync();

            if(response.IsSuccessStatusCode){

                var error_check = JsonConvert.DeserializeObject<CoinoneErrorResponse>(content);

                if(error_check.Result == ECoinoneResult.ERROR){

                    result.IsSuccess = false;
                    result.Message = error_check.ErrorMsg;
                    result.Code = error_check.ErrorCode;

                    return result;
                }

                var response_object = JsonConvert.DeserializeObject<T>(content);

                result.Result = response_object;

            }else{
                result.Message = content;
            }

            return result;
        }

        public Task<HttpResponseMessage> SendRequest(ICoinonePrivateApiRequest request){

            //header

            //X-COINONE-PAYLOAD
            //X-COINONE-SIGNATURE

            string payload = request.ToPayload();

            
            string signature = CryptoHelper.SHA512Hash(CryptoHelper.Base64Encode(payload), _secretKey);

            //httpclient 는 계속 재활용 하니까 default에 자꾸 넣으면 한없이 추가되버림
            //_client.DefaultRequestHeaders.Add("X-COINONE-PAYLOAD", payload);
            //_client.DefaultRequestHeaders.Add("X-COINONE-SIGNATURE", signature);

            HttpRequestMessage request_message = new HttpRequestMessage(request.Method, request.EndPoint);

            request_message.Headers.Add("X-COINONE-PAYLOAD", CryptoHelper.Base64Encode(payload));
            request_message.Headers.Add("X-COINONE-SIGNATURE", signature);

            request_message.Content = new StringContent(payload,Encoding.UTF8,"application/json");

            return _client.SendAsync(request_message);
        }





    }

}