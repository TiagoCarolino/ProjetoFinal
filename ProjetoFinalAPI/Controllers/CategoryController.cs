using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinalAPI.Queries;

namespace ProjetoFinalAPI.Controllers
{
    public class CategoryController : Controller
    {
        IMediator Mediator { get; set; }

        public CategoryController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet("/categories")]
        public async Task<IActionResult> GetCategories()
        {
            var result = await Mediator.Send(new GetCategoriesQuery());
            return Ok(result);
        }
    }
}
