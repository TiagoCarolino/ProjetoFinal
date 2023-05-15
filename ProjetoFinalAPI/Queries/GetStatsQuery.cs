using MediatR;
using ProjetoFinalAPI.Models;

namespace ProjetoFinalAPI.Queries
{
    public record GetStatsQuery : IRequest<Dashboard>
    {
    }
}
