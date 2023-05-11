using Microsoft.AspNetCore.Components;
using ProjetoFinalAPI.Models;
using System.Diagnostics;

namespace ProjetoFinal.Pages
{
    public partial class AddOrder
    {
        Order OrderModel { get; set; } = new();

        private List<Product> Products { get; set; } = new();

        Order NewOrder { get; set; } = new Order();

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

            public async void OnCreateNewOrder()
        {
            try
            {
                var response = await WebServiceAPI.AddOrder(OrderModel);

                if (response is not null) 
                { 
                
                //Do something
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void OnselectChanged(ChangeEventArgs args)
        {
            NewOrder.IdProduct = Convert.ToInt32(args.Value);
            StateHasChanged();

        }
    }
}
