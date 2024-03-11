using FluentValidation.Results;
using SiteScriber.Api.Repositories.Abstractions;
using SiteScriber.Api.Services.Abstractions;
using SiteScriber.Framework;
using SiteScriber.Framework.Contracts;

namespace SiteScriber.Api.Services;

public class SubscriptionService : LogicalLayerElement, ISubscriptionService
{
    private readonly ISubscriptionRepository _subscriptionRepository;

    public SubscriptionService(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }

    public async Task<ServiceResponse<ValidationResult>> ValidateSubscriptionsAsync(
        CancellationToken cancellationToken = default)
    {
        using var cursor =
            await _subscriptionRepository.GetExpiredSubscriptionsCursorAsync(cancellationToken: cancellationToken);
        while (await cursor.MoveNextAsync(cancellationToken))
        {
            var batch = cursor.Current;
            await _subscriptionRepository.ExpireSubscriptionsByIdsAsync(batch.Select(x => x.Id), cancellationToken);
        }

        return Success();
    }
}