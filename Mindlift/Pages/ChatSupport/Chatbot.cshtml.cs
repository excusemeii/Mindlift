using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mindlift.Models; // Ensure this includes ChatGPTClient
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

        // GET handler to load the page with an initial welcome message
        public void OnGet()
        {
            // Add a welcoming message when the page loads
            ChatbotResponses.Add("Hello! How can I assist you today?");
        }

        // POST handler to process user input and get a response from the ChatGPT API
        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrEmpty(UserMessage))
            {
                // Add user message to the response list
                ChatbotResponses.Add($"You said: {UserMessage}");

                try
                {
                    // Get a response from the ChatGPT API (through the ChatGPTClient)
                    var botResponse = await _chatGPTClient.GetChatResponseAsync(UserMessage);
                    ChatbotResponses.Add($"Chatbot: {botResponse}");
                }
                catch (Exception ex)
                {
                    // Handle any errors that occur when calling the ChatGPT API
                    ChatbotResponses.Add("Chatbot: Sorry, I encountered an error. Please try again.");
                    // Log the error (optional)
                    Console.WriteLine($"Error calling ChatGPT API: {ex.Message}");
                }

                // Optionally clear the UserMessage property after posting
                UserMessage = string.Empty;
            }

            // Return the page with updated responses
            return Page();
        }
    }
}
