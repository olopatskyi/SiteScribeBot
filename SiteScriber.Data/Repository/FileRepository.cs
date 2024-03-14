using MongoDB.Bson;
using MongoDB.Driver.GridFS;
using SiteScriber.Data.Repository.Abstractions;
using SiteScriber.Data.Settings;

namespace SiteScriber.Data.Repository;

public class FileRepository : IFileRepository
{
    private readonly GridFSBucket _bucket;

    public FileRepository(GeneralContext context)
    {
        _bucket = context.Bucket;
    }

    public async Task<string> UploadAsync(UploadFileSettings settings, CancellationToken cancellationToken = default)
    {
        var fileId =
            (await _bucket.UploadFromStreamAsync(settings.Name, settings.Stream, cancellationToken: cancellationToken))
            .ToString();

        return fileId;
    }

    public async Task<byte[]> GetAsync(string fileId, CancellationToken cancellationToken)
    {
        var file = await _bucket
            .DownloadAsBytesAsync(new ObjectId(fileId), cancellationToken: cancellationToken);

        return file;
    }
}