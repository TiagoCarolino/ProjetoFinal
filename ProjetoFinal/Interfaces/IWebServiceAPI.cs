using Microsoft.AspNetCore.Mvc;
using ProjetoFinalAPI.Models;
using Refit;

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
    }
}
