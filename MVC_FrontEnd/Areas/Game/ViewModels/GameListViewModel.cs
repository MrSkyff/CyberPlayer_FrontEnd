using MVC_FrontEnd.Areas.Game.Models;
using MVC_FrontEnd.Areas.Group.Models;

namespace MVC_FrontEnd.Areas.Game.ViewModels
{
    public class GameListViewModel
    {
        public List<GameSimpleModel> Games { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<int> PagesToShow { get; set; }
    }
}
