using Exam1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Domain.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product, Guid>
    {
        Task<bool> IsTitleDulicateAsync(string title, Guid? id = null);

        Task<(List<Product> records, int total, int totalDisplay)>
            GetTableDataAsync(string searchTitle, uint searchFeesFrom,
            uint searchFeesTo, string orderBy, int pageIndex, int pageSize);
    }
}
