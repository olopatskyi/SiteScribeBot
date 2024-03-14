using System.Text;
using SiteScriber.Data.Entities.Tasks;
using SiteScriber.Data.Repository.Abstractions;
using SiteScriber.Framework.Services.QueueService.Processor;
using SiteScriber.Framework.Services.QueueService.Storage.Interfaces;

namespace SiteScriber.FileProcessor.Services.Queue;

public class FileProcessTaskQueueProcessor : QueueElementProcessor<FileProcessTask>
{
    private readonly IFileRepository _fileRepository;

    public FileProcessTaskQueueProcessor(IQueueRepository<FileProcessTask> queue,
        IFileRepository fileRepository) : base(queue)
    {
        _fileRepository = fileRepository;
    }

    protected override async Task<bool> ExecuteAsync(FileProcessTask element, CancellationToken stoppingToken = default)
    {
        try
        {
            var file = await _fileRepository.GetAsync(element.FileId, stoppingToken);
            var content = await ReadFileContent(file);
            var chunks = SplitContent(content, 1000);
            var tasks = GetFileProcessingTasks(element.ApiKey, chunks);
            var resultChunks = await Task.WhenAll(tasks);
            var result = Collapse(resultChunks);
            
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    private static List<string> SplitContent(string content, int chunkSize)
    {
        var contentChunks = new List<string>();

        for (var i = 0; i < content.Length; i += chunkSize)
        {
            var chunkLength = Math.Min(chunkSize, content.Length - i);
            var chunk = content.Substring(i, chunkLength);
            contentChunks.Add(chunk);
        }

        return contentChunks;
    }

    private static async Task<string> ReadFileContent(byte[] file)
    {
        using var stream = new MemoryStream(file);
        using var reader = new StreamReader(stream, Encoding.UTF8);

        return await reader.ReadToEndAsync();
    }

    private static IEnumerable<Task<string>> GetFileProcessingTasks(string apiKey, IEnumerable<string> content)
    {
        var gptService = new GptService(apiKey);
        var tasks = content.Select(async chunk => await gptService.GenerateText(GetPrompt(chunk)));
        return tasks;
    }

    private static string GetPrompt(string chunk)
    {
        var title = "rephrase content in this html and get in response only code";
        return $"{title}\n{chunk}";
    }

    private static List<byte> Collapse(IEnumerable<string> chunks)
    {
        var result = new List<byte>();
        foreach (var chunk in chunks)
        {
            var chunkBytes = Encoding.UTF8.GetBytes(chunk);
            result.AddRange(chunkBytes);
        }

        return result;
    }
}