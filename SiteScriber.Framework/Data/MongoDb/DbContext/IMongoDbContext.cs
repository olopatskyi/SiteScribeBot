using System.Threading.Tasks;
using MongoDB.Driver;

namespace SiteScriber.Framework.Data.MongoDb.DbContext;

public interface IMongoDbContext
{
    IMongoDatabase Database { get; }

    Task MigrateAsync();
}