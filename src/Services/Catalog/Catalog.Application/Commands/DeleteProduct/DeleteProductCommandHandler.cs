using Catalog.Application.Utilities.DTOs;
using Catalog.Infrastructure.IRepositories.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Application.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result<Unit>>
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly ILogger<DeleteProductCommandHandler> _logger;

        public DeleteProductCommandHandler(ICatalogRepository catalogRepository, ILogger<DeleteProductCommandHandler> logger)
        {
            _catalogRepository = catalogRepository;
            _logger = logger;
        }

        public async Task<Result<Unit>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productToDelete = await _catalogRepository.GetByIdAsync(request.Id);

            if (productToDelete == null)
            {
                return null;
            }

            bool success = await _catalogRepository.DeleteAsync(productToDelete) > 0;

            if (success)
            {
                _logger.LogInformation($"Product {productToDelete.Id} is successfully deleted.");
                return Result<Unit>.Success(Unit.Value);
            }

            return Result<Unit>.Failure("Failed to delete the product");
        }
    }
}
