using FluentValidation.Results;
using SiteScriber.Api.Models;
using SiteScriber.Api.Models.Request;
using SiteScriber.Api.Repositories.Abstractions;
using SiteScriber.Api.Services.Abstractions;
using SiteScriber.Framework;
using SiteScriber.Framework.Contracts;

namespace SiteScriber.Api.Services;

public class AccountService : LogicalLayerElement, IAccountService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserGptKeyRepository _userGptKeyRepository;

    public AccountService(IUserRepository userRepository, IUserGptKeyRepository userGptKeyRepository)
    {
        _userRepository = userRepository;
        _userGptKeyRepository = userGptKeyRepository;
    }

    public async Task<ServiceResponse<ValidationResult>> SignUpAsync(SignUpModelRequest request, CancellationToken cancellationToken = default)
    {
        await _userRepository.CreateAsync(request, cancellationToken);
        await _userGptKeyRepository.CreateAsync(new CreateUserGptKeyModel
        {
            UserId = request.UserId,
            ApiKey = request.GptApiKey
        }, cancellationToken);

        return Success();
    }
}