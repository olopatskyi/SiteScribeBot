using AutoMapper;
using MongoDB.Driver;
using SiteScriber.Api.Models;
using SiteScriber.Api.Repositories.Abstractions;
using SiteScriber.Data.Entities;

namespace SiteScriber.Api.Repositories;

public class UserGptKeyRepository : IUserGptKeyRepository
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<UserGptKey> _collection;

    public UserGptKeyRepository(IMapper mapper, IMongoCollection<UserGptKey> collection)
    {
        _mapper = mapper;
        _collection = collection;
    }

    public Task CreateAsync(CreateUserGptKeyModel model, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<UserGptKey>(model);
        return _collection.InsertOneAsync(entity, cancellationToken: cancellationToken);
    }

    public async Task<GetUserGptKeyModel> GetOneAsync(string userId, CancellationToken cancellationToken = default)
    {
        var filter = Builders<UserGptKey>.Filter.Eq(x => x.UserId, userId);
        var projection = Builders<UserGptKey>.Projection
            .Include(x => x.ApiKey);

        var result = await _collection.Find(filter).FirstOrDefaultAsync(cancellationToken);
        return _mapper.Map<GetUserGptKeyModel>(result);
    }
}