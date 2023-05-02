using MediatR;
using ProjetoFinalAPI.Models;

namespace ProjetoFinalAPI.Commands
{
     public record UpdateProductCommand(Product Product, int Id) : IRequest<Product>;
}
