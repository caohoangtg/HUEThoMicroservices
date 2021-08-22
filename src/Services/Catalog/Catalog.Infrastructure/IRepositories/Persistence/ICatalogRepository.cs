using Catalog.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.IRepositories.Persistence
{
    public interface ICatalogRepository : IAsyncRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategory(string category);
        IQueryable<Product> GetProductsAsQueryable();
    }
}
