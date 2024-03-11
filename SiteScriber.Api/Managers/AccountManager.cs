using FluentValidation.Results;
using SiteScriber.Api.Managers.Abstractions;
using SiteScriber.Api.Models.Request;
using SiteScriber.Api.Services.Abstractions;
using SiteScriber.Framework;
using SiteScriber.Framework.Contracts;

namespace SiteScriber.Api.Managers;

public class AccountManager : LogicalLayerElement, IAccountManager
{
    private readonly IAccountService _accountService;

    public AccountManager(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public async Task<ServiceResponse<ValidationResult>> SignUpAsync(SignUpModelRequest request,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await new SignUpModelRequestValidator().ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return ValidationFailure(validationResult);
        }

        await _accountService.SignUpAsync(request, cancellationToken);
        return Success();
    }
}