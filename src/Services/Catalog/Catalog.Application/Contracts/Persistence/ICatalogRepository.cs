using Catalog.Application.Utilities.DTOs;
using Catalog.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Application.Contracts.Persistence
{
    public interface ICatalogRepository : IAsyncRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategory(string category);
    }
}
