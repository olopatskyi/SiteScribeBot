using SiteScriber.Data.Entities.Tasks;
using SiteScriber.Framework.Services.QueueService.Service;
using SiteScriber.Framework.Services.QueueService.Storage.Interfaces;
using Telegram.Bot;

namespace SiteScriber.NotificationService.Services.Queue;

public class TelegramMessageSendTaskQueueService : QueueService<TelegramMessageSendTask>
{
    public TelegramMessageSendTaskQueueService(IQueueRepository<TelegramMessageSendTask, string> queue) : base(queue)
    {
    }

    protected override Task ProcessElementAsync(TelegramMessageSendTask element, CancellationToken stoppingToken = default)
    {
        throw new NotImplementedException();
    }
}