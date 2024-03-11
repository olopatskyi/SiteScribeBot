using System.ComponentModel.DataAnnotations.Schema;
using SiteScriber.Framework.Data.Abstractions.MongoDb;

namespace SiteScriber.Data.Entities;

[Table("users_gpt_keys")]
public class UserGptKey : IdentifiedEntity
{
    public string UserId { get; set; }

    public string ApiKey { get; set; }
}