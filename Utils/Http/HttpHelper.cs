using System.Text.Json;
using System.Text;

namespace Utils.Http
{
    public abstract class HttpHelper
    {
        public static StringContent ToJson(object body)
        {
            return new StringContent(
                                    JsonSerializer.Serialize(body),
                                    Encoding.UTF8,
                                    "application/json");
        }

        public static async Task<T?> ToObjectAsync<T>(HttpResponseMessage responseMessage)
        {
            JsonSerializerOptions options = new()
            {
                PropertyNameCaseInsensitive = true
            };

            var content = await responseMessage.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(content, options);
        }

        public static bool EnsureStatusCode(HttpResponseMessage response)
        {
            switch ((int)response.StatusCode)
            {
                case 401:
                case 403:
                case 404:
                case 500:
                    throw new Exception($"{response.StatusCode}");

                case 400:
                    return false;
            }

            response.EnsureSuccessStatusCode();
            return true;
        }
    }
}
