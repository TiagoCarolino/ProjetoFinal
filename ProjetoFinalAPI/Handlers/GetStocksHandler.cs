using AutoMapper;
using MediatR;
using ProjetoFinalAPI.Data;
using ProjetoFinalAPI.Models;
using ProjetoFinalAPI.Queries;

namespace ProjetoFinalAPI.Handlers
{
    public class GetStocksHandler : IRequestHandler<GetStocksQuery, List<Stock>>
    {
        IDataContext _dataContext;

        IMapper _mapper;
        public GetStocksHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public Task<List<Stock>> Handle(GetStocksQuery request, CancellationToken cancellationToken)
        {
            var query = _dataContext.Stocks.AsQueryable();

            if (request.ProductId != null)
            {
                query = query.Where(x => x.ProductId == request.ProductId);
            }

            if (request.IsDeleted == false)
            {
                query = query.Where(x => x.IsDeleted == false);
            }

            var pageSize = request.PageSize ?? request.PageSizeDefault;
            query = query.Skip((request.Page ?? request.PageDefault) * pageSize).Take(pageSize);

            var handMapped = query.Select(x => new Stock
            {
                Id = x.Id,
                Quantity = x.Quantity,
                ProductId = x.ProductId,
                Product = x.Product,
                IsDeleted = x.IsDeleted,
                IsEntry = x.IsEntry
            }).ToList();

            var autoMapped = _mapper.Map<List<Stock>>(query);

            return Task.FromResult(autoMapped);
        }
    }
}
