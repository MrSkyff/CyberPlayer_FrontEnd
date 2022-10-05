using Grpc.Net.Client;
using System.Configuration;
using System.Text.Json;
using NuGet.Protocol;
using System;
using Google.Protobuf.WellKnownTypes;
using MVC_Admin.Areas.News.Interfaces;
using MVC_Admin.Areas.News.Models;
using MVC_Admin.Protos.News;
using MVC_Admin.Areas.News.ViewModels;

namespace MVC_Admin.Areas.News.Repositories
{

    public class NewsRepository : INews
    {
        private readonly IConfiguration config;

        public NewsRepository(IConfiguration config)
        {
            this.config = config;
        }

        public async Task<NewsModel> AddNews(NewsModel model)
        {
            NewsProto protoModel = new NewsProto
            {
                Id = model.Id,
                Title = model.Title,
                Text = model.Text,
                ShortText = model.ShortText,
                BigLogo = model.BigLogo,
                SmallLogo = model.SmallLogo,
                AuthorId = model.AuthorId,
                //PostDate = model.PostDate.ToTimestamp(),
                NewsType = model.NewsType
            };

            try
            {
                using var channel = GrpcChannel.ForAddress(config.GetSection("ServiceRouting").GetSection("NewsService").Value);
                var client = new NewsToNews.NewsToNewsClient(channel);
                var result = await client.CreateNewsAsync(
                    new NewsCreateRequest { News = protoModel });
                model = JsonSerializer.Deserialize<NewsModel>(result.News.ToString(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
                return model;
            }
            catch (Exception)
            {
                model.Id = 0;
                return model;
            }
        }

        public async Task<NewsModel> UpdateNews(NewsModel model)
        {
            NewsProto protoModel = new NewsProto
            {
                Id = model.Id,
                Title = model.Title,
                Text = model.Text,
                ShortText = model.ShortText,
                BigLogo = model.BigLogo,
                SmallLogo = model.SmallLogo,
                AuthorId = model.AuthorId,
                //PostDate = model.PostDate.ToTimestamp(),
                NewsType = model.NewsType
            };

            try
            {
                using var channel = GrpcChannel.ForAddress(config.GetSection("ServiceRouting").GetSection("NewsService").Value);
                var client = new NewsToNews.NewsToNewsClient(channel);
                var result = await client.UpdateNewsAsync(new NewsUpdateRequest { News = protoModel });
                model = JsonSerializer.Deserialize<NewsModel>(result.News.ToString(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
                return model;
            }
            catch (Exception)
            {
                model.Id = 0;
                return model;
            }
        }

        public Task DeleteNews(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<NewsModel> GetNewsById(int id)
        {
            NewsModel model = default;
            try
            {
                using var channel = GrpcChannel.ForAddress(config.GetSection("ServiceRouting").GetSection("NewsService").Value);
                var client = new NewsToNews.NewsToNewsClient(channel);
                var result = await client.GetNewsByIdAsync(new NewsByIdRequest { Id = id });
                model = JsonSerializer.Deserialize<NewsModel>(result.News.ToString(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
                return model;
            }
            catch (Exception)
            {
                model.Id = 0;
                return model;
            }
        }

        public async Task<List<NewsSimpleViewModel>> GetNewsList()
        {
            List<NewsSimpleViewModel> newsList = default;
            try
            {
                using var channel = GrpcChannel.ForAddress(config.GetSection("ServiceRouting").GetSection("NewsService").Value);
                var client = new NewsToNews.NewsToNewsClient(channel);
                var result = await client.GetNewsListAsync(new NewsListRequest());
                newsList = JsonSerializer.Deserialize<List<NewsSimpleViewModel>>(result.NewsList.ToString(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
                return newsList;
            }
            catch (Exception)
            {
                newsList.Add(new NewsSimpleViewModel { Id = 0 });
                return newsList;
            }
        }
    }
}
