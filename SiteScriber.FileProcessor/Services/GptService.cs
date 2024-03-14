using OpenAI_API;
using OpenAI_API.Completions;
using OpenAI_API.Models;

public class GptService
{
    private readonly IOpenAIAPI _openAiApi;

    public GptService(string apiKey)
    {
        _openAiApi = new OpenAIAPI(apiKey);
    }

    public async Task<string> GenerateText(string prompt, int maxTokens = 100)
    {
        try
        {
            var completionRequest = new CompletionRequest
            {
                Model = Model.Davinci, // Choose the model you want to use
                MaxTokens = maxTokens,
                Prompt = prompt
            };

            var completionResponse = await _openAiApi.Completions.CreateCompletionAsync(completionRequest);

            if (completionResponse is not { Completions.Count: > 0 })
                throw new Exception("Failed to generate text.");

            var choices = completionResponse.Completions;
            return choices[0].Text;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error generating text: {ex.Message}");
            throw;
        }
    }
}