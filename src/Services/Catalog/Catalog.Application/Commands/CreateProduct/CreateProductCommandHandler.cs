using AutoMapper;
using Catalog.Application.Utilities.DTOs;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.IRepositories.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Application.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<Unit>>
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateProductCommandHandler> _logger;

        public CreateProductCommandHandler(ICatalogRepository catalogRepository, IMapper mapper, ILogger<CreateProductCommandHandler> logger)
        {
            _catalogRepository = catalogRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<Unit>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Create Product");
            var product = _mapper.Map<Product>(request);

            await _catalogRepository.AddAsync(product);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
