using System.Collections.Generic;
using System.Threading.Tasks;
using Mindlift.Models; // Make sure this namespace contains the ChatGPTClient

namespace Mindlift.Models
{
    public class ChatbotModel
    {
        // Property to hold the user's message
        public string UserMessage { get; set; }

        // Property to hold chatbot's responses
        public List<string> ChatbotResponses { get; set; } = new List<string>();

        // Injecting ChatGPTClient into the constructor
        private readonly ChatGPTClient _chatGPTClient;

        public ChatbotModel(ChatGPTClient chatGPTClient)
        {
            _chatGPTClient = chatGPTClient;
        }

        // Method to get chat response
        public async Task<string> GetChatResponseAsync(string userMessage)
        {
            if (string.IsNullOrEmpty(userMessage))
            {
                return "Please provide a message.";
            }

            // Call ChatGPT API through ChatGPTClient and get the response
            var botResponse = await _chatGPTClient.GetChatResponseAsync(userMessage);

            // Add the response to the list of responses
            ChatbotResponses.Add($"Chatbot: {botResponse}");

            return botResponse;
        }

        // Method to simulate sending user input
        public void OnUserMessage(string userMessage)
        {
            if (!string.IsNullOrEmpty(userMessage))
            {
                // Add the user message to the response list
                ChatbotResponses.Add($"You said: {userMessage}");
            }
        }
    }
}
