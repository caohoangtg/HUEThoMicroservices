﻿using Catalog.Application.Contracts.Persistence;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Repositories
{
    public class CatalogRepository : RepositoryBase<Product>, ICatalogRepository
    {
        public CatalogRepository(CatalogContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                return await _dbContext.Products.ToListAsync();
            }

            return await _dbContext.Products
                .Where(p => p.Category == category)
                .ToListAsync();
        }
    }
}