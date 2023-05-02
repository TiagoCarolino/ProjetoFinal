using ProjetoFinalAPI.Commands;
using ProjetoFinalAPI.Data;
using MediatR;

namespace ProjetoFinalAPI.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
    {
        IDataContext _dataContext;
        public DeleteProductHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var products = _dataContext.Products;

            var product = products.FirstOrDefault(x => x.Id == request.id);

            if (product is not null)
            {
                product.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
            }

        }
    }
}
