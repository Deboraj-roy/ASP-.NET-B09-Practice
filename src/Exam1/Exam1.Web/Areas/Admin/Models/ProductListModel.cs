using Autofac;
using Exam1.Domain.Feature;
using Exam1.Infrastructure;
using System.Web;

namespace Exam1.Web.Areas.Admin.Models
{
    public class ProductListModel
    {
        private ILifetimeScope _scope;
        private IProductManagementService _productManagementService;
        public ProductSearchModel SearchModel { get; set; }
        public ProductListModel() { }
        public ProductListModel(IProductManagementService productManagementService)
        {
            _productManagementService = productManagementService;
        }
        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _productManagementService = _scope.Resolve<IProductManagementService>();
        }

        public async Task<object> GetPagedProductsAsync(DataTablesAjaxRequestUtility dataTablesAjax)
        {
            var data = await _productManagementService.GetPageProductAsync(
                SearchModel.ProductName,
                SearchModel.ProductPriceFrom,
                SearchModel.ProductPriceTo,
                dataTablesAjax.GetSortText(new string[] { "Name", "Price", "Wight" }),
                dataTablesAjax.PageIndex,
                dataTablesAjax.PageSize);
            return new
            {
                recordsTotal = data.total,
                recordsFilterd = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                           HttpUtility.HtmlEncode(record.Name),
                           record.Price.ToString(),
                           record.Weight.ToString(),
                           record.Id.ToString(),
                        }).ToArray()
            };
        }
        public async Task DeleteProductAsync(Guid id)
        {
            await _productManagementService.DeleteProductAsync(id);
        }
    }
}
