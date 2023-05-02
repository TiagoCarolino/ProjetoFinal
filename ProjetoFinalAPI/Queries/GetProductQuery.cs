using MediatR;
using ProjetoFinalAPI.Models;

namespace ProjetoFinalAPI.Queries
{
    public record GetProductQuery (Product Product) : IRequest<Product>;
    
}
