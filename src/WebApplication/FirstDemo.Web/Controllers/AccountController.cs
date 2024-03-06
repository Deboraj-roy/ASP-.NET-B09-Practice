using Autofac;
using Azure;
using FirstDemo.Infrastructure.Membership;
using FirstDemo.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace FirstDemo.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<AccountController> _logger;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(ILifetimeScope scope,
            ILogger<AccountController> logger, RoleManager<ApplicationRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _scope = scope;
            _logger = logger;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userManager = userManager;
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
                var baseUrl = $"{Request.Scheme}://{Request.Host}";

                // If you need to include the port number in the URL
                // var baseUrl = $"{Request.Scheme}://{Request.Host.Value}";

                var response = await model.RegisterAsync(Url.Content(baseUrl));
            
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

        public async Task<IActionResult> LoginAsync(string returnUrl = null)
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}";
            //returnUrl ??= Url.Content("~/");
            //returnUrl ??= baseUrl;
            returnUrl ??= baseUrl;

            var model = _scope.Resolve<LoginModel>();

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            model.ReturnUrl = returnUrl;
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(LoginModel model)
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}";
            //model.ReturnUrl ??= Url.Content("~/");

            model.ReturnUrl ??= baseUrl;

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return LocalRedirect(model.ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }

            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> LogoutAsync(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string code, string returnUrl)
        {
            if (userId == null || code == null)
            {
                // Handle invalid parameters
                return BadRequest("User Id or code is missing.");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                // Handle user not found
                return NotFound("User not found.");
            }

            // Decode the code
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            // Confirm the user's email
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                // Email confirmed successfully
                // Redirect to the specified returnUrl or a default page
                return Redirect(returnUrl ?? "/"); // You may adjust the default page as needed
            }
            else
            {
                // Failed to confirm email
                // You may handle the failure appropriately, such as showing an error message
                return BadRequest("Failed to confirm email.");
            }
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
