using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoFinalAPI.Data;
using ProjetoFinalAPI.Models;
using static ProjetoFinalAPI.Queries.GetStockStatusQuery;

namespace ProjetoFinalAPI.Queries
{
    public class GetStockStatusQuery : IRequest<List<Stock>>
    {
        public class GetStockStatusHandler : IRequestHandler<GetStockStatusQuery, List<Stock>>
        {
            IDataContext _dataContext;

            public GetStockStatusHandler(IDataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public Task<List<Stock>> Handle(GetStockStatusQuery request, CancellationToken cancellationToken)
            {
                //Stock e Produtos
               var stockProducts = _dataContext.Stocks
                    .Include(x => x.Product).ToList();

                //Grouping Stock

                var groupedStock = stockProducts.GroupBy(x => x.ProductId).Select(x => new Stock
                {
                    ProductId = x.Key,
                    Quantity = x.Sum(x => x.Quantity),
                    Product = x.FirstOrDefault().Product

                }).ToList();


                //Orders e Produtos
                var orderProduct = _dataContext.Orders
                    .Include(x => x.Product).ToList();
                
                //Grouping Order with Stock

                var groupedOrderProducts = orderProduct.GroupBy(x => x.IdProduct).Select(x => new Stock
                {
                    ProductId = x.Key,
                    Quantity = x.Sum(x => x.QuantityOrder) * -1,
                    Product = x.FirstOrDefault().Product
                }).ToList();


                //Show all
                groupedOrderProducts.AddRange(groupedStock);

                var groupResult = groupedOrderProducts.GroupBy(x => x.ProductId).Select(x => new Stock
                {
                    ProductId = x.Key,
                    Quantity = x.Sum(x => x.Quantity),
                    Product = x.FirstOrDefault().Product
                }).ToList();

                return Task.FromResult(groupResult);
            }
        }

        public class StockStatusResult : Stock
        {
            public int Result { get; set; }
        }
    }
}
