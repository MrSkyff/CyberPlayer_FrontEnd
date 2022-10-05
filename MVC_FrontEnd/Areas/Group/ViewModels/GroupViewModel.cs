using MVC_FrontEnd.Areas.Game.Models;
using MVC_FrontEnd.Areas.Group.Models;

namespace MVC_FrontEnd.Areas.Group.ViewModels
{
    public class GroupViewModel
    {
        public GroupModel Group { get; set; } 
        public IEnumerable<GameModel> Games { get; set; }
    }
}
