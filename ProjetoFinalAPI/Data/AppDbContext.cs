using Microsoft.EntityFrameworkCore;
using ProjetoFinalAPI.Models;
using System.Collections.Generic;

namespace ProjetoFinalAPI.Data
{
    public class AppDbContext : DbContext , IDataContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-A636UJT\SQLEXPRESS;Initial Catalog=ProjetoFinal; Trusted_Connection=True; TrustServerCertificate=True;");
        }
    }
}
