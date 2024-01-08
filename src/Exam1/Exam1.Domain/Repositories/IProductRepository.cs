using Exam1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Domain.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product, Guid>
    {/*
        Task<bool> IsTitleDuplicateAsync(Product product);  */
        Task<bool> IsNameDuplicateAsync(string name, Guid? id = null);
        Task<(List<Product> records, int total, int totalDisplay)> GetTableDataAsync(string searchName, uint searchPriceFrom, uint searchPriceTo, string sortBy,
            int pageIndex, int pageSize);
    }
}
