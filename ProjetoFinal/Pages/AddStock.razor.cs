using Microsoft.AspNetCore.Components;
using ProjetoFinal.Interfaces;
using ProjetoFinalAPI.Models;
using System.Diagnostics;

namespace ProjetoFinal.Pages
{
    public partial class AddStock
    {
        Stock StockModel { get; set; } = new();
        private List<Product> Products { get; set; } = new();
        Stock NewStock { get; set; } = new Stock();
        [Inject] IWebServiceAPI WebServiceAPI { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var response = await WebServiceAPI.GetProducts();

                if (response is not null)
                {
                    Products = response;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

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

        private void OnselectChanged(ChangeEventArgs args)
        {
            NewStock.ProductId = Convert.ToInt32(args.Value);
            StateHasChanged();

        }
    }
}
