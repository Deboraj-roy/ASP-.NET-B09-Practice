using DemoServerAWS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoServerAWS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(ViewBag);
        }

        public IActionResult Privacy()
        {
            // Get the server's IP address
            ViewBag.IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
