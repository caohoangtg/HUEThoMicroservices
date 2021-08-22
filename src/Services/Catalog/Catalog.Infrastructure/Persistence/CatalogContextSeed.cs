using Catalog.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Persistence
{
    public class CatalogContextSeed
    {
        public static async Task SeedAsync(CatalogContext orderContext, ILogger<CatalogContextSeed> logger)
        {
            if (!orderContext.Products.Any())
            {
                orderContext.Products.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(CatalogContext).Name);
            }
        }

        private static IEnumerable<Product> GetPreconfiguredOrders()
        {
            return new List<Product>
            {
                new Product("Banh Bao", "Banh", "Banh Bao", "Ngon ngon", "", 10000)
            };
        }
    }
}
