using MediatR;
using ProjetoFinalAPI.Data;
using ProjetoFinalAPI.Models;
using ProjetoFinalAPI.Queries;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
            var query = _dataContext.Products.AsQueryable();

            if (!string.IsNullOrEmpty(request.Search))
            {
                query = query.Where(x => x.Name.Contains(request.Search) || x.Description.Contains(request.Search));
            }

            if (request.IsDeleted == false)
            {
                query = query.Where(x => x.IsDeleted == false);
            }

            var pageSize = request.PageSize ?? request.PageSizeDefault;
            query = query.Skip((request.Page ?? request.PageDefault) * pageSize).Take(pageSize);

            var handMapped = query.Select(x => new Product
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                IsDeleted = x.IsDeleted,
                CategoryId = x.CategoryId,
                Category = x.Category,
                Price = x.Price
            }).ToList();

            var autoMapped = _mapper.Map<List<Product>>(query);

            return Task.FromResult(autoMapped);
        }
    }
}
