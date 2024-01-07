using Exam1.Domain.Entities;
using Exam1.Domain.Repositories;
using Exam1.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product, Guid>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }

        public Task<(List<Product> records, int total, int totalDisplay)> GetTableDataAsync(string name, uint price, double weigh, string sortBy, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
