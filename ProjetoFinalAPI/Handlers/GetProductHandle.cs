using ProjetoFinalAPI.Queries;
using MediatR;
using ProjetoFinalAPI.Models;
using ProjetoFinalAPI.Data;

namespace ProjetoFinalAPI.Handlers
{
    public class GetProductHandle : IRequestHandler<GetProductQuery, Product>
    {
        IDataContext _dataContext;

        public GetProductHandle(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {

            var query = _dataContext.Products.Where(x => x.Id == request.Product.Id).FirstOrDefault();

            return Task.FromResult(query);
        }
    }
}
