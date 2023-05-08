using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoFinalAPI.Data;
using ProjetoFinalAPI.Models;
using static ProjetoFinalAPI.Queries.GetStockStatusQuery;

namespace ProjetoFinalAPI.Queries
{
    public class GetStockStatusQuery : IRequest<List<StockStatusResult>>
    {
        public class GetStockStatusHandler : IRequestHandler<GetStockStatusQuery, List<StockStatusResult>>
        {
            IDataContext _dataContext;

            public GetStockStatusHandler(IDataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public Task<List<StockStatusResult>> Handle(GetStockStatusQuery request, CancellationToken cancellationToken)
            {
                //Stock e Produtos
               var stockProducts = _dataContext.Stocks
                    .Include(x => x.Product).ToList();

                //Orders e Produtos
                var orderProduct = _dataContext.Orders
                    .Include(x => x.Product).ToList();

                return Task.FromResult(new List<StockStatusResult>());
            }
        }

        public class StockStatusResult : Stock
        {
            public int Result { get; set; }
        }
    }
}
