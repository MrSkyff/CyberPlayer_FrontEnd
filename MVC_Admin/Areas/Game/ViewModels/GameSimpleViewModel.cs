namespace MVC_Admin.Areas.Game.ViewModels
{
    public class GameSimpleViewModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string SmallLogo { get; set; }
        public DateTime RealeseDate { get; set; }
    }
}
