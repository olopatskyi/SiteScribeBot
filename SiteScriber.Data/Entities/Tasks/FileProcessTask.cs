using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;
using SiteScriber.Framework.Services.QueueService.Storage.Entities;

namespace SiteScriber.Data.Entities.Tasks;

[Table("upload_file_tasks")]
public class FileProcessTask : QueueElementEntity
{
    [BsonElement("f")]
    public string FileId { get; set; }

    [BsonElement("cid")]
    public string ChatId { get; set; }
}