using Microsoft.AspNetCore.Components;
using ProjetoFinal.Shared;
using ProjetoFinalAPI.Models;
using System.Diagnostics;



namespace ProjetoFinal.Pages
{

    public partial class CreateProduct
    {
        List<Product> ProductsData { get; set; } = new();

        Product NewProduct { get; set; } = new Product();

        private List<Category> Categories { get; set; } = new();

        private string Message { get; set; }

        ModalComponent? Modal { get; set; } = new();


        protected override async Task OnInitializedAsync()
        {
            try
            {
                var response = await WebServiceAPI.GetCategories();

                if (response is not null)
                {
                    Categories = response;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        private async Task CreateNewProduct()
        {
            try
            {
                var response = await WebServiceAPI.CreateProduct(NewProduct);
                ProductsData.Add(response);
                NewProduct = new Product();

                if (response is not null)
                {
                    Message = $"Product {response.Name} data was sucessfully Created";
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
            NewProduct.CategoryId = Convert.ToInt32(args.Value);
            StateHasChanged();

        }
    }
}
