using Microsoft.AspNetCore.Components;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Shared;
using ProjetoFinalAPI.Models;
using System.Diagnostics;



namespace ProjetoFinal.Pages
{
    public partial class ProductStock
    {
        [Parameter]
        public int Id { get; set; }

        Product ProductData { get; set; } = new();

        Stock Stock { get; set; } = new();

        int stockQuantity { get; set; } = 0;

        List<Stock> productStocks { get; set; } = new List<Stock>();

        private string Message { get; set; }

        ModalComponent? Modal { get; set; } = new();

        int page = 0;
        int pagesize = 10;

        protected override async Task OnInitializedAsync()
        {

            try
            {
                ProductData = await WebServiceAPI.GetProduct(Id);
                productStocks = await WebServiceAPI.GetProductStocks(Id, false, Page: page, PageSize: pagesize);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
            StateHasChanged();
        }

        private async Task AddStock(bool isEntry)
        {
            if (stockQuantity <= 0)
                return;

            if (isEntry == false && ProductData.Quantity < stockQuantity)
                return;

            Stock stock = new Stock();
            stock.ProductId = ProductData.Id;
            stock.IsEntry = isEntry;
            stock.IsDeleted = false;
            stock.Quantity = stockQuantity;

            try
            {
                stock = await WebServiceAPI.CreateStock(stock);
                ProductData = stock.Product;

                if (productStocks.Count() < pagesize)
                    productStocks.Add(stock);
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
                productStocks.Remove(stock);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;

            }
        }
    }
}
