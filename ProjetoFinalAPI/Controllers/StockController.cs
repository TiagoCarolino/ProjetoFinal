using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinalAPI.Commands;
using ProjetoFinalAPI.Models;
using ProjetoFinalAPI.Queries;

namespace ProjetoFinalAPI.Controllers
{
    public class StockController : Controller
    {
            IMediator Mediator;

            public StockController(IMediator mediator)
            {
                Mediator = mediator;
            }

        [HttpGet("stocks")]
        public async Task<IActionResult> GetStocks([FromQuery] StockRequest request)
        {
            var result = await Mediator.Send(new GetStocksQuery
            {
                ProductId = request.ProductId,
                IsDeleted = request.IsDeleted,
                Page = request.Page,
                PageSize = request.PageSize
            });
            return Ok(result);
        }

        [HttpPost("stocks")]
        public async Task<IActionResult> AddStock([FromBody] Stock stock)
        {
            var result = await Mediator.Send(new AddStockCommand(stock));
            return Ok(result);
        }

        [HttpDelete("stocks/{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            await Mediator.Send(new DeleteStockCommand(id));
            return Ok();
        }



    }
    }

