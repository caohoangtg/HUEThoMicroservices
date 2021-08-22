using AutoMapper;
using AutoMapper.QueryableExtensions;
using Catalog.Application.Utilities.DTOs;
using Catalog.Infrastructure.IRepositories.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Application.Queries
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

            var query = _catalogRepository.GetProductsAsQueryable()
                .ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider);

            return Result<PagedList<ProductViewModel>>.Success(
                    await PagedList<ProductViewModel>.CreateAsync(query, request.PagingParams.PageNumber, request.PagingParams.PageSize)
                );
        }
    }
}
