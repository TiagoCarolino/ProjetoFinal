
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinalAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey(nameof(Product.CategoryId))]
        public Category? Category { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }

        
    }

    
}
