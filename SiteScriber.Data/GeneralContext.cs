using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SiteScriber.Data.Entities;
using SiteScriber.Framework.Data.MongoDb.DbContext;

namespace SiteScriber.Data;

public class GeneralContext : MongoDbContext
{
    public GeneralContext(IOptions<MongoDbContextOptions<GeneralContext>> options) : base(options)
    {
    }

    public IMongoCollection<User> Users { get; set; }
    
    public IMongoCollection<Subscription> Subscriptions { get; set; }
}