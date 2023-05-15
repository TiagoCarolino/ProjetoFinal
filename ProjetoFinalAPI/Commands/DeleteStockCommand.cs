using MediatR;

namespace ProjetoFinalAPI.Commands
{
    public record DeleteStockCommand(int id) : IRequest;
    
}
