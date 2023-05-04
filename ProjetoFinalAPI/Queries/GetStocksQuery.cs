using MediatR;
using ProjetoFinalAPI.Models;

namespace ProjetoFinalAPI.Queries
{
    public record GetStocksQuery : IRequest<List<Stock>>
    {
        public bool? IsDeleted { get; set; }
        public int? ProductId { get; set; }
    }
}
