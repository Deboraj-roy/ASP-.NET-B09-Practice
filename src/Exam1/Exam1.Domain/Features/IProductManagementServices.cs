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
        Task CreateProductAsync(string name, uint price, double weight);
        Task DeleteProductAsync(Guid id);
        Task<Product> GetProductAsync(Guid id);
        Task<(List<Product> records, int total, int totalDisplay)>
            GetPagedProductAsync(string searchName,
            uint price, double weigh, string sortBy,int pageIndex, int pageSize);
        //Task UpdateProductAsync(Product product);
        Task UpdateProductAsync(Guid Id,string Name,uint Price,double Weight);
        
    }
}
