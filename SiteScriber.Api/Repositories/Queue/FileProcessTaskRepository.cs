using MongoDB.Driver;
using SiteScriber.Data;
using SiteScriber.Data.Entities.Tasks;
using SiteScriber.Framework.Services.QueueService.Storage;

namespace SiteScriber.Api.Repositories.Queue;

public class FileProcessTaskRepository : QueueRepository<FileProcessTask>
{
    private readonly IMongoCollection<FileProcessTask> _collection;
    
    public FileProcessTaskRepository(GeneralContext context) : base(collection)
    {
        _collection = collection;
    }
}