using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration; // Add this
using Newtonsoft.Json.Linq;

namespace Mindlift.Pages.Videos
{
    public class IndexModel : PageModel
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly IConfiguration _configuration; // Add IConfiguration

        public IList<YouTubeVideo> ExternalVideos { get; set; } = new List<YouTubeVideo>();

        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; } = "self-help"; // Default search query

        public IndexModel(IConfiguration configuration) // Inject IConfiguration
        {
            _configuration = configuration;
        }

        public async Task OnGetAsync()
        {
            // Retrieve API key from appsettings.json
            var config = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();
            string apikey = config["apikey"];
            ViewData["apikey"] = apikey;

            if (!string.IsNullOrWhiteSpace(SearchQuery))
            {
                // Construct the YouTube API URL with the search query
                string url = $"https://www.googleapis.com/youtube/v3/search?part=snippet&q={Uri.EscapeDataString(SearchQuery)}&type=video&maxResults=3&key={apikey}";

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject jsonResponse = JObject.Parse(responseBody);
                    var items = jsonResponse["items"];

                    if (items != null)
                    {
                        foreach (var item in items)
                        {
                            string videoId = item["id"]?["videoId"]?.ToString() ?? string.Empty;
                            string title = item["snippet"]?["title"]?.ToString() ?? "N/A";
                            string description = item["snippet"]?["description"]?.ToString() ?? "N/A";
                            string thumbnailUrl = item["snippet"]?["thumbnails"]?["medium"]?["url"]?.ToString() ?? string.Empty;
                            string channelTitle = item["snippet"]?["channelTitle"]?.ToString() ?? "N/A";

                            // Create a new YouTubeVideo object
                            ExternalVideos.Add(new YouTubeVideo
                            {
                                VideoId = videoId,
                                Title = title,
                                Description = description,
                                ThumbnailUrl = thumbnailUrl,
                                ChannelTitle = channelTitle
                            });
                        }
                    }
                }
                catch (HttpRequestException e)
                {
                    // Handle request errors (log or display error message as needed)
                    Console.WriteLine($"Request error: {e.Message}");
                }
            }
        }
    }

    public class YouTubeVideo
    {
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; }
        public string ChannelTitle { get; set; }
    }
}
