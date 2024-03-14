using SiteScriber.Data.Entities.Tasks;
using SiteScriber.Framework.Services.QueueService.Processor;
using SiteScriber.Framework.Services.QueueService.Storage.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SiteScriber.NotificationService.Services.Queue;

public class TelegramMessageSendTaskQueueProcessor : QueueElementProcessor<TelegramMessageSendTask>
{
    private readonly ITelegramBotClient _telegramBotClient;

    public TelegramMessageSendTaskQueueProcessor(IQueueRepository<TelegramMessageSendTask> queue, ITelegramBotClient telegramBotClient) : base(queue)
    {
        _telegramBotClient = telegramBotClient;
    }

    protected override async Task<bool> ExecuteAsync(TelegramMessageSendTask element, CancellationToken stoppingToken = default)
    {
        try
        {
            if (string.IsNullOrEmpty(element.FileId))
            {
                await _telegramBotClient.SendTextMessageAsync(element.ChatId, element.Text, cancellationToken: stoppingToken);
            }
            else
            {
                await using var stream = new FileStream(element.FileId, FileMode.Open);
                var file = new InputFileStream(stream);
                await _telegramBotClient.SendDocumentAsync(element.ChatId, file, caption: element.Text, cancellationToken: stoppingToken);
            }

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending Telegram message: {ex.Message}");
            return false;
        }
    }
}