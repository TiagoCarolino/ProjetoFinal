using MediatR;
using ProjetoFinalAPI.Models;

namespace ProjetoFinalAPI.Queries
{
    public record GetProductsQuery() : IRequest<List<Product>>;

}
