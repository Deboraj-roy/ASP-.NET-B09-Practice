using Autofac;
using Microsoft.AspNetCore.Mvc;

namespace Exam1.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<ProductController> _logger;


        public ProductController(ILifetimeScope scope, ILogger<ProductController> logger)
        { 
            _logger = logger;
            _scope = scope;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
