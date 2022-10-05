using MVC_Admin.Areas.News.Models;
using MVC_Admin.Areas.News.ViewModels;

namespace MVC_Admin.Areas.News.Interfaces
{
    public interface INews
    {
        Task<List<NewsSimpleViewModel>> GetNewsList();
        Task<NewsModel> GetNewsById(int id);
        Task<NewsModel> AddNews(NewsModel model);
        Task<NewsModel> UpdateNews(NewsModel model);
        Task DeleteNews(int id);
    }
}
