using MediatR;
using ProjetoFinalAPI.Data;
using ProjetoFinalAPI.Models;
using ProjetoFinalAPI.Queries;

namespace ProjetoFinalAPI.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<Product>>
    {
        IDataContext _dataContext;

        public GetProductsHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var query = _dataContext.Products;
            
            return Task.FromResult(query.ToList());
        }
    }
}
