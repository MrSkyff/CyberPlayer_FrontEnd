using Grpc.Net.Client;
using MVC_FrontEnd.Areas.Game.Interfaces;
using MVC_FrontEnd.Areas.Game.ViewModels;
using System.Text.Json;
using MVC_FrontEnd.Areas.Game.Models;
using MVC_FrontEnd.Areas.Group.Models;
using MVC_FrontEnd.Areas.Server.Models;
using Grpc.Core;
using MVC_FrontEnd.Areas.Game.Protos;
using MVC_FrontEnd.Services.Mapper;
using System.Collections.Generic;

namespace MVC_FrontEnd.Areas.Game.Repositories
{

    public class GameRepository : IGame
    {
        private readonly IConfiguration config;
        private readonly Mapper mapper;

        public GameRepository(IConfiguration config, Mapper mapper)
        {
            this.config = config;
            this.mapper = mapper;
        }
       
        public async Task<GameListViewModel> GetGameListAsync(int pageNumber, int pageSize)
        {
            GameListViewModel games = new GameListViewModel();
            try
            {
                using var channel = GrpcChannel.ForAddress(config.GetSection("ServiceRouting").GetSection("GameService").Value);
                var client = new GameToGame.GameToGameClient(channel);
                var result = await client.GetGameListAsync(new GameListRequest() { PageNumber = pageNumber, PageSize = pageSize });

                games.Games = mapper.MapFromProto(new List<GameSimpleModel>(), result.Games.ToList());
                games.PagesToShow = result.PagesToShow.ToList();
                return games;
            }
            catch (RpcException x)
            {
                return null;
            }
        }

        public async Task<GameModel> GetGameByIdAsync(int id)
        {
            using var channel = GrpcChannel.ForAddress(config.GetSection("ServiceRouting").GetSection("GameService").Value);
            var client = new GameToGame.GameToGameClient(channel);
            var result = await client.GetGameByIdAsync(new GameByIdRequest { Id = id });

            var model = mapper.MapFromProto(new GameModel(), result.Game);

            return model;
        }
    }
}
