using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Mediator.Queries;
using ProductsApi.Repositories;
using Shared.Entities;

namespace ProductsApi.Mediator.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductEntity>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductEntity>> Handle(GetProductsQuery request, CancellationToken cancellationToken) {
            return await _productRepository.GetProducts().ToListAsync(cancellationToken);
        }
    }
}
