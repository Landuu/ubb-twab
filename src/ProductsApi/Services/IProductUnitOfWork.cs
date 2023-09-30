using Shared.Entities;

namespace ProductsApi.Services
{
    public interface IProductUnitOfWork
    {
        void AddProducts(ProductEntity product1, ProductEntity product2);
        void Save();
    }
}