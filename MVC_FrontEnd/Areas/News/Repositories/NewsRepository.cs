using Grpc.Net.Client;
using MVC_FrontEnd.Areas.Group.Models;
using MVC_FrontEnd.Areas.News.Interfaces;
using MVC_FrontEnd.Areas.News.Models;
using MVC_FrontEnd.Areas.News.Protos;
using MVC_FrontEnd.Areas.News.ViewModels;
using MVC_FrontEnd.Services.Mapper;
using MVC_FrontEnd.Services.Paginator;
using System.Diagnostics;
using System.Text.Json;

namespace MVC_FrontEnd.Areas.News.Repositories
{
    public class NewsRepository : INews 
    {
        private readonly IConfiguration config;
        private readonly Mapper mapper;

        public NewsRepository(IConfiguration config, Mapper mapper)
        {
            this.config = config;
            this.mapper = mapper;
        }

        public async Task<NewsListViewModel> GetNewsListAsync(PaginatorModel paginator)
        {
            using var channel = GrpcChannel.ForAddress(config.GetSection("ServiceRouting").GetSection("NewsService").Value);
            var client = new News.Protos.News.NewsClient(channel);
            var result = await client.GetNewsListAsync(
                new NewsListRequest { PagedNews = mapper.MapToProto(new PaginatorNewsProto(), paginator) }
                );

            NewsListViewModel model = new NewsListViewModel();
            model.NewsSimple = mapper.MapFromProto(new List<NewsSimpleModel>(), result.NewsList.ToList());

            List<int> pageList = new List<int>();
            foreach (var item in result.PagedNews.PageList)
            {
                pageList.Add(item);
            }
            paginator.PageList = pageList;
            model.Paginator = paginator;

            return model;
        }

        public async Task<List<NewsSimpleModel>> GetNewsListByGameAsync(int id)
        {

            List<NewsSimpleModel> model = new List<NewsSimpleModel>();
            try
            {
                using var channel = GrpcChannel.ForAddress(config.GetSection("ServiceRouting").GetSection("NewsService").Value);
                var client = new News.Protos.News.NewsClient(channel);
                var result = await client.GetNewsByGameAsync(new NewsListByGameRequest { Id = id });

                model = mapper.MapFromProto(new List<NewsSimpleModel>(), result.NewsList.ToList());
            }
            catch (Exception)
            {
                model.Add(new NewsSimpleModel { Id = 0 });
            }
            return model;
        }

        public async Task<NewsModel> GetNewsByIdAsync(int id)
        {
            using var channel = GrpcChannel.ForAddress(config.GetSection("ServiceRouting").GetSection("NewsService").Value);
            var client = new News.Protos.News.NewsClient(channel);
            var result = await client.GetNewsByIdAsync(new NewsByIdRequest { Id = id });

            return mapper.MapFromProto(new NewsModel(), result.News);
        }
    }
}
