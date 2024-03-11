using Microsoft.Extensions.Localization;

namespace SiteScriber.Framework.Extensions.StringLocalizer;

public static class StringLocalizerExtensions
{
    public static string Localize(this IStringLocalizer localizer, string message)
        => localizer == null ? message : localizer[message];
}