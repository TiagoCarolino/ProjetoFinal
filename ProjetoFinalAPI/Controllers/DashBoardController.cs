using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinalAPI.Queries;

namespace ProjetoFinalAPI.Controllers
{
    public class DashBoardController : Controller
    {
       IMediator Mediator { get; set; }

        public DashBoardController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet("Stats")]
        public async Task<IActionResult> GetStats()
        {
            var result = await Mediator.Send(new GetStatsQuery());
            return Ok(result);
        }
    }
}
