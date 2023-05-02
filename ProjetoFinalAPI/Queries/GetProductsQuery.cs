using MediatR;
using ProjetoFinalAPI.Models;

namespace ProjetoFinalAPI.Queries
{
    public record GetProductsQuery() : IRequest<List<Product>>
    {
    public string? Search { get; set; }
    public bool? IsDeleted { get; set; }
    public int? Page { get; set; }
    public int? PageSize { get; set; }

    public int PageDefault = 0;

    public int PageSizeDefault = 50;

}
}
