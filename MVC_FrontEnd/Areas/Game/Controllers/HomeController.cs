using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using MVC_FrontEnd.Areas.Game.Interfaces;
using MVC_FrontEnd.Areas.Game.Models;
using MVC_FrontEnd.Areas.Game.ViewModels;
using MVC_FrontEnd.Areas.Group.Interfaces;
using MVC_FrontEnd.Areas.Group.Models;
using System.Collections.Generic;

namespace MVC_FrontEnd.Areas.Game.Controllers
{
    [Area("Game")]
    public class HomeController : Controller
    {
        private readonly IGame gamesRepository;

        public HomeController(IGame gamesRepository, IGroup groupRepository)
        {
            this.gamesRepository = gamesRepository;
        }

        [Route("Games")]
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 24)
        {
            var model = await gamesRepository.GetGameListAsync(pageNumber, pageSize);
            model.CurrentPage = pageNumber;
            model.PageSize = pageSize;
            return View(model);
        }

        [Route("Game/{id?}")]
        public async Task<IActionResult> Game(int id)
        {
            var model = await gamesRepository.GetGameByIdAsync(id);
            return View(model);
        }
    }
}
