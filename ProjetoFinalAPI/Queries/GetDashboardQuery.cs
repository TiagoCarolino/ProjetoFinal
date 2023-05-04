using MediatR;
using ProjetoFinalAPI.Models;

namespace ProjetoFinalAPI.Queries
{
    public record GetDashboardQuery : IRequest<DashBoard>
    {
    }
}
