using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace MVC_Admin.Areas.Game.Models
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

        [NotMapped]
        [DisplayName("Upload big logo")]
        public IFormFile BigLogoFile { get; set; }
        [NotMapped]
        [DisplayName("Upload small logo")]
        public IFormFile SmallLogoFile { get; set; }
    }
}
