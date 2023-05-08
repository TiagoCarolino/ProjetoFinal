using MediatR;
using ProjetoFinalAPI.Data;
using ProjetoFinalAPI.Models;

namespace ProjetoFinalAPI.Commands
{
    public class AddStockCommand : IRequest
    {
        public Stock Stock { get; set; }

        public class AddStockHandler : IRequestHandler<AddStockCommand>
        {
            IDataContext _dataContext;

            public AddStockHandler(IDataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task Handle(AddStockCommand request, CancellationToken cancellationToken)
            {
                var context = _dataContext.Stocks;

                context.Entry(request.Stock).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                await _dataContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
