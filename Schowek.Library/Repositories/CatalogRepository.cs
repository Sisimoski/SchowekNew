using Schowek.Library.Interfaces;
using Schowek.Library.Models;
using Schowek.Library.Data;
using Microsoft.EntityFrameworkCore;

namespace Schowek.Library.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly DataContext dataContext;
        public CatalogRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<IEnumerable<Catalog>> GetCatalogs()
        {
            var catalogs = await dataContext.Catalogs!.ToListAsync();
            return catalogs;
        }

        public async Task<Catalog> GetCatalog(int catalogId)
        {
            var catalog = await dataContext.Catalogs!.FindAsync(catalogId);

            return catalog!;
        }

        public async Task<Catalog> AddCatalog(Catalog catalog)
        {
            await dataContext.Catalogs!.AddAsync(catalog);
            await dataContext.SaveChangesAsync();
            return catalog;
        }

        public async Task<Catalog?> UpdateCatalog(int catalogId, Catalog catalog)
        {
            Catalog? c = dataContext.Catalogs!.Find(catalogId);
            if (c is null) return null;

            c.CatalogName = catalog.CatalogName;
            c.Description = catalog.Description;
            c.Icon = catalog.Icon;
            c.CatalogColor = catalog.CatalogColor;

            dataContext.Catalogs.Update(c);
            await dataContext.SaveChangesAsync();

            return catalog;
        }

        public async Task<Catalog> DeleteCatalog(int catalogId)
        {
            Catalog? catalog = dataContext.Catalogs!.Find(catalogId);
            if (catalog is null) return null!;

            dataContext.Catalogs.Remove(catalog);
            await dataContext.SaveChangesAsync();

            return catalog;
        }
    }
}