using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinalAPI.Commands;
using ProjetoFinalAPI.Models;
using ProjetoFinalAPI.Queries;

namespace ProjetoFinalAPI.Controllers
{
    public class StockController : Controller
    {
        public class OrderController : Controller
        {
            IMediator Mediator;

            public OrderController(IMediator mediator)
            {
                Mediator = mediator;
            }

            [HttpPost("stocks")]
            public async Task<IActionResult> AddStock([FromBody] Stock stock)
            {
                await Mediator.Send(new AddStockCommand
                {
                    Stock = stock

                });

                return Ok();
            }

            [HttpGet("stockstatus")]
            public async Task<IActionResult> GetStockStatus()
            {
                var result = await Mediator.Send(new GetStockStatusQuery());

                return Ok(result);
            }

        }
    }
}
