using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using MVC_Admin.Areas.Game.Interfaces;
using MVC_Admin.Areas.Game.Models;
using MVC_Admin.Areas.Game.Protos;
using MVC_Admin.Areas.Game.ViewModels;
using MVC_Admin.Interfacies;
using MVC_Admin.Services.Paginator;
using MVC_Admin.Services.ProtoMapper;
using System.Globalization;
using System.Text.Json;

namespace MVC_Admin.Areas.Game.Repositories
{
    public class GameRepository : IGame
    {
        private readonly IConfiguration config;
        private readonly IImage imageRepository;
        private readonly Mapper mapper;

        public GameRepository(IConfiguration config, IImage imageRepository, Mapper mapper)
        {
            this.config = config;
            this.imageRepository = imageRepository;
            this.mapper = mapper;
        }

        public async Task<int> CreateGameAsync(GameModel model)
        {

            GameProto protoModel = new GameProto
            {
                Id = 0,
                Url = model.Url,
                Name = model.Name,
                Description = model.Description,
                ShortDescription = model.ShortDescription,
                BigLogo = "https://th.bing.com/th/id/R.f77b64a44eb89c7cbe80a0ef613a2838?rik=W2riMkIUkEmw7w&riu=http%3a%2f%2fi.imgur.com%2fhHdjkpC.png&ehk=ehX3rhfc5IQ%2bEXVXILFHbCLeUSrN31x0OTzkTj6ya%2b4%3d&risl=&pid=ImgRaw&r=0",
                SmallLogo = "https://th.bing.com/th/id/R.f77b64a44eb89c7cbe80a0ef613a2838?rik=W2riMkIUkEmw7w&riu=http%3a%2f%2fi.imgur.com%2fhHdjkpC.png&ehk=ehX3rhfc5IQ%2bEXVXILFHbCLeUSrN31x0OTzkTj6ya%2b4%3d&risl=&pid=ImgRaw&r=0",
                OwnerId = model.OwnerId,
                RealeseDate = model.RealeseDate.ToString()
            };

            int gameId = -1;
            try
            {
                using var channel = GrpcChannel.ForAddress(config.GetSection("ServiceRouting").GetSection("GameService").Value);
                var client = new Protos.Game.GameClient(channel);
                var result = await client.CreateGameAsync(new CreateGameRequest { Game = protoModel });

                gameId = result.GameId;

                return gameId;
            }
            catch (Exception)
            {
                model.Id = 0;
                return model.Id;
            }
        }

        public Task DeleteGameAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GameModel> GetGameByIdAsync(int id)
        {
            GameModel model = default;
            try
            {
                using var channel = GrpcChannel.ForAddress(config.GetSection("ServiceRouting").GetSection("GameService").Value);
                var client = new Protos.Game.GameClient(channel);
                var result = await client.GetGameByIdAsync(new GameByIdRequest { Id = id });

                GameModel gameModel = new GameModel
                {
                    Id = result.Game.Id,
                    Url = result.Game.Url,
                    Name = result.Game.Name,
                    Description = result.Game.Description,
                    ShortDescription = result.Game.ShortDescription,
                    BigLogo = result.Game.BigLogo,
                    SmallLogo = result.Game.SmallLogo,
                    OwnerId = result.Game.OwnerId,
                    RealeseDate = DateTime.ParseExact(result.Game.RealeseDate, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)
                };


                return gameModel;
            }
            catch (Exception)
            {
                model.Id = 0;
                return model;
            }
        }

        public async Task<GameListViewModel> GetGameListAsync(int currentPage, int pageSize, int pagesCountToShow)
        {
            // = = = = = = = = = MAP TO PROTO = = = = = = = = =
            GameListRequest gameListRequest = new GameListRequest();
            PaginatorGameProto paginatorProto = new PaginatorGameProto();
            paginatorProto.CurrentPage = currentPage;
            paginatorProto.PagesCountToShow = pagesCountToShow;
            paginatorProto.PageSize = pageSize;
            gameListRequest.Paginator = paginatorProto;

            // = = = = = = = = = GRPC SERVER REQUEST = = = = = = = = =
            using var channel = GrpcChannel.ForAddress(config.GetSection("ServiceRouting").GetSection("GameService").Value);
            var client = new MVC_Admin.Areas.Game.Protos.Game.GameClient(channel);
            var result = await client.GetGameListAsync(gameListRequest);

            // = = = = = = = = = MAP FROM PROTO = = = = = = = = =
            GameListViewModel model = new GameListViewModel();
            PaginatorModel paginator = new PaginatorModel();
            paginator.CurrentPage = result.Paginator.CurrentPage;
            paginator.PageList = result.Paginator.PageList.ToList();
            model.Paginator = paginator;
            model.Games = mapper.MapFromProto(new List<GameSimpleModel>(), result.Games.ToList());

            return model;
        }

        public async Task<GameModel> UpdateGameAsync(GameModel model)
        {

            if (model.BigLogoFile != null)
            {
                model.BigLogo = await imageRepository.LogoUploadAsync(model.BigLogoFile, model.Id, "big-logo", "games");
            }
            if (model.SmallLogoFile != null)
            {
                model.SmallLogo = await imageRepository.LogoUploadAsync(model.SmallLogoFile, model.Id, "small-logo", "games");
            }

            GameProto protoModel = new GameProto
            {
                Id = model.Id,
                Url = model.Url,
                Name = model.Name,
                Description = model.Description,
                ShortDescription = model.ShortDescription,
                BigLogo = model.BigLogo,
                SmallLogo = model.SmallLogo,
                OwnerId = model.OwnerId,
                RealeseDate = model.RealeseDate.ToString()
            };

            try
            {
                using var channel = GrpcChannel.ForAddress(config.GetSection("ServiceRouting").GetSection("GameService").Value);
                var client = new Protos.Game.GameClient(channel);
                var result = await client.UpdateGameAsync(new UpdateGameRequest { Game = protoModel });

                //Result is not used in this case. Designed for future features. Can be reworket to result give only ID to reverse.
                GameModel gameModel = new GameModel
                {
                    Id = result.Game.Id,
                    Url = result.Game.Url,
                    Name = result.Game.Name,
                    Description = result.Game.Description,
                    ShortDescription = result.Game.ShortDescription,
                    BigLogo = result.Game.BigLogo,
                    SmallLogo = result.Game.SmallLogo,
                    OwnerId = result.Game.OwnerId,
                    RealeseDate = DateTime.ParseExact(result.Game.RealeseDate, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)
                };


                return gameModel;
            }
            catch (Exception)
            {
                model.Id = 0;
                return model;
            }

            return model;
        }

    }
}
