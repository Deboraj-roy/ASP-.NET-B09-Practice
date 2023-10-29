using Microsoft.AspNetCore.Mvc;

namespace FirstDemo.Web.Areas.Coustomer.Controllers
{
    [Area("Customer")]
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
