using FirstDemo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;

        public HomeController(ILogger<HomeController> logger, IEmailSender emailSender, ISmsSender smsSender)
        {
            _logger = logger;
            _emailSender = emailSender;
            _smsSender = smsSender;
        }

        public IActionResult Index()
        {
            var user = new UserClass() {
                Id = 1,
                Name = "John Doe",
                Email = "johndoe@example.com",
                Password = "password123",
                Phone = "1234567890"
            };
            var k = user.Sum(71 , 2);
            _logger.LogInformation("I am in index");
            return View(user);
        }

        public IActionResult Test()
        {
            TestModel model = new TestModel();
            model.Email = "jalal@email.com";
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Test(TestModel model)
        {
            if (ModelState.IsValid)
            {
                // code to write in future
                int x = 5;
            }
            return View(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }
        public ActionResult UserData() 
        {
            var user = new UserClass()
            {
                Id = 1,
                Name = "John Doe",
                Email = "johndoe@example.com",
                Password = "password123",
                Phone = "1234567890"
            };
            var k = user.Sum(71, 2);
            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}