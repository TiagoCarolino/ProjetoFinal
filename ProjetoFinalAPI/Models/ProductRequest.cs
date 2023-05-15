namespace ProjetoFinalAPI.Models
{
    public class ProductRequest
    {
        public int? Id { get; set; }
        public string? Search { get; set; }
        public string? Category { get; set; }
        public bool? IsDeleted { get; set; }

        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
