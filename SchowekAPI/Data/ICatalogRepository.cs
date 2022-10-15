using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchowekAPI.Models;

namespace SchowekAPI.Data
{
    public interface ICatalogRepository
    {
        Task<List<Catalog>> GetCatalogs();
        Task<Catalog> GetCatalog(int catalogId);
        Task<Catalog> AddCatalog(Catalog catalog);
        Task<Catalog> UpdateCatalog(Catalog catalog);
        Task<Catalog> DeleteCatalog(int catalogId);
    }
}