using ProjetoFinalAPI.Commands;
using ProjetoFinalAPI.Data;
using ProjetoFinalAPI.Models;
using MediatR;

namespace ProjetoFinalAPI.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Product>
    {

        IDataContext _dataContext;
        public UpdateProductHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _dataContext.Products.FirstOrDefault(x => x.Id == request.Id);
            if (product == null)
            {
                return null;
            }
            else
            {
                product.Name = request.Product.Name;
                product.Description = request.Product.Description;
                product.Category = request.Product.Category;
                product.Price = request.Product.Price;

                await _dataContext.SaveChangesAsync(cancellationToken);

            }
            return product;
        }
    }
}
