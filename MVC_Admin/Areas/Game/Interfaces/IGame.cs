using MVC_Admin.Areas.Game.Models;
using MVC_Admin.Areas.Game.ViewModels;

namespace MVC_Admin.Areas.Game.Interfaces
{
    public interface IGame
    {
        Task<GameListViewModel> GetGameListAsync(int currentPage, int pageSize, int pagesCountToShow);
        Task<GameModel> GetGameByIdAsync(int id);
        Task<int> CreateGameAsync(GameModel model);
        Task<GameModel> UpdateGameAsync(GameModel model);
        Task DeleteGameAsync(int id);
    }
}
