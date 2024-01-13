using Exam1.Domain.Entity;
using Exam1.Domain.Feature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Application.Feature
{
    public class ProductManagementService : IProductManagementService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        public ProductManagementService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateProductAsync(string name, uint price, double weight)
        {
            Product product = new Product
            {
                Name = name,
                Price = price,
                Weight = weight
            };

            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteProductAsync(Guid id)
        {
            await _unitOfWork.ProductRepository.RemoveAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<(List<Product> records, int total, int totalDisplay)> GetPageProductAsync(string searchName, uint searchPriceFrom, uint searchPriceTo, string sortBy, int pageIndex, int pageSize)
        {
            return await _unitOfWork.ProductRepository.GetTableDataAsync(searchName, searchPriceFrom, searchPriceTo, sortBy, pageIndex, pageSize);
        }

        public async Task<Product> GetProductAsync(Guid id)
        {
            return await _unitOfWork.ProductRepository.GetByIdAsync(id);
        }

        public async Task UpdateProductAsync(Product productUp)
        {
            var newProduct = await GetProductAsync(productUp.Id);
            if (newProduct is not null)
            {
                //newProduct = productUp;
                newProduct.Id = productUp.Id;
                newProduct.Name = productUp.Name;
                newProduct.Price = productUp.Price;
                newProduct.Weight = productUp.Weight;
                Console.WriteLine(newProduct.Name);
                Console.WriteLine(newProduct.Price);
                Console.WriteLine(newProduct.Weight); 
            }
            await _unitOfWork.SaveAsync();
        }
    }
}
