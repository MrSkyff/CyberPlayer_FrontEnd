namespace MVC_Admin.Areas.News.Models
{
    public class NewsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ShortText { get; set; }
        public string BigLogo { get; set; }
        public string SmallLogo { get; set; }
        public int AuthorId { get; set; }
        public DateTime PostDate { get; set; }
        public int NewsType { get; set; }
    }
}
