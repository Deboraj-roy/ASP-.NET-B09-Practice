using Microsoft.AspNetCore.Mvc;

namespace Presentations.Web.Controllers
{
    public class AdminController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
