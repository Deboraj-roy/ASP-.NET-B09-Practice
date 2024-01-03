using Autofac;
using Exam1.Domain.Features;
using Exam1.Infrastructure;
using System.Web;

namespace Exam1.Web.Areas.Admin.Models
{
    public class ProductListModel
    {
        private ILifetimeScope _scope;
        private IProductManagementServices _productManagementServices;

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

        /*
                public async Task<object> GetPagedCoursesAsync(DataTablesAjaxRequestUtility dataTablesUtility)
                {
                    var data = await _courseManagementService.GetPagedCoursesAsync(
                        dataTablesUtility.PageIndex,
                        dataTablesUtility.PageSize,
                        SearchItem.Title,
                        SearchItem.CourseFeesFrom,
                        SearchItem.CourseFeesTo,
                        dataTablesUtility.GetSortText(new string[] { "Title", "Description", "Fees" }));

                    return new
                    {
                        recordsTotal = data.total,
                        recordsFiltered = data.totalDisplay,
                        data = (from record in data.records
                                select new string[]
                                {
                                        HttpUtility.HtmlEncode(record.Title),
                                        HttpUtility.HtmlEncode(record.Description),
                                        record.Fees.ToString(),
                                        record.Id.ToString()
                                }
                            ).ToArray()
                    };
                }
        */

        internal async Task DeleteProductAsync(Guid id)
        {
            await _productManagementServices.DeleteProductAsync(id);
        }
    }
}
