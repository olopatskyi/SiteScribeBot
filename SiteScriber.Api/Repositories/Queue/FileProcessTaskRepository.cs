using SiteScriber.Data;
using SiteScriber.Data.Entities.Tasks;
using SiteScriber.Framework.Services.QueueService.Storage;

namespace SiteScriber.Api.Repositories.Queue;

public class FileProcessTaskRepository : QueueRepository<FileProcessTask>
{
    public FileProcessTaskRepository(GeneralContext context) : base(context.FileProcessTasks)
    {
    }
}