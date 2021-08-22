using Catalog.Application.Utilities.DTOs;
using MediatR;
using System.Collections.Generic;

namespace Catalog.Application.Features.Catalogs.Queries
{
    public class GetProductByCategoryQuery : IRequest<Result<List<ProductViewModel>>>
    {
        public string Category { get; private set; }

        public GetProductByCategoryQuery(string category)
        {
            Category = category;
        }
    }
}
