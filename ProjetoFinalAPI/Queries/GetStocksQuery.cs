using MediatR;
using ProjetoFinalAPI.Models;

namespace ProjetoFinalAPI.Queries
{
    public record GetStocksQuery : IRequest<List<Stock>>
    {
        public bool? IsDeleted { get; set; }
        public int? ProductId { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }

        public int PageDefault = 0;

        public int PageSizeDefault = 1000;
    }
}
