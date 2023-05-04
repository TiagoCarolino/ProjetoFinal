namespace ProjetoFinalAPI.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public bool IsEntry { get; set; }
        public bool IsDeleted { get; set; }

    }
}
