using MediatR;
using ProjetoFinalAPI.Data;
using ProjetoFinalAPI.Models;

namespace ProjetoFinalAPI.Commands
{
    public class AddOrderCommand : IRequest<Order>
    {
        public Order Order { get; set; }

        public class AddOrderHandler : IRequestHandler<AddOrderCommand, Order>
        {
            IDataContext _dataContext;

            public AddOrderHandler(IDataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Order> Handle(AddOrderCommand request, CancellationToken cancellationToken)
            {
                var context = _dataContext.Orders;

                try
                {
                    context.Entry(request.Order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    await _dataContext.SaveChangesAsync(cancellationToken);
                    return request.Order;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
