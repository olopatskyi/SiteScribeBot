using SiteScriber.Api.Models;

namespace SiteScriber.Api.Repositories.Abstractions;

public interface IUserGptKeyRepository
{
    Task CreateAsync(CreateUserGptKeyModel model, CancellationToken cancellationToken = default);

    Task<GetUserGptKeyModel> GetOneAsync(string userId, CancellationToken cancellationToken = default);
}