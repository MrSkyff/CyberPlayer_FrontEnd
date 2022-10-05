using Microsoft.AspNetCore.Mvc;

namespace MVC_Admin.Areas.Game.Controllers
{
    public class CrudController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
