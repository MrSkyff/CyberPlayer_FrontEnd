using Microsoft.AspNetCore.Mvc;
using MVC_FrontEnd.Areas.News.Interfaces;
using MVC_FrontEnd.Areas.News.Models;

namespace MVC_FrontEnd.ViewComponents.News
{
    public class NewsListViewComponent : ViewComponent
    {
        private readonly INews newsRepository;

        public NewsListViewComponent(INews newsRepository)
        {
            this.newsRepository = newsRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return View(await newsRepository.GetNewsListByGameAsync(id));
        }

    }
}
