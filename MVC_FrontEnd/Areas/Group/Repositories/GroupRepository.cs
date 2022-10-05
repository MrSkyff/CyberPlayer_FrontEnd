using Grpc.Core;
using Grpc.Net.Client;
using MVC_FrontEnd.Areas.Group.Interfaces;
using MVC_FrontEnd.Areas.Group.Models;
using MVC_FrontEnd.Areas.Group.ViewModels;
using System.Text.Json;

namespace MVC_FrontEnd.Areas.Group.Repositories
{
    public class GroupRepository : IGroup
    {
        private readonly IConfiguration config; //config.GetSection("ServiceRouting").GetSection("GroupService").Value

        public GroupRepository(IConfiguration config)
        {
            this.config = config;
        }

    }
}
