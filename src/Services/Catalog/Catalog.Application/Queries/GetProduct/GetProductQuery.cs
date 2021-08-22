using Catalog.Application.Utilities.DTOs;
using MediatR;
using System;

namespace Catalog.Application.Queries
{
    public class GetProductQuery : IRequest<Result<ProductViewModel>>
    {
        public Guid Id { get; private set; }

        public GetProductQuery(Guid id)
        {
            Id = id;
        }
    }
}
