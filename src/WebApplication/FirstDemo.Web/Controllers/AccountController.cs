using Autofac;
using Azure;
using FirstDemo.Infrastructure.Membership;
using FirstDemo.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FirstDemo.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<AccountController> _logger;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountController(ILifetimeScope scope,
            ILogger<AccountController> logger, RoleManager<ApplicationRole> roleManager)
        {
            _scope = scope;
            _logger = logger;
            _roleManager = roleManager;
        }

        public IActionResult Register()
        {
            var model = _scope.Resolve<RegistrationModel>();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrationModel model)
        {

            if (ModelState.IsValid)
            {
                model.Resolve(_scope);
                var response = await model.RegisterAsync(Url.Content("~/"));
            
                if (response.errors is not null)
                {
                    foreach (var error in response.errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(model);
                }
                else
                    return Redirect(response.redirectLocation);
            }
            return View(model);

           
        }
 
        public async Task<IActionResult> CreateRoles()
        {
            //await _roleManager.CreateAsync(new ApplicationRole { Name = "Admin"});
            //await _roleManager.CreateAsync(new ApplicationRole { Name = "User" });
            //await _roleManager.CreateAsync(new ApplicationRole { Name = "Employee" });
            //await _roleManager.CreateAsync(new ApplicationRole { Name = "Supervisor" });
            await _roleManager.CreateAsync(new ApplicationRole { Name = UserRoles.Admin });
            await _roleManager.CreateAsync(new ApplicationRole { Name = UserRoles.User });
            await _roleManager.CreateAsync(new ApplicationRole { Name = UserRoles.Employee });
            await _roleManager.CreateAsync(new ApplicationRole { Name = UserRoles.Supervisor });

            return View();
        }
    }
}
