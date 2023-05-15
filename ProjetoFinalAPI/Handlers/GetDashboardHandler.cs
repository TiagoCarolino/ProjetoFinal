using AutoMapper;
using MediatR;
using ProjetoFinalAPI.Data;
using ProjetoFinalAPI.Models;
using ProjetoFinalAPI.Queries;

namespace ProjetoFinalAPI.Handlers
{
    public class GetDashboardHandler : IRequestHandler<GetStatsQuery, Dashboard>
    {
        IDataContext _dataContext;

        IMapper _mapper;

        public Task<Dashboard> Handle(GetStatsQuery request, CancellationToken cancellationToken)
        {
            var categoryQuery = _dataContext.Categories.AsQueryable();

            var handMapped = categoryQuery.Select(x => new Product
            {
                Id = x.CategoryId,
                Name = x.Name
            }).ToList();

            var categories = _mapper.Map<List<Category>>(categoryQuery);

            var Dashboard = new Dashboard();
            Dashboard.statsCategories = new List<Tuple<Category, int, decimal>>();

            if (categories != null)
            {
                var productsQuery = _dataContext.Products.AsQueryable().Where(x => x.IsDeleted == false);

                foreach (var category in categories)
                {


                    var filteredQuery = productsQuery.Where(x => x.CategoryId == category.CategoryId);
                    var avg_price = filteredQuery.Average(x => (Decimal?)x.Price);
                    Dashboard.statsCategories.Add(Tuple.Create(category, filteredQuery.Count(), avg_price ?? -Decimal.One));
                }
            }

            return Task.FromResult(Dashboard);
        }
    }
    
}
