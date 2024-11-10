using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mindlift.Models; // Make sure this namespace includes ChatGPTClient
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mindlift.Pages.ChatSupport
{
    public class ChatbotModel : PageModel
    {
        // Property to hold the user's message
        [BindProperty]
        public string UserMessage { get; set; }

        // Property to hold chatbot's responses
        public List<string> ChatbotResponses { get; set; } = new List<string>();

        // Inject ChatGPTClient via constructor
        private readonly ChatGPTClient _chatGPTClient;

        public ChatbotModel(ChatGPTClient chatGPTClient)
        {
            _chatGPTClient = chatGPTClient;
        }

        // GET handler to load the page
        public void OnGet()
        {
            // Logic to display initial page (e.g., welcoming message)
            ChatbotResponses.Add("Hello! How can I assist you today?");
        }

        // POST handler to process user input
        public async Task OnPostAsync()
        {
            if (!string.IsNullOrEmpty(UserMessage))
            {
                // Add user message to the response list
                ChatbotResponses.Add($"You said: {UserMessage}");

                // Get a response from the ChatGPT API (through the ChatGPTClient)
                var botResponse = await _chatGPTClient.GetChatResponseAsync(UserMessage);
                ChatbotResponses.Add($"Chatbot: {botResponse}");

                // Optionally clear the UserMessage property after posting
                UserMessage = string.Empty;
            }
        }
    }
}
