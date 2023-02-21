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

        public async Task<IEnumerable<Catalog>> GetCatalogsAsync()
        {
            var catalogs = await dataContext.Catalogs!.ToListAsync();
            return catalogs;
        }

        public async Task<Catalog> GetCatalogAsync(int catalogId)
        {
            var catalog = await dataContext.Catalogs!.FindAsync(catalogId);

            return catalog!;
        }

        public async Task<Catalog> AddCatalogAsync(Catalog catalog)
        {
            await dataContext.Catalogs!.AddAsync(catalog);
            await dataContext.SaveChangesAsync();
            return catalog;
        }

        public async Task<Catalog?> UpdateCatalogAsync(int catalogId, Catalog catalog)
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

        public async Task<Catalog> DeleteCatalogAsync(int catalogId)
        {
            Catalog? catalog = dataContext.Catalogs!.Find(catalogId);
            if (catalog is null) return null!;

            dataContext.Catalogs.Remove(catalog);
            await dataContext.SaveChangesAsync();

            return catalog;
        }

        public IEnumerable<Catalog> GetCatalogs()
        {
            var catalogs = dataContext.Catalogs!.ToList();
            return catalogs;
        }

        public Catalog GetCatalog(int catalogId)
        {
            var catalog = dataContext.Catalogs!.Find(catalogId);
            return catalog!;
        }

        public Catalog AddCatalog(Catalog catalog)
        {
            dataContext.Catalogs!.Add(catalog);
            dataContext.SaveChanges();
            return catalog;
        }

        public Catalog UpdateCatalog(int catalogId, Catalog catalog)
        {
            Catalog? c = dataContext.Catalogs!.Find(catalogId);
            if (c is null) return null!;

            c.CatalogName = catalog.CatalogName;
            c.Description = catalog.Description;
            c.Icon = catalog.Icon;
            c.CatalogColor = catalog.CatalogColor;

            dataContext.Catalogs.Update(c);
            dataContext.SaveChanges();

            return catalog;
        }

        public Catalog DeleteCatalog(int catalogId)
        {
            Catalog? catalog = dataContext.Catalogs!.Find(catalogId);
            if (catalog is null) return null!;

            dataContext.Catalogs.Remove(catalog);
            dataContext.SaveChanges();

            return catalog;
        }
    }
}