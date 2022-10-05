using Microsoft.AspNetCore.Mvc;
using MVC_FrontEnd.Areas.Game.Interfaces;
using MVC_FrontEnd.Areas.Group.Models;

namespace MVC_FrontEnd.ViewComponents.Group
{
    public class GroupListViewComponent : ViewComponent
    {
        private readonly IGame gameRepository;

        public GroupListViewComponent(IGame gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int gameId)
        {

            return View();
        }




    }
}
