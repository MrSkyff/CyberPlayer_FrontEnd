using MVC_Admin.Areas.Game.Models;
using MVC_Admin.Services.Paginator;

namespace MVC_Admin.Areas.Game.ViewModels
{
    public class GameListViewModel
    {
        public List<GameSimpleModel> Games { get; set; }
        public PaginatorModel Paginator { get; set; }
    }
}
