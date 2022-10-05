using Microsoft.Extensions.Hosting;
using MVC_Admin.Interfacies;

namespace MVC_Admin.Repositories
{
    public class ImageRepository : IImage
    {
        private readonly IWebHostEnvironment hostEnvironment;
        public ImageRepository(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }

        public async Task<string> LogoUploadAsync(IFormFile logo, int id, string logoName, string folderName)
        {
            string wwwRootPath = hostEnvironment.WebRootPath;
            string extension = Path.GetExtension(logo.FileName);
            string path = Path.Combine(wwwRootPath + "/data/" + folderName + "/" + id + "/logos/" + logoName + extension);

            if (Directory.Exists(wwwRootPath + "/data/" + folderName + "/" + id + "/logos"))
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    await logo.CopyToAsync(fileStream);
                }
            }
            else
            {
                Directory.CreateDirectory(wwwRootPath + "/data/" + folderName + "/" + id + "/logos");

                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    await logo.CopyToAsync(fileStream);
                }
            }

            string result = "/data/" + folderName + "/" + id + "/logos/" + logoName + extension;

            return result;
        }
    }
}
