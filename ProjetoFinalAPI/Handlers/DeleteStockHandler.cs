using MediatR;
using ProjetoFinalAPI.Commands;
using ProjetoFinalAPI.Data;

namespace ProjetoFinalAPI.Handlers
{
    public class DeleteStockHandler : IRequestHandler<DeleteStockCommand>
    {
        IDataContext _dataContext;
        public DeleteStockHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Handle(DeleteStockCommand request, CancellationToken cancellationToken)
        {
            var stocks = _dataContext.Stocks;

            var stock = stocks.FirstOrDefault(x => x.Id == request.id);

            if (stock is not null)
            {
                stock.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
            }

        }
    }
}
