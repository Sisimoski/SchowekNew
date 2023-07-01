using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schowek.Shared.Domain.Models;

namespace Schowek.Client.BlazorWASM.Interfaces
{
    public interface ICatalogService
    {
        Task<Catalog> GetCatalogAsync(int catalogId);
    }
}