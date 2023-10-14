using MediatR;
using ProductsApi.Mediator.Commands;
using ProductsApi.Repositories;

namespace ProductsApi.Mediator.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public AddProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.InsertProductAsync(request.Product, cancellationToken);
            await _productRepository.SaveAsync(cancellationToken);
            return;
        }
    }
}
