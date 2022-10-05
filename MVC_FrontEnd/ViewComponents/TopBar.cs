using Microsoft.AspNetCore.Mvc;

namespace MVC_FrontEnd.ViewComponents
{
    public class TopBar : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
