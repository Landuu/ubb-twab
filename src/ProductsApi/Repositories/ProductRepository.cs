using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace ProductsApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApiDbContext _context;
        private readonly DbSet<ProductEntity> _set;

        public ProductRepository(ApiDbContext context)
        {
            _context = context;
            _set = context.Set<ProductEntity>();
        }

        public void DeleteProduct(int id)
        {
            _set.Where(x => x.Id == id).ExecuteDelete();
        }

        public ProductEntity? GetProductById(int id)
        {
            return _set.Find(id);
        }

        public IQueryable<ProductEntity> GetProducts()
        {
            return _set.AsQueryable();
        }

        public void InsertProduct(ProductEntity product)
        {
            _set.Add(product);
        }

        public void UpdateProduct(ProductEntity product)
        {
            _set.Update(product);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
