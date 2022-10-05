using Grpc.Net.Client;
using MVC_FrontEnd.Areas.Identity.Interfaces;
using MVC_FrontEnd.Areas.Identity.Models;
using MVC_FrontEnd.Areas.Identity.ViewModels;
using System.Security.Claims;
using System.Text.Json;

namespace MVC_FrontEnd.Areas.Identity.Repositories
{
    public class UserRepository : IUser
    {
        private readonly IConfiguration config; //config.GetSection("ServiceRouting").GetSection("IdentityService").Value

        public UserRepository(IConfiguration config)
        {
            this.config = config;
        }

        public async Task<ClaimsPrincipal> GetClaimsAsync(LoginViewModel loginViewModel)
        {
            //UserModel user = new UserModel();
            
            //try
            //{           
            //    using var channel = GrpcChannel.ForAddress(config.GetSection("ServiceRouting").GetSection("IdentityService").Value);
            //    var client = new MVC_FrontEnd.Identity.IdentityClient(channel);
            //    var results = await client.LoginAsync(new LoginViewProto { Email = loginViewModel.Email });
            //    user = JsonSerializer.Deserialize<UserModel>(results.ToString(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
            //}
            //catch (Exception)
            //{
            //    user = null!; 
            //}

            //if (user != null)
            //{
            //    var claims = new List<Claim>
            //        {
            //            new Claim("Id", user.Id.ToString()),
            //            new Claim("FullName", user.FirstName + " " + user.LastName),
            //        };

            //    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "CP_Cookies");
            //    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            //    return claimsPrincipal;
            //}

            return null!;
        }

        public Task<UserModel> GetUserById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoleModel> GetUserRoles(int id)
        {
            throw new NotImplementedException();
        }

    }
}
