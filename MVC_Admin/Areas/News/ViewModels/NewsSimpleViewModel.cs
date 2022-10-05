namespace MVC_Admin.Areas.News.ViewModels
{
    public class NewsSimpleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortText { get; set; }
        public string SmallLogo { get; set; }
        public int AuthorId { get; set; }
        public DateTime PostDate { get; set; }
        public int NewsType { get; set; }
    }
}
