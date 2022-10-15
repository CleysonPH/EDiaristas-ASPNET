using EDiaristas.Core.Services.Storage.Adapters;

namespace EDiaristas.Core.Services.Storage.Providers.Local;

public class LocalStorageService : IStorageService
{
    public string UploadFile(string fileName, Stream fileStream, string contentType)
    {
        fileName = $"{Guid.NewGuid()}-{fileName}";
        var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
        if (!Directory.Exists(uploadDirectory))
        {
            Directory.CreateDirectory(uploadDirectory);
        }
        var filePath = Path.Combine(uploadDirectory, fileName);
        using (var fileStreamToSave = new FileStream(filePath, FileMode.Create))
        {
            fileStream.CopyTo(fileStreamToSave);
        }
        return $"/uploads/{fileName}";
    }
}