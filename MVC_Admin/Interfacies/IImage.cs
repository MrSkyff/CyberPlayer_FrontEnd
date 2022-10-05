namespace MVC_Admin.Interfacies
{
    public interface IImage
    {
        Task<string> LogoUploadAsync(IFormFile logo, int id, string logoName, string folderName);
    }
}
