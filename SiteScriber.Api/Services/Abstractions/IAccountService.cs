using FluentValidation.Results;
using SiteScriber.Api.Models.Request;
using SiteScriber.Framework.Contracts;

namespace SiteScriber.Api.Services.Abstractions;

public interface IAccountService
{
    Task<ServiceResponse<ValidationResult>> SignUpAsync(SignUpModelRequest request,
        CancellationToken cancellationToken = default);
}