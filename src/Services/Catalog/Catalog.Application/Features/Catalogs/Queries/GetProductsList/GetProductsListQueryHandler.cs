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
    public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, Result<List<ProductViewModel>>>
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetProductsListQueryHandler> _logger;

        public GetProductsListQueryHandler(ICatalogRepository catalogRepository, IMapper mapper, ILogger<GetProductsListQueryHandler> logger)
        {
            _catalogRepository = catalogRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<List<ProductViewModel>>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Get All Products");
            var productList = await _catalogRepository.GetAllAsync();

            return Result<List<ProductViewModel>>.Success(_mapper.Map<List<ProductViewModel>>(productList));
        }
    }
}
