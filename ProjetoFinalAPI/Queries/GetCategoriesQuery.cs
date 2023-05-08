using MediatR;
using ProjetoFinalAPI.Models;

namespace ProjetoFinalAPI.Queries
{
    public record GetCategoriesQuery : IRequest<List<Category>>;
   
}
