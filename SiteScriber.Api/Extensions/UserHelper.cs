namespace SiteScriber.Api.Extensions;

public static class UserHelper
{
    public static string GetFileName(string userId, string chatId)
    {
        var timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
        return $"{userId}_{chatId}_{timestamp}";
    }
}