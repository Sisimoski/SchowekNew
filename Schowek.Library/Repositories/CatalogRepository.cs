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
            var catalogs = await dataContext.Catalogs!.Include(c => c.Items).ToListAsync();
            return catalogs;
        }

        public async Task<Catalog> GetCatalogAsync(int catalogId)
        {
            // var catalog = await dataContext.Catalogs!.FindAsync(catalogId);
            var catalog = await dataContext.Catalogs!.Include(c => c.Items).FirstOrDefaultAsync(c => c.Id == catalogId);
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
            Catalog? dbCatalog = dataContext.Catalogs!.Find(catalogId);
            if (dbCatalog is null) return null;

            dataContext.Entry(catalog).State = EntityState.Modified;

            dbCatalog.CatalogName = catalog.CatalogName;
            dbCatalog.Description = catalog.Description;
            dbCatalog.Icon = catalog.Icon;
            dbCatalog.CatalogColor = catalog.CatalogColor;

            dataContext.Catalogs.Update(dbCatalog);
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
            var catalogs = dataContext.Catalogs!.Include(c => c.Items).ToList();
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
            Catalog? dbCatalog = dataContext.Catalogs!.Find(catalogId);
            if (dbCatalog is null) return null!;

            dbCatalog.CatalogName = catalog.CatalogName;
            dbCatalog.Description = catalog.Description;
            dbCatalog.Icon = catalog.Icon;
            dbCatalog.CatalogColor = catalog.CatalogColor;

            dataContext.Catalogs.Update(dbCatalog);
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