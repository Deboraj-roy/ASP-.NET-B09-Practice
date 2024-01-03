using Exam1.Domain.Entities;
using Exam1.Domain.Repositories;
using Exam1.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product, Guid>, IProductRepository
    {
        public ProductRepository(IApplicationDbContext context) : base((DbContext)context)
        {
        }

        public Task<(List<Product> records, int total, int totalDisplay)> GetTableDataAsync(string searchTitle, uint searchFeesFrom, uint searchFeesTo, string orderBy, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
            /*Expression<Func<Product, bool>> expression = null;
            if(!string.IsNullOrWhiteSpace(searchTitle))
            {
                expression = x =>IsTitleDulicateAsync().Contains
            }*/
        }

        public Task<bool> IsTitleDulicateAsync(string title, Guid? id = null)
        {
            throw new NotImplementedException();
        }

        /* public async Task<bool> IsTitleDulicateAsync(string title, Guid? id = null)
         {
             if(id.HasValue)
             {
                 return (await GetCountAsync(x => x.Id != id.Value && x.TiTle == title)) > 0;
             }
             else
             {
                 return (await GetCountAsync(x.TiTle == title)) > 0;
             }
         }*/
    }
}
