using FirstDemo.Domain.Entities;
using FirstDemo.Infrastructure.Membership;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FirstDemo.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,
        ApplicationRole, Guid,
        ApplicationUserClaim, ApplicationUserRole,
        ApplicationUserLogin, ApplicationRoleClaim,
        ApplicationUserToken>,
        IApplicationDbContext
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
            builder.Entity<CourseEnrollment>().ToTable("CourseEnrollments");
            builder.Entity<CourseEnrollment>().HasKey(x => new { x.CourseId, x.StudentId });

            builder.Entity<CourseEnrollment>()
                .HasOne<Course>()
                .WithMany()
                .HasForeignKey(x => x.CourseId);

            builder.Entity<CourseEnrollment>()
                            .HasOne<Student>()
                            .WithMany()
                            .HasForeignKey(x => x.StudentId);


            builder.Entity<Course>().HasData(new Course[]
            {
                new Course{ Id=new Guid("672b26ca-6a94-46a0-8296-5583a37c84d9"), Title = "Test Course 1", Description= " Test Description 1", Fees = 2000 },
                new Course{ Id=new Guid("7c47af1a-8fe1-4424-bce9-b002d606a86f"), Title = "Test Course 2", Description= " Test Description 2", Fees = 3000 }
            });
            base.OnModelCreating(builder);
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}