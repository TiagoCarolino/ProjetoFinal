using ProjetoFinalAPI.Models;

namespace ProjetoFinal.Pages
{
    public partial class AddOrder
    {
        Order OrderModel { get; set; } = new();

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
    }
}
