using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using UeharaApi_91Tel.Models;
using UeharaApi_91Tel.Repositories;

namespace UeharaApi_91Tel.Service
{
    public class ClientApi91:IClientApi91
    {
        private IRestClient _client { get; set; }
        private ILogResponseRepository _logRepository { get; set; }

        public ClientApi91(IRestClient client)
        {
            _client = client;
        }
        public ClientApi91(Uri url)
        {
            _client = new RestClient
            {
                BaseUrl = url
            };
        }

        public async Task<List<LogResponse>> GetLogs(string token, string datetime){
            
            _client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", token));

            var parameters = new Dictionary<string, string>();
            parameters.Add("filter", string.Format("Data ge {0}", datetime));
            var result = await Execute<List<LogResponse>>("/Service/api/LogSistema", Method.GET, parameters,ParameterType.QueryString );
            return result;
        }

        public async Task<Response91Model> Authentication(string grant_type, string username, string password){
            var parameters = new Dictionary<string, string>();

            parameters.Add("grant_type", grant_type);
            parameters.Add("username", username);
            parameters.Add("password", password);
            parameters.Add("abc", null);
            var result = await Execute<Response91Model>("/Service/oauth2/Token", Method.POST, parameters);
            return result;
        }

       
        public virtual async Task<T> Execute<T>(string resource, Method method, Dictionary<string, string> parameter = null, ParameterType parameterType = ParameterType.GetOrPost)
        {
            var request = new RestRequest(resource, method);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.RequestFormat = DataFormat.Json;

            if (parameter != null)
            {
                foreach (KeyValuePair<string, string> entry in parameter)
                {
                    request.AddParameter(entry.Key, entry.Value, parameterType);
                }
            }
            TaskCompletionSource<IRestResponse> taskCompletion = new TaskCompletionSource<IRestResponse>();
            RestRequestAsyncHandle handle = _client.ExecuteAsync(
                request, r => taskCompletion.SetResult(r));
                                                        
            RestResponse restResponse = (RestResponse)(await taskCompletion.Task);

            if (restResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new ApplicationException(restResponse.Content);
            }

            if (restResponse.Content != null)
            {

                 dynamic content = JsonConvert.DeserializeObject<T>(restResponse.Content);
                 return content;
               
            };
            return JsonConvert.DeserializeObject<T>(restResponse.Content);
        }
    }
}
