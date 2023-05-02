using MediatR;
using ProjetoFinalAPI.Models;

namespace ProjetoFinalAPI.Commands
{
    public record AddProductCommand(Product product) : IRequest<Product>;
   
}
