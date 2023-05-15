using AutoMapper;
using MediatR;
using ProjetoFinalAPI.Data;
using ProjetoFinalAPI.Models;
using ProjetoFinalAPI.Queries;

namespace ProjetoFinalAPI.Handlers
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, List<Category>>
    {
        IDataContext _dataContext;
        IMapper _mapper;
        public GetCategoriesHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public Task<List<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var query = _dataContext.Categories.AsQueryable();

            var autoMapped = _mapper.Map<List<Category>>(query);

            return Task.FromResult(autoMapped);
        }
    }

}
