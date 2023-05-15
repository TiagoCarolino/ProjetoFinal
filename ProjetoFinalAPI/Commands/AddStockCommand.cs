using MediatR;
using ProjetoFinalAPI.Data;
using ProjetoFinalAPI.Models;

namespace ProjetoFinalAPI.Commands
{
    public record AddStockCommand(Stock stock) : IRequest<Stock>;
    
}
