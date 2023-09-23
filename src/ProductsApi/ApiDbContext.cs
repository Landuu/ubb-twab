using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace ProductsApi
{
    public class ApiDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public ApiDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("Database"));
        }

        public DbSet<ProductEntity> Products { get; set; }

    }
}
