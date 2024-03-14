using SiteScriber.Data.Settings;

namespace SiteScriber.Data.Repository.Abstractions;

public interface IFileRepository
{
    Task<string> UploadAsync(UploadFileSettings settings, CancellationToken cancellationToken = default);

    Task<byte[]> GetAsync(string fileId, CancellationToken cancellationToken);
}