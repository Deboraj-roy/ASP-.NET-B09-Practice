using Exam1.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
    {
        public DbSet<Product> Products { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
