namespace EDiaristas.Core.Services.Storage.Adapters;

public class StorageServiceExcetpion : Exception
{
    public StorageServiceExcetpion(string message) : base(message)
    { }
}