namespace SiteScriber.Api.Extensions;

public static class FileHelper
{
    public static async Task<Stream> GetStreamFromIFormFileAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return null;

        var memoryStream = new MemoryStream();
        await file.CopyToAsync(memoryStream);
        memoryStream.Position = 0;
        return memoryStream;
    }
}