using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinalAPI.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
