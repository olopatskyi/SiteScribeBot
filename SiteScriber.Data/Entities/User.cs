using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;
using SiteScriber.Framework.Data.Abstractions.MongoDb;

namespace SiteScriber.Data.Entities;

[Table("users")]
public class User : IdentifiedEntity
{
    [BsonElement("cid")]
    public string ChatId { get; set; }
    
    [BsonElement("un")]
    public string UserName { get; set; }
    
    [BsonElement("fn")]
    public string FirstName { get; set; }

    [BsonElement("ln")]
    public string LastName { get; set; }
}