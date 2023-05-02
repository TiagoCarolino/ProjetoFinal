using MediatR;

namespace ProjetoFinalAPI.Commands
{
    public record DeleteProductCommand(int id) : IRequest;
}
