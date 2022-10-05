namespace MVC_FrontEnd.Areas.News.Models
{
    public class NewsSimpleModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortText { get; set; }
        public int AuthorId { get; set; }
        public DateTime PostDate { get; set; }
        public int NewsType { get; set; }
        public int GameId { get; set; }
    }
}
