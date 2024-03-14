using SiteScriber.Data.Entities.Tasks;
using SiteScriber.Framework.Services.QueueService.Service;
using SiteScriber.Framework.Services.QueueService.Storage.Interfaces;

namespace SiteScriber.FileProcessor.Services;

public class FileProcessTaskQueueService : QueueService<FileProcessTask>
{
    public FileProcessTaskQueueService(IQueueRepository<FileProcessTask, string> queue) : base(queue)
    {
    }

    protected override Task ProcessElementAsync(FileProcessTask element, CancellationToken stoppingToken = default)
    {
        throw new NotImplementedException();
    }
}