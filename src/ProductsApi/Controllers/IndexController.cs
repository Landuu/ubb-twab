using Microsoft.AspNetCore.Mvc;
using ProductsApi.Repositories;
using Shared.Entities;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("/api")]
    public class IndexController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public IndexController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IResult Index()
        {
            var product = new ProductEntity()
            {
                Name = "Test",
                Price = 1.20m
            };

            return Results.Text("Hello World!");
        }

        [HttpGet("products")]
        public IResult GetProducts()
        {
            var products = _productRepository.GetProducts().ToList();
            return Results.Json(products);
        }

        [HttpGet("insert")]
        public IResult Insert()
        {
            var rnd = new Random();

            var product = new ProductEntity()
            {
                Name = "Test",
                Price = Convert.ToDecimal(rnd.Next(1, 100))
            };
            _productRepository.InsertProduct(product);
            _productRepository.Save();
            return Results.Text("ok");

        }

    }
}