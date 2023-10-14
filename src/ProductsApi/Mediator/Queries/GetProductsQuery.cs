using MediatR;
using Shared.Entities;

namespace ProductsApi.Mediator.Queries
{
    public record GetProductsQuery() : IRequest<IEnumerable<ProductEntity>>;
}
