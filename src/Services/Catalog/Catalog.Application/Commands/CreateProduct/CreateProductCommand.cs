using Catalog.Application.Utilities.DTOs;
using MediatR;

namespace Catalog.Application.Commands
{
    public class CreateProductCommand : IRequest<Result<Unit>>
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public string ImageFile { get; set; }

        public decimal Price { get; set; }
    }
}
