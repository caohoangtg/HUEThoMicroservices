using AutoMapper;
using Catalog.Application.Contracts.Persistence;
using Catalog.Application.Utilities.DTOs;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Catalogs.Queries
{
    public class GetProductByCategoryQueryHandler : IRequestHandler<GetProductByCategoryQuery, Result<List<ProductViewModel>>>
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetProductsListQueryHandler> _logger;

        public GetProductByCategoryQueryHandler(ICatalogRepository catalogRepository, IMapper mapper, ILogger<GetProductsListQueryHandler> logger)
        {
            _catalogRepository = catalogRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Result<List<ProductViewModel>>> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
        {
            var products = await _catalogRepository.GetProductsByCategory(request.Category);

            return Result<List<ProductViewModel>>.Success(
                _mapper.Map<List<ProductViewModel>>(products)
            );
        }
    }
}
