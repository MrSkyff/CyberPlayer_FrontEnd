using Microsoft.AspNetCore.Mvc;

namespace MVC_FrontEnd.ViewComponents
{
    public class LeftSideBar : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
