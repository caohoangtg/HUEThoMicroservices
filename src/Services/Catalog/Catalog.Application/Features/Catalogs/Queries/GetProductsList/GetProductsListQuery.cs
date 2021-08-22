using Catalog.Application.Utilities.DTOs;
using MediatR;
using System.Collections.Generic;

namespace Catalog.Application.Features.Catalogs.Queries
{
    public class GetProductsListQuery : IRequest<Result<List<ProductViewModel>>>
    {
        public GetProductsListQuery()
        {
        }
    }
}
