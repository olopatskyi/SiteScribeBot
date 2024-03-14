using FluentValidation.Results;

namespace SiteScriber.Api.Extensions;

public static class ValidationMessages
{
    public static readonly ValidationFailure UserWithoutApiKey = new("API key", "User don't have API key");
}