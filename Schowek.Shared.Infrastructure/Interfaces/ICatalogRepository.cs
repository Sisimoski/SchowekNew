using Schowek.Shared.Domain.Models;

namespace Schowek.Shared.Core.Interfaces
{
    public interface ICatalogRepository
    {
        IEnumerable<Catalog> GetCatalogs();
        Task<IEnumerable<Catalog>> GetCatalogsAsync();

        Catalog GetCatalog(int catalogId);
        Task<Catalog> GetCatalogAsync(int catalogId);

        Catalog AddCatalog(Catalog catalog);
        Task<Catalog> AddCatalogAsync(Catalog catalog);

        Catalog UpdateCatalog(int catalogId, Catalog catalog);
        Task<Catalog?> UpdateCatalogAsync(int catalogId, Catalog catalog);

        Catalog DeleteCatalog(int catalogId);
        Task<Catalog> DeleteCatalogAsync(int catalogId);
    }
}