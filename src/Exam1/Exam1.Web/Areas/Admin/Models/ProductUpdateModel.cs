using Autofac;
using AutoMapper;
using Exam1.Domain.Entities;
using Exam1.Domain.Features;
using System.ComponentModel.DataAnnotations;

namespace Exam1.Web.Areas.Admin.Models
{
    public class ProductUpdateModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public uint Price { get; set; }
        public double Weight { get; set; }

        private IProductManagementService _productManagementService;
        private IMapper _mapper;
        public ProductUpdateModel()
        {
            
        }

        public ProductUpdateModel(IProductManagementService productManagementService, IMapper mapper)
        {
            _productManagementService = productManagementService;
            _mapper = mapper;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _productManagementService = scope.Resolve<IProductManagementService>();
            _mapper = scope.Resolve<IMapper>();
        }
        public async Task LoadAsync(Guid id)
        {
            Product product = await _productManagementService.GetProductAsync(id);
            if (product != null)
            {
                _mapper.Map(product, this);
            }
        }

        public async Task UpdateProductAsync()
        {
            if(!string.IsNullOrEmpty(Name) && Price >= 0 )
            { 
                await _productManagementService.UpdateProductAsync(Id, Name, Price, Weight);
            }
        }
    }
}
