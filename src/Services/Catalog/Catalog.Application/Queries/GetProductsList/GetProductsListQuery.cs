using Catalog.Application.Utilities.DTOs;
using MediatR;
using System.Collections.Generic;

namespace Catalog.Application.Queries
{
    public class GetProductsListQuery : IRequest<Result<List<ProductViewModel>>>
    {
        public GetProductsListQuery()
        {
        }
    }
}
