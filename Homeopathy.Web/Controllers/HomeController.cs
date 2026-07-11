using Microsoft.AspNetCore.Mvc;

namespace Homeopathy.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
