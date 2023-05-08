using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinalAPI.Commands;
using ProjetoFinalAPI.Models;

namespace ProjetoFinalAPI.Controllers
{
    public class StockController : Controller
    {
        public class OrderController : Controller
        {
            IMediator _mediator;

            public OrderController(IMediator mediator)
            {
                _mediator = mediator;
            }

            [HttpPost("stocks")]
            public async Task<IActionResult> AddStock([FromBody] Stock stock)
            {
                await _mediator.Send(new AddStockCommand
                {
                    Stock = stock

                });

                return Ok();
            }

        }
    }
}
