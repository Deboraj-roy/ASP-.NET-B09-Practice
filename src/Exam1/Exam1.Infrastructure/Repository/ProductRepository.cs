using Exam1.Domain.Entity;
using Exam1.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product, Guid>, IProductRepository
    {
        public ProductRepository(IApplicationDbContext context) : base((DbContext)context) { }
        public Task<(List<Product> records, int total, int totalDisplay)> GetTableDataAsync(string searchName, uint searchPriceFrom, uint searchPriceTo, string sortyBy, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsNameDuplicateAsync(string name, Guid? id = null)
        {
            if (id.HasValue)
            {
                return (await GetCountAsync(x => x.Id != id.Value && x.Name == name) > 0);
            }
            else
            {
                return (await GetCountAsync(x.Name == name) > 0);
            }
        }
    }
}


