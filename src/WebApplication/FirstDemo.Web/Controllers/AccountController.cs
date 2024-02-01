using Autofac;
using FirstDemo.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstDemo.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<AccountController> _logger;
        public AccountController(ILifetimeScope scope, ILogger<AccountController> logger)
        {
            _scope = scope;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            var model = _scope.Resolve<RegistrationModel>();
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrationModel model)
        {
            IList<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                model.Resolve(_scope);
                await model.Register();
            }

            if (errors.Count > 0)
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }

            return View(model);
        }
    }
}
