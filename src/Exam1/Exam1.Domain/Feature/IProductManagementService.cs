﻿using Exam1.Domain.Entity;

namespace Exam1.Domain.Feature
{
    public interface IProductManagementService
    {
        Task CreateProductAsync(string name, uint price, double weight);
        Task DeleteProductAsync(Guid id);
        Task<Product> GetProductAsync(Guid id);
        Task UpdateProductAsync(Product product);
        Task<(List<Product> records, int total, int totalDisplay)> 
            GetPageProductAsync(string searchName, uint searchPriceFrom, uint searchPriceTo, string sortBy, int pageIndex, int pageSize);
    }
}
