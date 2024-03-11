using FluentValidation;
using SiteScriber.Framework.Extensions.StringLocalizer;
using Microsoft.Extensions.Localization;

namespace SiteScriber.Framework.FluentValidation.Validators;

public static partial class BasicValidators
{
    public static IRuleBuilderOptions<T, TProperty> Required<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder,
        IStringLocalizer localizer = null, string message = "The property is required.")
        => ruleBuilder
            .NotEmpty()
            .WithMessage(localizer.Localize(message));
}