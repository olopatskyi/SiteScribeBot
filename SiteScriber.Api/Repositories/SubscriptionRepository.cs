using MongoDB.Driver;
using SiteScriber.Api.Repositories.Abstractions;
using SiteScriber.Data;
using SiteScriber.Data.Entities;
using SiteScriber.Data.Enums;

namespace SiteScriber.Api.Repositories;

public class SubscriptionRepository : ISubscriptionRepository
{
    private readonly IMongoCollection<Subscription> _collection;

    public SubscriptionRepository(GeneralContext context)
    {
        _collection = context.Subscriptions;
    }

    public Task<IAsyncCursor<Subscription>> GetExpiredSubscriptionsCursorAsync(int batchSize = 100,
        CancellationToken cancellationToken = default)
    {
        var projection = Builders<Subscription>.Projection
            .Include(x => x.Id);

        var cursorOptions = new FindOptions<Subscription, Subscription>()
        {
            Projection = projection,
            BatchSize = batchSize,
            NoCursorTimeout = true
        };

        var filter = Builders<Subscription>.Filter.Lt(x => x.ExpireDate, DateTime.Today);

        return _collection.FindAsync(filter, cursorOptions, cancellationToken);
    }

    public Task ExpireSubscriptionsByIdsAsync(IEnumerable<string> ids, CancellationToken cancellationToken = default)
    {
        var filter = Builders<Subscription>.Filter.In(x => x.Id, ids);
        var update = Builders<Subscription>.Update.Set(x => x.Status, SubscriptionStatus.Expired);

        return _collection.UpdateManyAsync(filter, update, cancellationToken: cancellationToken);
    }
}