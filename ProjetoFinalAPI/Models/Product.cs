using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinalAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ProductsCategory Category { get; set; }
        public bool Stock { get; set; }
        public int QuantityStock { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }
    }

    public enum ProductsCategory
    {
        Smartphone,
        Laptops,
        TVs,
        Audio,
        Accessories
    }
}
