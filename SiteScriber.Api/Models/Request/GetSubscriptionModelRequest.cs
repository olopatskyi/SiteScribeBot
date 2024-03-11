using SiteScriber.Framework.FluentValidation;
using SiteScriber.Framework.FluentValidation.Validators;

namespace SiteScriber.Api.Models.Request;

public class GetSubscriptionModelRequest
{
    public string UserId { get; set; }
}

public class GetSubscriptionModelRequestValidator : BasicAbstractValidator<GetSubscriptionModelRequest>
{
    public GetSubscriptionModelRequestValidator()
    {
        RuleFor(x => x.UserId)
            .Required();
    }
}

