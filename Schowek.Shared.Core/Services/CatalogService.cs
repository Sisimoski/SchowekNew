using Schowek.Shared.Core.Interfaces;
using Schowek.Shared.Domain.Models;

namespace Schowek.Shared.Core.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository catalogRepository;

        public CatalogService(ICatalogRepository catalogRepository)
        {
            this.catalogRepository = catalogRepository;
        }

        public async Task<Catalog> AddCatalogAsync(Catalog catalog)
        {
            return await catalogRepository.AddCatalogAsync(catalog);
        }

        public async Task<Catalog> DeleteCatalogAsync(int catalogId)
        {
            return await catalogRepository.DeleteCatalogAsync(catalogId);
        }

        public async Task<Catalog> GetCatalogAsync(int catalogId)
        {
            return await catalogRepository.GetCatalogAsync(catalogId);
        }

        public async Task<IEnumerable<Catalog>> GetCatalogsAsync()
        {
            return await catalogRepository.GetCatalogsAsync();
        }

        public async Task<Catalog?> UpdateCatalogAsync(int catalogId, Catalog catalog)
        {
            return await catalogRepository.UpdateCatalogAsync(catalogId, catalog);
        }
    }
}