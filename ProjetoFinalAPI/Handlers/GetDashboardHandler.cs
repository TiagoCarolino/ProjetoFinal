using AutoMapper;
using MediatR;
using ProjetoFinalAPI.Data;
using ProjetoFinalAPI.Models;
using ProjetoFinalAPI.Queries;

namespace ProjetoFinalAPI.Handlers
{
    //public class GetDashboardHandler : IRequestHandler<GetDashboardQuery, DashBoard>
    //{
    //    IDataContext _dataContext;

    //    IMapper _mapper;

    //    public GetDashboardHandler(IDataContext dataContext, IMapper mapper)
    //    {
    //        _dataContext = dataContext;
    //        _mapper = mapper;
    //    }
    //public Task<DashBoard> Handle(GetDashboardQuery request, CancellationToken cancellationToken)
    //{
    //    var categoryQuery = _dataContext.Categories.AsQueryable();

    //    var handMapped = categoryQuery.Select(x => new Product
    //    {
    //        Id = x.Id,
    //        Name = x.Name
    //    }).ToList();

    //    var categories = _mapper.Map<List<Category>>(categoryQuery);

    //    var Stats = new DashBoard();
    //    Stats.CategoriesDashboard = new List<Tuple<Category, int, decimal>>();

    //    if (categories != null)
    //    {
    //        var productsQuery = _dataContext.Products.AsQueryable().Where(x => x.IsDeleted == false);

    //        foreach (var category in categories)
    //        {
    //            var filteredQuery = productsQuery.Where(x => x.Category == category.Id);
    //            var avg_price = filteredQuery.Average(x => (Decimal?)x.Price);
    //            Stats.statsCategories.Add(Tuple.Create(category, filteredQuery.Count(), avg_price ?? -Decimal.One));
    //        }
    //    }

    //            return Task.FromResult(Stats);
    //        }
    //    }

}
