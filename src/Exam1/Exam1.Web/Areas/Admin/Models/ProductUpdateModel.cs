using Autofac;
using Exam1.Domain.Entity;
using Exam1.Domain.Feature;

namespace Exam1.Web.Areas.Admin.Models
{
    public class ProductUpdateModel
    {
        /* [Required]
         public Guid Id { get; set; }
         [Required]
         public string Name { get; set; }

         public uint Price { get; set; }

         public double Weight { get; set; }*/

        public Product productM { get; set; }

        private IProductManagementService _productManagementService;
        public ProductUpdateModel()
        {

        }
        public ProductUpdateModel(IProductManagementService productManagementService)
        {
            _productManagementService = productManagementService;
        }
        public void Resolve(ILifetimeScope scope)
        {
            _productManagementService = scope.Resolve<IProductManagementService>();
        }
        public async Task LoadAsync(Guid id)
        {
            Product newProduct = await _productManagementService.GetProductAsync(id);
            if (newProduct != null)
            {
                productM = newProduct;
            }
        }

        public async Task UpdateProductAsync()
        {
            if (!string.IsNullOrEmpty(productM.Name) && productM.Price >= 0)
            {
                await _productManagementService.UpdateProductAsync(productM);
            }
        }
    }
}
