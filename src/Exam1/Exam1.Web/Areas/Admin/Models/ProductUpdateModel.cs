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

        private IProductManagementServices _poductManagementServices;
        private IMapper _mapper;

        public ProductUpdateModel()
        {

        }
        public ProductUpdateModel(IProductManagementServices productManagementServices, IMapper mapper)
        {
            _mapper = mapper;
            _poductManagementServices = productManagementServices;
        }
        internal void Resolve(ILifetimeScope scope)
        {
            _poductManagementServices = scope.Resolve<IProductManagementServices>();
            _mapper = scope.Resolve<IMapper>();
        }

        internal async Task LoadAsync(Guid id)
        {
            Product product = await _poductManagementServices.GetProductAsync(id);
            if (product != null)
            {
                _mapper.Map(product, this);
            }
        }

        internal async Task UpdateProductAsync()
        {
            if (!string.IsNullOrWhiteSpace(Name) && Price >= 0)
            {
                await _poductManagementServices.UpdateProductAsync(Id, Name, Price, Weight);
            }
        }
    }
}
