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
        //private readonly IApplicationDbContext _context;
        public ProductRepository(IApplicationDbContext context) : base((DbContext)context)
        {
            //_context = context;
        }

        /* public async Task<IEnumerable<Product>> GetAllProductsAsync()
         {
             return await _context.Set<Product>().ToListAsync();
         }*/

        /* public async Task<(List<Product> records, int total, int totalDisplay)> GetTableDataAsync(string name, uint price, double weight, string orderBy, int pageIndex, int pageSize)
         {
             Expression<Func<Product, bool>> expression = null;

             if (!string.IsNullOrWhiteSpace(name))
                 expression = (x => x.Name.Contains(name) || ((x.Price >= price) || (x.Weight >= weight)));

             //return await GetDynamicAsync(expression, orderBy, null, pageIndex, pageSize, true);

             return await GetDynamicAsync(expression, orderBy, null, pageIndex, pageSize, true);
         }*/

        /*

                public async Task<(List<Product> records, int total, int totalDisplay)> GetTableDataAsync(string name, uint price, double weight, string orderBy, int pageIndex, int pageSize)
                {
                    Expression<Func<Product, bool>> expression = null;
                    if (!string.IsNullOrWhiteSpace(name))
                        expression = x => x.Name.Contains(name) || ((x.Price >= price) || (x.Weight >= weight));
                    return await GetDynamicAsync(expression, orderBy, null, pageIndex, pageSize, true);
                    //throw new NotImplementedException();
                }

        */


        public async Task<(List<Product> records, int total, int totalDisplay)> GetTableDataAsync(string name, uint price, double weight, string orderBy, int pageIndex, int pageSize)
        {
            Expression<Func<Product, bool>> expression = null;

            if (!string.IsNullOrWhiteSpace(name))
                expression = (x => x.Name.Contains(name) || ((x.Price >= price) || (x.Weight >= weight)));

            var result = await GetDynamicAsync(expression, orderBy, null, pageIndex, pageSize, true);

            // Explicitly convert the tuple elements to the expected types
            List<Product> records = result.data.ToList();
            int total = result.total;
            int totalDisplay = result.totalDisplay;

            return (records, total, totalDisplay);
        }



        /* public async Task<(IList<Product> records, int total, int totalDisplay)> GetTableDataAsync(string name, uint price, double weight, string orderBy, int pageIndex, int pageSize)
         {
             Expression<Func<Product, bool>> expression = null;

             if (!string.IsNullOrWhiteSpace(name))
                 expression = x => x.Name.Contains(name) || ((x.Price >= price) || (x.Weight >= weight));

             return await GetDynamicAsync(expression, orderBy, null, pageIndex, pageSize, true);
         }*/


        public async Task<bool> IsTitleDulicateAsync(string name, Guid? id = null)
        {
            if (id.HasValue)
            {
                return (await GetCountAsync(x => x.Id != id.Value && x.Name == name)) > 0;
            }
            else
            {
                return (await GetCountAsync(x => x.Name == name)) > 0;
            }
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
