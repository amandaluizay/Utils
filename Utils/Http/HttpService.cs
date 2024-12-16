namespace Utils.Http
{
    public class HttpService : HttpHelper, IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromMinutes(10);
        }

        public async Task<T?> SendPostAsync<T>(string uri, object body)
        {
            var response = await ExecuteAsync(HttpMethod.Post, uri, body);

            if (!EnsureStatusCode(response))
            {
                throw new Exception(response.RequestMessage.ToString());
            }

            return await ToObjectAsync<T>(response);
        }

        public async Task SendPostAsync(string uri, object body)
        {
            var response = await ExecuteAsync(HttpMethod.Post, uri, body);

            if (!EnsureStatusCode(response))
            {
                throw new Exception(response.RequestMessage.ToString());
            }
        }

        public async Task<T?> SendGetAsync<T>(string uri)
        {
            var response = await ExecuteAsync(HttpMethod.Get, uri);

            if (!EnsureStatusCode(response))
            {
                throw new Exception(response.RequestMessage.ToString());
            }

            return await ToObjectAsync<T>(response);
        }

        public async Task SendGetAsync(string uri)
        {
            var response = await ExecuteAsync(HttpMethod.Get, uri);

            if (!EnsureStatusCode(response))
            {
                throw new Exception(response.RequestMessage.ToString());
            }
        }

        public async Task<T?> SendPutAsync<T>(string uri, object body)
        {
            var response = await ExecuteAsync(HttpMethod.Put, uri, body);

            if (!EnsureStatusCode(response))
            {
                throw new Exception(response.RequestMessage.ToString());
            }

            return await ToObjectAsync<T>(response);
        }

        public async Task SendPutAsync(string uri, object body)
        {
            var response = await ExecuteAsync(HttpMethod.Put, uri, body);

            if (!EnsureStatusCode(response))
            {
                throw new Exception(response.RequestMessage.ToString());
            }
        }

        public async Task<T?> SendDeleteAsync<T>(string uri)
        {
            var response = await ExecuteAsync(HttpMethod.Delete, uri);

            if (!EnsureStatusCode(response))
            {
                throw new Exception(response.RequestMessage.ToString());
            }

            return await ToObjectAsync<T>(response);
        }

        public async Task SendDeleteAsync(string uri)
        {
            var response = await ExecuteAsync(HttpMethod.Delete, uri);

            if (!EnsureStatusCode(response))
            {
                throw new Exception(response.RequestMessage.ToString());
            }
        }

        public async Task<HttpResponseMessage> ExecuteAsync(HttpMethod httpMethod, string url, object body = null)
        {
            var httpRequestMessage = new HttpRequestMessage(httpMethod, url);

            if (body != null)
            {
                httpRequestMessage.Content = ToJson(body);
            }

            return await _httpClient.SendAsync(httpRequestMessage);
        }
    }
}
