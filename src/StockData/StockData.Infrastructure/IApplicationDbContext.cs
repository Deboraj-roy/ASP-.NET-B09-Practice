using Microsoft.EntityFrameworkCore;
using StockData.Domain.Entities;

namespace StockData.Infrastructure
{
    public interface IApplicationDbContext
    {
        public DbSet<Company> Company { get; set; }
        public DbSet<StockPrice> StockPrices { get; set; }

    }
}