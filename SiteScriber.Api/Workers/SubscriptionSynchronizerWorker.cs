using SiteScriber.Api.Services.Abstractions;

namespace SiteScriber.Api.Workers;

public class SubscriptionSynchronizerWorker : BackgroundService
{
    private readonly ISubscriptionService _subscriptionService;

    public SubscriptionSynchronizerWorker(ISubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _subscriptionService.ValidateSubscriptionsAsync(stoppingToken);
            await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
        }
    }
}