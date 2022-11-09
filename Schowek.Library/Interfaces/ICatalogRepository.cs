using Schowek.Library.Models;

namespace Schowek.Library.Interfaces
{
    public interface ICatalogRepository
    {
        Task<IEnumerable<Catalog>> GetCatalogs();
        Task<Catalog> GetCatalog(int catalogId);
        Task<Catalog> AddCatalog(Catalog catalog);
        Task<Catalog?> UpdateCatalog(int catalogId, Catalog catalog);
        Task<Catalog> DeleteCatalog(int catalogId);
    }
}