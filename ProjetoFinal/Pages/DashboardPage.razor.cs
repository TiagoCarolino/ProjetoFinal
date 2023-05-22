using ProjetoFinal.Interfaces;
using ProjetoFinal.Shared;
using ProjetoFinalAPI.Models;
using System.Diagnostics;

namespace ProjetoFinal.Pages
{
    public partial class DashboardPage
    {
        Dashboard Dashboard { get; set; } = new();

        List<Tuple<Category, int>> categoryByProducts = new();

        List<Tuple<Category, Decimal>> categoryByAvgPrice = new();


        protected override async Task OnInitializedAsync()
        {
                try
                {
                    Dashboard = await WebServiceAPI.GetStats();
                    categoryByProducts = Dashboard.statsCategories
                                    .OrderByDescending(x => x.Item2)
                                    .Take(5)
                                    .Select(x => Tuple.Create(x.Item1, x.Item2))
                                    .ToList();
                    categoryByAvgPrice = Dashboard.statsCategories
                                    .Where(x => x.Item3 != -1)
                                    .OrderByDescending(x => x.Item3)
                                    .Select(x => Tuple.Create(x.Item1, x.Item3))
                                    .ToList();

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    throw;
                }
            }
        
    }
}
