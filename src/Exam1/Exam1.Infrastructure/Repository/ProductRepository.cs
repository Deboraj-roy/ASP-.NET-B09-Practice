using Exam1.Domain.Entity;
using Exam1.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Exam1.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product, Guid>, IProductRepository
    {
        public ProductRepository(IApplicationDbContext context) : base((DbContext)context) { }
        public async Task<(List<Product> records, int total, int totalDisplay)> GetTableDataAsync(string searchName, uint searchPriceFrom, uint searchPriceTo, string sortyBy, int pageIndex, int pageSize)
        {
            Expression<Func<Product, bool>> expression = null;
            if(!string.IsNullOrEmpty(searchName))
            {
                expression = x=> x.Name.Contains(searchName)
                && (x.Price >= searchPriceFrom && x.Price <= searchPriceTo);
            }
            var result = await GetDynamicAsync(expression, sortyBy, null, pageIndex, pageSize, true);

            List<Product> records = result.data.ToList();
            int total = result.total;
            int totalDisplay = result.totalDisplay;
            return (records, total, totalDisplay);
        }

        // Not Require to implement
        public async Task<bool> IsNameDuplicateAsync(string name, Guid? id = null)
        {
            if (id.HasValue)
            {
                return (await GetCountAsync(x => x.Id != id.Value && x.Name == name) > 0);
            }
            else
            {
                return (await GetCountAsync(x => x.Name == name) > 0);
            }
        }
    }
}


