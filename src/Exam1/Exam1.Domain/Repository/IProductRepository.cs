using Exam1.Domain.Entity;

namespace Exam1.Domain.Repository
{
    public interface IProductRepository : IRepositoryBase<Product, Guid>
    {
        Task<bool> IsNameDuplicateAsync(string name, Guid? id = null);
        Task<(List<Product> records, int total, int totalDisplay)> 
            GetTableDataAsync( string searchName, uint searchPriceFrom, uint searchPriceTo, string sortyBy, int pageIndex, int pageSize);
    }
}
