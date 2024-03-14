using System.ComponentModel.DataAnnotations.Schema;
using SiteScriber.Framework.Services.QueueService.Storage.Entities;

namespace SiteScriber.Data.Entities.Tasks;

[Table("telegram_message_send_task")]
public class TelegramMessageSendTask : QueueElementEntity
{
    public string ChatId { get; set; }
    
    public string Text { get; set; }

    public string FileId { get; set; }
}