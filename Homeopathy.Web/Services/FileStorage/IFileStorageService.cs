namespace Homeopathy.Web.Services.FileStorage
{
    public interface IFileStorageService
    {
        Task<string?> UploadAsync(
       IFormFile? file,
       string folderName,
       CancellationToken cancellationToken = default);

        Task DeleteAsync(string? filePath);
    }
}
