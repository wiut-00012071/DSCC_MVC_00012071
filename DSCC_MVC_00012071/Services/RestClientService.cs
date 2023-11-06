using RestSharp;
using System.Text.Json;

namespace DSCC_MVC_00012071.Services
{
    public class RestClientService
    {
        private readonly RestClient _restClient;

        public RestClientService( IConfiguration configuration )
        {
            string apiBaseUrl = configuration[ "ApiBaseUrl" ];

            _restClient = new RestClient(apiBaseUrl);
        }

        public T Get<T>( string url )
        {
            var request = new RestRequest(url);

            var response = _restClient.Get(request);

            return _deserializeResponse<T>(response);
        }

        public T Post<T>( string url, T body)
        {
            var request = new RestRequest(url);

            request.AddBody(body);

            var response = _restClient.Post(request);

            return _deserializeResponse<T>(response);
        }

        public T Put<T>( string url, T body )
        {
            var request = new RestRequest(url);

            request.AddBody(body);

            var response = _restClient.Put(request);

            return _deserializeResponse<T>(response);
        }

        public string Delete( string url )
        {
            var request = new RestRequest(url);

            var response = _restClient.Delete(request);

            return response.StatusCode.ToString();
        }

        private T _deserializeResponse<T>( RestResponseBase response )
        {
            string jsonText = response.Content.ToString();

            var data = JsonSerializer.Deserialize<T>(jsonText, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return data;
        }
    }
}
