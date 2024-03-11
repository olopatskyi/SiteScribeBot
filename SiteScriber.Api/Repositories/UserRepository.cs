using MongoDB.Driver;
using SiteScriber.Api.Models.Request;
using SiteScriber.Api.Repositories.Abstractions;
using SiteScriber.Data;
using SiteScriber.Data.Entities;

namespace SiteScriber.Api.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _collection;

    public UserRepository(GeneralContext context)
    {
        _collection = context.Users;
    }

    public Task CreateAsync(SignUpModelRequest request, CancellationToken cancellationToken = default)
    {
        var entity = new User
        {
            Id = request.UserId,
            ChatId = request.ChatId,
            UserName = request.UserName
        };

        return _collection.InsertOneAsync(entity, cancellationToken: cancellationToken);
    }
}