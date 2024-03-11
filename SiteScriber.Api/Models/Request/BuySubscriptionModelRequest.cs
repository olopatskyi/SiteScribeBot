using SiteScriber.Framework.FluentValidation;
using SiteScriber.Framework.FluentValidation.Validators;

namespace SiteScriber.Api.Models.Request;

public class BuySubscriptionModelRequest
{
    public string UserId { get; set; }
}

public class BuySubscriptionModelRequestValidator : BasicAbstractValidator<BuySubscriptionModelRequest>
{
    public BuySubscriptionModelRequestValidator()
    {
        RuleFor(x => x.UserId)
            .Required();
    }
}
