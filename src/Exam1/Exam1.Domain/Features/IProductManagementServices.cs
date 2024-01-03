using Exam1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exam1.Domain.Features
{
    public interface IProductManagementServices
    {
        //Task CreateProductAsync(string title, uint fees, string description);
        //Task CreateProductAsync(Product product);
        Task CreateProductAsync(string Name, uint Price, double Weight);
        Task DeleteProductAsync(Guid id);
        Task<Product> GetProductAsync(Guid id);
        Task<(List<Product> records, int total, int totalDisplay)>
            GetPagedProductAsync(int pageIndex, int pageSize, string searchName,
            uint serachPriceFrom, uint searchPriceTo, string sortBy);
        //Task UpdateProductAsync(Product product);
        Task UpdateProductAsync(Guid Id,string Name,uint Price,double Weight);
        
    }
}
