using MVC_FrontEnd.Areas.Group.Models;
using MVC_FrontEnd.Areas.News.Models;
using MVC_FrontEnd.Areas.News.ViewModels;
using MVC_FrontEnd.Services.Paginator;

namespace MVC_FrontEnd.Areas.News.Interfaces
{
    public interface INews
    {
        Task<List<NewsSimpleModel>> GetNewsListByGameAsync(int id);
        Task<NewsListViewModel> GetNewsListAsync(PaginatorModel paginator);
        Task<NewsModel> GetNewsByIdAsync(int id);
    }
}
