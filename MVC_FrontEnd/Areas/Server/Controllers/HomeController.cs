using Microsoft.AspNetCore.Mvc;

namespace MVC_FrontEnd.Areas.Server.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
