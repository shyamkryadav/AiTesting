using OpenAI_API.Completions;
using OpenAI_API;

public class OpenAiService
{
    private readonly OpenAIAPI _openAiApi;

    public OpenAiService(string apiKey)
    {
        _openAiApi = new OpenAIAPI(apiKey);
    }

    public async Task<string> GetChatGptResponse(string prompt)
    {
        try
        {
            var result = await _openAiApi.Completions.CreateCompletionAsync(new CompletionRequest
            {
                Prompt = prompt,
                MaxTokens = 150
            });

            return result.Completions[0].Text;
        }
        catch (HttpRequestException ex)
        {
            // Check if the exception is related to exceeding quota or rate limits
            if (ex.Message.Contains("insufficient_quota") || ex.Message.Contains("TooManyRequests"))
            {
                // Log the error and notify the user
                return "Error: You've exceeded your API quota. Please check your plan and billing details.";
            }

            // Handle other types of exceptions
            throw;
        }
    }
}
