namespace Schowek.Client.BlazorWASM;

public interface IHttpService
{
    Task<T> Get<T>(string url);
}
