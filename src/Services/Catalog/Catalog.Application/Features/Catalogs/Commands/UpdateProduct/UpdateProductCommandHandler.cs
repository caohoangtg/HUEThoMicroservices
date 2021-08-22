using AutoMapper;
using Catalog.Application.Contracts.Persistence;
using Catalog.Application.Utilities.DTOs;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Catalogs.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result<Unit>>
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateProductCommandHandler> _logger;

        public UpdateProductCommandHandler(ICatalogRepository catalogRepository, IMapper mapper, ILogger<UpdateProductCommandHandler> logger)
        {
            _catalogRepository = catalogRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<Unit>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productToUpdate = await _catalogRepository.GetByIdAsync(request.Id);

            if (productToUpdate == null)
            {
                return null;
            }

            _mapper.Map(request, productToUpdate);//CreateMap
            //_mapper.Map(request, productToUpdate, typeof(UpdateProductCommand), typeof(Product));

            productToUpdate.UpdateLastModified("HoangTC", DateTime.UtcNow);

            var success = await _catalogRepository.UpdateAsync(productToUpdate) > 0;

            if (success)
            {
                _logger.LogInformation($"Product {productToUpdate.Id} is successfully updated.");
                return Result<Unit>.Success(Unit.Value);
            }

            return Result<Unit>.Failure("Failed to create product");
        }
    }
}
