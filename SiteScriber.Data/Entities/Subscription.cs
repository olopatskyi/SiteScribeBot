using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;
using SiteScriber.Data.Enums;
using SiteScriber.Framework.Data.Abstractions.MongoDb;

namespace SiteScriber.Data.Entities;

[Table("subscriptions")]
public class Subscription : IdentifiedEntity
{
    [BsonElement("uid")]
    public string UserId { get; set; }

    [BsonElement("sd")]
    public DateTime StartDate { get; set; }

    [BsonElement("exp")]
    public DateTime ExpireDate { get; set; }

    [BsonElement("s")]
    public SubscriptionStatus Status { get; set; }
}