using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using MVC_FrontEnd.Areas.News.Interfaces;
using MVC_FrontEnd.Services.Paginator;

namespace MVC_FrontEnd.Areas.News.Controllers
{
    [Area("News")]
    public class HomeController : Controller
    {
        private readonly IConfiguration config; //config.GetSection("ServiceRouting").GetSection("NewsService").Value
        private readonly INews newsRepository;

        public HomeController(IConfiguration config, INews newsRepository)
        {
            this.config = config;
            this.newsRepository = newsRepository;
        }

        public async Task<IActionResult> Index(int currentPage = 1, int pageSize = 8)
        {
            PaginatorModel paginator = new PaginatorModel();
            paginator.CurrentPage = currentPage;
            paginator.PageSize = pageSize;
            paginator.PagesCountToShow = 6;

            var model = await newsRepository.GetNewsListAsync(paginator);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Read(int id)
        {
            return View(await newsRepository.GetNewsByIdAsync(id));
        }
    }
}
