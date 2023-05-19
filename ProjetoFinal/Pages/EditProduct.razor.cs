using Microsoft.AspNetCore.Components;
using ProjetoFinal.Shared;
using ProjetoFinalAPI.Models;
using System.Diagnostics;

namespace ProjetoFinal.Pages
{
    public partial class EditProduct
    {
        [Parameter]
        public int Id { get; set; }

        Product ProductData { get; set; } = new();

        Stock Stock { get; set; } = new();

        int stockQuantity { get; set; } = 0;

        private List<Category> Categories { get; set; } = new();

        List<Stock> productStocks { get; set; } = new List<Stock>();

        private string Message { get; set; }

        ModalComponent? Modal { get; set; } = new();

        int page = 0;
        int pagesize = 10;


        protected override async Task OnInitializedAsync()
        {

            try
            {
                var response = await WebServiceAPI.GetCategories();
                if (response is not null)
                {
                    Categories = response;
                }
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

        public async void UpdateProduct()
        {
            try
            {
                var newProduct = new Product
                {

                    Name = ProductData.Name,
                    Description = ProductData.Description,
                    CategoryId = ProductData.CategoryId,
                    Price = ProductData.Price,
                    IsDeleted = ProductData.IsDeleted
                };

                var response = await WebServiceAPI.UpdateProduct(newProduct, Id);

                if (response is not null)
                {
                    Message = $"Product {response.Name} data was sucessfully Updated";
                    Modal.Message = Message;
                    Modal.Title = "Success";
                    Modal?.OpenModal();
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        private void OnselectChanged(ChangeEventArgs args)
        {
            ProductData.CategoryId = Convert.ToInt32(args.Value);
            StateHasChanged();

        }
    }
}
