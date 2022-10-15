namespace EDiaristas.Core.Services.Storage.Adapters;

public interface IStorageService
{
    string UploadFile(string fileName, Stream fileStream, string contentType);
}