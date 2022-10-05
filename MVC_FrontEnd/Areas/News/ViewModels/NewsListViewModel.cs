using MVC_FrontEnd.Areas.News.Models;
using MVC_FrontEnd.Services.Paginator;

namespace MVC_FrontEnd.Areas.News.ViewModels
{
    public class NewsListViewModel
    {
        public List<NewsSimpleModel> NewsSimple { get; set; }
        public PaginatorModel Paginator { get; set; }
    }
}
