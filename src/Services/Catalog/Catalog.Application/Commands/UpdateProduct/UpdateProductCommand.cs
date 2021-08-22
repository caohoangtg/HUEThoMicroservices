using Catalog.Application.Utilities.DTOs;
using MediatR;
using System;

namespace Catalog.Application.Commands
{
    public class UpdateProductCommand : IRequest<Result<Unit>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Category { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public string ImageFile { get; set; }

        public decimal Price { get; set; }
    }
}
