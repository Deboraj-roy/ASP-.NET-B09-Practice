using Microsoft.EntityFrameworkCore;
using StockData.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Infrastructure
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockPrice>().HasKey(x => x.Id);

            modelBuilder.Entity<Company>().HasKey(x => x.Id);

            modelBuilder.Entity<StockPrice>().HasOne<Company>().WithMany()
                .HasForeignKey(company => company.CompanyId).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Company> Company { get; set; }
        public DbSet<StockPrice> StockPrices { get; set; }
    }
}
