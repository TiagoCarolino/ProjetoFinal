using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinalAPI.Commands;
using ProjetoFinalAPI.Models;
using ProjetoFinalAPI.Queries;

namespace ProjetoFinalAPI.Controllers
{
    public class ProductController : Controller
    {
        IMediator Mediator { get; set; }

        public ProductController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProducts()
        {
            var result = await Mediator.Send(new GetProductsQuery());
          
            return Ok(result);
        }

        [HttpGet("product-details/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await Mediator.Send(new GetProductQuery(new Models.Product
            {
                Id = id
            }));
            return Ok(result);
        }

        [HttpPost("products")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            var result = await Mediator.Send(new AddProductCommand(product));
            return Ok(result);
        }

        [HttpDelete("products/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await Mediator.Send(new DeleteProductCommand(id));
            return Ok();
        }

        [HttpPut("product-edit/{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product, int id)
        {
            var result = await Mediator.Send(new UpdateProductCommand(product, id));

            return Ok(result);
        }

    }
}
