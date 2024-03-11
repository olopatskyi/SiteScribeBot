using FluentValidation.Results;
using SiteScriber.Framework.Contracts;

namespace SiteScriber.Api.Services.Abstractions;

public interface ISubscriptionService
{
    Task<ServiceResponse<ValidationResult>> ValidateSubscriptionsAsync(CancellationToken cancellationToken = default);
}