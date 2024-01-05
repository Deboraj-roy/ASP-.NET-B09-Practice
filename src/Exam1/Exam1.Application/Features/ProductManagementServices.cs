using Exam1.Domain;
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

        public async Task CreateProductAsync(string name, uint price, double weight)
        {
            Product product = new Product
            {
                Name = name,
                Price = price,
                Weight = weight
            };
            _unitofWork.ProductRepository.Add(product);
            await _unitofWork.SaveAsync();
        }

        public async Task DeleteProductAsync(Guid id)
        {
            await _unitofWork.ProductRepository.RemoveAsync(id);
            await _unitofWork.SaveAsync();
        }

        /*public async Task<Product> GetAllProductAsync()
        {
             return await _unitofWork.ProductRepository.GetAllProductsAsync();
        }*/

        public async Task<(List<Product> records, int total, int totalDisplay)> 
            GetPagedProductAsync(string name, uint price, double weight, string sortBy, int pageIndex, int pageSize)
        {
            return await _unitofWork.ProductRepository.GetTableDataAsync(name, price, weight, sortBy, pageIndex, pageSize);
        }

        public async Task<Product> GetProductAsync(Guid id)
        {
            return await _unitofWork.ProductRepository.GetByIdAsync(id);
        }

        public async Task UpdateProductAsync(Guid Id, string name, uint price, double weight)
        {
            var course = await GetProductAsync(Id);
            if (course is not null)
            {
                course.Name = name;
                course.Price = price;
                course.Weight = weight;
            }
            await _unitofWork.SaveAsync();
        }
    }
}
