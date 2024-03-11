using MongoDB.Driver;
using SiteScriber.Data.Entities;

namespace SiteScriber.Api.Repositories.Abstractions;

public interface ISubscriptionRepository
{
    Task<IAsyncCursor<Subscription>> GetExpiredSubscriptionsCursorAsync(int batchSize = 100, CancellationToken cancellationToken = default);

    Task ExpireSubscriptionsByIdsAsync(IEnumerable<string> ids, CancellationToken cancellationToken = default);
}