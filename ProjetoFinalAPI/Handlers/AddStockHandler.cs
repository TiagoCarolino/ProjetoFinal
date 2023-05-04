using MediatR;
using ProjetoFinalAPI.Commands;
using ProjetoFinalAPI.Data;
using ProjetoFinalAPI.Models;

namespace ProjetoFinalAPI.Handlers
{
    public class AddStockHandler : IRequestHandler<AddStockCommand, Stock>
    {
        IDataContext _dataContext;

        public AddStockHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task<Stock> Handle(AddStockCommand request, CancellationToken cancellationToken)
        {
            var stocks = _dataContext.Stocks;

            if (stocks == null)
            {
                return null;
            }
            else
            {
                try
                {
                    var product = _dataContext.Products.Where(x => x.Id == request.stock.ProductId).FirstOrDefault();

                    if (product != null)
                    {
                        if (request.stock.IsEntry)
                            product.QuantityStock += request.stock.Quantity;
                        else
                            product.QuantityStock -= request.stock.Quantity;

                        request.stock.Product = product;

                        await stocks.AddAsync(request.stock);
                        await _dataContext.SaveChangesAsync(cancellationToken);
                    }



                    return request.stock;
                }
                catch (Exception)
                {

                    throw;
                }
            }


        }
    }
}
