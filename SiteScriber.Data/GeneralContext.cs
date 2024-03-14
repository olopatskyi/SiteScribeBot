using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using SiteScriber.Data.Entities;
using SiteScriber.Data.Entities.Tasks;
using SiteScriber.Framework.Data.MongoDb.DbContext;

namespace SiteScriber.Data;

public class GeneralContext : MongoDbContext
{
    private readonly GridFSBucket _bucket;
    public GeneralContext(IOptions<MongoDbContextOptions<GeneralContext>> options) : base(options)
    {
        _bucket = new GridFSBucket(Database);
    }

    public IMongoCollection<User> Users { get; set; }
    
    public IMongoCollection<Subscription> Subscriptions { get; set; }

    public IMongoCollection<FileProcessTask> FileProcessTasks { get; set; }

    public GridFSBucket Bucket => _bucket;
}