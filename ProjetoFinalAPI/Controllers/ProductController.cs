using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    }
}
