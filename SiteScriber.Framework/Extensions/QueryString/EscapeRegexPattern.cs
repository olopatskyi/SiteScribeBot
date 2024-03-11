using System.Text.RegularExpressions;

namespace SiteScriber.Framework.Extensions.QueryString;

public static partial class QueryStringExtensions
{
    private static readonly Regex EscapeRegexPattern = new("([~'^$.|?*+()/\\\\#!\"\\\\{\\}\\[\\]\\:\\<\\>\\&])", RegexOptions.Compiled);
}