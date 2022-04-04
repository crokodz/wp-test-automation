using Newtonsoft.Json;
using RestSharp;
using WestPac.BuggyCarsRating.APITest.Models;
using WestPac.BuggyCarsRating.APITest.Support;

namespace WestPac.BuggyCarsRating.UITest.Services
{
    public class CommonService
    {
        private static string _authUrl = Environment.GetEnvironmentVariable("AuthUrl");

        public CommonService()
        {
        }

        public RestResponse GetOpenData(string url)
        {
            var request = new HttpRequestWrapper()
                           .SetMethod(Method.GET)
                           .SetResourse(url);

            var response = (RestResponse)request.Execute();
            return response;
        }

        public AuthResponse GetToken()
        {
            var payload = $"grant_type=password&username=efrenvaldez&password=4gK7GC@iB3aZLSN";
            var request = new HttpRequestWrapper()
                           .SetMethod(Method.POST)
                           .SetResourse($"{_authUrl}")
                           .AddJsonContent(null, null, payload);

            var response = (RestResponse)request.Execute();
            return JsonConvert.DeserializeObject<AuthResponse>(response.Content);
        }
    }
}
