
using Microsoft.AspNetCore.Components;
using ProjetoFinalAPI.Models;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace ProjetoFinal.Pages
{
    public partial class Products
    {
       
        List<Product> ProductsData { get; set; } = new();

        private bool dense = false;
        private bool hover = true;
        private bool striped = false;
        private bool bordered = false;
        private string searchString1 = "";
        private Product selectedItem1 = null;

        private bool FilterFunc1(Product product) => FilterFunc(product, searchString1);

        private bool FilterFunc(Product product, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (product.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if ($"{product.Price}".Contains(searchString))
                return true;
            if ($"{product.Quantity}".Contains(searchString))
                return true;
            return false;
        }

        protected override async Task OnInitializedAsync()
        {

            try
            {
                var response = await WebServiceAPI.GetProducts();
                ProductsData = response.Where(p => !p.IsDeleted).ToList();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }
        private async Task DeleteProduct(int id)
        {
            try
            {
                await WebServiceAPI.DeleteProduct(id);
                ProductsData.RemoveAll(p => p.Id == id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }
        private void EditProduct(int id)
        {
            NavigationManager.NavigateTo($"/editproduct/{id}");
        }

        private void EditStockProduct(int id)
        {
            NavigationManager.NavigateTo($"/editproductstock/{id}");
        }
    }
}
