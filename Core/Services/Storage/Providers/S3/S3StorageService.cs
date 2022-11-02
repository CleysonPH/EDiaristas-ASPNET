using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using EDiaristas.Core.Services.Storage.Adapters;

namespace EDiaristas.Core.Services.Storage.Providers.S3;

public class S3StorageService : IStorageService
{
    private readonly string _accessKey;
    private readonly string _secretKey;
    private readonly string _bucket;
    private readonly RegionEndpoint _region;

    public S3StorageService(IConfiguration configuration)
    {
        _accessKey = configuration.GetValue<string>("Storage:S3:AccessKey");
        _secretKey = configuration.GetValue<string>("Storage:S3:SecretKey");
        _bucket = configuration.GetValue<string>("Storage:S3:Bucket");
        _region = RegionEndpoint.GetBySystemName(configuration.GetValue<string>("Storage:S3:Region"));
    }

    public string UploadFile(string fileName, Stream fileStream, string contentType)
    {
        try
        {
            return tryUploadFile(fileName, fileStream, contentType);
        }
        catch (Exception ex)
        {
            throw new StorageServiceExcetpion(ex.Message);
        }
    }

    private string tryUploadFile(string fileName, Stream fileStream, string contentType)
    {
        var credentials = new BasicAWSCredentials(_accessKey, _secretKey);
        var config = createAmazonS3Config();
        var uploadRequest = createTransferUtilityUploadRequest(fileName, fileStream, contentType);
        var client = new AmazonS3Client(credentials, config);
        var fileTransferUtility = new TransferUtility(client);
        fileTransferUtility.Upload(uploadRequest);
        return $"https://{_bucket}.s3.{_region.SystemName}.amazonaws.com/{uploadRequest.Key}";
    }

    private GetPreSignedUrlRequest createGetPreSignedUrlRequest(TransferUtilityUploadRequest uploadRequest)
    {
        return new GetPreSignedUrlRequest
        {
            BucketName = _bucket,
            Key = uploadRequest.Key,
            Expires = DateTime.Now.AddMinutes(5)
        };
    }

    private TransferUtilityUploadRequest createTransferUtilityUploadRequest(string fileName, Stream fileStream, string contentType)
    {
        return new TransferUtilityUploadRequest
        {
            InputStream = fileStream,
            Key = $"{Guid.NewGuid()}-{fileName}",
            BucketName = _bucket,
            CannedACL = S3CannedACL.PublicRead,
            ContentType = contentType
        };
    }

    private AmazonS3Config createAmazonS3Config()
    {
        return new AmazonS3Config
        {
            RegionEndpoint = _region
        };
    }
}