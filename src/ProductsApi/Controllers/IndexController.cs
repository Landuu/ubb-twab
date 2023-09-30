using Microsoft.AspNetCore.Mvc;
using ProductsApi.Repositories;
using ProductsApi.Services;
using Shared.Entities;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("/api")]
    public class IndexController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductUnitOfWork _unitOfWork;

        public IndexController(IProductRepository productRepository, IProductUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
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

        [HttpGet("unit")]
        public IResult GetUnit()
        {
            var p1 = new ProductEntity()
            {
                Name = "Prod",
                Price = 11.2m
            };

            var p2 = new ProductEntity()
            {
                Name = "Prod2",
                Price = 24.4m
            };

            _unitOfWork.AddProducts(p1, p2);
            _unitOfWork.Save();
            return Results.Text("Ok");
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