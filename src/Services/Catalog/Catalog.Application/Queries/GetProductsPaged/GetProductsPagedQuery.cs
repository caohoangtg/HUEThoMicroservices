using Catalog.Application.Utilities.DTOs;
using MediatR;
using System.Collections.Generic;

namespace Catalog.Application.Queries
{
    public class GetProductsPagedQuery : IRequest<Result<PagedList<ProductViewModel>>>
    {
        public PagingParams PagingParams { get; private set; }

        public GetProductsPagedQuery(PagingParams pagingParams)
        {
            PagingParams = pagingParams;
        }

        //public GetProductsPagedQuery(int pageNumber, int pageSize)
        //{
        //    PagingParams = new PagingParams(pageNumber, pageSize);
        //}
    }
}
