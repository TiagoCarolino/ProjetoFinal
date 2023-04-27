﻿using Microsoft.EntityFrameworkCore;
using ProjetoFinalAPI.Models;

namespace ProjetoFinalAPI.Data
{
    public interface IDataContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Stock> Stocks { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellation = default);
    }
}