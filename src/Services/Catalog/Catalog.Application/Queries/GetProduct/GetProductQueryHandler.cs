using AutoMapper;
using Catalog.Application.Utilities.DTOs;
using Catalog.Infrastructure.IRepositories.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Application.Queries
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Result<ProductViewModel>>
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetProductQueryHandler> _logger;

        public GetProductQueryHandler(ICatalogRepository catalogRepository, IMapper mapper, ILogger<GetProductQueryHandler> logger)
        {
            _catalogRepository = catalogRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<ProductViewModel>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Get Product by Id");
            var product = await _catalogRepository.GetByIdAsync(request.Id);

            return Result<ProductViewModel>.Success(
                _mapper.Map<ProductViewModel>(product)
            );
        }
    }
}
