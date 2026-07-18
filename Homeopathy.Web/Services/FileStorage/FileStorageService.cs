
namespace Homeopathy.Web.Services.FileStorage
{
    public sealed class FileStorageService : IFileStorageService
    {
        private readonly IWebHostEnvironment _environment;
        public FileStorageService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public Task DeleteAsync(string? filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return Task.CompletedTask;

            var fullPath = Path.Combine(
                _environment.WebRootPath,
                filePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }

            return Task.CompletedTask;
        }

        public async Task<string?> UploadAsync(IFormFile? file, string folderName, CancellationToken cancellationToken = default)
        {
            if (file == null || file.Length == 0)
                return null;

            var uploadsRoot = Path.Combine(
                _environment.WebRootPath,
                "uploads",
                folderName);

            if (!Directory.Exists(uploadsRoot))
                Directory.CreateDirectory(uploadsRoot);

            var extension = Path.GetExtension(file.FileName);

            var fileName = $"{Guid.NewGuid()}{extension}";

            var fullPath = Path.Combine(uploadsRoot, fileName);

            await using var stream = new FileStream(fullPath, FileMode.Create);

            await file.CopyToAsync(stream, cancellationToken);

            return $"/uploads/{folderName}/{fileName}";
        }
    }
}
