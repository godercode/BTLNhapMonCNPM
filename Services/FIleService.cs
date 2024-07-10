namespace BTLNhapMonCNPM.Services;

public class FileService : IFileService
{

    public async Task<string> UploadAsync(string path, IFormFile file, CancellationToken cancellationToken = default)
    {
        // Check if the file exists else, throw an exception        
        if (file.Length < 1) throw new Exception($"No file found!");

        // State the file extensions you require to be uploaded.
        var allowedFileTypes = new[] { "png", "jpg" };

        // Get the file extension.
        var fileExtension = Path.GetExtension(file.FileName).Substring(1);

        // validate the file extension type.
        if (!allowedFileTypes.Contains(fileExtension))
        {
            throw new Exception($"File format {Path.GetExtension(file.FileName)} is invalid for this operation.");
        }

        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

        // Create an instance of the memory stream.
        await using var memoryStream = new MemoryStream();

        // Write file to Stream
        await file.CopyToAsync(memoryStream, cancellationToken);

        // Read from the start of the memoryStream
        memoryStream.Position = 0;

        // Write file to System path
        var filePath = Path.Combine("wwwroot", "Documents", fileName);
        using var fileStream = new FileStream(filePath, FileMode.Create);

        // Write Memory Stream to FileStream
        await memoryStream.CopyToAsync(fileStream, cancellationToken);

        return $"{path}/api/Files/{fileName}";
    }
}