using FirstDemo.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FirstDemo.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;

        public ApplicationDbContext(string connectionString, string migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString,
                    x => x.MigrationsAssembly(_migrationAssembly));
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Course>().HasData(new Course[]
            {
                new Course{ Id=Guid.NewGuid(), Title = "Test Course 1", Description= " Test Description 1", Fees = 2000 },
                new Course{ Id=Guid.NewGuid(), Title = "Test Course 2", Description= " Test Description 2", Fees = 3000 }
            });
            base.OnModelCreating(builder);
        }

        public DbSet<Course> Courses { get; set; }
    }
}