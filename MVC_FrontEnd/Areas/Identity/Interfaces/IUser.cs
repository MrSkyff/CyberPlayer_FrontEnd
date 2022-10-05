using MVC_FrontEnd.Areas.Identity.Models;
using MVC_FrontEnd.Areas.Identity.ViewModels;
using System.Security.Claims;

namespace MVC_FrontEnd.Areas.Identity.Interfaces
{
    public interface IUser
    {
        Task<UserModel> GetUserById();
        Task<ClaimsPrincipal> GetClaimsAsync(LoginViewModel loginViewModel);
        IEnumerable<RoleModel> GetUserRoles(int id);
    }
}
