using System.Net.Http.Json;

namespace Schowek.Client.BlazorWASM;

public class HttpService : IHttpService
{
    private readonly HttpClient httpClient;

    public HttpService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
    public async Task<T> Get<T>(string url)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        HttpResponseMessage response = await httpClient.SendAsync(request);
        return await response.Content.ReadFromJsonAsync<T>();
    }
}
