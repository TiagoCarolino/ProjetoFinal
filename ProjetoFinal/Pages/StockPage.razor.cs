using ProjetoFinal.Interfaces;
using ProjetoFinalAPI.Models;
using System.Diagnostics;

namespace ProjetoFinal.Pages
{
    public partial class StockPage
    {
        List<Stock> StocksData { get; set; } = new ();

        private bool dense = false;
        private bool hover = true;
        private bool striped = false;
        private bool bordered = false;
        private string searchString1 = "";
        private Stock selectedItem1 = null;
        

        private bool FilterFunc1(Stock stock) => FilterFunc(stock, searchString1);
        

        private bool FilterFunc(Stock stock, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (stock.Product.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (stock.Product.Category.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if ($"{stock.IsEntry}".Contains(searchString))
                return true;
            if ($"{stock.Quantity}".Contains(searchString))
                return true;
            return false;
        }

        protected override async Task OnInitializedAsync()
        {

            try
            {
                StocksData = await WebServiceAPI.GetStocks(false);

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
