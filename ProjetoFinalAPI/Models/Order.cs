using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinalAPI.Models
{
    public class Order
    {
        [Key]
        public int IdOrder { get; set; }
        public int IdProduct { get; set; }

        [ForeignKey(nameof(IdProduct))]
        public Product? Product { get; set; }
        public int QuantityOrder { get; set; }
        public DateTime OrderCreatedAt { get; set; }
    }
}
