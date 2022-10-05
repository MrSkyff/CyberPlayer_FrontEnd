using MVC_FrontEnd.Areas.Game.Models;
using MVC_FrontEnd.Areas.Game.ViewModels;
using MVC_FrontEnd.Areas.Group.Models;
using MVC_FrontEnd.Areas.Server.Models;

namespace MVC_FrontEnd.Areas.Game.Interfaces
{
    public interface IGame
    {
        Task<GameListViewModel> GetGameListAsync(int pageNumber, int pageSize);
        Task<GameModel> GetGameByIdAsync(int id);     
    }
}
