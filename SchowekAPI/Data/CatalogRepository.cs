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

        public async Task<Catalog> AddCatalog(Catalog catalog)
        {
            var result = await dataContext.Catalogs.AddAsync(catalog);
            await dataContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Catalog> DeleteCatalog(int catalogId)
        {
            var result = await dataContext.Catalogs.FirstOrDefaultAsync(c => c.Id == catalogId);
            if (result is not null)
            {
                dataContext.Catalogs.Remove(result);
                await dataContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task<Catalog> GetCatalog(int catalogId)
        {
            var catalog = await dataContext.Catalogs.FirstOrDefaultAsync(c => c.Id == catalogId);

            return catalog;
        }

        public async Task<IEnumerable<Catalog>> GetCatalogs()
        {
            var catalogs = await dataContext.Catalogs.ToListAsync();
            return catalogs;
        }

        public Task<Catalog> UpdateCatalog(Catalog catalog)
        {
            throw new NotImplementedException();
        }
    }
}