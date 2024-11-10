using Newtonsoft.Json;
using System.Text;

public class ChatGPTClient
{
    private readonly string _apiKey;
    private readonly HttpClient _httpClient;

    // Constructor accepts IConfiguration and IHttpClientFactory
    public ChatGPTClient(IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        // Retrieve API key from configuration
        _apiKey = configuration["ChatGPT:ApiKey"] ?? throw new InvalidOperationException("API key for ChatGPT not found in configuration.");

        // Initialize HttpClient using IHttpClientFactory
        _httpClient = httpClientFactory.CreateClient();

        // Set the Authorization header for the API request
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
    }

    // Method to get chat response
    public async Task<string> GetChatResponseAsync(string userMessage)
    {
        var requestBody = new
        {
            model = "gpt-4",
            messages = new[]
            {
                new { role = "system", content = "You are a helpful assistant." },
                new { role = "user", content = userMessage }
            }
        };

        // Serialize the request body to JSON format
        var requestContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

        // Make the API request to OpenAI
        var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", requestContent);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"API request failed with status code {response.StatusCode}");
        }

        // Read and parse the API response
        var responseContent = await response.Content.ReadAsStringAsync();
        dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);

        // Extract and return the ChatGPT response
        return jsonResponse.choices[0].message.content;
    }
}
