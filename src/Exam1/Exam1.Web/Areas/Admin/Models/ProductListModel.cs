using Autofac;
using Exam1.Domain.Features;
using Exam1.Infrastructure;
using System.Drawing.Printing;
using System.Globalization;
using System.Web;

namespace Exam1.Web.Areas.Admin.Models
{
    public class ProductListModel
    {
        private ILifetimeScope _scope;
        private IProductManagementServices _productManagementServices;

        public ProductSearchModel SearchModel { get; set; }

        public ProductListModel()
        {

        }
        public ProductListModel(IProductManagementServices productManagementServices)
        {
            _productManagementServices = productManagementServices;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _productManagementServices = _scope.Resolve<IProductManagementServices>();
        }


        public async Task<object> GetPagedProductsAsync(DataTablesAjaxRequestUtility dataTablesUtility)
        {
            var data = await _productManagementServices.GetPagedProductAsync(
                SearchModel.Name,
                SearchModel.PriceFrom,
                SearchModel.PriceTo,
                dataTablesUtility.GetSortText(new string[] { "Name", "Price", "Wight" }),
                dataTablesUtility.PageIndex,
                dataTablesUtility.PageSize);

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
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
            await _productManagementServices.DeleteProductAsync(id);
        }
    }
}
