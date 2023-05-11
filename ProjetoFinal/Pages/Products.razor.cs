using Microsoft.AspNetCore.Components;
using ProjetoFinalAPI.Models;
using System.Diagnostics;

namespace ProjetoFinal.Pages
{
    public partial class Products
    {
        List<Product> ProductsData { get; set; } = new();

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
    }
}
