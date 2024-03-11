using SiteScriber.Api.Models.Request;

namespace SiteScriber.Api.Repositories.Abstractions;

public interface IUserRepository
{
    Task CreateAsync(SignUpModelRequest request, CancellationToken cancellationToken = default);
}