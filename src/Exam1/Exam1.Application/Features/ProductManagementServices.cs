using Exam1.Domain.Entities;
using Exam1.Domain.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Application.Features
{
    public class ProductManagementServices : IProductManagementServices
    {
        private readonly IApplicationUnitofWork _unitofWork;
        public ProductManagementServices(IApplicationUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public Task CreateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<(List<Product> records, int total, int totalDisplay)> GetPagedProductAsync(int pageIndex, int pageSize, string searchTitle, uint serachFeesFrom, uint searchFeesTo, string sortBy)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
