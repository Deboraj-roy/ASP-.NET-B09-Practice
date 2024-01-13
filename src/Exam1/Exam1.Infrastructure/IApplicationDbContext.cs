using Exam1.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Exam1.Infrastructure
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
    }
}
