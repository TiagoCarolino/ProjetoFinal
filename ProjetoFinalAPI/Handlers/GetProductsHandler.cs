using MediatR;
using ProjetoFinalAPI.Data;
using ProjetoFinalAPI.Models;
using ProjetoFinalAPI.Queries;
using AutoMapper;

namespace ProjetoFinalAPI.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<Product>>
    {
        IDataContext _dataContext;

        IMapper _mapper;

        public GetProductsHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;

        }

        public Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var query = _dataContext.Products.Skip(request.Page ?? request.PageDefault).Take(request.PageSize ?? request.PageSizeDefault).AsQueryable();


            if (!string.IsNullOrEmpty(request.Search))
            {
                query = query.Where(x => x.Name.Contains(request.Search) || x.Description.Contains(request.Search));
            }

            var handMapped = query.Select(x => new Product
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                IsDeleted = x.IsDeleted,
                Category = x.Category,
                Price = x.Price
            }).ToList();

            var autoMapped = _mapper.Map<List<Product>>(query);

            return Task.FromResult(query.ToList());
        }
    }
}
