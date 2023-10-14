
using Shared.Entities;

namespace ProductsApi.Repositories
{
    public interface IProductRepository : IDisposable
    {
        IQueryable<ProductEntity> GetProducts();
        ProductEntity? GetProductById(int id);
        void InsertProduct(ProductEntity product);
        void DeleteProduct(int id);
        void UpdateProduct(ProductEntity product);
        void Save();
        Task InsertProductAsync(ProductEntity product, CancellationToken cancellationToken);
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
