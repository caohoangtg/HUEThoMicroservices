using Catalog.Application.Utilities.DTOs;
using MediatR;
using System;

namespace Catalog.Application.Commands
{
    public class DeleteProductCommand : IRequest<Result<Unit>>
    {
        public Guid Id { get; private set; }

        public DeleteProductCommand(Guid id)
        {
            Id = id;
        }
    }
}
