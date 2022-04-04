using Newtonsoft.Json;
using RestSharp;
using WestPac.BuggyCarsRating.APITest.Models;

namespace WestPac.BuggyCarsRating.APITest.Support
{
    public class HttpRequestWrapper
    {
        private RestRequest _restRequest;
        private RestClient _restClient;
        private static string token = "";
        private static string _baseUrl = Environment.GetEnvironmentVariable("ApiUrl");

        public HttpRequestWrapper()
        {
            _restRequest = new RestRequest();
    }

        public HttpRequestWrapper SetResourse(string resource)
        {
            _restRequest.Resource = resource;
            return this;
        }

        public HttpRequestWrapper SetMethod(Method method)
        {
            _restRequest.Method = method;
            _restRequest.Timeout = 500000;
            return this;
        }

        public HttpRequestWrapper AddHeaders(IDictionary<string, string> headers)
        {
            foreach (var header in headers)
            {
                _restRequest.AddParameter(header.Key, header.Value, ParameterType.HttpHeader);
            }
            return this;
        }

        public HttpRequestWrapper AddJsonContent(object data, string token, string body)
        {
            _restRequest.RequestFormat = DataFormat.Json;
            _restRequest.AddHeader("content-type", "application/x-www-form-urlencoded");
            _restRequest.AddHeader("content-length", "65");
            _restRequest.AddHeader("User-Agent", "PostmanRuntime/7.29.0");

            if (!string.IsNullOrEmpty(token))
            {
                _restRequest.AddHeader("Authorization", string.Format("Bearer {0}", token));
            }
            if (data != null)
            {
                _restRequest.AddJsonBody(data);
            }
            if (body != null)
            {
                _restRequest.AddParameter("text/xml", body, ParameterType.RequestBody);
            }
            
            return this;
        }

        public IRestResponse Execute()
        {
            try
            {
                _restClient = new RestClient(_baseUrl);
                _restClient.Timeout = 20000; // 10000 milliseconds == 10 seconds
                var response = _restClient.Execute(_restRequest);
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public T Execute<T>()
        {
            _restClient = new RestClient(_baseUrl);
            var response = _restClient.Execute(_restRequest);
            var data = JsonConvert.DeserializeObject<T>(response.Content);
            return data;
        }
    }
}