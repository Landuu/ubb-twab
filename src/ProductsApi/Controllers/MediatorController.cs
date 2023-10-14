using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Mediator.Commands;
using ProductsApi.Mediator.Queries;
using Shared.Entities;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediatorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MediatorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("products")]
        public async Task<IResult> GetProducts()
        {
            var products = await _mediator.Send(new GetProductsQuery());
            return Results.Json(products);
        }

        [HttpGet("insert-product")]
        public async Task<IResult> InsertProduct()
        {
            var product = new ProductEntity()
            {
                Name = "name",
                Price = 124.4m
            };

            await _mediator.Send(new AddProductCommand(product));
            return Results.Ok();
        }
    }
}
