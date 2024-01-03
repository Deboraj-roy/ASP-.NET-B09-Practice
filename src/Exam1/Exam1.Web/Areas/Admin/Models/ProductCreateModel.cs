using Autofac;
using Exam1.Domain.Entities;
using Exam1.Domain.Features;

namespace Exam1.Web.Areas.Admin.Models
{
    public class ProductCreateModel
    {
        private ILifetimeScope _scope;
        private IProductManagementServices _productManagementServices;
        public string Name { get; set; }
        public uint Price { get; set; }
        public double Weight { get; set; }
        // public Product product {  get; set; } 
        public ProductCreateModel()
        {

        }
        public ProductCreateModel(IProductManagementServices productManagementServices)
        {
            _productManagementServices = productManagementServices;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _productManagementServices = _scope.Resolve<IProductManagementServices>();
        }

        internal async Task CreateCourseAsync()
        {
            await _productManagementServices.CreateProductAsync( Name, Price, Weight);
        }

    }
}
