namespace MVC_FrontEnd.Services.Paginator
{
    public class PaginatorModel
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int PagesCountToShow { get; set; }
        public List<int> PageList { get; set; }
    }
}
