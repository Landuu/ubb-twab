using MediatR;
using Shared.Entities;

namespace ProductsApi.Mediator.Commands
{
    public record AddProductCommand(ProductEntity Product) : IRequest;
}
