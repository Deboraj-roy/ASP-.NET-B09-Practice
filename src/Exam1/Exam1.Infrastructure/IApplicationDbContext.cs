using Exam1.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Infrastructure
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
    }
}
