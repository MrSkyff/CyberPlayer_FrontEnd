using Microsoft.AspNetCore.Mvc;

namespace MVC_Admin.Areas.News.Controllers
{
    public class HomeController : Controller
    {
        [Area("News")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
