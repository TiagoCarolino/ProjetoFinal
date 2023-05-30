using ProjetoFinalAPI.Models;
using Refit;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoFinal.Interfaces
{
    public interface IWebServiceAPI
    {
        [Get("/products")]
        public Task<List<Product>> GetProducts();

        [Get("/product-details/{id}")]
        public Task<Product> GetProduct(int id);

        [Post("/products")]
        public Task<Product> CreateProduct([Body] Product newProduct);

        [Put("/product-edit/{id}")]
        public Task<Product> UpdateProduct([FromBody] Product updatedProduct, int id);

        [Delete("/products/{id}")]
        public Task DeleteProduct(int id);



        [Get("/categories")]
        public Task<List<Category>> GetCategories();


        [Get("/stats")]
        public Task<Dashboard> GetStats();


        [Get("/stocks")]
        public Task<List<Stock>> GetProductStocks(int ProductId, bool IsDeleted = true);

        [Get("/stocks")]
        public Task<List<Stock>> GetStocks(bool IsDeleted = true);

        [Post("/stocks")]
        public Task<Stock> CreateStock([Body] Stock newStock);


        [Delete("/stocks/{id}")]
        public Task DeleteStock(int id);

    }
}
