using AutoMapper;
using Catalog.Application.Utilities.DTOs;
using Catalog.Infrastructure.IRepositories.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Catalogs.Queries
{
    public class GetProductsPagedQueryHandler : IRequestHandler<GetProductsPagedQuery, Result<PagedList<ProductViewModel>>>
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetProductsPagedQueryHandler> _logger;

        public GetProductsPagedQueryHandler(ICatalogRepository catalogRepository, IMapper mapper, ILogger<GetProductsPagedQueryHandler> logger)
        {
            _catalogRepository = catalogRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<PagedList<ProductViewModel>>> Handle(GetProductsPagedQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Get Products Paged");
            var products = await _catalogRepository.GetAllAsync();

            var productsList = _mapper.Map<IEnumerable<ProductViewModel>>(products);

            //var productPaged = PagedList<ProductViewModel>
            //        .CreateAsync(productsList, request.PagingParams.PageNumber, request.PagingParams.PageSize);

            return Result<PagedList<ProductViewModel>>.Success(
                PagedList<ProductViewModel>
                    .CreateAsync(productsList, request.PagingParams.PageNumber, request.PagingParams.PageSize)
            );
        }
    }
}
