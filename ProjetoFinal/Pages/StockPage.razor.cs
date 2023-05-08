using Microsoft.AspNetCore.Components;
using ProjetoFinal.Interfaces;
using ProjetoFinalAPI.Models;

namespace ProjetoFinal.Pages
{
    public partial class StockPage
    {
        Stock StockModel { get; set; } = new();
        [Inject] IWebServiceAPI WebServiceAPI { get; set; }

        public async void OnCreateStock()
        {
            try
            {
                await WebServiceAPI.AddStock(StockModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
