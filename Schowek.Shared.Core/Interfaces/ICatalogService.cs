using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schowek.Shared.Domain.Models;

namespace Schowek.Shared.Core.Interfaces
{
    public interface ICatalogService
    {
        Task<IEnumerable<Catalog>> GetCatalogsAsync();
        Task<Catalog> GetCatalogAsync(int catalogId);
        Task<Catalog> AddCatalogAsync(Catalog catalog);
        Task<Catalog?> UpdateCatalogAsync(int catalogId, Catalog catalog);
        Task<Catalog> DeleteCatalogAsync(int catalogId);
    }
}