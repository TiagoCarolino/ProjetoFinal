using ProjetoFinalAPI.Commands;
using ProjetoFinalAPI.Data;
using ProjetoFinalAPI.Models;
using MediatR;

namespace ProjetoFinalAPI.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
        IDataContext _dataContext;

        public AddProductHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = _dataContext.Products;

            if (product == null)
            {
                return null;
            }
            else
            {
                try
                {
                    await product.AddAsync(request.product);
                    await _dataContext.SaveChangesAsync(cancellationToken);

                    return request.product;
                }
                catch (Exception e)
                {

                    throw;
                }
            }


        }
    }
}
