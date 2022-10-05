using Microsoft.AspNetCore.Mvc;
using MVC_Admin.Areas.Game.Interfaces;
using MVC_Admin.Areas.Game.Models;

namespace MVC_Admin.Areas.Game.Controllers
{
    [Area("Game")]
    public class HomeController : Controller
    {
        private readonly IGame gameRepository;

        public HomeController(IGame gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public async Task<IActionResult> Index(int currentPage = 1, int pageSize = 8, int pagesCountToShow = 6)
        {
            return View(await gameRepository.GetGameListAsync(currentPage, pageSize, pagesCountToShow));
        }

        public async Task<IActionResult> GameView(int id)
        {
            return View(await gameRepository.GetGameByIdAsync(id));
        }

        public async Task<IActionResult> GameList()
        {
            return View(); 
        }

        [HttpGet]
        public IActionResult CreateGame()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGame(GameModel model)
        {
            int result = await gameRepository.CreateGameAsync(model);
            return RedirectToAction("UpdateGame", new { id = result });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateGame(int id)
        {
            return View(await gameRepository.GetGameByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGame(GameModel model)
        {
            await gameRepository.UpdateGameAsync(model);
            return RedirectToAction("UpdateGame", model.Id);
        }
    }
}
