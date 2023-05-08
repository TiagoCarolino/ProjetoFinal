using Microsoft.AspNetCore.Components;
using ProjetoFinalAPI.Models;
using System.Diagnostics;

namespace ProjetoFinal.Pages
{
    public partial class EditProduct
    {
        [Parameter]
        public int Id { get; set; }

        Product ProductData { get; set; } = new();

        private List<Category> Categories { get; set; } = new();


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
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
            StateHasChanged();
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
