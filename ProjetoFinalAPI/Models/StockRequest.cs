namespace ProjetoFinalAPI.Models
{
    public class StockRequest
    {
        public int? Id { get; set; }

        public int? ProductId { get; set; }

        public bool? IsDeleted { get; set; }
        public int? Page { get; set; }

        public int? PageSize { get; set; }
    }
}
