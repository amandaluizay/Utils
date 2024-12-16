namespace Utils.Http
{
    public interface IHttpService
    {
        Task<T?> SendGetAsync<T>(string uri);
        Task<T?> SendPostAsync<T>(string uri, object body);
    }
}