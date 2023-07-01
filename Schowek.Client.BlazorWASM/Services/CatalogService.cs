using Schowek.Client.BlazorWASM.Interfaces;
using Schowek.Shared.Domain.Models;

namespace Schowek.Client.BlazorWASM;

public class CatalogService : ICatalogService
{
    private readonly IHttpService httpService;
    public CatalogService(IHttpService httpService)
    {
        this.httpService = httpService;
    }

    public async Task<Catalog> GetCatalogAsync(int catalogId)
    {
        return await httpService.Get<Catalog>($"api/catalog/{catalogId}");
    }
}
