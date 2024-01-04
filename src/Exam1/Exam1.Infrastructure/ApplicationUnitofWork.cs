using Exam1.Application;
using Exam1.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Infrastructure
{
    public class ApplicationUnitofWork : UnitOfWork, IApplicationUnitofWork
    {
        public IProductRepository ProductRepository { get; private set; }
        public ApplicationUnitofWork(IProductRepository productRepository, IApplicationDbContext  dbContext) : base((DbContext)dbContext)
        {
            ProductRepository = productRepository;
        }

    }
}
