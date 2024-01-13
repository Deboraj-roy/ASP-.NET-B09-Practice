using Autofac;
using Exam1.Domain.Entity;
using Exam1.Domain.Feature;

namespace Exam1.Web.Areas.Admin.Models
{
    public class ProductCreateModel
    {
        private ILifetimeScope _scope;
        private IProductManagementService _productManagementService;
        //public Product pp {  get; set; }
        public string ProductName { get; set; }
        public uint ProductPrice { get; set; }
        public double ProductWeight { get; set; }

        public ProductCreateModel()
        {
            
        }
        public ProductCreateModel(IProductManagementService productManagementService)
        { 
            _productManagementService = productManagementService;
        }
        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _productManagementService = _scope.Resolve<IProductManagementService>();
        }
        public async Task CtrateProductAsync()
        {
            await _productManagementService.CreateProductAsync(ProductName, ProductPrice, ProductWeight);
        }
    }
}
