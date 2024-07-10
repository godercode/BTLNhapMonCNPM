namespace BTLNhapMonCNPM.Services;

public interface IFileService
{
    Task<string> UploadAsync(string path, IFormFile formFile, CancellationToken cancellationToken);
}