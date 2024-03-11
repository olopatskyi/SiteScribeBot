using FluentValidation.Results;
using SiteScriber.Api.Models.Request;
using SiteScriber.Framework.Contracts;

namespace SiteScriber.Api.Managers.Abstractions;

public interface IAccountManager
{
    Task<ServiceResponse<ValidationResult>> SignUpAsync(SignUpModelRequest request,
        CancellationToken cancellationToken = default);
}