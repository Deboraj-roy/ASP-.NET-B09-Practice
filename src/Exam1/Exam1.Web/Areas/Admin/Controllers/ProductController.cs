using Autofac;
using Exam1.Domain.Exceptions;
using Exam1.Infrastructure;
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
            _logger = logger;
            _scope = scope;
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
                    await model.CreateCourseAsync();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Server Error Create Course");
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<JsonResult> GetCourses(ProductListModel model)
        {
            var dataTablesModel = new DataTablesAjaxRequestUtility(Request);
            model.Resolve(_scope);

            var data = await model.GetPagedCoursesAsync(dataTablesModel);
            return Json(data);
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var model = _scope.Resolve<ProductUpdateModel>();
            await model.LoadAsync(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProductUpdateModel model)
        {
            model.Resolve(_scope);

            if (ModelState.IsValid)
            {
                try
                {
                    await model.UpdateProductAsync();
                    return RedirectToAction("Index");
                } 
                catch (Exception e)
                {
                    _logger.LogError(e, "Server Error");
 
                }
            }

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = _scope.Resolve<ProductListModel>();

            if (ModelState.IsValid)
            {
                try
                {
                    await model.DeleteProductAsync(id);  
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Server Error");
 
                }
            }

            return RedirectToAction("Index");
        }

    }
}
