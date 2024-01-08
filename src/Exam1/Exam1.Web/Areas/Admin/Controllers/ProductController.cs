using Autofac;
using Exam1.Web.Areas.Admin.Models;
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
            _scope = scope;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var model = _scope.Resolve<ProductCreateModel>();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Resolve(_scope);
                    await model.CreateProductAsync();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Server Error");
                }
            }

            return View(model);
        }
    }
}
