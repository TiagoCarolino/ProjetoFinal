using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinalAPI.Commands;
using ProjetoFinalAPI.Models;
using ProjetoFinalAPI.Queries;

namespace ProjetoFinalAPI.Controllers
{
    public class OrderController : Controller
    {
        IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("orders")]
        public async Task<IActionResult> AddOrder([FromBody] Order order)
        {
            var result = await _mediator.Send(new AddOrderCommand 
            {
            Order = order
            
            });

            return Ok(result);
        }

    }
}
