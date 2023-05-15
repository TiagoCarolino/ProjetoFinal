using ProjetoFinal.Interfaces;
using ProjetoFinalAPI.Models;
using System.Diagnostics;

namespace ProjetoFinal.Pages
{
    public partial class StockPage
    {
        List<Stock> StocksData { get; set; } = new List<Stock>();

        int page = 0;

        int pageSize = 10;

        protected override async Task OnInitializedAsync()
        {

            try
            {
                StocksData = await WebServiceAPI.GetStocks(false, Page: page, PageSize: pageSize);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }
        private async Task DeleteStock(Stock stock)
        {
            try
            {
                await WebServiceAPI.DeleteStock(stock.Id);
                StocksData.Remove(stock);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;

            }
        }
    }
}
