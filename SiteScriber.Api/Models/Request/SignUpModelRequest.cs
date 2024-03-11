using SiteScriber.Framework.FluentValidation;
using SiteScriber.Framework.FluentValidation.Validators;

namespace SiteScriber.Api.Models.Request;

public class SignUpModelRequest
{
    public string UserId { get; set; }

    public string ChatId { get; set; }

    public string UserName { get; set; }

    public string GptApiKey { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }
}

public class SignUpModelRequestValidator : BasicAbstractValidator<SignUpModelRequest>
{
    public SignUpModelRequestValidator()
    {
        RuleFor(x => x.UserId)
            .Required();

        RuleFor(x => x.ChatId)
            .Required();

        RuleFor(x => x.UserName)
            .Required();

        RuleFor(x => x.GptApiKey)
            .Required();
    }
}