using Microsoft.AspNetCore.Mvc;
using MVC_FrontEnd.Areas.Game.Interfaces;
using MVC_FrontEnd.Areas.Server.Models;

namespace MVC_FrontEnd.ViewComponents.Server
{
    public class ServerListViewComponent : ViewComponent
    {
        private readonly IGame gameRepository;

        public ServerListViewComponent(IGame gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int gameId)
        {
            
            return View();
        }
    }
}
