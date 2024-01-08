using Autofac;
using Exam1.Domain.Features;
using Exam1.Infrastructure;
using System.Web;

namespace Exam1.Web.Areas.Admin.Models
{
    public class ProductListModel
    {
        private ILifetimeScope _scope;
        private IProductManagementService _productManagementService;

        public ProductSearchModel SearchModel { get; set; }

        public ProductListModel()
        {
            
        }
        public ProductListModel(IProductManagementService productManagementService)
        {
            _productManagementService = productManagementService;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _productManagementService = _scope.Resolve<IProductManagementService>();
        }

        public async Task<object> GetPagedProductsAsync(DataTablesAjaxRequestUtility dataTablesUtility)
        {
            var data = await _productManagementService.GetPageProductAsync(
                SearchModel.Name,
                SearchModel.PriceFrom,
                SearchModel.PriceTo,
                dataTablesUtility.GetSortText(new string[] { "Name", "Price", "Weight" }),
                dataTablesUtility.PageIndex,
                dataTablesUtility.PageSize);

            return new
            {
                recorddsTotal = data.total,
                recordsFilterd = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            HttpUtility.HtmlEncode(record.Name),
                            record.Price.ToString(),
                            record.Weight.ToString(),
                            record.Id.ToString()
                        }
                       ).ToArray()
            };

        }

        internal async Task DeleteProductAsync(Guid id)
        {
            await _productManagementService.DeleteProductAsync(id);
        }
    }
}
