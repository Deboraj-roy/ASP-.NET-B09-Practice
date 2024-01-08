using Exam1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Domain.Features
{
    public interface IProductManagementService
    {
        Task CreateProductAsync(string name, uint price, double weight);
        Task DeleteProductAsync(Guid id);
        Task<Product> GetProductAsync(Guid id);
        Task UpdateProductAsync(Guid id, string name, uint price, double weight);
        Task<(List<Product> records, int total, int totalDisplay)> GetPageProductAsync(string searchName, uint searchPriceFrom, uint searchPriceTo, string sortBy, 
            int  pageIndex, int pageSize);
    }
}
