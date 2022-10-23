using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchowekAPI.Models;

namespace SchowekAPI.Data
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
            var catalogs = await dataContext.Catalogs.ToListAsync();
            return catalogs;
        }

        public async Task<Catalog> GetCatalog(int catalogId)
        {
            // var catalog = await dataContext.Catalogs.FirstOrDefaultAsync(c => c.Id == catalogId);
            var catalog = await dataContext.Catalogs.FindAsync(catalogId);

            return catalog;
        }

        public async Task<Catalog> AddCatalog(Catalog catalog)
        {
            // var result = await dataContext.Catalogs.AddAsync(catalog);
            // await dataContext.SaveChangesAsync();
            // return result.Entity;

            await dataContext.Catalogs.AddAsync(catalog);
            await dataContext.SaveChangesAsync();
            return catalog;
        }

        public async Task<Catalog?> UpdateCatalog(int catalogId, Catalog catalog)
        {
            // var result = await dataContext.Catalogs.FirstOrDefaultAsync(c => c.Id == catalog.Id);

            // if (result != null)
            // {
            //     result.CategoryName = category.CategoryName;
            //     result.Icon = category.Icon;

            //     await _dbContext.SaveChangesAsync();
            // }

            // return result;

            Catalog? c = dataContext.Catalogs.Find(catalogId);
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
            // var result = await dataContext.Catalogs.FirstOrDefaultAsync(c => c.Id == catalogId);
            // if (result is not null)
            // {
            //     dataContext.Catalogs.Remove(result);
            //     await dataContext.SaveChangesAsync();
            // }
            // return result;

            Catalog? catalog = dataContext.Catalogs.Find(catalogId);
            if (catalog is null) return null;

            dataContext.Catalogs.Remove(catalog);
            await dataContext.SaveChangesAsync();

            return catalog;
        }
    }
}