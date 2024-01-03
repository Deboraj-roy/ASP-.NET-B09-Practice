using Exam1.Domain.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Application.Features
{
    public class ProductManagementServices : IProductManagementServices
    {
        private readonly IApplicationUnitofWork _unitofWork;
        public ProductManagementServices(IApplicationUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
    }
}
