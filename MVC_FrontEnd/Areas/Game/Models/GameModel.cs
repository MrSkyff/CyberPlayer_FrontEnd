namespace MVC_FrontEnd.Areas.Game.Models
{
    public class GameModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string BigLogo { get; set; }
        public string SmallLogo { get; set; }
        public int OwnerId { get; set; }
        public DateTime RealeseDate { get; set; }
    }
}
