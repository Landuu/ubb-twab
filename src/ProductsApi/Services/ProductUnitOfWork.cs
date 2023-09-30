using ProductsApi.Repositories;
using Shared.Entities;

namespace ProductsApi.Services
{
    public class ProductUnitOfWork : IProductUnitOfWork
    {
        private readonly IProductRepository _productRepository;

        public ProductUnitOfWork(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProducts(ProductEntity product1, ProductEntity product2)
        {
            _productRepository.InsertProduct(product1);
            _productRepository.InsertProduct(product2);
        }

        public void Save()
        {
            _productRepository.Save();
        }
    }
}
